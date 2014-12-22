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
        /// 绑定学期
        /// </summary>
        private void BindYearTerm()
        {
            r_YearTerm yearTerm = new r_YearTerm();
            //UIBase.BindComboBox(yearTerm.GetOnAllTerm(), cbYearTerm, "YearTermName", "YearTermID");
            cbYearTerm.SelectedValue = Utility.selectTerm;
        }
        /// <summary>
        /// 绑定开课单位
        /// </summary>
        private void BindDept()
        {
            r_Dept dept = new r_Dept();
            DataTable dt = dept.GetAllDept();
            DataRow dr = dt.NewRow();
            dr["DeptID"] = "100";
            dr["ADeptName"] = "全部";
            dt.Rows.InsertAt(dr, 0);
            //UIBase.BindComboBox(dt, cbDept, "ADeptName", "DeptID");
        }
        /// <summary>
        /// 绑定任务类型
        /// </summary>
        private void BindReupType()
        {
            DataTable dt = Utility.GetReupTypeDataTable();
            DataRow dr = dt.NewRow();
            dr["ReupTypeID"] = "100";
            dr["ReupTypeName"] = "全部";
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
                    if (dr["CourWeek"].ToString() == "" || dr["CourWeek"].ToString() == "0")//理论课程
                    {
                        dr["ReupTypeName"] = Utility.GetReupTypeNameByID(dr["ReupFlag"].ToString());
                        if ((dr["ReupTypeName"].ToString().IndexOf("开班重修") > -1) 
                            && Utility.IsNumeric(dr["TotalTime"].ToString().Trim()))//开班重修，上课只要求1/3学时
                        {
                            dr["CourInfo"] = "总学时：" + int.Parse(dr["TotalTime"].ToString().Trim()) / 3 + "（"+dr["ReupTypeName"].ToString()+"）";
                        }
                        else
                        {
                            dr["CourInfo"] = "总学时：" + dr["TotalTime"].ToString().Trim() + "、其中理论：" + dr["TheoTime"].ToString().Trim();
                            if (!(dr["ExpeTime"].ToString() == "" || dr["ExpeTime"].ToString() == "0"))
                                dr["CourInfo"] += "、实验：" + dr["ExpeTime"].ToString().Trim();
                            if (!(dr["MachTime"].ToString() == "" || dr["MachTime"].ToString() == "0"))
                                dr["CourInfo"] += "、上机：" + dr["MachTime"].ToString().Trim();
                        }
                    }
                    else//集中实践环节
                    {
                        dr["CourInfo"] = "周数：" + dr["CourWeek"].ToString() + "周、" + dr["TaskMemo"].ToString();
                    }
                }
                StringBuilder sb = new StringBuilder();                
                sb.Append("1=1 ");
                if (cbDept.SelectedValue.ToString() != "100")//全部系部
                {
                    sb.Append(" And DeptID='" + cbDept.SelectedValue.ToString() + "'");
                }
                if (cbReupType.SelectedValue.ToString() != "100")//全部任务
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