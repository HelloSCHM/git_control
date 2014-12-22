using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace MyPlayers
{
    public static class C_SqlOper
    {
        private static string aSqlConnPath = Application.StartupPath + "\\PlagyInfo";
        private static SQLiteConnection aSqlConn = null;

        private static bool InitSqlConnOpen()
        {
            try
            {
                if (aSqlConn == null)
                    aSqlConn = new SQLiteConnection();

                if (aSqlConn.State == ConnectionState.Open)
                    return true;

                aSqlConn.ConnectionString = "data source=" + aSqlConnPath + ";password=lymegg";
                aSqlConn.Open();
            }
            catch (Exception Err)
            {
                MessageBox.Show("连接信息数据出错！\n" + Err.Message, "提示");
                return false;
            }

            if (aSqlConn.State != ConnectionState.Open)
                return false;

            return true;
        }

        private static bool CloseConn()
        {
            if (aSqlConn == null)
                return true;

            if (aSqlConn.State == ConnectionState.Open)
            {
                aSqlConn.Close();
            }

            return true;
        }

        public static bool SeleData(string SqlStr,ref DataTable AdapDateTable)
        {
            if (InitSqlConnOpen() == false)
                return false;

            AdapDateTable.Clear();
            SQLiteDataAdapter iSqliteAdapData = new SQLiteDataAdapter(SqlStr, aSqlConn);
            try
            {
                iSqliteAdapData.Fill(AdapDateTable);
            }
            catch (Exception Err)
            {
                MessageBox.Show("查询数据信息出错！\n" + Err.Message, "提示");
                return false;
            }
            finally
            {
                if (iSqliteAdapData != null)
                    iSqliteAdapData.Dispose();

                CloseConn();
            }

            return true;
        }

        public static bool OperData(string SqlStr)
        {
            if (InitSqlConnOpen() == false)
                return false;

            SQLiteCommand iSqliteComm = new SQLiteCommand(SqlStr, aSqlConn);
            try
            {
                iSqliteComm.ExecuteNonQuery();
            }
            catch (Exception Err)
            {
                MessageBox.Show("操作数据信息出错！\n" + Err.Message, "提示");
                return false;
            }
            finally
            {
                if (iSqliteComm != null)
                    iSqliteComm.Dispose();

                CloseConn();
            }

            return true;
        }

        public static object SeleDataObj(string SqlStr,bool IsCloseConn)
        {
            if (InitSqlConnOpen() == false)
                return null;

            SQLiteCommand iSqliteComm = new SQLiteCommand(SqlStr, aSqlConn);
            object iRetObj = null;
            try
            {
                iRetObj = iSqliteComm.ExecuteScalar();
            }
            catch (Exception Err)
            {
                MessageBox.Show("操作数据信息出错！\n" + Err.Message, "提示");
                return null;
            }
            finally
            {
                if (iSqliteComm != null)
                    iSqliteComm.Dispose();

                if (IsCloseConn)
                    CloseConn();
            }

            return iRetObj;
        }

        public static object SeleDataObj(string SqlStr)
        {
            return SeleDataObj(SqlStr, true);
        }
    }
}
