<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOverwatchHeroSelect
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOverwatchHeroSelect))
        Me.chkHero01 = New System.Windows.Forms.CheckBox()
        Me.chkHero02 = New System.Windows.Forms.CheckBox()
        Me.chkHero04 = New System.Windows.Forms.CheckBox()
        Me.chkHero03 = New System.Windows.Forms.CheckBox()
        Me.chkHero08 = New System.Windows.Forms.CheckBox()
        Me.chkHero07 = New System.Windows.Forms.CheckBox()
        Me.chkHero06 = New System.Windows.Forms.CheckBox()
        Me.chkHero05 = New System.Windows.Forms.CheckBox()
        Me.chkHero14 = New System.Windows.Forms.CheckBox()
        Me.chkHero13 = New System.Windows.Forms.CheckBox()
        Me.chkHero12 = New System.Windows.Forms.CheckBox()
        Me.chkHero11 = New System.Windows.Forms.CheckBox()
        Me.chkHero10 = New System.Windows.Forms.CheckBox()
        Me.chkHero09 = New System.Windows.Forms.CheckBox()
        Me.chkHero20 = New System.Windows.Forms.CheckBox()
        Me.chkHero19 = New System.Windows.Forms.CheckBox()
        Me.chkHero18 = New System.Windows.Forms.CheckBox()
        Me.chkHero17 = New System.Windows.Forms.CheckBox()
        Me.chkHero16 = New System.Windows.Forms.CheckBox()
        Me.chkHero15 = New System.Windows.Forms.CheckBox()
        Me.chkHero27 = New System.Windows.Forms.CheckBox()
        Me.chkHero26 = New System.Windows.Forms.CheckBox()
        Me.chkHero25 = New System.Windows.Forms.CheckBox()
        Me.chkHero24 = New System.Windows.Forms.CheckBox()
        Me.chkHero23 = New System.Windows.Forms.CheckBox()
        Me.chkHero22 = New System.Windows.Forms.CheckBox()
        Me.chkHero21 = New System.Windows.Forms.CheckBox()
        Me.cmdOBSConnect = New System.Windows.Forms.Button()
        Me.txtReticleColor = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSupportHeroes = New System.Windows.Forms.Label()
        Me.lblTankHeroes = New System.Windows.Forms.Label()
        Me.lblDefenseHeroes = New System.Windows.Forms.Label()
        Me.lblOffenseHeroes = New System.Windows.Forms.Label()
        Me.picDoomfist = New System.Windows.Forms.PictureBox()
        Me.picGenji = New System.Windows.Forms.PictureBox()
        Me.picMcCree = New System.Windows.Forms.PictureBox()
        Me.picPharah = New System.Windows.Forms.PictureBox()
        Me.picReaper = New System.Windows.Forms.PictureBox()
        Me.picSoldier76 = New System.Windows.Forms.PictureBox()
        Me.picSombra = New System.Windows.Forms.PictureBox()
        Me.picTracer = New System.Windows.Forms.PictureBox()
        Me.picBastion = New System.Windows.Forms.PictureBox()
        Me.picHanzo = New System.Windows.Forms.PictureBox()
        Me.picJunkrat = New System.Windows.Forms.PictureBox()
        Me.picZenyatta = New System.Windows.Forms.PictureBox()
        Me.picMei = New System.Windows.Forms.PictureBox()
        Me.picSymmetra = New System.Windows.Forms.PictureBox()
        Me.picTorbjorn = New System.Windows.Forms.PictureBox()
        Me.picMoira = New System.Windows.Forms.PictureBox()
        Me.picWidowmaker = New System.Windows.Forms.PictureBox()
        Me.picMercy = New System.Windows.Forms.PictureBox()
        Me.picDva = New System.Windows.Forms.PictureBox()
        Me.picLucio = New System.Windows.Forms.PictureBox()
        Me.picOrisa = New System.Windows.Forms.PictureBox()
        Me.picBrigitte = New System.Windows.Forms.PictureBox()
        Me.picReinhardt = New System.Windows.Forms.PictureBox()
        Me.picAna = New System.Windows.Forms.PictureBox()
        Me.picRoadhog = New System.Windows.Forms.PictureBox()
        Me.picWinston = New System.Windows.Forms.PictureBox()
        Me.picZarya = New System.Windows.Forms.PictureBox()
        Me.lblReticleColor = New System.Windows.Forms.Label()
        Me.tmrReticle = New System.Windows.Forms.Timer(Me.components)
        Me.txtLookFor = New System.Windows.Forms.TextBox()
        Me.lblLookFor = New System.Windows.Forms.Label()
        Me.cmdConnectToTwitch = New System.Windows.Forms.Button()
        Me.txtOBSPass = New System.Windows.Forms.TextBox()
        Me.txtOBSPort = New System.Windows.Forms.TextBox()
        Me.txtOBSHost = New System.Windows.Forms.TextBox()
        Me.lblHPP = New System.Windows.Forms.Label()
        Me.lblUO = New System.Windows.Forms.Label()
        Me.txtTwitchOAuth = New System.Windows.Forms.TextBox()
        Me.txtTwitchUsername = New System.Windows.Forms.TextBox()
        Me.cmdStartStop = New System.Windows.Forms.Button()
        Me.txtTwitchChat = New System.Windows.Forms.RichTextBox()
        Me.lstAlreadyVoted = New System.Windows.Forms.ListBox()
        Me.tmrBar1 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrBar2 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrBar3 = New System.Windows.Forms.Timer(Me.components)
        Me.AlertPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.tmrNewVote = New System.Windows.Forms.Timer(Me.components)
        Me.tmrEndVote = New System.Windows.Forms.Timer(Me.components)
        Me.tmrVote1 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrVote2 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrVote3 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrUpdateVote = New System.Windows.Forms.Timer(Me.components)
        Me.grpOBS = New System.Windows.Forms.GroupBox()
        Me.txtOBSSceneVote3 = New System.Windows.Forms.TextBox()
        Me.txtOBSSceneVote2 = New System.Windows.Forms.TextBox()
        Me.txtOBSSceneVote1 = New System.Windows.Forms.TextBox()
        Me.txtOBSSceneOverwatch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOBSSourceBar3Y = New System.Windows.Forms.TextBox()
        Me.txtOBSSourceBar2Y = New System.Windows.Forms.TextBox()
        Me.txtOBSSourceBar1Y = New System.Windows.Forms.TextBox()
        Me.txtOBSSourceBar3 = New System.Windows.Forms.TextBox()
        Me.txtOBSSourceBar2 = New System.Windows.Forms.TextBox()
        Me.txtOBSSourceBar1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCloseSettings = New System.Windows.Forms.Button()
        Me.lblOBSScenes = New System.Windows.Forms.Label()
        Me.lblOBSInfo = New System.Windows.Forms.Label()
        Me.lblOBSSources = New System.Windows.Forms.Label()
        Me.picOBSLogo = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdOpenSettings = New System.Windows.Forms.Button()
        Me.txtReticleY = New System.Windows.Forms.TextBox()
        Me.txtReticleX = New System.Windows.Forms.TextBox()
        Me.lblReticleX = New System.Windows.Forms.Label()
        Me.lblReticleY = New System.Windows.Forms.Label()
        Me.picReticleColor = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.picDoomfist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGenji, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMcCree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPharah, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picReaper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSoldier76, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSombra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTracer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBastion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHanzo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picJunkrat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picZenyatta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMei, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSymmetra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTorbjorn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMoira, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWidowmaker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMercy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLucio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picOrisa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBrigitte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picReinhardt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAna, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRoadhog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWinston, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picZarya, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AlertPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOBS.SuspendLayout()
        CType(Me.picOBSLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picReticleColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkHero01
        '
        Me.chkHero01.AutoSize = True
        Me.chkHero01.Location = New System.Drawing.Point(23, 79)
        Me.chkHero01.Name = "chkHero01"
        Me.chkHero01.Size = New System.Drawing.Size(15, 14)
        Me.chkHero01.TabIndex = 67
        Me.chkHero01.Tag = "DOOMFIST"
        Me.chkHero01.UseVisualStyleBackColor = True
        '
        'chkHero02
        '
        Me.chkHero02.AutoSize = True
        Me.chkHero02.Location = New System.Drawing.Point(54, 79)
        Me.chkHero02.Name = "chkHero02"
        Me.chkHero02.Size = New System.Drawing.Size(15, 14)
        Me.chkHero02.TabIndex = 68
        Me.chkHero02.Tag = "GENJI"
        Me.chkHero02.UseVisualStyleBackColor = True
        '
        'chkHero04
        '
        Me.chkHero04.AutoSize = True
        Me.chkHero04.Location = New System.Drawing.Point(116, 79)
        Me.chkHero04.Name = "chkHero04"
        Me.chkHero04.Size = New System.Drawing.Size(15, 14)
        Me.chkHero04.TabIndex = 70
        Me.chkHero04.Tag = "PHARAH"
        Me.chkHero04.UseVisualStyleBackColor = True
        '
        'chkHero03
        '
        Me.chkHero03.AutoSize = True
        Me.chkHero03.Location = New System.Drawing.Point(85, 79)
        Me.chkHero03.Name = "chkHero03"
        Me.chkHero03.Size = New System.Drawing.Size(15, 14)
        Me.chkHero03.TabIndex = 69
        Me.chkHero03.Tag = "MCCREE"
        Me.chkHero03.UseVisualStyleBackColor = True
        '
        'chkHero08
        '
        Me.chkHero08.AutoSize = True
        Me.chkHero08.Location = New System.Drawing.Point(240, 79)
        Me.chkHero08.Name = "chkHero08"
        Me.chkHero08.Size = New System.Drawing.Size(15, 14)
        Me.chkHero08.TabIndex = 74
        Me.chkHero08.Tag = "TRACER"
        Me.chkHero08.UseVisualStyleBackColor = True
        '
        'chkHero07
        '
        Me.chkHero07.AutoSize = True
        Me.chkHero07.Location = New System.Drawing.Point(209, 79)
        Me.chkHero07.Name = "chkHero07"
        Me.chkHero07.Size = New System.Drawing.Size(15, 14)
        Me.chkHero07.TabIndex = 73
        Me.chkHero07.Tag = "SOMBRA"
        Me.chkHero07.UseVisualStyleBackColor = True
        '
        'chkHero06
        '
        Me.chkHero06.AutoSize = True
        Me.chkHero06.Location = New System.Drawing.Point(178, 79)
        Me.chkHero06.Name = "chkHero06"
        Me.chkHero06.Size = New System.Drawing.Size(15, 14)
        Me.chkHero06.TabIndex = 72
        Me.chkHero06.Tag = "SOLDIER76"
        Me.chkHero06.UseVisualStyleBackColor = True
        '
        'chkHero05
        '
        Me.chkHero05.AutoSize = True
        Me.chkHero05.Location = New System.Drawing.Point(147, 79)
        Me.chkHero05.Name = "chkHero05"
        Me.chkHero05.Size = New System.Drawing.Size(15, 14)
        Me.chkHero05.TabIndex = 71
        Me.chkHero05.Tag = "REAPER"
        Me.chkHero05.UseVisualStyleBackColor = True
        '
        'chkHero14
        '
        Me.chkHero14.AutoSize = True
        Me.chkHero14.Location = New System.Drawing.Point(178, 151)
        Me.chkHero14.Name = "chkHero14"
        Me.chkHero14.Size = New System.Drawing.Size(15, 14)
        Me.chkHero14.TabIndex = 80
        Me.chkHero14.Tag = "WIDOWMAKER"
        Me.chkHero14.UseVisualStyleBackColor = True
        '
        'chkHero13
        '
        Me.chkHero13.AutoSize = True
        Me.chkHero13.Location = New System.Drawing.Point(147, 151)
        Me.chkHero13.Name = "chkHero13"
        Me.chkHero13.Size = New System.Drawing.Size(15, 14)
        Me.chkHero13.TabIndex = 79
        Me.chkHero13.Tag = "TORBJORN"
        Me.chkHero13.UseVisualStyleBackColor = True
        '
        'chkHero12
        '
        Me.chkHero12.AutoSize = True
        Me.chkHero12.Location = New System.Drawing.Point(116, 151)
        Me.chkHero12.Name = "chkHero12"
        Me.chkHero12.Size = New System.Drawing.Size(15, 14)
        Me.chkHero12.TabIndex = 78
        Me.chkHero12.Tag = "MEI"
        Me.chkHero12.UseVisualStyleBackColor = True
        '
        'chkHero11
        '
        Me.chkHero11.AutoSize = True
        Me.chkHero11.Location = New System.Drawing.Point(85, 151)
        Me.chkHero11.Name = "chkHero11"
        Me.chkHero11.Size = New System.Drawing.Size(15, 14)
        Me.chkHero11.TabIndex = 77
        Me.chkHero11.Tag = "JUNKRAT"
        Me.chkHero11.UseVisualStyleBackColor = True
        '
        'chkHero10
        '
        Me.chkHero10.AutoSize = True
        Me.chkHero10.Location = New System.Drawing.Point(54, 151)
        Me.chkHero10.Name = "chkHero10"
        Me.chkHero10.Size = New System.Drawing.Size(15, 14)
        Me.chkHero10.TabIndex = 76
        Me.chkHero10.Tag = "HANZO"
        Me.chkHero10.UseVisualStyleBackColor = True
        '
        'chkHero09
        '
        Me.chkHero09.AutoSize = True
        Me.chkHero09.Enabled = False
        Me.chkHero09.Location = New System.Drawing.Point(23, 151)
        Me.chkHero09.Name = "chkHero09"
        Me.chkHero09.Size = New System.Drawing.Size(15, 14)
        Me.chkHero09.TabIndex = 75
        Me.chkHero09.Tag = "BASTION"
        Me.chkHero09.UseVisualStyleBackColor = True
        '
        'chkHero20
        '
        Me.chkHero20.AutoSize = True
        Me.chkHero20.Location = New System.Drawing.Point(178, 223)
        Me.chkHero20.Name = "chkHero20"
        Me.chkHero20.Size = New System.Drawing.Size(15, 14)
        Me.chkHero20.TabIndex = 86
        Me.chkHero20.Tag = "ZARYA"
        Me.chkHero20.UseVisualStyleBackColor = True
        '
        'chkHero19
        '
        Me.chkHero19.AutoSize = True
        Me.chkHero19.Location = New System.Drawing.Point(147, 223)
        Me.chkHero19.Name = "chkHero19"
        Me.chkHero19.Size = New System.Drawing.Size(15, 14)
        Me.chkHero19.TabIndex = 85
        Me.chkHero19.Tag = "WINSTON"
        Me.chkHero19.UseVisualStyleBackColor = True
        '
        'chkHero18
        '
        Me.chkHero18.AutoSize = True
        Me.chkHero18.Location = New System.Drawing.Point(116, 223)
        Me.chkHero18.Name = "chkHero18"
        Me.chkHero18.Size = New System.Drawing.Size(15, 14)
        Me.chkHero18.TabIndex = 84
        Me.chkHero18.Tag = "ROADHOG"
        Me.chkHero18.UseVisualStyleBackColor = True
        '
        'chkHero17
        '
        Me.chkHero17.AutoSize = True
        Me.chkHero17.Location = New System.Drawing.Point(85, 223)
        Me.chkHero17.Name = "chkHero17"
        Me.chkHero17.Size = New System.Drawing.Size(15, 14)
        Me.chkHero17.TabIndex = 83
        Me.chkHero17.Tag = "REINHARDT"
        Me.chkHero17.UseVisualStyleBackColor = True
        '
        'chkHero16
        '
        Me.chkHero16.AutoSize = True
        Me.chkHero16.Location = New System.Drawing.Point(54, 223)
        Me.chkHero16.Name = "chkHero16"
        Me.chkHero16.Size = New System.Drawing.Size(15, 14)
        Me.chkHero16.TabIndex = 82
        Me.chkHero16.Tag = "ORISA"
        Me.chkHero16.UseVisualStyleBackColor = True
        '
        'chkHero15
        '
        Me.chkHero15.AutoSize = True
        Me.chkHero15.Location = New System.Drawing.Point(23, 223)
        Me.chkHero15.Name = "chkHero15"
        Me.chkHero15.Size = New System.Drawing.Size(15, 14)
        Me.chkHero15.TabIndex = 81
        Me.chkHero15.Tag = "DVA"
        Me.chkHero15.UseVisualStyleBackColor = True
        '
        'chkHero27
        '
        Me.chkHero27.AutoSize = True
        Me.chkHero27.Location = New System.Drawing.Point(209, 295)
        Me.chkHero27.Name = "chkHero27"
        Me.chkHero27.Size = New System.Drawing.Size(15, 14)
        Me.chkHero27.TabIndex = 100
        Me.chkHero27.Tag = "ZENYATTA"
        Me.chkHero27.UseVisualStyleBackColor = True
        '
        'chkHero26
        '
        Me.chkHero26.AutoSize = True
        Me.chkHero26.Location = New System.Drawing.Point(178, 295)
        Me.chkHero26.Name = "chkHero26"
        Me.chkHero26.Size = New System.Drawing.Size(15, 14)
        Me.chkHero26.TabIndex = 99
        Me.chkHero26.Tag = "SYMMETRA"
        Me.chkHero26.UseVisualStyleBackColor = True
        '
        'chkHero25
        '
        Me.chkHero25.AutoSize = True
        Me.chkHero25.Location = New System.Drawing.Point(147, 295)
        Me.chkHero25.Name = "chkHero25"
        Me.chkHero25.Size = New System.Drawing.Size(15, 14)
        Me.chkHero25.TabIndex = 98
        Me.chkHero25.Tag = "MOIRA"
        Me.chkHero25.UseVisualStyleBackColor = True
        '
        'chkHero24
        '
        Me.chkHero24.AutoSize = True
        Me.chkHero24.Location = New System.Drawing.Point(116, 295)
        Me.chkHero24.Name = "chkHero24"
        Me.chkHero24.Size = New System.Drawing.Size(15, 14)
        Me.chkHero24.TabIndex = 97
        Me.chkHero24.Tag = "MERCY"
        Me.chkHero24.UseVisualStyleBackColor = True
        '
        'chkHero23
        '
        Me.chkHero23.AutoSize = True
        Me.chkHero23.Location = New System.Drawing.Point(85, 295)
        Me.chkHero23.Name = "chkHero23"
        Me.chkHero23.Size = New System.Drawing.Size(15, 14)
        Me.chkHero23.TabIndex = 96
        Me.chkHero23.Tag = "LUCIO"
        Me.chkHero23.UseVisualStyleBackColor = True
        '
        'chkHero22
        '
        Me.chkHero22.AutoSize = True
        Me.chkHero22.Location = New System.Drawing.Point(54, 295)
        Me.chkHero22.Name = "chkHero22"
        Me.chkHero22.Size = New System.Drawing.Size(15, 14)
        Me.chkHero22.TabIndex = 95
        Me.chkHero22.Tag = "BRIGITTE"
        Me.chkHero22.UseVisualStyleBackColor = True
        '
        'chkHero21
        '
        Me.chkHero21.AutoSize = True
        Me.chkHero21.Location = New System.Drawing.Point(23, 295)
        Me.chkHero21.Name = "chkHero21"
        Me.chkHero21.Size = New System.Drawing.Size(15, 14)
        Me.chkHero21.TabIndex = 94
        Me.chkHero21.Tag = "ANA"
        Me.chkHero21.UseVisualStyleBackColor = True
        '
        'cmdOBSConnect
        '
        Me.cmdOBSConnect.Font = New System.Drawing.Font("BigNoodleTitling", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOBSConnect.Location = New System.Drawing.Point(23, 21)
        Me.cmdOBSConnect.Name = "cmdOBSConnect"
        Me.cmdOBSConnect.Size = New System.Drawing.Size(245, 55)
        Me.cmdOBSConnect.TabIndex = 101
        Me.cmdOBSConnect.Text = "> Connect to OBS <"
        Me.cmdOBSConnect.UseVisualStyleBackColor = True
        '
        'txtReticleColor
        '
        Me.txtReticleColor.Location = New System.Drawing.Point(49, 298)
        Me.txtReticleColor.Name = "txtReticleColor"
        Me.txtReticleColor.Size = New System.Drawing.Size(85, 20)
        Me.txtReticleColor.TabIndex = 102
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSupportHeroes)
        Me.GroupBox1.Controls.Add(Me.lblTankHeroes)
        Me.GroupBox1.Controls.Add(Me.lblDefenseHeroes)
        Me.GroupBox1.Controls.Add(Me.lblOffenseHeroes)
        Me.GroupBox1.Controls.Add(Me.picDoomfist)
        Me.GroupBox1.Controls.Add(Me.picGenji)
        Me.GroupBox1.Controls.Add(Me.picMcCree)
        Me.GroupBox1.Controls.Add(Me.picPharah)
        Me.GroupBox1.Controls.Add(Me.chkHero27)
        Me.GroupBox1.Controls.Add(Me.picReaper)
        Me.GroupBox1.Controls.Add(Me.chkHero26)
        Me.GroupBox1.Controls.Add(Me.picSoldier76)
        Me.GroupBox1.Controls.Add(Me.chkHero25)
        Me.GroupBox1.Controls.Add(Me.picSombra)
        Me.GroupBox1.Controls.Add(Me.chkHero24)
        Me.GroupBox1.Controls.Add(Me.picTracer)
        Me.GroupBox1.Controls.Add(Me.chkHero23)
        Me.GroupBox1.Controls.Add(Me.picBastion)
        Me.GroupBox1.Controls.Add(Me.chkHero22)
        Me.GroupBox1.Controls.Add(Me.picHanzo)
        Me.GroupBox1.Controls.Add(Me.chkHero21)
        Me.GroupBox1.Controls.Add(Me.picJunkrat)
        Me.GroupBox1.Controls.Add(Me.picZenyatta)
        Me.GroupBox1.Controls.Add(Me.picMei)
        Me.GroupBox1.Controls.Add(Me.picSymmetra)
        Me.GroupBox1.Controls.Add(Me.picTorbjorn)
        Me.GroupBox1.Controls.Add(Me.picMoira)
        Me.GroupBox1.Controls.Add(Me.picWidowmaker)
        Me.GroupBox1.Controls.Add(Me.picMercy)
        Me.GroupBox1.Controls.Add(Me.picDva)
        Me.GroupBox1.Controls.Add(Me.picLucio)
        Me.GroupBox1.Controls.Add(Me.picOrisa)
        Me.GroupBox1.Controls.Add(Me.picBrigitte)
        Me.GroupBox1.Controls.Add(Me.picReinhardt)
        Me.GroupBox1.Controls.Add(Me.picAna)
        Me.GroupBox1.Controls.Add(Me.picRoadhog)
        Me.GroupBox1.Controls.Add(Me.chkHero20)
        Me.GroupBox1.Controls.Add(Me.picWinston)
        Me.GroupBox1.Controls.Add(Me.chkHero19)
        Me.GroupBox1.Controls.Add(Me.picZarya)
        Me.GroupBox1.Controls.Add(Me.chkHero18)
        Me.GroupBox1.Controls.Add(Me.chkHero01)
        Me.GroupBox1.Controls.Add(Me.chkHero17)
        Me.GroupBox1.Controls.Add(Me.chkHero02)
        Me.GroupBox1.Controls.Add(Me.chkHero16)
        Me.GroupBox1.Controls.Add(Me.chkHero03)
        Me.GroupBox1.Controls.Add(Me.chkHero15)
        Me.GroupBox1.Controls.Add(Me.chkHero04)
        Me.GroupBox1.Controls.Add(Me.chkHero14)
        Me.GroupBox1.Controls.Add(Me.chkHero05)
        Me.GroupBox1.Controls.Add(Me.chkHero13)
        Me.GroupBox1.Controls.Add(Me.chkHero06)
        Me.GroupBox1.Controls.Add(Me.chkHero12)
        Me.GroupBox1.Controls.Add(Me.chkHero07)
        Me.GroupBox1.Controls.Add(Me.chkHero11)
        Me.GroupBox1.Controls.Add(Me.chkHero08)
        Me.GroupBox1.Controls.Add(Me.chkHero10)
        Me.GroupBox1.Controls.Add(Me.chkHero09)
        Me.GroupBox1.Font = New System.Drawing.Font("BigNoodleTitling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(294, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 325)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Available Heroes"
        '
        'lblSupportHeroes
        '
        Me.lblSupportHeroes.AutoSize = True
        Me.lblSupportHeroes.Location = New System.Drawing.Point(19, 240)
        Me.lblSupportHeroes.Name = "lblSupportHeroes"
        Me.lblSupportHeroes.Size = New System.Drawing.Size(65, 21)
        Me.lblSupportHeroes.TabIndex = 104
        Me.lblSupportHeroes.Text = "Support-"
        '
        'lblTankHeroes
        '
        Me.lblTankHeroes.AutoSize = True
        Me.lblTankHeroes.Location = New System.Drawing.Point(19, 168)
        Me.lblTankHeroes.Name = "lblTankHeroes"
        Me.lblTankHeroes.Size = New System.Drawing.Size(42, 21)
        Me.lblTankHeroes.TabIndex = 103
        Me.lblTankHeroes.Text = "Tank-"
        '
        'lblDefenseHeroes
        '
        Me.lblDefenseHeroes.AutoSize = True
        Me.lblDefenseHeroes.Location = New System.Drawing.Point(19, 96)
        Me.lblDefenseHeroes.Name = "lblDefenseHeroes"
        Me.lblDefenseHeroes.Size = New System.Drawing.Size(60, 21)
        Me.lblDefenseHeroes.TabIndex = 102
        Me.lblDefenseHeroes.Text = "Defense-"
        '
        'lblOffenseHeroes
        '
        Me.lblOffenseHeroes.AutoSize = True
        Me.lblOffenseHeroes.Location = New System.Drawing.Point(19, 24)
        Me.lblOffenseHeroes.Name = "lblOffenseHeroes"
        Me.lblOffenseHeroes.Size = New System.Drawing.Size(61, 21)
        Me.lblOffenseHeroes.TabIndex = 101
        Me.lblOffenseHeroes.Text = "Offense-"
        '
        'picDoomfist
        '
        Me.picDoomfist.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_doomfist
        Me.picDoomfist.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picDoomfist.Location = New System.Drawing.Point(17, 48)
        Me.picDoomfist.Name = "picDoomfist"
        Me.picDoomfist.Size = New System.Drawing.Size(28, 25)
        Me.picDoomfist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDoomfist.TabIndex = 43
        Me.picDoomfist.TabStop = False
        '
        'picGenji
        '
        Me.picGenji.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_genji
        Me.picGenji.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picGenji.Location = New System.Drawing.Point(48, 48)
        Me.picGenji.Name = "picGenji"
        Me.picGenji.Size = New System.Drawing.Size(28, 25)
        Me.picGenji.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picGenji.TabIndex = 44
        Me.picGenji.TabStop = False
        '
        'picMcCree
        '
        Me.picMcCree.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_mccree
        Me.picMcCree.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picMcCree.Location = New System.Drawing.Point(79, 48)
        Me.picMcCree.Name = "picMcCree"
        Me.picMcCree.Size = New System.Drawing.Size(28, 25)
        Me.picMcCree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMcCree.TabIndex = 45
        Me.picMcCree.TabStop = False
        '
        'picPharah
        '
        Me.picPharah.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_pharah
        Me.picPharah.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picPharah.Location = New System.Drawing.Point(110, 48)
        Me.picPharah.Name = "picPharah"
        Me.picPharah.Size = New System.Drawing.Size(28, 25)
        Me.picPharah.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPharah.TabIndex = 46
        Me.picPharah.TabStop = False
        '
        'picReaper
        '
        Me.picReaper.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_reaper
        Me.picReaper.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picReaper.Location = New System.Drawing.Point(141, 48)
        Me.picReaper.Name = "picReaper"
        Me.picReaper.Size = New System.Drawing.Size(28, 25)
        Me.picReaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picReaper.TabIndex = 47
        Me.picReaper.TabStop = False
        '
        'picSoldier76
        '
        Me.picSoldier76.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_Soldier76
        Me.picSoldier76.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picSoldier76.Location = New System.Drawing.Point(172, 48)
        Me.picSoldier76.Name = "picSoldier76"
        Me.picSoldier76.Size = New System.Drawing.Size(28, 25)
        Me.picSoldier76.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSoldier76.TabIndex = 48
        Me.picSoldier76.TabStop = False
        '
        'picSombra
        '
        Me.picSombra.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_sombra
        Me.picSombra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picSombra.Location = New System.Drawing.Point(203, 48)
        Me.picSombra.Name = "picSombra"
        Me.picSombra.Size = New System.Drawing.Size(28, 25)
        Me.picSombra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSombra.TabIndex = 49
        Me.picSombra.TabStop = False
        '
        'picTracer
        '
        Me.picTracer.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_tracer
        Me.picTracer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picTracer.Location = New System.Drawing.Point(234, 48)
        Me.picTracer.Name = "picTracer"
        Me.picTracer.Size = New System.Drawing.Size(28, 25)
        Me.picTracer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTracer.TabIndex = 50
        Me.picTracer.TabStop = False
        '
        'picBastion
        '
        Me.picBastion.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_bastion
        Me.picBastion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picBastion.Location = New System.Drawing.Point(17, 120)
        Me.picBastion.Name = "picBastion"
        Me.picBastion.Size = New System.Drawing.Size(28, 25)
        Me.picBastion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBastion.TabIndex = 51
        Me.picBastion.TabStop = False
        '
        'picHanzo
        '
        Me.picHanzo.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_hanzo
        Me.picHanzo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picHanzo.Location = New System.Drawing.Point(48, 120)
        Me.picHanzo.Name = "picHanzo"
        Me.picHanzo.Size = New System.Drawing.Size(28, 25)
        Me.picHanzo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picHanzo.TabIndex = 52
        Me.picHanzo.TabStop = False
        '
        'picJunkrat
        '
        Me.picJunkrat.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_Junkrat
        Me.picJunkrat.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picJunkrat.Location = New System.Drawing.Point(79, 120)
        Me.picJunkrat.Name = "picJunkrat"
        Me.picJunkrat.Size = New System.Drawing.Size(28, 25)
        Me.picJunkrat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picJunkrat.TabIndex = 53
        Me.picJunkrat.TabStop = False
        '
        'picZenyatta
        '
        Me.picZenyatta.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_zenyatta
        Me.picZenyatta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picZenyatta.Location = New System.Drawing.Point(203, 264)
        Me.picZenyatta.Name = "picZenyatta"
        Me.picZenyatta.Size = New System.Drawing.Size(28, 25)
        Me.picZenyatta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picZenyatta.TabIndex = 93
        Me.picZenyatta.TabStop = False
        '
        'picMei
        '
        Me.picMei.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_mei
        Me.picMei.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picMei.Location = New System.Drawing.Point(110, 120)
        Me.picMei.Name = "picMei"
        Me.picMei.Size = New System.Drawing.Size(28, 25)
        Me.picMei.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMei.TabIndex = 54
        Me.picMei.TabStop = False
        '
        'picSymmetra
        '
        Me.picSymmetra.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_symmetra
        Me.picSymmetra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picSymmetra.Location = New System.Drawing.Point(172, 264)
        Me.picSymmetra.Name = "picSymmetra"
        Me.picSymmetra.Size = New System.Drawing.Size(28, 25)
        Me.picSymmetra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSymmetra.TabIndex = 92
        Me.picSymmetra.TabStop = False
        '
        'picTorbjorn
        '
        Me.picTorbjorn.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_torbjorn
        Me.picTorbjorn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picTorbjorn.Location = New System.Drawing.Point(141, 120)
        Me.picTorbjorn.Name = "picTorbjorn"
        Me.picTorbjorn.Size = New System.Drawing.Size(28, 25)
        Me.picTorbjorn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTorbjorn.TabIndex = 55
        Me.picTorbjorn.TabStop = False
        '
        'picMoira
        '
        Me.picMoira.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_moira
        Me.picMoira.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picMoira.Location = New System.Drawing.Point(141, 264)
        Me.picMoira.Name = "picMoira"
        Me.picMoira.Size = New System.Drawing.Size(28, 25)
        Me.picMoira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMoira.TabIndex = 91
        Me.picMoira.TabStop = False
        '
        'picWidowmaker
        '
        Me.picWidowmaker.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_widowmaker
        Me.picWidowmaker.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picWidowmaker.Location = New System.Drawing.Point(172, 120)
        Me.picWidowmaker.Name = "picWidowmaker"
        Me.picWidowmaker.Size = New System.Drawing.Size(28, 25)
        Me.picWidowmaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picWidowmaker.TabIndex = 56
        Me.picWidowmaker.TabStop = False
        '
        'picMercy
        '
        Me.picMercy.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_mercy
        Me.picMercy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picMercy.Location = New System.Drawing.Point(110, 264)
        Me.picMercy.Name = "picMercy"
        Me.picMercy.Size = New System.Drawing.Size(28, 25)
        Me.picMercy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMercy.TabIndex = 90
        Me.picMercy.TabStop = False
        '
        'picDva
        '
        Me.picDva.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_dva
        Me.picDva.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picDva.Location = New System.Drawing.Point(17, 192)
        Me.picDva.Name = "picDva"
        Me.picDva.Size = New System.Drawing.Size(28, 25)
        Me.picDva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDva.TabIndex = 59
        Me.picDva.TabStop = False
        '
        'picLucio
        '
        Me.picLucio.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_Lucio
        Me.picLucio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picLucio.Location = New System.Drawing.Point(79, 264)
        Me.picLucio.Name = "picLucio"
        Me.picLucio.Size = New System.Drawing.Size(28, 25)
        Me.picLucio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLucio.TabIndex = 89
        Me.picLucio.TabStop = False
        '
        'picOrisa
        '
        Me.picOrisa.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_orisa
        Me.picOrisa.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picOrisa.Location = New System.Drawing.Point(48, 192)
        Me.picOrisa.Name = "picOrisa"
        Me.picOrisa.Size = New System.Drawing.Size(28, 25)
        Me.picOrisa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picOrisa.TabIndex = 60
        Me.picOrisa.TabStop = False
        '
        'picBrigitte
        '
        Me.picBrigitte.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_brigitte
        Me.picBrigitte.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picBrigitte.Location = New System.Drawing.Point(48, 264)
        Me.picBrigitte.Name = "picBrigitte"
        Me.picBrigitte.Size = New System.Drawing.Size(28, 25)
        Me.picBrigitte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBrigitte.TabIndex = 88
        Me.picBrigitte.TabStop = False
        '
        'picReinhardt
        '
        Me.picReinhardt.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_reinhardt
        Me.picReinhardt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picReinhardt.Location = New System.Drawing.Point(79, 192)
        Me.picReinhardt.Name = "picReinhardt"
        Me.picReinhardt.Size = New System.Drawing.Size(28, 25)
        Me.picReinhardt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picReinhardt.TabIndex = 61
        Me.picReinhardt.TabStop = False
        '
        'picAna
        '
        Me.picAna.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_ana
        Me.picAna.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picAna.Location = New System.Drawing.Point(17, 264)
        Me.picAna.Name = "picAna"
        Me.picAna.Size = New System.Drawing.Size(28, 25)
        Me.picAna.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAna.TabIndex = 87
        Me.picAna.TabStop = False
        '
        'picRoadhog
        '
        Me.picRoadhog.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_Roadhog
        Me.picRoadhog.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picRoadhog.Location = New System.Drawing.Point(110, 192)
        Me.picRoadhog.Name = "picRoadhog"
        Me.picRoadhog.Size = New System.Drawing.Size(28, 25)
        Me.picRoadhog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRoadhog.TabIndex = 62
        Me.picRoadhog.TabStop = False
        '
        'picWinston
        '
        Me.picWinston.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_winston
        Me.picWinston.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picWinston.Location = New System.Drawing.Point(141, 192)
        Me.picWinston.Name = "picWinston"
        Me.picWinston.Size = New System.Drawing.Size(28, 25)
        Me.picWinston.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picWinston.TabIndex = 63
        Me.picWinston.TabStop = False
        '
        'picZarya
        '
        Me.picZarya.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.Icon_zarya
        Me.picZarya.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picZarya.Location = New System.Drawing.Point(172, 192)
        Me.picZarya.Name = "picZarya"
        Me.picZarya.Size = New System.Drawing.Size(28, 25)
        Me.picZarya.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picZarya.TabIndex = 64
        Me.picZarya.TabStop = False
        '
        'lblReticleColor
        '
        Me.lblReticleColor.AutoSize = True
        Me.lblReticleColor.Font = New System.Drawing.Font("BigNoodleTitling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReticleColor.Location = New System.Drawing.Point(19, 277)
        Me.lblReticleColor.Name = "lblReticleColor"
        Me.lblReticleColor.Size = New System.Drawing.Size(56, 21)
        Me.lblReticleColor.TabIndex = 105
        Me.lblReticleColor.Text = "Reticle-"
        '
        'tmrReticle
        '
        Me.tmrReticle.Interval = 200
        '
        'txtLookFor
        '
        Me.txtLookFor.Location = New System.Drawing.Point(160, 298)
        Me.txtLookFor.Name = "txtLookFor"
        Me.txtLookFor.Size = New System.Drawing.Size(85, 20)
        Me.txtLookFor.TabIndex = 106
        '
        'lblLookFor
        '
        Me.lblLookFor.AutoSize = True
        Me.lblLookFor.Font = New System.Drawing.Font("BigNoodleTitling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLookFor.Location = New System.Drawing.Point(156, 277)
        Me.lblLookFor.Name = "lblLookFor"
        Me.lblLookFor.Size = New System.Drawing.Size(67, 21)
        Me.lblLookFor.TabIndex = 107
        Me.lblLookFor.Text = "Look For-"
        '
        'cmdConnectToTwitch
        '
        Me.cmdConnectToTwitch.Font = New System.Drawing.Font("BigNoodleTitling", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConnectToTwitch.Location = New System.Drawing.Point(23, 119)
        Me.cmdConnectToTwitch.Name = "cmdConnectToTwitch"
        Me.cmdConnectToTwitch.Size = New System.Drawing.Size(245, 55)
        Me.cmdConnectToTwitch.TabIndex = 108
        Me.cmdConnectToTwitch.Text = "> Connect to Twitch <"
        Me.cmdConnectToTwitch.UseVisualStyleBackColor = True
        '
        'txtOBSPass
        '
        Me.txtOBSPass.Location = New System.Drawing.Point(149, 95)
        Me.txtOBSPass.Name = "txtOBSPass"
        Me.txtOBSPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOBSPass.Size = New System.Drawing.Size(52, 20)
        Me.txtOBSPass.TabIndex = 444
        '
        'txtOBSPort
        '
        Me.txtOBSPort.Location = New System.Drawing.Point(91, 95)
        Me.txtOBSPort.Name = "txtOBSPort"
        Me.txtOBSPort.Size = New System.Drawing.Size(52, 20)
        Me.txtOBSPort.TabIndex = 442
        '
        'txtOBSHost
        '
        Me.txtOBSHost.Location = New System.Drawing.Point(32, 95)
        Me.txtOBSHost.Name = "txtOBSHost"
        Me.txtOBSHost.Size = New System.Drawing.Size(52, 20)
        Me.txtOBSHost.TabIndex = 441
        '
        'lblHPP
        '
        Me.lblHPP.AutoSize = True
        Me.lblHPP.Font = New System.Drawing.Font("BigNoodleTitling", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHPP.Location = New System.Drawing.Point(46, 77)
        Me.lblHPP.Name = "lblHPP"
        Me.lblHPP.Size = New System.Drawing.Size(143, 15)
        Me.lblHPP.TabIndex = 443
        Me.lblHPP.Text = "Host                    Port                   Pass"
        Me.lblHPP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUO
        '
        Me.lblUO.AutoSize = True
        Me.lblUO.Font = New System.Drawing.Font("BigNoodleTitling", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUO.Location = New System.Drawing.Point(78, 175)
        Me.lblUO.Name = "lblUO"
        Me.lblUO.Size = New System.Drawing.Size(138, 15)
        Me.lblUO.TabIndex = 447
        Me.lblUO.Text = "User                                            OAuth"
        Me.lblUO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTwitchOAuth
        '
        Me.txtTwitchOAuth.Location = New System.Drawing.Point(149, 193)
        Me.txtTwitchOAuth.Name = "txtTwitchOAuth"
        Me.txtTwitchOAuth.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtTwitchOAuth.Size = New System.Drawing.Size(100, 20)
        Me.txtTwitchOAuth.TabIndex = 449
        '
        'txtTwitchUsername
        '
        Me.txtTwitchUsername.Location = New System.Drawing.Point(42, 193)
        Me.txtTwitchUsername.Name = "txtTwitchUsername"
        Me.txtTwitchUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtTwitchUsername.TabIndex = 448
        '
        'cmdStartStop
        '
        Me.cmdStartStop.Enabled = False
        Me.cmdStartStop.Font = New System.Drawing.Font("BigNoodleTitling", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStartStop.Location = New System.Drawing.Point(23, 219)
        Me.cmdStartStop.Name = "cmdStartStop"
        Me.cmdStartStop.Size = New System.Drawing.Size(245, 55)
        Me.cmdStartStop.TabIndex = 450
        Me.cmdStartStop.Text = "> Start <"
        Me.cmdStartStop.UseVisualStyleBackColor = True
        '
        'txtTwitchChat
        '
        Me.txtTwitchChat.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwitchChat.Location = New System.Drawing.Point(907, 36)
        Me.txtTwitchChat.Name = "txtTwitchChat"
        Me.txtTwitchChat.Size = New System.Drawing.Size(245, 52)
        Me.txtTwitchChat.TabIndex = 451
        Me.txtTwitchChat.Text = "Twitch Chat"
        '
        'lstAlreadyVoted
        '
        Me.lstAlreadyVoted.FormattingEnabled = True
        Me.lstAlreadyVoted.Location = New System.Drawing.Point(907, 94)
        Me.lstAlreadyVoted.Name = "lstAlreadyVoted"
        Me.lstAlreadyVoted.Size = New System.Drawing.Size(245, 43)
        Me.lstAlreadyVoted.TabIndex = 488
        '
        'tmrBar1
        '
        Me.tmrBar1.Interval = 15
        '
        'tmrBar2
        '
        Me.tmrBar2.Interval = 15
        '
        'tmrBar3
        '
        Me.tmrBar3.Interval = 15
        '
        'AlertPlayer
        '
        Me.AlertPlayer.Enabled = True
        Me.AlertPlayer.Location = New System.Drawing.Point(907, 143)
        Me.AlertPlayer.Name = "AlertPlayer"
        Me.AlertPlayer.OcxState = CType(resources.GetObject("AlertPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AlertPlayer.Size = New System.Drawing.Size(245, 48)
        Me.AlertPlayer.TabIndex = 492
        '
        'tmrNewVote
        '
        Me.tmrNewVote.Interval = 500
        '
        'tmrEndVote
        '
        Me.tmrEndVote.Interval = 30000
        '
        'tmrVote1
        '
        Me.tmrVote1.Interval = 15
        '
        'tmrVote2
        '
        Me.tmrVote2.Interval = 15
        '
        'tmrVote3
        '
        Me.tmrVote3.Interval = 15
        '
        'tmrUpdateVote
        '
        Me.tmrUpdateVote.Interval = 2000
        '
        'grpOBS
        '
        Me.grpOBS.Controls.Add(Me.txtOBSSceneVote3)
        Me.grpOBS.Controls.Add(Me.txtOBSSceneVote2)
        Me.grpOBS.Controls.Add(Me.txtOBSSceneVote1)
        Me.grpOBS.Controls.Add(Me.txtOBSSceneOverwatch)
        Me.grpOBS.Controls.Add(Me.Label2)
        Me.grpOBS.Controls.Add(Me.txtOBSSourceBar3Y)
        Me.grpOBS.Controls.Add(Me.txtOBSSourceBar2Y)
        Me.grpOBS.Controls.Add(Me.txtOBSSourceBar1Y)
        Me.grpOBS.Controls.Add(Me.txtOBSSourceBar3)
        Me.grpOBS.Controls.Add(Me.txtOBSSourceBar2)
        Me.grpOBS.Controls.Add(Me.txtOBSSourceBar1)
        Me.grpOBS.Controls.Add(Me.Label1)
        Me.grpOBS.Controls.Add(Me.cmdCloseSettings)
        Me.grpOBS.Controls.Add(Me.lblOBSScenes)
        Me.grpOBS.Controls.Add(Me.lblOBSInfo)
        Me.grpOBS.Controls.Add(Me.lblOBSSources)
        Me.grpOBS.Controls.Add(Me.picOBSLogo)
        Me.grpOBS.Controls.Add(Me.Label3)
        Me.grpOBS.Font = New System.Drawing.Font("BigNoodleTitling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpOBS.Location = New System.Drawing.Point(595, 12)
        Me.grpOBS.Name = "grpOBS"
        Me.grpOBS.Size = New System.Drawing.Size(282, 325)
        Me.grpOBS.TabIndex = 105
        Me.grpOBS.TabStop = False
        Me.grpOBS.Text = "OBS Assets"
        '
        'txtOBSSceneVote3
        '
        Me.txtOBSSceneVote3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSceneVote3.Location = New System.Drawing.Point(151, 183)
        Me.txtOBSSceneVote3.Name = "txtOBSSceneVote3"
        Me.txtOBSSceneVote3.Size = New System.Drawing.Size(79, 20)
        Me.txtOBSSceneVote3.TabIndex = 456
        '
        'txtOBSSceneVote2
        '
        Me.txtOBSSceneVote2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSceneVote2.Location = New System.Drawing.Point(63, 183)
        Me.txtOBSSceneVote2.Name = "txtOBSSceneVote2"
        Me.txtOBSSceneVote2.Size = New System.Drawing.Size(79, 20)
        Me.txtOBSSceneVote2.TabIndex = 455
        '
        'txtOBSSceneVote1
        '
        Me.txtOBSSceneVote1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSceneVote1.Location = New System.Drawing.Point(151, 141)
        Me.txtOBSSceneVote1.Name = "txtOBSSceneVote1"
        Me.txtOBSSceneVote1.Size = New System.Drawing.Size(79, 20)
        Me.txtOBSSceneVote1.TabIndex = 454
        '
        'txtOBSSceneOverwatch
        '
        Me.txtOBSSceneOverwatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSceneOverwatch.Location = New System.Drawing.Point(63, 141)
        Me.txtOBSSceneOverwatch.Name = "txtOBSSceneOverwatch"
        Me.txtOBSSceneOverwatch.Size = New System.Drawing.Size(79, 20)
        Me.txtOBSSceneOverwatch.TabIndex = 453
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("BigNoodleTitling", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(66, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 15)
        Me.Label2.TabIndex = 457
        Me.Label2.Text = "Overwatch Main                      Vote1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOBSSourceBar3Y
        '
        Me.txtOBSSourceBar3Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSourceBar3Y.Location = New System.Drawing.Point(184, 269)
        Me.txtOBSSourceBar3Y.Name = "txtOBSSourceBar3Y"
        Me.txtOBSSourceBar3Y.Size = New System.Drawing.Size(65, 20)
        Me.txtOBSSourceBar3Y.TabIndex = 452
        '
        'txtOBSSourceBar2Y
        '
        Me.txtOBSSourceBar2Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSourceBar2Y.Location = New System.Drawing.Point(113, 269)
        Me.txtOBSSourceBar2Y.Name = "txtOBSSourceBar2Y"
        Me.txtOBSSourceBar2Y.Size = New System.Drawing.Size(65, 20)
        Me.txtOBSSourceBar2Y.TabIndex = 451
        '
        'txtOBSSourceBar1Y
        '
        Me.txtOBSSourceBar1Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSourceBar1Y.Location = New System.Drawing.Point(42, 269)
        Me.txtOBSSourceBar1Y.Name = "txtOBSSourceBar1Y"
        Me.txtOBSSourceBar1Y.Size = New System.Drawing.Size(65, 20)
        Me.txtOBSSourceBar1Y.TabIndex = 450
        '
        'txtOBSSourceBar3
        '
        Me.txtOBSSourceBar3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSourceBar3.Location = New System.Drawing.Point(184, 245)
        Me.txtOBSSourceBar3.Name = "txtOBSSourceBar3"
        Me.txtOBSSourceBar3.Size = New System.Drawing.Size(65, 20)
        Me.txtOBSSourceBar3.TabIndex = 449
        '
        'txtOBSSourceBar2
        '
        Me.txtOBSSourceBar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSourceBar2.Location = New System.Drawing.Point(113, 245)
        Me.txtOBSSourceBar2.Name = "txtOBSSourceBar2"
        Me.txtOBSSourceBar2.Size = New System.Drawing.Size(65, 20)
        Me.txtOBSSourceBar2.TabIndex = 447
        '
        'txtOBSSourceBar1
        '
        Me.txtOBSSourceBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtOBSSourceBar1.Location = New System.Drawing.Point(42, 245)
        Me.txtOBSSourceBar1.Name = "txtOBSSourceBar1"
        Me.txtOBSSourceBar1.Size = New System.Drawing.Size(65, 20)
        Me.txtOBSSourceBar1.TabIndex = 446
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("BigNoodleTitling", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 227)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 15)
        Me.Label1.TabIndex = 448
        Me.Label1.Text = "Bar1                          Bar2                         Bar3"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCloseSettings
        '
        Me.cmdCloseSettings.Font = New System.Drawing.Font("BigNoodleTitling", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCloseSettings.Location = New System.Drawing.Point(198, 295)
        Me.cmdCloseSettings.Name = "cmdCloseSettings"
        Me.cmdCloseSettings.Size = New System.Drawing.Size(85, 30)
        Me.cmdCloseSettings.TabIndex = 445
        Me.cmdCloseSettings.Text = "> Done <"
        Me.cmdCloseSettings.UseVisualStyleBackColor = True
        '
        'lblOBSScenes
        '
        Me.lblOBSScenes.AutoSize = True
        Me.lblOBSScenes.Location = New System.Drawing.Point(19, 105)
        Me.lblOBSScenes.Name = "lblOBSScenes"
        Me.lblOBSScenes.Size = New System.Drawing.Size(55, 21)
        Me.lblOBSScenes.TabIndex = 103
        Me.lblOBSScenes.Text = "Scenes-"
        '
        'lblOBSInfo
        '
        Me.lblOBSInfo.Font = New System.Drawing.Font("BigNoodleTitling", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOBSInfo.Location = New System.Drawing.Point(78, 28)
        Me.lblOBSInfo.Name = "lblOBSInfo"
        Me.lblOBSInfo.Size = New System.Drawing.Size(203, 64)
        Me.lblOBSInfo.TabIndex = 444
        Me.lblOBSInfo.Text = "this application directly interfaces with assets inside obs in order to display i" &
    "nformation. please verify that all scene and source information is correct befor" &
    "e proceeding."
        Me.lblOBSInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOBSSources
        '
        Me.lblOBSSources.AutoSize = True
        Me.lblOBSSources.Location = New System.Drawing.Point(19, 206)
        Me.lblOBSSources.Name = "lblOBSSources"
        Me.lblOBSSources.Size = New System.Drawing.Size(65, 21)
        Me.lblOBSSources.TabIndex = 104
        Me.lblOBSSources.Text = "Sources-"
        '
        'picOBSLogo
        '
        Me.picOBSLogo.Image = Global.Overwatch_Hero_2._0.My.Resources.Resources.obs_icon_small
        Me.picOBSLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picOBSLogo.Location = New System.Drawing.Point(6, 21)
        Me.picOBSLogo.Name = "picOBSLogo"
        Me.picOBSLogo.Size = New System.Drawing.Size(75, 75)
        Me.picOBSLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picOBSLogo.TabIndex = 51
        Me.picOBSLogo.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("BigNoodleTitling", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 15)
        Me.Label3.TabIndex = 458
        Me.Label3.Text = "Vote2                               Vote3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdOpenSettings
        '
        Me.cmdOpenSettings.Font = New System.Drawing.Font("BigNoodleTitling", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpenSettings.Location = New System.Drawing.Point(207, 95)
        Me.cmdOpenSettings.Name = "cmdOpenSettings"
        Me.cmdOpenSettings.Size = New System.Drawing.Size(52, 20)
        Me.cmdOpenSettings.TabIndex = 494
        Me.cmdOpenSettings.Text = "Settings"
        Me.cmdOpenSettings.UseVisualStyleBackColor = True
        '
        'txtReticleY
        '
        Me.txtReticleY.Location = New System.Drawing.Point(104, 317)
        Me.txtReticleY.Name = "txtReticleY"
        Me.txtReticleY.Size = New System.Drawing.Size(30, 20)
        Me.txtReticleY.TabIndex = 496
        '
        'txtReticleX
        '
        Me.txtReticleX.Location = New System.Drawing.Point(58, 317)
        Me.txtReticleX.Name = "txtReticleX"
        Me.txtReticleX.Size = New System.Drawing.Size(30, 20)
        Me.txtReticleX.TabIndex = 495
        '
        'lblReticleX
        '
        Me.lblReticleX.AutoSize = True
        Me.lblReticleX.Font = New System.Drawing.Font("BigNoodleTitling", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReticleX.Location = New System.Drawing.Point(47, 318)
        Me.lblReticleX.Name = "lblReticleX"
        Me.lblReticleX.Size = New System.Drawing.Size(15, 17)
        Me.lblReticleX.TabIndex = 497
        Me.lblReticleX.Text = "X:"
        '
        'lblReticleY
        '
        Me.lblReticleY.AutoSize = True
        Me.lblReticleY.Font = New System.Drawing.Font("BigNoodleTitling", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReticleY.Location = New System.Drawing.Point(92, 318)
        Me.lblReticleY.Name = "lblReticleY"
        Me.lblReticleY.Size = New System.Drawing.Size(15, 17)
        Me.lblReticleY.TabIndex = 498
        Me.lblReticleY.Text = "Y:"
        '
        'picReticleColor
        '
        Me.picReticleColor.BackColor = System.Drawing.Color.Black
        Me.picReticleColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picReticleColor.Location = New System.Drawing.Point(23, 298)
        Me.picReticleColor.Name = "picReticleColor"
        Me.picReticleColor.Size = New System.Drawing.Size(20, 20)
        Me.picReticleColor.TabIndex = 103
        Me.picReticleColor.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'frmOverwatchHeroSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 351)
        Me.Controls.Add(Me.picReticleColor)
        Me.Controls.Add(Me.txtReticleColor)
        Me.Controls.Add(Me.txtReticleY)
        Me.Controls.Add(Me.lblReticleY)
        Me.Controls.Add(Me.txtReticleX)
        Me.Controls.Add(Me.lblReticleX)
        Me.Controls.Add(Me.grpOBS)
        Me.Controls.Add(Me.cmdOpenSettings)
        Me.Controls.Add(Me.AlertPlayer)
        Me.Controls.Add(Me.lstAlreadyVoted)
        Me.Controls.Add(Me.txtTwitchChat)
        Me.Controls.Add(Me.cmdStartStop)
        Me.Controls.Add(Me.txtTwitchOAuth)
        Me.Controls.Add(Me.txtTwitchUsername)
        Me.Controls.Add(Me.lblUO)
        Me.Controls.Add(Me.txtOBSPass)
        Me.Controls.Add(Me.txtOBSPort)
        Me.Controls.Add(Me.txtOBSHost)
        Me.Controls.Add(Me.lblHPP)
        Me.Controls.Add(Me.cmdConnectToTwitch)
        Me.Controls.Add(Me.lblLookFor)
        Me.Controls.Add(Me.txtLookFor)
        Me.Controls.Add(Me.lblReticleColor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOBSConnect)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOverwatchHeroSelect"
        Me.Text = "Overwatch Hero Select"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picDoomfist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGenji, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMcCree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPharah, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picReaper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSoldier76, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSombra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTracer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBastion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHanzo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picJunkrat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picZenyatta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMei, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSymmetra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTorbjorn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMoira, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWidowmaker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMercy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLucio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picOrisa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBrigitte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picReinhardt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAna, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRoadhog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWinston, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picZarya, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AlertPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOBS.ResumeLayout(False)
        Me.grpOBS.PerformLayout()
        CType(Me.picOBSLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picReticleColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picZarya As PictureBox
    Friend WithEvents picWinston As PictureBox
    Friend WithEvents picRoadhog As PictureBox
    Friend WithEvents picReinhardt As PictureBox
    Friend WithEvents picOrisa As PictureBox
    Friend WithEvents picDva As PictureBox
    Friend WithEvents picWidowmaker As PictureBox
    Friend WithEvents picTorbjorn As PictureBox
    Friend WithEvents picMei As PictureBox
    Friend WithEvents picJunkrat As PictureBox
    Friend WithEvents picHanzo As PictureBox
    Friend WithEvents picBastion As PictureBox
    Friend WithEvents picTracer As PictureBox
    Friend WithEvents picSombra As PictureBox
    Friend WithEvents picSoldier76 As PictureBox
    Friend WithEvents picReaper As PictureBox
    Friend WithEvents picPharah As PictureBox
    Friend WithEvents picMcCree As PictureBox
    Friend WithEvents picGenji As PictureBox
    Friend WithEvents picDoomfist As PictureBox
    Friend WithEvents chkHero01 As CheckBox
    Friend WithEvents chkHero02 As CheckBox
    Friend WithEvents chkHero04 As CheckBox
    Friend WithEvents chkHero03 As CheckBox
    Friend WithEvents chkHero08 As CheckBox
    Friend WithEvents chkHero07 As CheckBox
    Friend WithEvents chkHero06 As CheckBox
    Friend WithEvents chkHero05 As CheckBox
    Friend WithEvents chkHero14 As CheckBox
    Friend WithEvents chkHero13 As CheckBox
    Friend WithEvents chkHero12 As CheckBox
    Friend WithEvents chkHero11 As CheckBox
    Friend WithEvents chkHero10 As CheckBox
    Friend WithEvents chkHero09 As CheckBox
    Friend WithEvents chkHero20 As CheckBox
    Friend WithEvents chkHero19 As CheckBox
    Friend WithEvents chkHero18 As CheckBox
    Friend WithEvents chkHero17 As CheckBox
    Friend WithEvents chkHero16 As CheckBox
    Friend WithEvents chkHero15 As CheckBox
    Friend WithEvents chkHero27 As CheckBox
    Friend WithEvents chkHero26 As CheckBox
    Friend WithEvents chkHero25 As CheckBox
    Friend WithEvents chkHero24 As CheckBox
    Friend WithEvents chkHero23 As CheckBox
    Friend WithEvents chkHero22 As CheckBox
    Friend WithEvents chkHero21 As CheckBox
    Friend WithEvents picZenyatta As PictureBox
    Friend WithEvents picSymmetra As PictureBox
    Friend WithEvents picMoira As PictureBox
    Friend WithEvents picMercy As PictureBox
    Friend WithEvents picLucio As PictureBox
    Friend WithEvents picBrigitte As PictureBox
    Friend WithEvents picAna As PictureBox
    Friend WithEvents cmdOBSConnect As Button
    Friend WithEvents picReticleColor As PictureBox
    Friend WithEvents txtReticleColor As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblSupportHeroes As Label
    Friend WithEvents lblTankHeroes As Label
    Friend WithEvents lblDefenseHeroes As Label
    Friend WithEvents lblOffenseHeroes As Label
    Friend WithEvents lblReticleColor As Label
    Friend WithEvents tmrReticle As Timer
    Friend WithEvents txtLookFor As TextBox
    Friend WithEvents lblLookFor As Label
    Friend WithEvents cmdConnectToTwitch As Button
    Friend WithEvents txtOBSPass As TextBox
    Friend WithEvents txtOBSPort As TextBox
    Friend WithEvents txtOBSHost As TextBox
    Friend WithEvents lblHPP As Label
    Friend WithEvents lblUO As Label
    Friend WithEvents txtTwitchOAuth As TextBox
    Friend WithEvents txtTwitchUsername As TextBox
    Friend WithEvents cmdStartStop As Button
    Friend WithEvents txtTwitchChat As RichTextBox
    Friend WithEvents lstAlreadyVoted As ListBox
    Friend WithEvents tmrBar1 As Timer
    Friend WithEvents tmrBar2 As Timer
    Friend WithEvents tmrBar3 As Timer
    Friend WithEvents AlertPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents tmrNewVote As Timer
    Friend WithEvents tmrEndVote As Timer
    Friend WithEvents tmrVote1 As Timer
    Friend WithEvents tmrVote2 As Timer
    Friend WithEvents tmrVote3 As Timer
    Friend WithEvents tmrUpdateVote As Timer
    Friend WithEvents grpOBS As GroupBox
    Friend WithEvents picOBSLogo As PictureBox
    Friend WithEvents lblOBSScenes As Label
    Friend WithEvents lblOBSSources As Label
    Friend WithEvents lblOBSInfo As Label
    Friend WithEvents cmdCloseSettings As Button
    Friend WithEvents txtOBSSourceBar3 As TextBox
    Friend WithEvents txtOBSSourceBar2 As TextBox
    Friend WithEvents txtOBSSourceBar1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtOBSSourceBar3Y As TextBox
    Friend WithEvents txtOBSSourceBar2Y As TextBox
    Friend WithEvents txtOBSSourceBar1Y As TextBox
    Friend WithEvents txtOBSSceneVote3 As TextBox
    Friend WithEvents txtOBSSceneVote2 As TextBox
    Friend WithEvents txtOBSSceneVote1 As TextBox
    Friend WithEvents txtOBSSceneOverwatch As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdOpenSettings As Button
    Friend WithEvents txtReticleY As TextBox
    Friend WithEvents txtReticleX As TextBox
    Friend WithEvents lblReticleX As Label
    Friend WithEvents lblReticleY As Label
    Friend WithEvents Timer1 As Timer
End Class
