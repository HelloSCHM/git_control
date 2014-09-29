namespace QQ音乐地址获取winfrom
{
    partial class Form_QQ音乐地址获取winfrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_QQ音乐地址获取winfrom));
            this.btn_Search = new System.Windows.Forms.Button();
            this.txb_Search = new System.Windows.Forms.TextBox();
            this.txb_Uri_1 = new System.Windows.Forms.TextBox();
            this.txb_Uri_2 = new System.Windows.Forms.TextBox();
            this.btn_Play = new System.Windows.Forms.Button();
            this.txb_Uri_3 = new System.Windows.Forms.TextBox();
            this.txb_Uri_4 = new System.Windows.Forms.TextBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(6, 448);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "搜索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txb_Search
            // 
            this.txb_Search.Location = new System.Drawing.Point(6, 29);
            this.txb_Search.Name = "txb_Search";
            this.txb_Search.Size = new System.Drawing.Size(433, 25);
            this.txb_Search.TabIndex = 1;
            this.txb_Search.Text = "心事如雨";
            this.txb_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txb_Uri_1
            // 
            this.txb_Uri_1.Location = new System.Drawing.Point(6, 60);
            this.txb_Uri_1.Multiline = true;
            this.txb_Uri_1.Name = "txb_Uri_1";
            this.txb_Uri_1.Size = new System.Drawing.Size(433, 150);
            this.txb_Uri_1.TabIndex = 2;
            // 
            // txb_Uri_2
            // 
            this.txb_Uri_2.Location = new System.Drawing.Point(6, 216);
            this.txb_Uri_2.Multiline = true;
            this.txb_Uri_2.Name = "txb_Uri_2";
            this.txb_Uri_2.Size = new System.Drawing.Size(433, 147);
            this.txb_Uri_2.TabIndex = 3;
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(173, 448);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(75, 23);
            this.btn_Play.TabIndex = 4;
            this.btn_Play.Text = "播放";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // txb_Uri_3
            // 
            this.txb_Uri_3.Location = new System.Drawing.Point(6, 369);
            this.txb_Uri_3.Multiline = true;
            this.txb_Uri_3.Name = "txb_Uri_3";
            this.txb_Uri_3.Size = new System.Drawing.Size(433, 25);
            this.txb_Uri_3.TabIndex = 5;
            // 
            // txb_Uri_4
            // 
            this.txb_Uri_4.Location = new System.Drawing.Point(6, 400);
            this.txb_Uri_4.Name = "txb_Uri_4";
            this.txb_Uri_4.Size = new System.Drawing.Size(433, 25);
            this.txb_Uri_4.TabIndex = 6;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(364, 448);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 7;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txb_Search);
            this.groupBox1.Controls.Add(this.btn_Stop);
            this.groupBox1.Controls.Add(this.txb_Uri_1);
            this.groupBox1.Controls.Add(this.btn_Play);
            this.groupBox1.Controls.Add(this.txb_Uri_4);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.txb_Uri_2);
            this.groupBox1.Controls.Add(this.txb_Uri_3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 478);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "音乐获取";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "程序由Hello.SCHM编写   v2.0.0";
            // 
            // Form_QQ音乐地址获取winfrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_QQ音乐地址获取winfrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QQ音乐地址获取winfrom";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txb_Search;
        private System.Windows.Forms.TextBox txb_Uri_1;
        private System.Windows.Forms.TextBox txb_Uri_2;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.TextBox txb_Uri_3;
        private System.Windows.Forms.TextBox txb_Uri_4;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}

