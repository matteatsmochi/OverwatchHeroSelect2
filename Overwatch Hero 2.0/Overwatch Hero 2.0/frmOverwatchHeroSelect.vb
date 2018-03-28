'OBS Control
Imports System
Imports WebSocketSharp
Imports Newtonsoft.Json.Linq

'Twitch Chat Control
Imports TwitchLib
Imports TwitchLib.Events.Client

'InputSimulator Control
Imports WindowsInput

Public Class frmOverwatchHeroSelect
    'Individual Declarations
    'OBS Control
    Dim _ws As WebSocket
    Dim _responseHandlers As Dictionary(Of String, TaskCompletionSource(Of JObject))



    'Chat Vote Control
    Dim ChatVote As Boolean = False

    'Connection Approval
    Dim OBSReady As Boolean = False
    Dim TwitchReady As Boolean = False

    'Bar Animation
    Dim Bar1 As New Bar
    Dim Bar2 As New Bar
    Dim Bar3 As New Bar

    'Vote Animation
    Dim Worker1 As New OBSMove
    Dim Worker2 As New OBSMove
    Dim Worker3 As New OBSMove
    Dim NewVoteStep As Integer

    'Voting Variables
    Dim Vote1 As Integer = 0
    Dim Vote2 As Integer = 0
    Dim Vote3 As Integer = 0

    'Hero Vote
    Dim Hero1 As String
    Dim Hero2 As String
    Dim Hero3 As String
    Dim Hero1Slot As Integer
    Dim Hero2Slot As Integer
    Dim Hero3Slot As Integer
    Dim PreviousHero As Integer = 0
    Dim Heroes = {"DOOMFIST", "GENJI", "MCCREE", "PHARAH", "REAPER", "SOLDIER76", "SOMBRA", "TRACER", "BASTION", "HANZO", "JUNKRAT", "MEI", "TORBJORN", "WIDOWMAKER", "DVA", "ORISA", "REINHARDT", "ROADHOG", "WINSTON", "ZARYA", "ANA", "BRIGITTE", "LUCIO", "MERCY", "MOIRA", "SYMMETRA", "ZENYATTA"}

    'Screen Looking
    Dim Dead As Integer = 0
    Dim InBetweenRounds As Boolean = True


#Region "OBS Structure"
    Public Structure OBSAuthInfo
        Public ReadOnly AuthRequired As Boolean
        Public ReadOnly Challenge As String
        Public ReadOnly PasswordSalt As String
        ''' <param name="data">JSON response body as a <see cref="JObject"/></param>
        Public Sub New(data As JObject)
            AuthRequired = data("authRequired").Value(Of Boolean)
            Challenge = data("challenge").Value(Of String)
            PasswordSalt = data("salt").Value(Of String)
        End Sub
    End Structure
#End Region


#Region "Mouse Control Declare"
    Declare Sub mouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dx As Int32, ByVal dy As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32)
    Private Declare Function BlockInput Lib "user32" Alias "BlockInput" (ByVal fBlockIt As Boolean) As Boolean

#End Region

#Region "Load and Close"
    Private Sub frmOverwatchHeroSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set And Lock Size
        Me.Width = 610
        Me.Height = 390
        Me.MaximumSize = New Size(610, 390)
        Me.MinimumSize = New Size(610, 390)

        'Assign Settings to txtBoxes
        LoadSettings()

        'OBS Control
        _responseHandlers = New Dictionary(Of String, TaskCompletionSource(Of JObject))()
    End Sub

    Private Sub frmOverwatchHeroSelect_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
#End Region

#Region "Buttons"
    Private Sub cmdOBSConnect_Click(sender As Object, e As EventArgs) Handles cmdOBSConnect.Click
        ConnectToOBS()
        cmdOBSConnect.Enabled = False
        OBSReady = True
        If OBSReady And TwitchReady Then cmdStartStop.Enabled = True
    End Sub

    Private Sub cmdConnectToTwitch_Click(sender As Object, e As EventArgs) Handles cmdConnectToTwitch.Click
        ConnectToTwitchChat()
    End Sub

    Private Sub cmdStartStop_Click(sender As Object, e As EventArgs) Handles cmdStartStop.Click
        Select Case cmdStartStop.Text
            Case "> Start <" 'start Hero switching
                cmdStartStop.Text = "> Stop <"
                tmrReticle.Enabled = True
            Case "> Stop <" 'stop Hero switching
                cmdStartStop.Text = "> Start <"
                tmrReticle.Enabled = False
        End Select
    End Sub

    Private Sub cmdOpenSettings_Click(sender As Object, e As EventArgs) Handles cmdOpenSettings.Click
        grpOBS.Left = 294
    End Sub

    Private Sub cmdCloseSettings_Click(sender As Object, e As EventArgs) Handles cmdCloseSettings.Click
        grpOBS.Left = 595
    End Sub

#End Region


#Region "OBS Control"
    'Command List
    'SetSourceRender(Source Name, True, Scene Name)
    'SetSourceRender(Source Name, False, Scene Name)
    'SetCurrentScene(Scene Name)
    'ToggleStreaming
    'StartStreaming
    'StopStreaming
    'ToggleMute("name")
    'SetSceneItemPosition(Source Name, X, Y, sceneName)
    'SetSceneItemTransform(Source Name, rotation, xScale, yScale, sceneName)

    Private Sub ConnectToOBS()
        Try
            ' ws://127.0.0.1:4444
            ' or
            ' wss://.... - for ssh
            Connect("ws://" & My.Settings.OBSHost & ":" & My.Settings.OBSPort, My.Settings.OBSPass)
        Catch generatedExceptionName As AuthFailureException
            'MessageBox.Show("Authentication failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        Catch ex As ErrorResponseException
            'MessageBox.Show("Connect failed : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try

    End Sub


    Public Sub Connect(url As String, password As String)
        If _ws IsNot Nothing AndAlso _ws.IsAlive() Then
            Disconnect()
        End If

        _ws = New WebSocket(url)
        AddHandler _ws.OnMessage, AddressOf WebsocketMessageHandler
        _ws.Connect()

        Dim authInfo As OBSAuthInfo = GetAuthInfo()
        If authInfo.AuthRequired Then
            Authenticate(password, authInfo)
        End If
    End Sub

    Public Sub Disconnect()
        If _ws IsNot Nothing Then _ws.Close()
        _ws = Nothing
        For Each cb As Object In _responseHandlers
            Dim tcs = cb.Value
            tcs.TrySetCanceled()
        Next
    End Sub

    Public Function Authenticate(password As String, authInfo As OBSAuthInfo) As Boolean
        Dim secret As String = HashEncode(password & Convert.ToString(authInfo.PasswordSalt))
        Dim authResponse As String = HashEncode(secret & Convert.ToString(authInfo.Challenge))

        Dim requestFields = New JObject()
        requestFields.Add("auth", authResponse)

        Try
            ' Throws ErrorResponseException if auth fails
            SendRequest("Authenticate", requestFields)
        Catch generatedExceptionName As ErrorResponseException
            Throw New AuthFailureException()
        End Try

        Return True
    End Function

    Public Class ErrorResponseException
        Inherits Exception
        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="message"></param>
        Public Sub New(message As String)
            MyBase.New(message)
        End Sub
    End Class

    Public Class AuthFailureException
        Inherits Exception
    End Class

    Protected Function HashEncode(input As String) As String
        Dim sha256 = New Security.Cryptography.SHA256Managed()

        Dim textBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(input)
        Dim hash As Byte() = sha256.ComputeHash(textBytes)

        Return System.Convert.ToBase64String(hash)
    End Function

    Public Function GetAuthInfo() As OBSAuthInfo
        Dim response As JObject = SendRequest("GetAuthRequired")
        Return New OBSAuthInfo(response)
    End Function

    Private Sub WebsocketMessageHandler(sender As Object, e As MessageEventArgs)
        If Not e.IsText Then
            Return
        End If

        Dim body As JObject = JObject.Parse(e.Data)

        If body("message-id") IsNot Nothing Then
            ' Handle a request : 
            ' Find the response handler based on 
            ' its associated message ID
            Dim msgID As String = body("message-id").Value(Of String)
            Dim handler = _responseHandlers(msgID)

            If handler IsNot Nothing Then
                ' Set the response body as Result and notify the request sender
                handler.SetResult(body)

                ' The message with the given ID has been processed,
                ' so its handler can be discarded
                _responseHandlers.Remove(msgID)
            End If
        ElseIf body("update-type") IsNot Nothing Then
            ' Handle an event
            Dim eventType As String = body("update-type").ToString()
            ProcessEventType(eventType, body)
        End If
    End Sub

    Public Function SendRequest(requestType As String, Optional additionalFields As JObject = Nothing) As JObject
        Dim messageID As String

        ' Generate a random message id and make sure it is unique within the handlers dictionary
        Do
            messageID = NewMessageID()
        Loop While _responseHandlers.ContainsKey(messageID)

        ' Build the bare-minimum body for a request
        Dim body = New JObject()
        body.Add("request-type", requestType)
        body.Add("message-id", messageID)

        ' Add optional fields if provided
        If additionalFields IsNot Nothing Then
            Dim mergeSettings = New JsonMergeSettings() With {.MergeArrayHandling = MergeArrayHandling.Union}
            body.Merge(additionalFields)
        End If

        ' Prepare the asynchronous response handler
        Dim tcs = New TaskCompletionSource(Of JObject)()
        _responseHandlers.Add(messageID, tcs)

        ' Send the message and wait for a response
        ' (received and notified by the websocket response handler)
        _ws.Send(body.ToString())
        tcs.Task.Wait()

        ' Throw an exception if the server returned an error.
        ' An error occurs if authentication fails or one if the request body is invalid.
        Dim result = tcs.Task.Result

        If result("status").Value(Of String) = "error" Then
            Throw New ErrorResponseException(result("error").Value(Of String))
        End If

        Return result
    End Function

    Protected Function NewMessageID(Optional length As Integer = 16) As String
        Const pool As String = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim random = New Random()

        Dim result As String = ""
        For i As Integer = 0 To length - 1
            Dim index As Integer = random.[Next](0, pool.Length - 1)
            result += pool(index)
        Next

        Return result
    End Function


#Region "Events"
    ' as OBSWebsocket
    Public Delegate Sub SceneChangeCallback(sender As Object, newSceneName As String)
    Public Delegate Sub SourceOrderChangeCallback(sender As Object, sceneName As String)
    Public Delegate Sub SceneItemUpdateCallback(sender As Object, sceneName As String, itemname As String)
    Public Delegate Sub TransitionChangeCallback(sender As Object, newTransitionName As String)
    Public Delegate Sub TransitionDurationChangeCallback(sender As Object, newDuration As Integer)
    Public Delegate Sub OutputStateCallback(sender As Object, type As OutputState)
    Public Delegate Sub StreamStatusCallback(sender As Object, status As OBSStreamStatus)
    'public delegate void StreamStatusCallback(OBSWebsocket sender, OBSStreamStatus status);
    'Public Delegate Sub StreamStatusCallback(sender As Object, status As OBSStreamStatus)

    Public Event OnSceneChange As SceneChangeCallback
    Public Event OnSceneListChange As EventHandler
    Public Event OnSourceOrderChange As SourceOrderChangeCallback
    Public Event OnSceneItemAdded As SceneItemUpdateCallback
    Public Event OnSceneItemRemoved As SceneItemUpdateCallback
    Public Event OnSceneItemVisibilityChange As SceneItemUpdateCallback
    Public Event OnSceneCollectionChange As EventHandler
    Public Event OnSceneCollectionListChange As EventHandler
    Public Event OnTransitionChange As TransitionChangeCallback
    Public Event OnTransitionDurationChange As TransitionDurationChangeCallback
    Public Event OnTransitionListChange As EventHandler
    Public Event OnTransitionBegin As EventHandler
    Public Event OnProfileChange As EventHandler
    Public Event OnProfileListChange As EventHandler
    Public Event OnStreamingStateChange As OutputStateCallback
    Public Event OnRecordingStateChange As OutputStateCallback
    Public Event OnStreamStatus As StreamStatusCallback
    Public Event OnExit As EventHandler
#End Region

    Public Enum OutputState
        Starting
        Started
        Stopping
        Stopped
    End Enum

    Protected Sub ProcessEventType(eventType As String, body As JObject)
        Dim status As OBSStreamStatus
        Select Case eventType
            Case "SwitchScenes"
                RaiseEvent OnSceneChange(Me, body("scene-name").Value(Of String))
            Case "ScenesChanged"
                RaiseEvent OnSceneListChange(Me, EventArgs.Empty)
            Case "SourceOrderChanged"
                RaiseEvent OnSourceOrderChange(Me, body("scene-name").Value(Of String))
            Case "SceneItemAdded"
                RaiseEvent OnSceneItemAdded(Me, body("scene-name").Value(Of String), body("item-name").Value(Of String))
            Case "SceneItemRemoved"
                RaiseEvent OnSceneItemRemoved(Me, body("scene-name").Value(Of String), body("item-name").Value(Of String))
            Case "SceneItemVisibilityChanged"
                RaiseEvent OnSceneItemVisibilityChange(Me, body("scene-name").Value(Of String), body("item-name").Value(Of String))
            Case "SceneCollectionChanged"
                RaiseEvent OnSceneCollectionChange(Me, EventArgs.Empty)
            Case "SceneCollectionListChanged"
                RaiseEvent OnSceneCollectionListChange(Me, EventArgs.Empty)
            Case "SwitchTransition"
                RaiseEvent OnTransitionChange(Me, body("transition-name").Value(Of String))
            Case "TransitionDurationChanged"
                RaiseEvent OnTransitionDurationChange(Me, body("new-duration").Value(Of Integer))
            Case "TransitionListChanged"
                RaiseEvent OnTransitionListChange(Me, EventArgs.Empty)
            Case "TransitionBegin"
                RaiseEvent OnTransitionBegin(Me, EventArgs.Empty)
            Case "ProfileChanged"
                RaiseEvent OnProfileChange(Me, EventArgs.Empty)
            Case "ProfileListChanged"
                RaiseEvent OnProfileListChange(Me, EventArgs.Empty)
            Case "StreamStarting"
                RaiseEvent OnStreamingStateChange(Me, OutputState.Starting)
            Case "StreamStarted"
                RaiseEvent OnStreamingStateChange(Me, OutputState.Started)
            Case "StreamStopping"
                RaiseEvent OnStreamingStateChange(Me, OutputState.Stopping)
            Case "StreamStopped"
                RaiseEvent OnStreamingStateChange(Me, OutputState.Stopped)
            Case "RecordingStarting"
                RaiseEvent OnRecordingStateChange(Me, OutputState.Starting)
            Case "RecordingStarted"
                RaiseEvent OnRecordingStateChange(Me, OutputState.Started)
            Case "RecordingStopping"
                RaiseEvent OnRecordingStateChange(Me, OutputState.Stopping)
            Case "RecordingStopped"
                RaiseEvent OnRecordingStateChange(Me, OutputState.Stopped)
            Case "StreamStatus"
                'If OnStreamStatus IsNot Nothing Then
                status = New OBSStreamStatus(body)
                RaiseEvent OnStreamStatus(Me, status)
      'End If
            Case "Exiting"
                RaiseEvent OnExit(Me, EventArgs.Empty)
        End Select
    End Sub

    Public Structure OBSStreamStatus
        Public ReadOnly Streaming As Boolean ' True if streaming is started and running, false otherwise
        Public ReadOnly Recording As Boolean ' True if recording is started and running, false otherwise
        Public ReadOnly BytesPerSec As Integer ' Stream bitrate in bytes per second
        Public ReadOnly KbitsPerSec As Integer ' Stream bitrate in kilobits per second
        Public ReadOnly Strain As Single ' RTMP output strain
        Public ReadOnly TotalStreamTime As Integer ' Total time since streaming start
        Public ReadOnly TotalFrames As Integer ' Number of frames sent since streaming start
        Public ReadOnly DroppedFrames As Integer ' Overall number of frames dropped since streaming start
        Public ReadOnly FPS As Single ' Current framerate in Frames Per Second
        ' <param name="data">JSON event body as a <see cref="JObject"/></param>
        Public Sub New(data As JObject) ' Builds the object from the JSON event body
            Streaming = data("streaming").Value(Of Boolean)
            Recording = data("recording").Value(Of Boolean)
            BytesPerSec = data("bytes-per-sec").Value(Of Integer)
            KbitsPerSec = data("kbits-per-sec").Value(Of Integer)
            Strain = data("strain").Value(Of Single)
            TotalStreamTime = data("total-stream-time").Value(Of Integer)
            TotalFrames = data("num-total-frames").Value(Of Integer)
            DroppedFrames = data("num-dropped-frames").Value(Of Integer)
            FPS = data("fps").Value(Of Single)
        End Sub
    End Structure

    Public Sub SetSourceRender(itemName As String, visible As Boolean, Optional sceneName As String = Nothing)
        Dim requestFields = New JObject()
        requestFields.Add("source", itemName)
        requestFields.Add("render", visible)
        If sceneName IsNot Nothing Then
            requestFields.Add("scene-name", sceneName)
        End If
        SendRequest("SetSourceRender", requestFields)
    End Sub


    Public Sub SetCurrentScene(sceneName As String)
        Dim requestFields = New JObject()
        requestFields.Add("scene-name", sceneName)
        SendRequest("SetCurrentScene", requestFields)
    End Sub

    Public Sub ToggleStreaming()
        SendRequest("StartStopStreaming")
    End Sub

    Public Sub StartStreaming()
        SendRequest("StartStreaming")
    End Sub

    Public Sub StopStreaming()
        SendRequest("StopStreaming")
    End Sub

    Public Sub ToggleRecording()
        SendRequest("StartStopRecording")
    End Sub

    Public Sub StartRecording()
        SendRequest("StartRecording")
    End Sub

    Public Sub StopRecording()
        SendRequest("StopRecording")
    End Sub

    Public Sub ToggleMute(sourceName As String)
        Dim requestFields = New JObject()
        requestFields.Add("source", sourceName)
        SendRequest("ToggleMute", requestFields)
    End Sub

    Public Sub SetSceneItemPosition(itemName As String, X As Integer, Y As Integer, sceneName As String)
        Dim requestFields = New JObject()
        requestFields.Add("item", itemName)
        requestFields.Add("x", X)
        requestFields.Add("y", Y)
        requestFields.Add("scene-name", sceneName)
        SendRequest("SetSceneItemPosition", requestFields)
    End Sub

    Public Sub SetSceneItemTransform(itemName As String, rotation As Double, xScale As Double, yScale As Double, sceneName As String)
        Dim requestFields = New JObject()
        requestFields.Add("item", itemName)
        requestFields.Add("x-scale", xScale)
        requestFields.Add("y-scale", yScale)
        requestFields.Add("rotation", rotation)
        requestFields.Add("scene-name", sceneName)
        SendRequest("SetSceneItemTransform", requestFields)
    End Sub

    Public Function GetSourceSettings() As String
        Dim X As String = Nothing
        Return X
    End Function


#End Region

#Region "TwitchChat"
    'client.SendMessage("Message Here")
    'Public client As New TwitchClient(New TwitchLib.Models.Client.ConnectionCredentials(My.Settings.TwitchUser, My.Settings.TwitchOAuth))
    Public client As TwitchClient

    Private Sub ConnectToTwitchChat()
        client = New TwitchClient(New TwitchLib.Models.Client.ConnectionCredentials(My.Settings.TwitchUsername, My.Settings.TwitchOAuth))
        AddHandler client.OnConnected, AddressOf Me.onConnected
        AddHandler client.OnMessageReceived, AddressOf Me.globalChatMessageRecieved
        AddHandler client.OnDisconnected, AddressOf Me.onDisconnected
        If client.IsConnected = False Then
            client.Connect()
        End If
        txtTwitchChat.Text = "<< Connecting >>"
    End Sub

    Private Sub DisconnectFromTwitchChat()
        client.LeaveChannel(My.Settings.TwitchChannel)
        If client.IsConnected = True Then
            client.Disconnect()
        End If
        txtTwitchChat.Text = "<< Disconnecting . . . >>"
    End Sub
    Public Sub onConnected(sender As Object, e As OnConnectedArgs)
        CheckForIllegalCrossThreadCalls = False
        client.JoinChannel(My.Settings.TwitchChannel)
        txtTwitchChat.Text = "<< Connected >>"
        cmdConnectToTwitch.Enabled = False
        TwitchReady = True
        If OBSReady And TwitchReady Then cmdStartStop.Enabled = True
    End Sub
    Public Sub onDisconnected(sender As Object, e As OnDisconnectedArgs)
        CheckForIllegalCrossThreadCalls = False
        txtTwitchChat.Text = "<< Disconnected from chat server >>"
    End Sub

    Public Sub globalChatMessageRecieved(sender As Object, e As OnMessageReceivedArgs)
        CheckForIllegalCrossThreadCalls = False
        txtTwitchChat.Text = e.ChatMessage.Username & ": " + e.ChatMessage.Message
        'txtTwitchChat.Text = e.ChatMessage.Message
        If ChatVote Then 'only check if inside a vote
            Dim AlreadyVoted As Boolean = False

            For Each item In lstAlreadyVoted.Items
                If e.ChatMessage.Username = item Then AlreadyVoted = True
            Next

            If AlreadyVoted = False Then
                If ChatVote Then
                    Dim UCASEMESSAGE As String = UCase(e.ChatMessage.Message)

                    If UCASEMESSAGE.Contains(Hero1) Or e.ChatMessage.Message.Contains("1") Or UCASEMESSAGE.Contains("ONE") Then 'Hero 1 was voted for
                        Vote1 += 1

                        lstAlreadyVoted.Items.Add(e.ChatMessage.Username)
                    ElseIf UCASEMESSAGE.Contains(Hero2) Or e.ChatMessage.Message.Contains("2") Or UCASEMESSAGE.Contains("TWO") Then 'Hero 2 was voted for
                        Vote2 += 1

                        lstAlreadyVoted.Items.Add(e.ChatMessage.Username)
                    ElseIf UCASEMESSAGE.Contains(Hero3) Or e.ChatMessage.Message.Contains("3") Or UCASEMESSAGE.Contains("THREE") Then 'Hero 3 was voted for
                        Vote3 += 1

                        lstAlreadyVoted.Items.Add(e.ChatMessage.Username)
                    End If

                End If
            End If
        End If

    End Sub

#End Region

#Region "Mouse Control"
    Private Sub MoveMouse(X As Integer, Y As Integer)
        Me.Cursor = New Cursor(Cursor.Current.Handle)
        Cursor.Position = New Point(X, Y)
    End Sub

    Private Sub ClickMouse(Button As String)
        'LEFTDOWN = &H2
        'LEFTUP = &H4
        'RIGHTDOWN = &H8
        'RIGHTUP = &H10
        'MIDDLEUP = &H40
        'MIDDLEDOWN = &H20
        Select Case Button
            Case "LeftDown"
                mouse_event(&H2, 0, 0, 0, 1)
            Case "LeftUp"
                mouse_event(&H4, 0, 0, 0, 1)
            Case "LeftClick"
                mouse_event(&H2, 0, 0, 0, 1)
                mouse_event(&H4, 0, 0, 0, 1)
            Case "RightDown"
                mouse_event(&H8, 0, 0, 0, 1)
            Case "RightUp"
                mouse_event(&H10, 0, 0, 0, 1)
            Case "RightClick"
                mouse_event(&H8, 0, 0, 0, 1)
                mouse_event(&H10, 0, 0, 0, 1)
        End Select
    End Sub

#End Region

#Region "Functions"
    Private Sub CheckPixels()
        'Checking 1 pixel at the bottom center of Destiny in capture app
        Dim a As New Drawing.Bitmap(1, 1)
        Dim b As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(a)
        b.CopyFromScreen(New Drawing.Point(My.Settings.ReticleX, My.Settings.ReticleY), New Drawing.Point(0, 0), a.Size)
        Dim c As Drawing.Color = a.GetPixel(0, 0)
        picReticleColor.BackColor = c
        txtReticleColor.Text = picReticleColor.BackColor.Name
    End Sub

    Private Sub UpdateVotes()
        If Vote1 + Vote2 + Vote3 <> 0 Then
            'calculate and start Bar 1
            Bar1._T = 0
            Bar1._S = 0.012
            Bar1._SP = Bar1._FP
            Bar1._FP = Vote1 / (Vote1 + Vote2 + Vote3)
            Bar1._D = Bar1._FP - Bar1._SP
            tmrBar1.Enabled = True

            'calculate and start Bar 2
            Bar2._T = 0
            Bar2._S = 0.012
            Bar2._SP = Bar2._FP
            Bar2._FP = Vote2 / (Vote1 + Vote2 + Vote3)
            Bar2._D = Bar2._FP - Bar2._SP
            tmrBar2.Enabled = True

            'calculate and start Bar 3
            Bar3._T = 0
            Bar3._S = 0.012
            Bar3._SP = Bar3._FP
            Bar3._FP = Vote3 / (Vote1 + Vote2 + Vote3)
            Bar3._D = Bar3._FP - Bar3._SP
            tmrBar3.Enabled = True

            'update txt files
            Dim Vote1Percentage As Integer
            Dim Vote2Percentage As Integer
            Dim Vote3Percentage As Integer

            If Vote1 <> 0 Then
                Vote1Percentage = (Vote1 / (Vote1 + Vote2 + Vote3)) * 100
                WriteToTxt("Bar1Percent.txt", Vote1Percentage.ToString & "%")
            End If
            If Vote2 <> 0 Then
                Vote2Percentage = (Vote2 / (Vote1 + Vote2 + Vote3)) * 100
                WriteToTxt("Bar2Percent.txt", Vote2Percentage.ToString & "%")
            End If
            If Vote3 <> 0 Then
                Vote3Percentage = (Vote3 / (Vote1 + Vote2 + Vote3)) * 100
                WriteToTxt("Bar3Percent.txt", Vote3Percentage.ToString & "%")
            End If
        End If

    End Sub

    Private Sub ResetVotes()
        Vote1 = 0
        Vote2 = 0
        Vote3 = 0
        Bar1._SP = 0
        Bar1._FP = 0
        Bar2._SP = 0
        Bar2._FP = 0
        Bar3._SP = 0
        Bar3._FP = 0
        SetSceneItemTransform(My.Settings.OBSSourceBar1, 0, 0, 1, My.Settings.OBSSceneVote1)
        SetSceneItemTransform(My.Settings.OBSSourceBar2, 0, 0, 1, My.Settings.OBSSceneVote2)
        SetSceneItemTransform(My.Settings.OBSSourceBar3, 0, 0, 1, My.Settings.OBSSceneVote3)
        WriteToTxt("Bar1Percent.txt", "0%")
        WriteToTxt("Bar2Percent.txt", "0%")
        WriteToTxt("Bar3Percent.txt", "0%")
        lstAlreadyVoted.Items.Clear()
    End Sub

    Private Sub WriteToTxt(txtdoc As String, message As String)
        System.IO.File.WriteAllText("Text Files\" & txtdoc, message)
        'Dim objWriter As New System.IO.StreamWriter("Text Files\" & txtdoc, True)
        'objWriter.WriteLine(message)
        'objWriter.Close()
    End Sub

    Private Sub PlayAudio(TrackURL As String)
        'PlayAudio("NewQuestion.mp3")
        AlertPlayer.Ctlcontrols.stop()
        AlertPlayer.URL = "Audio/" & TrackURL
    End Sub

    Private Sub PlayWinnerAudio(track As Integer)
        Select Case track
            Case 1
                PlayAudio("Doomfist.mp3")
            Case 2
                PlayAudio("Genji.mp3")
            Case 3
                PlayAudio("McCree.mp3")
            Case 4
                PlayAudio("Pharah.mp3")
            Case 5
                PlayAudio("Reaper.mp3")
            Case 6
                PlayAudio("Soldier76.mp3")
            Case 7
                PlayAudio("Sombra.mp3")
            Case 8
                PlayAudio("Tracer.mp3")
            Case 9
                PlayAudio("Bastion.mp3")
            Case 10
                PlayAudio("Hanzo.mp3")
            Case 11
                PlayAudio("Junkrat.mp3")
            Case 12
                PlayAudio("Mei.mp3")
            Case 13
                PlayAudio("Torbjorn.mp3")
            Case 14
                PlayAudio("Widowmaker.mp3")
            Case 15
                PlayAudio("Dva.mp3")
            Case 16
                PlayAudio("Orisa.mp3")
            Case 17
                PlayAudio("Reinhardt.mp3")
            Case 18
                PlayAudio("Roadhog.mp3")
            Case 19
                PlayAudio("Winston.mp3")
            Case 20
                PlayAudio("Zarya.mp3")
            Case 21
                PlayAudio("Ana.mp3")
            Case 22
                PlayAudio("Brigitte.mp3")
            Case 23
                PlayAudio("Lucio.mp3")
            Case 24
                PlayAudio("Mercy.mp3")
            Case 25
                PlayAudio("Moira.mp3")
            Case 26
                PlayAudio("Symmetra.mp3")
            Case 27
                PlayAudio("Zenyatta.mp3")
        End Select
    End Sub

    Private Sub NewHeroes()
NewHeroTop:
        Hero1Slot = Rand(1, 27)
        Hero2Slot = Rand(1, 27)
        Hero3Slot = Rand(1, 27)

        If Hero1Slot = Hero2Slot Or Hero1Slot = Hero3Slot Or Hero2Slot = Hero3Slot Or Hero1Slot = PreviousHero Or Hero2Slot = PreviousHero Or Hero3Slot = PreviousHero Then
            GoTo NewHeroTop
        End If

        If Not CheckHeroAvail(Hero1Slot) Or Not CheckHeroAvail(Hero2Slot) Or Not CheckHeroAvail(Hero3Slot) Then
            GoTo NewHeroTop
        End If

        Hero1 = Heroes(Hero1Slot - 1)
        Hero2 = Heroes(Hero2Slot - 1)
        Hero3 = Heroes(Hero3Slot - 1)

        WriteToTxt("Hero1Name.txt", Hero1)
        WriteToTxt("Hero2Name.txt", Hero2)
        WriteToTxt("Hero3Name.txt", Hero3)

        OBSHeroImg(Hero1Slot, My.Settings.OBSSceneVote1)
        OBSHeroImg(Hero2Slot, My.Settings.OBSSceneVote2)
        OBSHeroImg(Hero3Slot, My.Settings.OBSSceneVote3)

        client.SendMessage("New Vote! [1] " & Hero1 & ", [2] " & Hero2 & ", [3] " & Hero3)

    End Sub

    Private Function CheckHeroAvail(hero As Integer) As Boolean
        Select Case hero
            Case 1
                If chkHero01.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 2
                If chkHero02.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 3
                If chkHero03.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 4
                If chkHero04.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 5
                If chkHero05.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 6
                If chkHero06.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 7
                If chkHero07.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 8
                If chkHero08.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 9
                If chkHero09.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 10
                If chkHero10.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 11
                If chkHero11.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 12
                If chkHero12.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 13
                If chkHero13.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 14
                If chkHero14.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 15
                If chkHero15.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 16
                If chkHero16.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 17
                If chkHero17.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 18
                If chkHero18.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 19
                If chkHero19.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 20
                If chkHero20.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 21
                If chkHero21.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 22
                If chkHero22.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 23
                If chkHero23.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 24
                If chkHero24.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 25
                If chkHero25.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 26
                If chkHero26.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
            Case 27
                If chkHero27.Checked Then
                    CheckHeroAvail = True
                Else
                    CheckHeroAvail = False
                End If
        End Select

        Return CheckHeroAvail
    End Function

    Private Sub OBSHeroImg(hero As Integer, scene As String)
        'all off
        SetSourceRender("Doomfist", False, scene)
        SetSourceRender("Genji", False, scene)
        SetSourceRender("McCree", False, scene)
        SetSourceRender("Pharah", False, scene)
        SetSourceRender("Reaper", False, scene)
        SetSourceRender("Soldier76", False, scene)
        SetSourceRender("Sombra", False, scene)
        SetSourceRender("Tracer", False, scene)
        SetSourceRender("Bastion", False, scene)
        SetSourceRender("Hanzo", False, scene)
        SetSourceRender("Junkrat", False, scene)
        SetSourceRender("Mei", False, scene)
        SetSourceRender("Torbjorn", False, scene)
        SetSourceRender("Widowmaker", False, scene)
        SetSourceRender("Dva", False, scene)
        SetSourceRender("Orisa", False, scene)
        SetSourceRender("Reinhardt", False, scene)
        SetSourceRender("Roadhog", False, scene)
        SetSourceRender("Winston", False, scene)
        SetSourceRender("Zarya", False, scene)
        SetSourceRender("Ana", False, scene)
        SetSourceRender("Brigitte", False, scene)
        SetSourceRender("Lucio", False, scene)
        SetSourceRender("Mercy", False, scene)
        SetSourceRender("Moira", False, scene)
        SetSourceRender("Symmetra", False, scene)
        SetSourceRender("Zenyatta", False, scene)

        'correct on
        Select Case hero
            Case 1 'Doomfist
                SetSourceRender("Doomfist", True, scene)
            Case 2 'Genji
                SetSourceRender("Genji", True, scene)
            Case 3 'McCree
                SetSourceRender("McCree", True, scene)
            Case 4 'Pharah
                SetSourceRender("Pharah", True, scene)
            Case 5 'Reaper
                SetSourceRender("Reaper", True, scene)
            Case 6 'Soldier76
                SetSourceRender("Soldier76", True, scene)
            Case 7 'Sombra
                SetSourceRender("Sombra", True, scene)
            Case 8 'Tracer
                SetSourceRender("Tracer", True, scene)
            Case 9 'Bastion
                SetSourceRender("Bastion", True, scene)
            Case 10 'Hanzo
                SetSourceRender("Hanzo", True, scene)
            Case 11 'Junkrat
                SetSourceRender("Junkrat", True, scene)
            Case 12 'Mei
                SetSourceRender("Mei", True, scene)
            Case 13 'Torbjorn
                SetSourceRender("Torbjorn", True, scene)
            Case 14 'Widowmaker
                SetSourceRender("Widowmaker", True, scene)
            Case 15 'Dva
                SetSourceRender("Dva", True, scene)
            Case 16 'Orisa
                SetSourceRender("Orisa", True, scene)
            Case 17 'Reinhardt
                SetSourceRender("Reinhardt", True, scene)
            Case 18 'Roadhog
                SetSourceRender("Roadhog", True, scene)
            Case 19 'Winston
                SetSourceRender("Winston", True, scene)
            Case 20 'Zarya
                SetSourceRender("Zarya", True, scene)
            Case 21 'Ana
                SetSourceRender("Ana", True, scene)
            Case 22 'Brigitte 
                SetSourceRender("Brigitte", True, scene)
            Case 23 'Lucio
                SetSourceRender("Lucio", True, scene)
            Case 24 'Mercy
                SetSourceRender("Mercy", True, scene)
            Case 25 'Moira
                SetSourceRender("Moira", True, scene)
            Case 26 'Symmetra
                SetSourceRender("Symmetra", True, scene)
            Case 27 'Zenyatta
                SetSourceRender("Zenyatta", True, scene)
        End Select
    End Sub

    Private Sub AssignNewHero(hero As Integer)
        BlockInput(True)
        InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H)
        System.Threading.Thread.Sleep(200)
        Select Case hero
            Case 1 'Doomfist
                MoveMouse(120, 900)
                ClickMouse("LeftClick")
            Case 2 'Genji
                MoveMouse(180, 900)
                ClickMouse("LeftClick")
            Case 3 'McCree
                MoveMouse(245, 900)
                ClickMouse("LeftClick")
            Case 4 'Pharah
                MoveMouse(305, 900)
                ClickMouse("LeftClick")
            Case 5 'Reaper
                MoveMouse(370, 900)
                ClickMouse("LeftClick")
            Case 6 'Soldier76
                MoveMouse(425, 900)
                ClickMouse("LeftClick")
            Case 7 'Sombra
                MoveMouse(500, 900)
                ClickMouse("LeftClick")
            Case 8 'Tracer
                MoveMouse(555, 900)
                ClickMouse("LeftClick")
            Case 9 'Bastion
                MoveMouse(645, 900)
                ClickMouse("LeftClick")
            Case 10 'Hanzo
                MoveMouse(710, 900)
                ClickMouse("LeftClick")
            Case 11 'Junkrat
                MoveMouse(775, 900)
                ClickMouse("LeftClick")
            Case 12 'Mei
                MoveMouse(830, 900)
                ClickMouse("LeftClick")
            Case 13 'Torbjorn
                MoveMouse(905, 900)
                ClickMouse("LeftClick")
            Case 14 'Widowmaker
                MoveMouse(955, 900)
                ClickMouse("LeftClick")
            Case 15 'Dva
                MoveMouse(1050, 900)
                ClickMouse("LeftClick")
            Case 16 'Orisa
                MoveMouse(1115, 900)
                ClickMouse("LeftClick")
            Case 17 'Reinhardt
                MoveMouse(1170, 900)
                ClickMouse("LeftClick")
            Case 18 'Roadhog
                MoveMouse(1240, 900)
                ClickMouse("LeftClick")
            Case 19 'Winston
                MoveMouse(1300, 900)
                ClickMouse("LeftClick")
            Case 20 'Zarya
                MoveMouse(1365, 900)
                ClickMouse("LeftClick")
            Case 21 'Ana
                MoveMouse(1450, 900)
                ClickMouse("LeftClick")
            Case 22 'Brigitte
                MoveMouse(1510, 900)
                ClickMouse("LeftClick")
            Case 23 'Lucio
                MoveMouse(1575, 900)
                ClickMouse("LeftClick")
            Case 24 'Mercy
                MoveMouse(1640, 900)
                ClickMouse("LeftClick")
            Case 25 'Moira
                MoveMouse(1700, 900)
                ClickMouse("LeftClick")
            Case 26 'Symmetra
                MoveMouse(1765, 900)
                ClickMouse("LeftClick")
            Case 27 'Zenyatta
                MoveMouse(1825, 900)
                ClickMouse("LeftClick")
        End Select
        System.Threading.Thread.Sleep(200)
        MoveMouse(960, 1000)
        ClickMouse("LeftClick")
        BlockInput(False)
        InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_W)
        InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_A)
        InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_S)
        InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_D)
        InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT)
        InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL)
        InputSimulator.SimulateKeyUp(VirtualKeyCode.MENU)
        InputSimulator.SimulateKeyUp(VirtualKeyCode.TAB)

    End Sub

    Private Function Rand(lowerbound As Integer, upperbound As Integer) As Integer
        Randomize()
        Return CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
    End Function


#End Region

#Region "Timers"
    Private Sub tmrReticle_Tick(sender As Object, e As EventArgs) Handles tmrReticle.Tick
        CheckPixels()
        If txtReticleColor.Text = txtLookFor.Text Then 'look at reticle color to determine if the player is alive
            Dead = 0
            InBetweenRounds = False
        Else
            If Not InBetweenRounds Then Dead += 1
        End If

        If Dead = 40 Then 'player is considered dead after 8 seconds of not seeing reticle color
            tmrReticle.Enabled = False
            Dead = 0
            AssignNewHero(PreviousHero)
            NewHeroes()
            ResetVotes()
            ChatVote = True
            tmrNewVote.Enabled = True
            tmrNewVote.Interval = 2000
            NewVoteStep = 1
            tmrEndVote.Enabled = True
            tmrUpdateVote.Enabled = True
            InBetweenRounds = True
        End If
    End Sub

    Private Sub tmrUpdateVote_Tick(sender As Object, e As EventArgs) Handles tmrUpdateVote.Tick
        UpdateVotes()
    End Sub

    Private Sub tmrBar1_Tick(sender As Object, e As EventArgs) Handles tmrBar1.Tick
        If Bar1._T >= 1 Then
            Bar1._T = 1
            tmrBar1.Enabled = False
        End If
        Bar1._P = QuadraticEaseInOut(Bar1._T)
        Bar1._PD = Bar1._P * Bar1._D

        SetSceneItemTransform(My.Settings.OBSSourceBar1, 0, Bar1._SP + Bar1._PD, 1, My.Settings.OBSSceneVote1)

        Bar1._T += Bar1._S
    End Sub

    Private Sub tmrBar2_Tick(sender As Object, e As EventArgs) Handles tmrBar2.Tick
        If Bar2._T >= 1 Then
            Bar2._T = 1
            tmrBar2.Enabled = False
        End If
        Bar2._P = QuadraticEaseInOut(Bar2._T)
        Bar2._PD = Bar2._P * Bar2._D

        SetSceneItemTransform(My.Settings.OBSSourceBar2, 0, Bar2._SP + Bar2._PD, 1, My.Settings.OBSSceneVote2)

        Bar2._T += Bar2._S
    End Sub

    Private Sub tmrBar3_Tick(sender As Object, e As EventArgs) Handles tmrBar3.Tick
        If Bar3._T >= 1 Then
            Bar3._T = 1
            tmrBar3.Enabled = False
        End If
        Bar3._P = QuadraticEaseInOut(Bar3._T)
        Bar3._PD = Bar3._P * Bar3._D

        SetSceneItemTransform(My.Settings.OBSSourceBar3, 0, Bar3._SP + Bar3._PD, 1, My.Settings.OBSSceneVote3)

        Bar3._T += Bar3._S
    End Sub

    Private Sub tmrVote1_Tick(sender As Object, e As EventArgs) Handles tmrVote1.Tick
        If Worker1._T >= 1 Then
            Worker1._T = 1
            tmrVote1.Enabled = False
        End If
        Worker1._P = QuadraticEaseInOut(Worker1._T)
        Worker1._XL = (Worker1._P * Worker1._XD) + Worker1.StartX
        Worker1._YL = (Worker1._P * Worker1._YD) + Worker1.StartY

        SetSceneItemPosition(My.Settings.OBSSceneVote1, Worker1._XL, Worker1._YL, My.Settings.OBSSceneOverwatch)

        Worker1._T += Worker1._S
    End Sub

    Private Sub tmrVote2_Tick(sender As Object, e As EventArgs) Handles tmrVote2.Tick
        If Worker2._T >= 1 Then
            Worker2._T = 1
            tmrVote2.Enabled = False
        End If
        Worker2._P = QuadraticEaseInOut(Worker2._T)
        Worker2._XL = (Worker2._P * Worker2._XD) + Worker2.StartX
        Worker2._YL = (Worker2._P * Worker2._YD) + Worker2.StartY

        SetSceneItemPosition(My.Settings.OBSSceneVote2, Worker2._XL, Worker2._YL, My.Settings.OBSSceneOverwatch)

        Worker2._T += Worker2._S
    End Sub

    Private Sub tmrVote3_Tick(sender As Object, e As EventArgs) Handles tmrVote3.Tick
        If Worker3._T >= 1 Then
            Worker3._T = 1
            tmrVote3.Enabled = False
        End If
        Worker3._P = QuadraticEaseInOut(Worker3._T)
        Worker3._XL = (Worker3._P * Worker3._XD) + Worker3.StartX
        Worker3._YL = (Worker3._P * Worker3._YD) + Worker3.StartY

        SetSceneItemPosition(My.Settings.OBSSceneVote3, Worker3._XL, Worker3._YL, My.Settings.OBSSceneOverwatch)

        Worker3._T += Worker3._S
    End Sub

    Private Sub tmrNewVote_Tick(sender As Object, e As EventArgs) Handles tmrNewVote.Tick
        'animate on
        tmrNewVote.Interval = 250

        Select Case NewVoteStep
            Case 1
                'Worker1 Right
                Worker1.StartX = -500
                Worker1.StartY = My.Settings.Bar1Y
                Worker1.EndX = 0
                Worker1.EndY = My.Settings.Bar1Y

                Worker1._S = 0.012
                Worker1._XD = Worker1.EndX - Worker1.StartX
                Worker1._YD = Worker1.EndY - Worker1.StartY
                Worker1._T = 0

                tmrVote1.Enabled = True

                NewVoteStep = 2
            Case 2
                'Worker2 Right
                Worker2.StartX = -500
                Worker2.StartY = My.Settings.Bar2Y
                Worker2.EndX = 0
                Worker2.EndY = My.Settings.Bar2Y

                Worker2._S = 0.012
                Worker2._XD = Worker2.EndX - Worker2.StartX
                Worker2._YD = Worker2.EndY - Worker2.StartY
                Worker2._T = 0

                tmrVote2.Enabled = True

                NewVoteStep = 3
            Case 3
                'Worker3 Right
                Worker3.StartX = -500
                Worker3.StartY = My.Settings.Bar3Y
                Worker3.EndX = 0
                Worker3.EndY = My.Settings.Bar3Y

                Worker3._S = 0.012
                Worker3._XD = Worker3.EndX - Worker3.StartX
                Worker3._YD = Worker3.EndY - Worker3.StartY
                Worker3._T = 0

                tmrVote3.Enabled = True

                NewVoteStep = 4
            Case 4
                tmrNewVote.Enabled = False
        End Select
    End Sub

    Private Sub tmrEndVote_Tick(sender As Object, e As EventArgs) Handles tmrEndVote.Tick
        If Vote1 >= Vote2 Then
            If Vote1 >= Vote3 Then
                'vote1 wins
                PreviousHero = Hero1Slot
            Else
                'vote3 wins
                PreviousHero = Hero3Slot
            End If
        Else
            If Vote2 >= Vote3 Then
                'vote2 wins
                PreviousHero = Hero2Slot
            Else
                'vote3 wins
                PreviousHero = Hero3Slot
            End If
        End If

        PlayWinnerAudio(PreviousHero)

        'Worker1 Right
        Worker1.StartX = 0
        Worker1.StartY = My.Settings.Bar1Y
        Worker1.EndX = -500
        Worker1.EndY = My.Settings.Bar1Y

        Worker1._S = 0.012
        Worker1._XD = Worker1.EndX - Worker1.StartX
        Worker1._YD = Worker1.EndY - Worker1.StartY
        Worker1._T = 0

        tmrVote1.Enabled = True

        'Worker2 Right
        Worker2.StartX = 0
        Worker2.StartY = My.Settings.Bar2Y
        Worker2.EndX = -500
        Worker2.EndY = My.Settings.Bar2Y

        Worker2._S = 0.012
        Worker2._XD = Worker2.EndX - Worker2.StartX
        Worker2._YD = Worker2.EndY - Worker2.StartY
        Worker2._T = 0

        tmrVote2.Enabled = True

        'Worker3 Right
        Worker3.StartX = 0
        Worker3.StartY = My.Settings.Bar3Y
        Worker3.EndX = -500
        Worker3.EndY = My.Settings.Bar3Y

        Worker3._S = 0.012
        Worker3._XD = Worker3.EndX - Worker3.StartX
        Worker3._YD = Worker3.EndY - Worker3.StartY
        Worker3._T = 0

        tmrVote3.Enabled = True

        Vote1 = 0
        Vote2 = 0
        Vote3 = 0
        UpdateVotes()

        tmrUpdateVote.Enabled = False
        tmrEndVote.Enabled = False
        tmrReticle.Enabled = True

    End Sub


#End Region


#Region "Settings"
    Private Sub chkHero01_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero01.CheckedChanged
        My.Settings.chkHero01 = chkHero01.Checked
    End Sub

    Private Sub chkHero02_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero02.CheckedChanged
        My.Settings.chkHero02 = chkHero02.Checked
    End Sub

    Private Sub chkHero03_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero03.CheckedChanged
        My.Settings.chkHero03 = chkHero03.Checked
    End Sub

    Private Sub chkHero04_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero04.CheckedChanged
        My.Settings.chkHero04 = chkHero04.Checked
    End Sub

    Private Sub chkHero05_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero05.CheckedChanged
        My.Settings.chkHero05 = chkHero05.Checked
    End Sub

    Private Sub chkHero06_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero06.CheckedChanged
        My.Settings.chkHero06 = chkHero06.Checked
    End Sub

    Private Sub chkHero07_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero07.CheckedChanged
        My.Settings.chkHero07 = chkHero07.Checked
    End Sub

    Private Sub chkHero08_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero08.CheckedChanged
        My.Settings.chkHero08 = chkHero08.Checked
    End Sub

    Private Sub chkHero09_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero09.CheckedChanged
        My.Settings.chkHero09 = chkHero09.Checked
    End Sub

    Private Sub chkHero10_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero10.CheckedChanged
        My.Settings.chkHero10 = chkHero10.Checked
    End Sub

    Private Sub chkHero11_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero11.CheckedChanged
        My.Settings.chkHero11 = chkHero11.Checked
    End Sub

    Private Sub chkHero12_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero12.CheckedChanged
        My.Settings.chkHero12 = chkHero12.Checked
    End Sub

    Private Sub chkHero13_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero13.CheckedChanged
        My.Settings.chkHero13 = chkHero13.Checked
    End Sub

    Private Sub chkHero14_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero14.CheckedChanged
        My.Settings.chkHero14 = chkHero14.Checked
    End Sub

    Private Sub chkHero15_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero15.CheckedChanged
        My.Settings.chkHero15 = chkHero15.Checked
    End Sub

    Private Sub chkHero16_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero16.CheckedChanged
        My.Settings.chkHero16 = chkHero16.Checked
    End Sub

    Private Sub chkHero17_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero17.CheckedChanged
        My.Settings.chkHero17 = chkHero17.Checked
    End Sub

    Private Sub chkHero18_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero18.CheckedChanged
        My.Settings.chkHero18 = chkHero18.Checked
    End Sub

    Private Sub chkHero19_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero19.CheckedChanged
        My.Settings.chkHero19 = chkHero19.Checked
    End Sub

    Private Sub chkHero20_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero20.CheckedChanged
        My.Settings.chkHero20 = chkHero20.Checked
    End Sub

    Private Sub chkHero21_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero21.CheckedChanged
        My.Settings.chkHero21 = chkHero21.Checked
    End Sub

    Private Sub chkHero22_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero22.CheckedChanged
        My.Settings.chkHero22 = chkHero22.Checked
    End Sub

    Private Sub chkHero23_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero23.CheckedChanged
        My.Settings.chkHero23 = chkHero23.Checked
    End Sub

    Private Sub chkHero24_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero24.CheckedChanged
        My.Settings.chkHero24 = chkHero24.Checked
    End Sub

    Private Sub chkHero25_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero25.CheckedChanged
        My.Settings.chkHero25 = chkHero25.Checked
    End Sub

    Private Sub chkHero26_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero26.CheckedChanged
        My.Settings.chkHero26 = chkHero26.Checked
    End Sub

    Private Sub chkHero27_CheckedChanged(sender As Object, e As EventArgs) Handles chkHero27.CheckedChanged
        My.Settings.chkHero27 = chkHero27.Checked
    End Sub

    Private Sub txtOBSHost_TextChanged(sender As Object, e As EventArgs) Handles txtOBSHost.TextChanged
        My.Settings.OBSHost = txtOBSHost.Text
    End Sub

    Private Sub txtOBSPort_TextChanged(sender As Object, e As EventArgs) Handles txtOBSPort.TextChanged
        My.Settings.OBSPort = txtOBSPort.Text
    End Sub

    Private Sub txtOBSPass_TextChanged(sender As Object, e As EventArgs) Handles txtOBSPass.TextChanged
        My.Settings.OBSPass = txtOBSPass.Text
    End Sub

    Private Sub txtTwitchUsername_TextChanged(sender As Object, e As EventArgs) Handles txtTwitchUsername.TextChanged
        My.Settings.TwitchUsername = txtTwitchUsername.Text
        My.Settings.TwitchChannel = txtTwitchUsername.Text
    End Sub

    Private Sub txtTwitchOAuth_TextChanged(sender As Object, e As EventArgs) Handles txtTwitchOAuth.TextChanged
        My.Settings.TwitchOAuth = txtTwitchOAuth.Text
    End Sub

    Private Sub txtLookFor_TextChanged(sender As Object, e As EventArgs) Handles txtLookFor.TextChanged
        My.Settings.LookFor = txtLookFor.Text
    End Sub

    Private Sub txtOBSSceneOverwatch_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSceneOverwatch.TextChanged
        My.Settings.OBSSceneOverwatch = txtOBSSceneOverwatch.Text
    End Sub

    Private Sub txtOBSSceneVote1_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSceneVote1.TextChanged
        My.Settings.OBSSceneVote1 = txtOBSSceneVote1.Text
    End Sub

    Private Sub txtOBSSceneVote2_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSceneVote2.TextChanged
        My.Settings.OBSSceneVote2 = txtOBSSceneVote2.Text
    End Sub

    Private Sub txtOBSSceneVote3_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSceneVote3.TextChanged
        My.Settings.OBSSceneVote3 = txtOBSSceneVote3.Text
    End Sub

    Private Sub txtOBSSourceBar1_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSourceBar1.TextChanged
        My.Settings.OBSSourceBar1 = txtOBSSourceBar1.Text
    End Sub

    Private Sub txtOBSSourceBar2_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSourceBar2.TextChanged
        My.Settings.OBSSourceBar2 = txtOBSSourceBar2.Text
    End Sub

    Private Sub txtOBSSourceBar3_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSourceBar3.TextChanged
        My.Settings.OBSSourceBar3 = txtOBSSourceBar3.Text
    End Sub

    Private Sub txtOBSSourceBar1Y_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSourceBar1Y.TextChanged
        My.Settings.Bar1Y = CInt(txtOBSSourceBar1Y.Text)
    End Sub

    Private Sub txtOBSSourceBar2Y_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSourceBar2Y.TextChanged
        My.Settings.Bar2Y = CInt(txtOBSSourceBar2Y.Text)
    End Sub

    Private Sub txtOBSSourceBar3Y_TextChanged(sender As Object, e As EventArgs) Handles txtOBSSourceBar3Y.TextChanged
        My.Settings.Bar3Y = CInt(txtOBSSourceBar3Y.Text)
    End Sub

    Private Sub txtReticleX_TextChanged(sender As Object, e As EventArgs) Handles txtReticleX.TextChanged
        My.Settings.ReticleX = CInt(txtReticleX.Text)
    End Sub

    Private Sub txtReticleY_TextChanged(sender As Object, e As EventArgs) Handles txtReticleY.TextChanged
        My.Settings.ReticleY = CInt(txtReticleY.Text)
    End Sub

    Private Sub LoadSettings()
        txtTwitchUsername.Text = My.Settings.TwitchUsername
        txtTwitchOAuth.Text = My.Settings.TwitchOAuth
        txtOBSHost.Text = My.Settings.OBSHost
        txtOBSPort.Text = My.Settings.OBSPort
        txtOBSPass.Text = My.Settings.OBSPass

        txtLookFor.Text = My.Settings.LookFor

        chkHero01.Checked = My.Settings.chkHero01
        chkHero02.Checked = My.Settings.chkHero02
        chkHero03.Checked = My.Settings.chkHero03
        chkHero04.Checked = My.Settings.chkHero04
        chkHero05.Checked = My.Settings.chkHero05
        chkHero06.Checked = My.Settings.chkHero06
        chkHero07.Checked = My.Settings.chkHero07
        chkHero08.Checked = My.Settings.chkHero08
        chkHero09.Checked = My.Settings.chkHero09
        chkHero10.Checked = My.Settings.chkHero10
        chkHero11.Checked = My.Settings.chkHero11
        chkHero12.Checked = My.Settings.chkHero12
        chkHero13.Checked = My.Settings.chkHero13
        chkHero14.Checked = My.Settings.chkHero14
        chkHero15.Checked = My.Settings.chkHero15
        chkHero16.Checked = My.Settings.chkHero16
        chkHero17.Checked = My.Settings.chkHero17
        chkHero18.Checked = My.Settings.chkHero18
        chkHero19.Checked = My.Settings.chkHero19
        chkHero20.Checked = My.Settings.chkHero20
        chkHero21.Checked = My.Settings.chkHero21
        chkHero22.Checked = My.Settings.chkHero22
        chkHero23.Checked = My.Settings.chkHero23
        chkHero24.Checked = My.Settings.chkHero24
        chkHero25.Checked = My.Settings.chkHero25
        chkHero26.Checked = My.Settings.chkHero26
        chkHero27.Checked = My.Settings.chkHero27

        txtOBSSceneOverwatch.Text = My.Settings.OBSSceneOverwatch
        txtOBSSceneVote1.Text = My.Settings.OBSSceneVote1
        txtOBSSceneVote2.Text = My.Settings.OBSSceneVote2
        txtOBSSceneVote3.Text = My.Settings.OBSSceneVote3
        txtOBSSourceBar1.Text = My.Settings.OBSSourceBar1
        txtOBSSourceBar2.Text = My.Settings.OBSSourceBar2
        txtOBSSourceBar3.Text = My.Settings.OBSSourceBar3
        txtOBSSourceBar1Y.Text = My.Settings.Bar1Y
        txtOBSSourceBar2Y.Text = My.Settings.Bar2Y
        txtOBSSourceBar3Y.Text = My.Settings.Bar3Y
        txtReticleX.Text = My.Settings.ReticleX
        txtReticleY.Text = My.Settings.ReticleY

    End Sub


#End Region

#Region "Audio"
    Private Sub picDoomfist_Click(sender As Object, e As EventArgs) Handles picDoomfist.Click
        PlayWinnerAudio(1)
    End Sub

    Private Sub picGenji_Click(sender As Object, e As EventArgs) Handles picGenji.Click
        PlayWinnerAudio(2)
    End Sub

    Private Sub picMcCree_Click(sender As Object, e As EventArgs) Handles picMcCree.Click
        PlayWinnerAudio(3)
    End Sub

    Private Sub picPharah_Click(sender As Object, e As EventArgs) Handles picPharah.Click
        PlayWinnerAudio(4)
    End Sub

    Private Sub picReaper_Click(sender As Object, e As EventArgs) Handles picReaper.Click
        PlayWinnerAudio(5)
    End Sub

    Private Sub picSoldier76_Click(sender As Object, e As EventArgs) Handles picSoldier76.Click
        PlayWinnerAudio(6)
    End Sub

    Private Sub picSombra_Click(sender As Object, e As EventArgs) Handles picSombra.Click
        PlayWinnerAudio(7)
    End Sub

    Private Sub picTracer_Click(sender As Object, e As EventArgs) Handles picTracer.Click
        PlayWinnerAudio(8)
    End Sub

    Private Sub picBastion_Click(sender As Object, e As EventArgs) Handles picBastion.Click
        PlayWinnerAudio(9)
    End Sub

    Private Sub picHanzo_Click(sender As Object, e As EventArgs) Handles picHanzo.Click
        PlayWinnerAudio(10)
    End Sub

    Private Sub picJunkrat_Click(sender As Object, e As EventArgs) Handles picJunkrat.Click
        PlayWinnerAudio(11)
    End Sub

    Private Sub picMei_Click(sender As Object, e As EventArgs) Handles picMei.Click
        PlayWinnerAudio(12)
    End Sub

    Private Sub picTorbjorn_Click(sender As Object, e As EventArgs) Handles picTorbjorn.Click
        PlayWinnerAudio(13)
    End Sub

    Private Sub picWidowmaker_Click(sender As Object, e As EventArgs) Handles picWidowmaker.Click
        PlayWinnerAudio(14)
    End Sub

    Private Sub picDva_Click(sender As Object, e As EventArgs) Handles picDva.Click
        PlayWinnerAudio(15)
    End Sub

    Private Sub picOrisa_Click(sender As Object, e As EventArgs) Handles picOrisa.Click
        PlayWinnerAudio(16)
    End Sub

    Private Sub picReinhardt_Click(sender As Object, e As EventArgs) Handles picReinhardt.Click
        PlayWinnerAudio(17)
    End Sub

    Private Sub picRoadhog_Click(sender As Object, e As EventArgs) Handles picRoadhog.Click
        PlayWinnerAudio(18)
    End Sub

    Private Sub picWinston_Click(sender As Object, e As EventArgs) Handles picWinston.Click
        PlayWinnerAudio(19)
    End Sub

    Private Sub picZarya_Click(sender As Object, e As EventArgs) Handles picZarya.Click
        PlayWinnerAudio(20)
    End Sub

    Private Sub picAna_Click(sender As Object, e As EventArgs) Handles picAna.Click
        PlayWinnerAudio(21)
    End Sub

    Private Sub picBrigitte_Click(sender As Object, e As EventArgs) Handles picBrigitte.Click
        PlayWinnerAudio(22)
    End Sub

    Private Sub picLucio_Click(sender As Object, e As EventArgs) Handles picLucio.Click
        PlayWinnerAudio(23)
    End Sub

    Private Sub picMercy_Click(sender As Object, e As EventArgs) Handles picMercy.Click
        PlayWinnerAudio(24)
    End Sub

    Private Sub picMoira_Click(sender As Object, e As EventArgs) Handles picMoira.Click
        PlayWinnerAudio(25)
    End Sub

    Private Sub picSymmetra_Click(sender As Object, e As EventArgs) Handles picSymmetra.Click
        PlayWinnerAudio(26)
    End Sub

    Private Sub picZenyatta_Click(sender As Object, e As EventArgs) Handles picZenyatta.Click
        PlayWinnerAudio(27)
    End Sub

#End Region

    'debug
    'Dim hero As Integer = 27
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'hero -= 1
        'If hero = 0 Then hero = 27
        'AssignNewHero(hero)
        'PlayWinnerAudio(hero)
    End Sub
End Class
