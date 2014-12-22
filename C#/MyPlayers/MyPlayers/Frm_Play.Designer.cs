namespace MyPlayers
{
    partial class Frm_Play
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Play));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lab_Volume = new System.Windows.Forms.Label();
            this.ima_Volume = new System.Windows.Forms.ImageList(this.components);
            this.btn_Next = new System.Windows.Forms.Button();
            this.ima_But = new System.Windows.Forms.ImageList(this.components);
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.dataSet1 = new System.Data.DataSet();
            this.dTable_FileList = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dTable_BfList = new System.Data.DataTable();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.fDialog_Folder = new System.Windows.Forms.FolderBrowserDialog();
            this.cMenu_BfList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_NewBfList = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Sava = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.oFDialog_OneFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lab_VolumeText = new System.Windows.Forms.Label();
            this.tBar_Volume = new System.Windows.Forms.TrackBar();
            this.lab_State = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer_PlayTime = new System.Windows.Forms.Timer(this.components);
            this.nIcon_Main = new System.Windows.Forms.NotifyIcon(this.components);
            this.cMenu_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_Init = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkB_Lyrics = new System.Windows.Forms.CheckBox();
            this.pic_FFT = new System.Windows.Forms.PictureBox();
            this.tBar_PlayTime = new System.Windows.Forms.TrackBar();
            this.lab_AllTime = new System.Windows.Forms.Label();
            this.lab_PlayTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_MusicName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.list_BoList = new System.Windows.Forms.ListBox();
            this.dataGV_FileList = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comB_PlayMode = new System.Windows.Forms.ComboBox();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_OpenFolder = new System.Windows.Forms.Button();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.timer_FFT = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTable_FileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTable_BfList)).BeginInit();
            this.cMenu_BfList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_Volume)).BeginInit();
            this.panel3.SuspendLayout();
            this.cMenu_Main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_FFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_PlayTime)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_FileList)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_Volume
            // 
            this.lab_Volume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_Volume.ImageIndex = 0;
            this.lab_Volume.ImageList = this.ima_Volume;
            this.lab_Volume.Location = new System.Drawing.Point(240, 12);
            this.lab_Volume.Name = "lab_Volume";
            this.lab_Volume.Size = new System.Drawing.Size(25, 25);
            this.lab_Volume.TabIndex = 7;
            this.lab_Volume.Click += new System.EventHandler(this.lab_Volume_Click);
            // 
            // ima_Volume
            // 
            this.ima_Volume.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ima_Volume.ImageStream")));
            this.ima_Volume.TransparentColor = System.Drawing.Color.Transparent;
            this.ima_Volume.Images.SetKeyName(0, "Volume16.png");
            this.ima_Volume.Images.SetKeyName(1, "NotVolume16.png");
            // 
            // btn_Next
            // 
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Next.ImageIndex = 0;
            this.btn_Next.ImageList = this.ima_But;
            this.btn_Next.Location = new System.Drawing.Point(155, 18);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(40, 40);
            this.btn_Next.TabIndex = 4;
            this.btn_Next.TabStop = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // ima_But
            // 
            this.ima_But.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ima_But.ImageStream")));
            this.ima_But.TransparentColor = System.Drawing.Color.Transparent;
            this.ima_But.Images.SetKeyName(0, "Next32.png");
            this.ima_But.Images.SetKeyName(1, "Pause32.png");
            this.ima_But.Images.SetKeyName(2, "Play32.png");
            this.ima_But.Images.SetKeyName(3, "Previouss32.png");
            this.ima_But.Images.SetKeyName(4, "Stop32.png");
            // 
            // btn_Previous
            // 
            this.btn_Previous.FlatAppearance.BorderSize = 0;
            this.btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Previous.ImageIndex = 3;
            this.btn_Previous.ImageList = this.ima_But;
            this.btn_Previous.Location = new System.Drawing.Point(115, 18);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(40, 40);
            this.btn_Previous.TabIndex = 3;
            this.btn_Previous.TabStop = false;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Stop.ImageIndex = 4;
            this.btn_Stop.ImageList = this.ima_But;
            this.btn_Stop.Location = new System.Drawing.Point(75, 18);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(40, 40);
            this.btn_Stop.TabIndex = 2;
            this.btn_Stop.TabStop = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Play.ImageIndex = 2;
            this.btn_Play.ImageList = this.ima_But;
            this.btn_Play.Location = new System.Drawing.Point(35, 18);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(40, 40);
            this.btn_Play.TabIndex = 1;
            this.btn_Play.TabStop = false;
            this.btn_Play.Tag = "播放";
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dTable_FileList,
            this.dTable_BfList});
            // 
            // dTable_FileList
            // 
            this.dTable_FileList.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dTable_FileList.TableName = "FileList";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AutoIncrement = true;
            this.dataColumn1.AutoIncrementSeed = ((long)(1));
            this.dataColumn1.ColumnName = "ID";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "FileName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "FilePath";
            // 
            // dTable_BfList
            // 
            this.dTable_BfList.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn4,
            this.dataColumn5});
            this.dTable_BfList.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ListName"}, true)});
            this.dTable_BfList.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn5};
            this.dTable_BfList.TableName = "BfList";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "ID";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.AllowDBNull = false;
            this.dataColumn5.ColumnName = "ListName";
            // 
            // fDialog_Folder
            // 
            this.fDialog_Folder.Description = "请选择存放音乐的文件夹：";
            this.fDialog_Folder.ShowNewFolderButton = false;
            // 
            // cMenu_BfList
            // 
            this.cMenu_BfList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_NewBfList,
            this.MenuItem_Sava,
            this.MenuItem_Del});
            this.cMenu_BfList.Name = "cMenu_BfList";
            this.cMenu_BfList.Size = new System.Drawing.Size(95, 70);
            // 
            // MenuItem_NewBfList
            // 
            this.MenuItem_NewBfList.Name = "MenuItem_NewBfList";
            this.MenuItem_NewBfList.Size = new System.Drawing.Size(94, 22);
            this.MenuItem_NewBfList.Text = "新建";
            this.MenuItem_NewBfList.Click += new System.EventHandler(this.MenuItem_NewBfList_Click);
            // 
            // MenuItem_Sava
            // 
            this.MenuItem_Sava.Name = "MenuItem_Sava";
            this.MenuItem_Sava.Size = new System.Drawing.Size(94, 22);
            this.MenuItem_Sava.Text = "保存";
            this.MenuItem_Sava.Click += new System.EventHandler(this.MenuItem_Sava_Click);
            // 
            // MenuItem_Del
            // 
            this.MenuItem_Del.Name = "MenuItem_Del";
            this.MenuItem_Del.Size = new System.Drawing.Size(94, 22);
            this.MenuItem_Del.Text = "删除";
            this.MenuItem_Del.Click += new System.EventHandler(this.MenuItem_Del_Click);
            // 
            // oFDialog_OneFile
            // 
            this.oFDialog_OneFile.Filter = "MP3文件|*.mp3|Mid文件|*.mid|Wav文件|*.wav|Wma文件|*.wma";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lab_VolumeText);
            this.groupBox2.Controls.Add(this.tBar_Volume);
            this.groupBox2.Controls.Add(this.lab_Volume);
            this.groupBox2.Controls.Add(this.btn_Next);
            this.groupBox2.Controls.Add(this.btn_Previous);
            this.groupBox2.Controls.Add(this.btn_Stop);
            this.groupBox2.Controls.Add(this.btn_Play);
            this.groupBox2.Controls.Add(this.lab_State);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 68);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "播放控制";
            // 
            // lab_VolumeText
            // 
            this.lab_VolumeText.AutoSize = true;
            this.lab_VolumeText.Location = new System.Drawing.Point(302, 47);
            this.lab_VolumeText.Name = "lab_VolumeText";
            this.lab_VolumeText.Size = new System.Drawing.Size(41, 12);
            this.lab_VolumeText.TabIndex = 9;
            this.lab_VolumeText.Text = "音量：";
            // 
            // tBar_Volume
            // 
            this.tBar_Volume.AutoSize = false;
            this.tBar_Volume.LargeChange = 1;
            this.tBar_Volume.Location = new System.Drawing.Point(268, 16);
            this.tBar_Volume.Maximum = 100;
            this.tBar_Volume.Name = "tBar_Volume";
            this.tBar_Volume.Size = new System.Drawing.Size(104, 27);
            this.tBar_Volume.TabIndex = 8;
            this.tBar_Volume.TabStop = false;
            this.tBar_Volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tBar_Volume.Value = 3;
            this.tBar_Volume.ValueChanged += new System.EventHandler(this.tBar_Volume_ValueChanged);
            // 
            // lab_State
            // 
            this.lab_State.Location = new System.Drawing.Point(227, 42);
            this.lab_State.Name = "lab_State";
            this.lab_State.Size = new System.Drawing.Size(69, 23);
            this.lab_State.TabIndex = 0;
            this.lab_State.Text = "状态：停止";
            this.lab_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 68);
            this.panel3.TabIndex = 7;
            // 
            // timer_PlayTime
            // 
            this.timer_PlayTime.Interval = 500;
            this.timer_PlayTime.Tick += new System.EventHandler(this.timer_PlayTime_Tick);
            // 
            // nIcon_Main
            // 
            this.nIcon_Main.ContextMenuStrip = this.cMenu_Main;
            this.nIcon_Main.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon_Main.Icon")));
            this.nIcon_Main.Text = "AudioPlayers";
            this.nIcon_Main.Visible = true;
            this.nIcon_Main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nIcon_Main_MouseClick);
            // 
            // cMenu_Main
            // 
            this.cMenu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Show,
            this.toolStripMenuItem1,
            this.MenuItem_About,
            this.MenuItem_Exit});
            this.cMenu_Main.Name = "cMenu_Main";
            this.cMenu_Main.Size = new System.Drawing.Size(95, 76);
            // 
            // MenuItem_Show
            // 
            this.MenuItem_Show.Name = "MenuItem_Show";
            this.MenuItem_Show.Size = new System.Drawing.Size(94, 22);
            this.MenuItem_Show.Text = "显示";
            this.MenuItem_Show.Click += new System.EventHandler(this.MenuItem_Show_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(91, 6);
            // 
            // MenuItem_About
            // 
            this.MenuItem_About.Name = "MenuItem_About";
            this.MenuItem_About.Size = new System.Drawing.Size(94, 22);
            this.MenuItem_About.Text = "关于";
            this.MenuItem_About.Click += new System.EventHandler(this.MenuItem_About_Click);
            // 
            // MenuItem_Exit
            // 
            this.MenuItem_Exit.Name = "MenuItem_Exit";
            this.MenuItem_Exit.Size = new System.Drawing.Size(94, 22);
            this.MenuItem_Exit.Text = "退出";
            this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
            // 
            // timer_Init
            // 
            this.timer_Init.Enabled = true;
            this.timer_Init.Tick += new System.EventHandler(this.timer_Init_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkB_Lyrics);
            this.groupBox1.Controls.Add(this.pic_FFT);
            this.groupBox1.Controls.Add(this.tBar_PlayTime);
            this.groupBox1.Controls.Add(this.lab_AllTime);
            this.groupBox1.Controls.Add(this.lab_PlayTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 136);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "播放信息";
            // 
            // checkB_Lyrics
            // 
            this.checkB_Lyrics.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkB_Lyrics.AutoSize = true;
            this.checkB_Lyrics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkB_Lyrics.Font = new System.Drawing.Font("宋体", 9F);
            this.checkB_Lyrics.Location = new System.Drawing.Point(266, 106);
            this.checkB_Lyrics.Name = "checkB_Lyrics";
            this.checkB_Lyrics.Size = new System.Drawing.Size(39, 22);
            this.checkB_Lyrics.TabIndex = 5;
            this.checkB_Lyrics.Tag = "9999";
            this.checkB_Lyrics.Text = "歌词";
            this.checkB_Lyrics.UseVisualStyleBackColor = true;
            this.checkB_Lyrics.CheckedChanged += new System.EventHandler(this.checkB_Lyrics_CheckedChanged);
            // 
            // pic_FFT
            // 
            this.pic_FFT.Location = new System.Drawing.Point(15, 68);
            this.pic_FFT.Name = "pic_FFT";
            this.pic_FFT.Size = new System.Drawing.Size(235, 60);
            this.pic_FFT.TabIndex = 4;
            this.pic_FFT.TabStop = false;
            this.pic_FFT.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_FFT_Paint);
            // 
            // tBar_PlayTime
            // 
            this.tBar_PlayTime.Location = new System.Drawing.Point(12, 20);
            this.tBar_PlayTime.Maximum = 0;
            this.tBar_PlayTime.Name = "tBar_PlayTime";
            this.tBar_PlayTime.Size = new System.Drawing.Size(248, 45);
            this.tBar_PlayTime.TabIndex = 3;
            this.tBar_PlayTime.TabStop = false;
            this.tBar_PlayTime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tBar_PlayTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tBar_PlayTime_MouseDown);
            this.tBar_PlayTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tBar_PlayTime_MouseUp);
            // 
            // lab_AllTime
            // 
            this.lab_AllTime.Location = new System.Drawing.Point(272, 82);
            this.lab_AllTime.Name = "lab_AllTime";
            this.lab_AllTime.Size = new System.Drawing.Size(100, 16);
            this.lab_AllTime.TabIndex = 2;
            this.lab_AllTime.Text = "总时长";
            this.lab_AllTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_PlayTime
            // 
            this.lab_PlayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_PlayTime.Font = new System.Drawing.Font("华文彩云", 25F, System.Drawing.FontStyle.Bold);
            this.lab_PlayTime.Location = new System.Drawing.Point(266, 20);
            this.lab_PlayTime.Name = "lab_PlayTime";
            this.lab_PlayTime.Size = new System.Drawing.Size(111, 50);
            this.lab_PlayTime.TabIndex = 1;
            this.lab_PlayTime.Text = "00:00";
            this.lab_PlayTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lab_MusicName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 28);
            this.panel1.TabIndex = 10;
            // 
            // lab_MusicName
            // 
            this.lab_MusicName.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_MusicName.Location = new System.Drawing.Point(0, 0);
            this.lab_MusicName.Name = "lab_MusicName";
            this.lab_MusicName.Size = new System.Drawing.Size(395, 28);
            this.lab_MusicName.TabIndex = 2;
            this.lab_MusicName.Text = "歌曲名";
            this.lab_MusicName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 232);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(395, 302);
            this.panel4.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Controls.Add(this.panel5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 302);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "播放列表";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.list_BoList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGV_FileList);
            this.splitContainer1.Size = new System.Drawing.Size(389, 247);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 2;
            // 
            // list_BoList
            // 
            this.list_BoList.ContextMenuStrip = this.cMenu_BfList;
            this.list_BoList.DataSource = this.dataSet1;
            this.list_BoList.DisplayMember = "BfList.ListName";
            this.list_BoList.Dock = System.Windows.Forms.DockStyle.Top;
            this.list_BoList.FormattingEnabled = true;
            this.list_BoList.ItemHeight = 12;
            this.list_BoList.Location = new System.Drawing.Point(0, 0);
            this.list_BoList.Name = "list_BoList";
            this.list_BoList.Size = new System.Drawing.Size(104, 244);
            this.list_BoList.TabIndex = 1;
            this.list_BoList.TabStop = false;
            this.list_BoList.SelectedIndexChanged += new System.EventHandler(this.list_BoList_SelectedIndexChanged);
            // 
            // dataGV_FileList
            // 
            this.dataGV_FileList.AllowUserToAddRows = false;
            this.dataGV_FileList.AllowUserToDeleteRows = false;
            this.dataGV_FileList.AutoGenerateColumns = false;
            this.dataGV_FileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_FileList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGV_FileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_FileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.FilePath});
            this.dataGV_FileList.DataMember = "FileList";
            this.dataGV_FileList.DataSource = this.dataSet1;
            this.dataGV_FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_FileList.EnableHeadersVisualStyles = false;
            this.dataGV_FileList.Location = new System.Drawing.Point(0, 0);
            this.dataGV_FileList.MultiSelect = false;
            this.dataGV_FileList.Name = "dataGV_FileList";
            this.dataGV_FileList.ReadOnly = true;
            this.dataGV_FileList.RowTemplate.Height = 23;
            this.dataGV_FileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGV_FileList.Size = new System.Drawing.Size(281, 247);
            this.dataGV_FileList.TabIndex = 3;
            this.dataGV_FileList.TabStop = false;
            this.dataGV_FileList.DoubleClick += new System.EventHandler(this.dataGV_FileList_DoubleClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.FillWeight = 13F;
            this.iDDataGridViewTextBoxColumn.HeaderText = "序号";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 54;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.FillWeight = 87F;
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "文件名";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comB_PlayMode);
            this.panel5.Controls.Add(this.btn_Del);
            this.panel5.Controls.Add(this.btn_Clear);
            this.panel5.Controls.Add(this.btn_OpenFolder);
            this.panel5.Controls.Add(this.btn_OpenFile);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(389, 35);
            this.panel5.TabIndex = 1;
            // 
            // comB_PlayMode
            // 
            this.comB_PlayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_PlayMode.FormattingEnabled = true;
            this.comB_PlayMode.Items.AddRange(new object[] {
            "单曲播放",
            "单曲循环",
            "顺序播放",
            "循环播放",
            "随机播放"});
            this.comB_PlayMode.Location = new System.Drawing.Point(282, 2);
            this.comB_PlayMode.Name = "comB_PlayMode";
            this.comB_PlayMode.Size = new System.Drawing.Size(86, 20);
            this.comB_PlayMode.TabIndex = 5;
            this.comB_PlayMode.TabStop = false;
            this.comB_PlayMode.SelectedIndexChanged += new System.EventHandler(this.comB_PlayMode_SelectedIndexChanged);
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(200, 1);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(67, 23);
            this.btn_Del.TabIndex = 3;
            this.btn_Del.TabStop = false;
            this.btn_Del.Text = "删除单曲";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(114, 1);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(87, 23);
            this.btn_Clear.TabIndex = 2;
            this.btn_Clear.TabStop = false;
            this.btn_Clear.Text = "清除当前列表";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_OpenFolder
            // 
            this.btn_OpenFolder.Location = new System.Drawing.Point(58, 1);
            this.btn_OpenFolder.Name = "btn_OpenFolder";
            this.btn_OpenFolder.Size = new System.Drawing.Size(57, 23);
            this.btn_OpenFolder.TabIndex = 1;
            this.btn_OpenFolder.TabStop = false;
            this.btn_OpenFolder.Text = "文件夹";
            this.btn_OpenFolder.UseVisualStyleBackColor = true;
            this.btn_OpenFolder.Click += new System.EventHandler(this.btn_OpenFolder_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Location = new System.Drawing.Point(12, 1);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(47, 23);
            this.btn_OpenFile.TabIndex = 0;
            this.btn_OpenFile.TabStop = false;
            this.btn_OpenFile.Text = "文件";
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // timer_FFT
            // 
            this.timer_FFT.Interval = 50;
            this.timer_FFT.Tick += new System.EventHandler(this.timer_FFT_Tick);
            // 
            // Frm_Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 534);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Play";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AudioPlayers By LYM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DShowPlay_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTable_FileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTable_BfList)).EndInit();
            this.cMenu_BfList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_Volume)).EndInit();
            this.panel3.ResumeLayout(false);
            this.cMenu_Main.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_FFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_PlayTime)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_FileList)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lab_Volume;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Play;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dTable_FileList;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.FolderBrowserDialog fDialog_Folder;
        private System.Windows.Forms.OpenFileDialog oFDialog_OneFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lab_State;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer_PlayTime;
        private System.Windows.Forms.TrackBar tBar_Volume;
        private System.Data.DataTable dTable_BfList;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.ContextMenuStrip cMenu_BfList;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NewBfList;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Sava;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Del;
        private System.Windows.Forms.ImageList ima_But;
        private System.Windows.Forms.ImageList ima_Volume;
        private System.Windows.Forms.NotifyIcon nIcon_Main;
        private System.Windows.Forms.ContextMenuStrip cMenu_Main;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Show;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
        private System.Windows.Forms.Label lab_VolumeText;
        private System.Windows.Forms.Timer timer_Init;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_About;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.PictureBox pic_FFT;
        private System.Windows.Forms.TrackBar tBar_PlayTime;
        private System.Windows.Forms.Label lab_AllTime;
        private System.Windows.Forms.Label lab_PlayTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_MusicName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox list_BoList;
        private System.Windows.Forms.DataGridView dataGV_FileList;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comB_PlayMode;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_OpenFolder;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Timer timer_FFT;
        private System.Windows.Forms.CheckBox checkB_Lyrics;
    }
}