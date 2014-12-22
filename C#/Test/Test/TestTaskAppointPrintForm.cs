using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClEas.BILayer;
using ClEas.Public;

namespace WinEasV2.Task
{
    public partial class TaskAppointPrintForm : Form
    {
        public TaskAppointPrintForm()
        {
            InitializeComponent();
            BindYearTerm();
            BindDept();
            BindReupType();
        }
        #region
        /// <summary>
        /// ��ѧ��
        /// </summary>
        private void BindYearTerm()
        {
            r_YearTerm yearTerm = new r_YearTerm();
            //UIBase.BindComboBox(yearTerm.GetOnAllTerm(), cbYearTerm, "YearTermName", "YearTermID");
            cbYearTerm.SelectedValue = Utility.selectTerm;
        }
        /// <summary>
        /// �󶨿��ε�λ
        /// </summary>
        private void BindDept()
        {
            r_Dept dept = new r_Dept();
            DataTable dt = dept.GetAllDept();
            DataRow dr = dt.NewRow();
            dr["DeptID"] = "100";
            dr["ADeptName"] = "ȫ��";
            dt.Rows.InsertAt(dr, 0);
            //UIBase.BindComboBox(dt, cbDept, "ADeptName", "DeptID");
        }
        /// <summary>
        /// ����������
        /// </summary>
        private void BindReupType()
        {
            DataTable dt = Utility.GetReupTypeDataTable();
            DataRow dr = dt.NewRow();
            dr["ReupTypeID"] = "100";
            dr["ReupTypeName"] = "ȫ��";
            dt.Rows.InsertAt(dr, 0);
            //UIBase.BindComboBox(dt, cbReupType, "ReupTypeName", "ReupTypeID");
            cbReupType.SelectedIndex = 1;
        }
        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cbYearTerm.SelectedValue != null && cbReupType.SelectedValue != null)
            {
                t_TeachTask teachTask = new t_TeachTask();
                DataTable dt = teachTask.GetTaskByTerm(cbYearTerm.SelectedValue.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CourWeek"].ToString() == "" || dr["CourWeek"].ToString() == "0")//���ۿγ�
                    {
                        dr["ReupTypeName"] = Utility.GetReupTypeNameByID(dr["ReupFlag"].ToString());
                        if ((dr["ReupTypeName"].ToString().IndexOf("��������") > -1) 
                            && Utility.IsNumeric(dr["TotalTime"].ToString().Trim()))//�������ޣ��Ͽ�ֻҪ��1/3ѧʱ
                        {
                            dr["CourInfo"] = "��ѧʱ��" + int.Parse(dr["TotalTime"].ToString().Trim()) / 3 + "��"+dr["ReupTypeName"].ToString()+"��";
                        }
                        else
                        {
                            dr["CourInfo"] = "��ѧʱ��" + dr["TotalTime"].ToString().Trim() + "���������ۣ�" + dr["TheoTime"].ToString().Trim();
                            if (!(dr["ExpeTime"].ToString() == "" || dr["ExpeTime"].ToString() == "0"))
                                dr["CourInfo"] += "��ʵ�飺" + dr["ExpeTime"].ToString().Trim();
                            if (!(dr["MachTime"].ToString() == "" || dr["MachTime"].ToString() == "0"))
                                dr["CourInfo"] += "���ϻ���" + dr["MachTime"].ToString().Trim();
                        }
                    }
                    else//����ʵ������
                    {
                        dr["CourInfo"] = "������" + dr["CourWeek"].ToString() + "�ܡ�" + dr["TaskMemo"].ToString();
                    }
                }
                StringBuilder sb = new StringBuilder();                
                sb.Append("1=1 ");
                if (cbDept.SelectedValue.ToString() != "100")//ȫ��ϵ��
                {
                    sb.Append(" And DeptID='" + cbDept.SelectedValue.ToString() + "'");
                }
                if (cbReupType.SelectedValue.ToString() != "100")//ȫ������
                {
                    sb.Append(" And ReupFlag=" + cbReupType.SelectedValue.ToString());
                }
                if (txtCourID.Text != "")
                {
                    sb.Append(" And CourID='" +txtCourID.Text.Trim()+"'");                    
                }
                if (txtCourOrder.Text != "")
                {
                    sb.Append(" And CourOrder =" +txtCourOrder.Text.Trim());
                }
                dt.DefaultView.RowFilter = sb.ToString();

            }
        }
    }
}