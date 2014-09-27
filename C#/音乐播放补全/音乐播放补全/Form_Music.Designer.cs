namespace 音乐播放补全
{
    partial class Form_Music
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Like = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.gpb_Control = new System.Windows.Forms.GroupBox();
            this.btn_Openfile = new System.Windows.Forms.Button();
            this.pal_Show = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_Time_3 = new System.Windows.Forms.Label();
            this.lb_Time_2 = new System.Windows.Forms.Label();
            this.lb_Time_1 = new System.Windows.Forms.Label();
            this.lb_MusicName = new System.Windows.Forms.Label();
            this.lb_Musician = new System.Windows.Forms.Label();
            this.picb_Show = new System.Windows.Forms.PictureBox();
            this.lsv_Music = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpb_List = new System.Windows.Forms.GroupBox();
            this.gpb_Control.SuspendLayout();
            this.pal_Show.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Show)).BeginInit();
            this.gpb_List.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Like
            // 
            this.btn_Like.Location = new System.Drawing.Point(158, 110);
            this.btn_Like.Name = "btn_Like";
            this.btn_Like.Size = new System.Drawing.Size(75, 23);
            this.btn_Like.TabIndex = 0;
            this.btn_Like.Text = "喜爱";
            this.btn_Like.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(239, 110);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(320, 110);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = "前一首";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(401, 110);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(75, 23);
            this.btn_Play.TabIndex = 3;
            this.btn_Play.Text = "播放";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(482, 110);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 23);
            this.btn_Next.TabIndex = 4;
            this.btn_Next.Text = "下一首";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // gpb_Control
            // 
            this.gpb_Control.Controls.Add(this.btn_Openfile);
            this.gpb_Control.Controls.Add(this.pal_Show);
            this.gpb_Control.Controls.Add(this.lb_Time_3);
            this.gpb_Control.Controls.Add(this.lb_Time_2);
            this.gpb_Control.Controls.Add(this.lb_Time_1);
            this.gpb_Control.Controls.Add(this.lb_MusicName);
            this.gpb_Control.Controls.Add(this.lb_Musician);
            this.gpb_Control.Controls.Add(this.picb_Show);
            this.gpb_Control.Controls.Add(this.btn_Like);
            this.gpb_Control.Controls.Add(this.btn_Next);
            this.gpb_Control.Controls.Add(this.btn_Delete);
            this.gpb_Control.Controls.Add(this.btn_Play);
            this.gpb_Control.Controls.Add(this.btn_Back);
            this.gpb_Control.Location = new System.Drawing.Point(13, 13);
            this.gpb_Control.Name = "gpb_Control";
            this.gpb_Control.Size = new System.Drawing.Size(690, 178);
            this.gpb_Control.TabIndex = 5;
            this.gpb_Control.TabStop = false;
            // 
            // btn_Openfile
            // 
            this.btn_Openfile.Location = new System.Drawing.Point(563, 110);
            this.btn_Openfile.Name = "btn_Openfile";
            this.btn_Openfile.Size = new System.Drawing.Size(75, 23);
            this.btn_Openfile.TabIndex = 12;
            this.btn_Openfile.Text = "打开文件";
            this.btn_Openfile.UseVisualStyleBackColor = true;
            this.btn_Openfile.Click += new System.EventHandler(this.btn_Openfile_Click);
            // 
            // pal_Show
            // 
            this.pal_Show.Controls.Add(this.pictureBox1);
            this.pal_Show.Location = new System.Drawing.Point(7, 151);
            this.pal_Show.Name = "pal_Show";
            this.pal_Show.Size = new System.Drawing.Size(514, 10);
            this.pal_Show.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 25);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lb_Time_3
            // 
            this.lb_Time_3.AutoSize = true;
            this.lb_Time_3.Location = new System.Drawing.Point(632, 21);
            this.lb_Time_3.Name = "lb_Time_3";
            this.lb_Time_3.Size = new System.Drawing.Size(47, 15);
            this.lb_Time_3.TabIndex = 10;
            this.lb_Time_3.Text = "05:00";
            // 
            // lb_Time_2
            // 
            this.lb_Time_2.AutoSize = true;
            this.lb_Time_2.Location = new System.Drawing.Point(615, 21);
            this.lb_Time_2.Name = "lb_Time_2";
            this.lb_Time_2.Size = new System.Drawing.Size(15, 15);
            this.lb_Time_2.TabIndex = 9;
            this.lb_Time_2.Text = "/";
            // 
            // lb_Time_1
            // 
            this.lb_Time_1.AutoSize = true;
            this.lb_Time_1.Location = new System.Drawing.Point(562, 21);
            this.lb_Time_1.Name = "lb_Time_1";
            this.lb_Time_1.Size = new System.Drawing.Size(47, 15);
            this.lb_Time_1.TabIndex = 8;
            this.lb_Time_1.Text = "00:00";
            // 
            // lb_MusicName
            // 
            this.lb_MusicName.AutoSize = true;
            this.lb_MusicName.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_MusicName.Location = new System.Drawing.Point(152, 64);
            this.lb_MusicName.Name = "lb_MusicName";
            this.lb_MusicName.Size = new System.Drawing.Size(110, 31);
            this.lb_MusicName.TabIndex = 7;
            this.lb_MusicName.Text = "正在播放";
            // 
            // lb_Musician
            // 
            this.lb_Musician.AutoSize = true;
            this.lb_Musician.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Musician.Location = new System.Drawing.Point(151, 15);
            this.lb_Musician.Name = "lb_Musician";
            this.lb_Musician.Size = new System.Drawing.Size(107, 39);
            this.lb_Musician.TabIndex = 6;
            this.lb_Musician.Text = "音乐人";
            // 
            // picb_Show
            // 
            this.picb_Show.Location = new System.Drawing.Point(7, 15);
            this.picb_Show.Name = "picb_Show";
            this.picb_Show.Size = new System.Drawing.Size(137, 118);
            this.picb_Show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picb_Show.TabIndex = 5;
            this.picb_Show.TabStop = false;
            // 
            // lsv_Music
            // 
            this.lsv_Music.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsv_Music.FullRowSelect = true;
            this.lsv_Music.Location = new System.Drawing.Point(11, 24);
            this.lsv_Music.Name = "lsv_Music";
            this.lsv_Music.Size = new System.Drawing.Size(674, 249);
            this.lsv_Music.TabIndex = 6;
            this.lsv_Music.UseCompatibleStateImageBehavior = false;
            this.lsv_Music.View = System.Windows.Forms.View.Details;
            this.lsv_Music.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_Music_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Songs";
            this.columnHeader1.Width = 600;
            // 
            // gpb_List
            // 
            this.gpb_List.Controls.Add(this.lsv_Music);
            this.gpb_List.Location = new System.Drawing.Point(12, 197);
            this.gpb_List.Name = "gpb_List";
            this.gpb_List.Size = new System.Drawing.Size(691, 279);
            this.gpb_List.TabIndex = 7;
            this.gpb_List.TabStop = false;
            this.gpb_List.Text = "文件列表";
            // 
            // Form_Music
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 488);
            this.Controls.Add(this.gpb_List);
            this.Controls.Add(this.gpb_Control);
            this.Name = "Form_Music";
            this.Text = "Music";
            this.Load += new System.EventHandler(this.Form_Music_Load);
            this.gpb_Control.ResumeLayout(false);
            this.gpb_Control.PerformLayout();
            this.pal_Show.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Show)).EndInit();
            this.gpb_List.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Like;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.GroupBox gpb_Control;
        private System.Windows.Forms.Button btn_Openfile;
        private System.Windows.Forms.Panel pal_Show;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_Time_3;
        private System.Windows.Forms.Label lb_Time_2;
        private System.Windows.Forms.Label lb_Time_1;
        private System.Windows.Forms.Label lb_MusicName;
        private System.Windows.Forms.Label lb_Musician;
        private System.Windows.Forms.PictureBox picb_Show;
        private System.Windows.Forms.ListView lsv_Music;
        private System.Windows.Forms.GroupBox gpb_List;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

