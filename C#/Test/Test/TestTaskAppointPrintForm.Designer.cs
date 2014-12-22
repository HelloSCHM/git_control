namespace WinEasV2.Task
{
    partial class TaskAppointPrintForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpPrintDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCourOrder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCourID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbReupType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbYearTerm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
//            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpPrintDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCourOrder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCourID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbReupType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbYearTerm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbDept);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1117, 59);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dtpPrintDate
            // 
            this.dtpPrintDate.CustomFormat = "yyyy-MM-dd";
            this.dtpPrintDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPrintDate.Location = new System.Drawing.Point(996, 20);
            this.dtpPrintDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPrintDate.Name = "dtpPrintDate";
            this.dtpPrintDate.Size = new System.Drawing.Size(108, 25);
            this.dtpPrintDate.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(915, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "打印日期：";
            // 
            // txtCourOrder
            // 
            this.txtCourOrder.Location = new System.Drawing.Point(877, 19);
            this.txtCourOrder.Margin = new System.Windows.Forms.Padding(4);
            this.txtCourOrder.MaxLength = 6;
            this.txtCourOrder.Name = "txtCourOrder";
            this.txtCourOrder.Size = new System.Drawing.Size(35, 25);
            this.txtCourOrder.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(815, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "课序号：";
            // 
            // txtCourID
            // 
            this.txtCourID.Location = new System.Drawing.Point(743, 19);
            this.txtCourID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCourID.MaxLength = 6;
            this.txtCourID.Name = "txtCourID";
            this.txtCourID.Size = new System.Drawing.Size(69, 25);
            this.txtCourID.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(687, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "编号：";
            // 
            // cbReupType
            // 
            this.cbReupType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbReupType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbReupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReupType.FormattingEnabled = true;
            this.cbReupType.IntegralHeight = false;
            this.cbReupType.ItemHeight = 15;
            this.cbReupType.Location = new System.Drawing.Point(585, 20);
            this.cbReupType.Margin = new System.Windows.Forms.Padding(4);
            this.cbReupType.Name = "cbReupType";
            this.cbReupType.Size = new System.Drawing.Size(92, 23);
            this.cbReupType.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "任务类型：";
            // 
            // cbYearTerm
            // 
            this.cbYearTerm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbYearTerm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbYearTerm.DropDownHeight = 200;
            this.cbYearTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYearTerm.FormattingEnabled = true;
            this.cbYearTerm.IntegralHeight = false;
            this.cbYearTerm.ItemHeight = 15;
            this.cbYearTerm.Location = new System.Drawing.Point(59, 22);
            this.cbYearTerm.Margin = new System.Windows.Forms.Padding(4);
            this.cbYearTerm.Name = "cbYearTerm";
            this.cbYearTerm.Size = new System.Drawing.Size(197, 23);
            this.cbYearTerm.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "学期：";
            // 
            // cbDept
            // 
            this.cbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDept.DropDownHeight = 250;
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.IntegralHeight = false;
            this.cbDept.ItemHeight = 15;
            this.cbDept.Location = new System.Drawing.Point(348, 20);
            this.cbDept.Margin = new System.Windows.Forms.Padding(4);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(159, 23);
            this.cbDept.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "所属院系：";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1129, 29);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(63, 29);
            this.btnQuery.TabIndex = 40;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // crv
            // 
//            this.crv.ActiveViewIndex = -1;
//            this.crv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.crv.DisplayGroupTree = false;
            //this.crv.Location = new System.Drawing.Point(4, 326);
            //this.crv.Margin = new System.Windows.Forms.Padding(4);
            //this.crv.Name = "crv";
            //this.crv.SelectionFormula = "";
            //this.crv.ShowGroupTreeButton = false;
            //this.crv.ShowRefreshButton = false;
            //this.crv.Size = new System.Drawing.Size(1257, 206);
            //this.crv.TabIndex = 43;
            //this.crv.ViewTimeSelectionFormula = "";
            // 
            // TaskAppointPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1257, 751);
//            this.Controls.Add(this.crv);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuery);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaskAppointPrintForm";
            this.Text = "打印开课任务聘书";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbReupType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbYearTerm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        //private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.TextBox txtCourID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCourOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpPrintDate;
    }
}