namespace 百度贴吧图片下载
{
    partial class BaiduPic_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaiduPic_Form));
            this.txb_path = new System.Windows.Forms.TextBox();
            this.lb_path = new System.Windows.Forms.Label();
            this.linklb_path = new System.Windows.Forms.LinkLabel();
            this.lb_show = new System.Windows.Forms.Label();
            this.Btn_Download = new System.Windows.Forms.Button();
            this.Btn_File = new System.Windows.Forms.Button();
            this.fdb = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txb_start = new System.Windows.Forms.TextBox();
            this.txb_end = new System.Windows.Forms.TextBox();
            this.lb_get = new System.Windows.Forms.Label();
            this.lb_to = new System.Windows.Forms.Label();
            this.lsb_show = new System.Windows.Forms.ListBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txb_path
            // 
            this.txb_path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_path.Location = new System.Drawing.Point(15, 27);
            this.txb_path.Name = "txb_path";
            this.txb_path.Size = new System.Drawing.Size(316, 27);
            this.txb_path.TabIndex = 0;
            this.txb_path.Text = "http://tieba.baidu.com/p/1859019972";
            // 
            // lb_path
            // 
            this.lb_path.AutoSize = true;
            this.lb_path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_path.Location = new System.Drawing.Point(12, 4);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new System.Drawing.Size(114, 20);
            this.lb_path.TabIndex = 2;
            this.lb_path.Text = "贴吧图片地址：";
            // 
            // linklb_path
            // 
            this.linklb_path.AutoSize = true;
            this.linklb_path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklb_path.Location = new System.Drawing.Point(10, 125);
            this.linklb_path.Name = "linklb_path";
            this.linklb_path.Size = new System.Drawing.Size(195, 20);
            this.linklb_path.TabIndex = 4;
            this.linklb_path.TabStop = true;
            this.linklb_path.Text = "http://www.mr-good.xyz/";
            this.linklb_path.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklb_path_LinkClicked);
            // 
            // lb_show
            // 
            this.lb_show.AutoSize = true;
            this.lb_show.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_show.Location = new System.Drawing.Point(10, 96);
            this.lb_show.Name = "lb_show";
            this.lb_show.Size = new System.Drawing.Size(84, 20);
            this.lb_show.TabIndex = 5;
            this.lb_show.Text = "点击查看：";
            // 
            // Btn_Download
            // 
            this.Btn_Download.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Download.Location = new System.Drawing.Point(254, 92);
            this.Btn_Download.Name = "Btn_Download";
            this.Btn_Download.Size = new System.Drawing.Size(77, 30);
            this.Btn_Download.TabIndex = 7;
            this.Btn_Download.Text = "下载";
            this.Btn_Download.UseVisualStyleBackColor = true;
            this.Btn_Download.Click += new System.EventHandler(this.Btn_Download_Click);
            // 
            // Btn_File
            // 
            this.Btn_File.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_File.Location = new System.Drawing.Point(115, 92);
            this.Btn_File.Name = "Btn_File";
            this.Btn_File.Size = new System.Drawing.Size(114, 30);
            this.Btn_File.TabIndex = 8;
            this.Btn_File.Text = "选择保存地址";
            this.Btn_File.UseVisualStyleBackColor = true;
            this.Btn_File.Click += new System.EventHandler(this.Btn_File_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 417);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(343, 25);
            this.statusStrip.TabIndex = 9;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(61, 20);
            this.toolStripStatusLabel1.Text = "             ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel2.Text = "Mr.Good~  提供v1.0.0";
            // 
            // txb_start
            // 
            this.txb_start.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_start.Location = new System.Drawing.Point(117, 62);
            this.txb_start.Name = "txb_start";
            this.txb_start.Size = new System.Drawing.Size(68, 27);
            this.txb_start.TabIndex = 10;
            this.txb_start.Text = "1";
            this.txb_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txb_end
            // 
            this.txb_end.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_end.Location = new System.Drawing.Point(254, 62);
            this.txb_end.Name = "txb_end";
            this.txb_end.Size = new System.Drawing.Size(77, 27);
            this.txb_end.TabIndex = 11;
            this.txb_end.Text = "5";
            this.txb_end.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_get
            // 
            this.lb_get.AutoSize = true;
            this.lb_get.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_get.Location = new System.Drawing.Point(12, 65);
            this.lb_get.Name = "lb_get";
            this.lb_get.Size = new System.Drawing.Size(99, 20);
            this.lb_get.TabIndex = 12;
            this.lb_get.Text = "获取页面从：";
            // 
            // lb_to
            // 
            this.lb_to.AutoSize = true;
            this.lb_to.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_to.Location = new System.Drawing.Point(205, 65);
            this.lb_to.Name = "lb_to";
            this.lb_to.Size = new System.Drawing.Size(24, 20);
            this.lb_to.TabIndex = 13;
            this.lb_to.Text = "到";
            // 
            // lsb_show
            // 
            this.lsb_show.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsb_show.FormattingEnabled = true;
            this.lsb_show.ItemHeight = 15;
            this.lsb_show.Location = new System.Drawing.Point(0, 173);
            this.lsb_show.Name = "lsb_show";
            this.lsb_show.Size = new System.Drawing.Size(343, 244);
            this.lsb_show.TabIndex = 15;
            // 
            // BaiduPic_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 442);
            this.Controls.Add(this.lsb_show);
            this.Controls.Add(this.lb_to);
            this.Controls.Add(this.lb_get);
            this.Controls.Add(this.txb_end);
            this.Controls.Add(this.txb_start);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.Btn_File);
            this.Controls.Add(this.Btn_Download);
            this.Controls.Add(this.txb_path);
            this.Controls.Add(this.lb_show);
            this.Controls.Add(this.linklb_path);
            this.Controls.Add(this.lb_path);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaiduPic_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "百度贴吧图片下载";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_path;
        private System.Windows.Forms.Label lb_path;
        private System.Windows.Forms.LinkLabel linklb_path;
        private System.Windows.Forms.Label lb_show;
        private System.Windows.Forms.Button Btn_Download;
        private System.Windows.Forms.Button Btn_File;
        private System.Windows.Forms.FolderBrowserDialog fdb;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txb_start;
        private System.Windows.Forms.TextBox txb_end;
        private System.Windows.Forms.Label lb_get;
        private System.Windows.Forms.Label lb_to;
        private System.Windows.Forms.ListBox lsb_show;
    }
}

