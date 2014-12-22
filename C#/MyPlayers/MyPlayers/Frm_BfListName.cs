using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPlayers
{
    public partial class Frm_BfListName : Form
    {
        public Frm_BfListName()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "")
            {
                MessageBox.Show("请输入名称信息！", "提示");
                txt_Name.Focus();
                return;
            }

            string iSqlStr = "SELECT [ID] FROM [PlaysList] WHERE [ListName]='" + txt_Name.Text + "'";
            object iRet = C_SqlOper.SeleDataObj(iSqlStr);
            if (iRet != null)
            {
                MessageBox.Show("已经存在的名称信息！请重新输入", "提示");
                txt_Name.Focus();
                txt_Name.SelectAll();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
