namespace MyPlayers
{
    partial class Frm_ShowLyrics
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
            this.lyrControl1 = new MyPlayers.LyrControl();
            this.SuspendLayout();
            // 
            // lyrControl1
            // 
            this.lyrControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(60)))), ((int)(((byte)(125)))));
            this.lyrControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lyrControl1.Location = new System.Drawing.Point(0, 0);
            this.lyrControl1.Name = "lyrControl1";
            this.lyrControl1.Size = new System.Drawing.Size(344, 427);
            this.lyrControl1.TabIndex = 0;
            // 
            // Frm_ShowLyrics
            // 
            this.ClientSize = new System.Drawing.Size(344, 427);
            this.Controls.Add(this.lyrControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ShowLyrics";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "歌词";
            this.ResumeLayout(false);

        }

        #endregion

        private LyrControl lyrControl1;

    }
}