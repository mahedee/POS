using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication1
{
    static class dbadmin
    {

        public static string conString()
        {
            string strCon = @"Data Source=localhost;Initial Catalog=IMS;User ID=sa;Password=leads@123";
            string conn = strCon.Replace("123", "123");            
            return conn;

        }

        private static string ErrorMessageViewText(Exception e)
        {
            return "Error: " + e.Message;
        }

        public static bool ExecuteCommand(string strQuery)
        {
            try
            {
                //string strCon = ConfigurationManager.ConnectionStrings["PCASpensiondbConnectionString"].ConnectionString;

                var connection = new SqlConnection(conString());
                connection.Open();
                var sqlCommand = new SqlCommand(strQuery, connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(ErrorMessageViewText(e));
            }
            return false;
        }


        public static DataSet ReturnDataSet(string strQuery)
        {
            try
            {

                //string strCon = ConfigurationManager.ConnectionStrings["PCASpensiondbConnectionString"].ConnectionString;
                var connection = new SqlConnection(conString());
                connection.Open();
                var sqlCommand = new SqlCommand(strQuery, connection);
                var dataSet = new DataSet();
                var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
            catch (Exception e)
            {
                MessageBox.Show(ErrorMessageViewText(e));
            }

            return null;
        }


        public static DataTable ReturnDataTable(string strQuery)
        {
            try
            {
                //string strCon = ConfigurationManager.ConnectionStrings["PCASpensiondbConnectionString"].ConnectionString;
                var connection = new SqlConnection(conString());
                connection.Open();
                var sqlCommand = new SqlCommand(strQuery, connection);
                var datatable = new DataTable();
                var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(datatable);
                connection.Close();
                return datatable;
            }
            catch (Exception e)
            {
                MessageBox.Show(ErrorMessageViewText(e));
            }

            return null;
        }

    }
}
