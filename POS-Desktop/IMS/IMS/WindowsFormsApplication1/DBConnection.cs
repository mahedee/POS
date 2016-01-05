using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography;
//using CrystalDecisions.Shared;

namespace IMS
{
    static class DBConnection
    {
        public static string user=null;
        //public static int userID;
        public static string BranchCode=null;
        public static Bitmap BgImage=null;
        static AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
        static AutoCompleteStringCollection scM = new AutoCompleteStringCollection();
        static AutoCompleteStringCollection scPT = new AutoCompleteStringCollection();
       
        //public static int ht;
        //public static int wd;

        

        static DBConnection()
        {

            
        }

        public static bool CheckDeletePermissin(object obj, int UserID)
        {
            Form objj = (Form)obj;
            string strBool = "SELECT [Delete_Permission] FROM [pensiondb].[dbo].[User_Permission] where [Menu_Id]='" + ReturnDataSet("SELECT [Menu_Id] FROM [pensiondb].[dbo].[Menu_Table] where [Form_Name]='" + objj.Name + "'").Tables[0].Rows[0][0].ToString() + "' and [User_Id]='" + UserID + "'";
            return Convert.ToBoolean(ReturnDataSet(strBool).Tables[0].Rows[0][0].ToString());
        }

       


        public static Int64 SL_Number()
        {
            return Convert.ToInt64(ReturnDataSet("SELECT isnull(max([SL_No])+1,50000002) FROM [IMAS].[dbo].[ProductInformation]").Tables[0].Rows[0][0].ToString());
        }

        public static Int64 ReturnProductCode(string productName)
        {
            Int64 code;
            DataSet ds = ReturnDataSet("SELECT [ProductCode] FROM [IMAS].[dbo].[ProductName] where [ProductName]='"+productName+"'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                code = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                code = Convert.ToInt64(ReturnDataSet("SELECT isnull(max([ProductCode])+1,50002) FROM [IMAS].[dbo].[ProductName]").Tables[0].Rows[0][0].ToString());
                ExecuteCommand("insert into IMAS.dbo.ProductName (ProductCode,ProductName) values('"+code+"','"+productName+"')");
                AutoLoadProductName();

            }

            return code;
 
        }

        public static Int64 ReturnProductModelCode(string productModel)
        {
            Int64 code;
            DataSet ds = ReturnDataSet("SELECT [ModelCode] FROM [IMAS].[dbo].[ProductModel] where ProductModel.[ProductModelName]='" + productModel + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                code = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                code = Convert.ToInt64(ReturnDataSet("SELECT isnull(max([ModelCode])+1,10001) FROM [IMAS].[dbo].[ProductModel]").Tables[0].Rows[0][0].ToString());
                ExecuteCommand("insert into IMAS.dbo.ProductModel (ModelCode,[ProductModelName]) values('" + code + "','" + productModel + "')");
                AutoLoadProductModel();

            }

            return code;

        }


        public static Int64 ReturnProductAccontCode(string PaymentType)
        {
            Int64 code;
            DataSet ds = ReturnDataSet("SELECT [AccCode]FROM [IMAS].[dbo].[AccHead] where [AccName]='" + PaymentType + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                code = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                code = Convert.ToInt64(ReturnDataSet("SELECT isnull(max([AccCode])+1,101)FROM [IMAS].[dbo].[AccHead]").Tables[0].Rows[0][0].ToString());
                ExecuteCommand("insert into IMAS.dbo.AccHead (AccCode,AccName) values('" + code + "','" + PaymentType + "')");
                AutoLoadAccHead();

            }

            return code;

        }


        //public static void dbInfo()
        //{
        //    ConnectionInfo connInfo = new ConnectionInfo();
        //    connInfo.ServerName = ConfigurationManager.AppSettings["Server"];
        //    //connInfo.DatabaseName = ConfigurationManager.AppSettings.Get("DatabaseName").ToString();
        //    connInfo.UserID = ConfigurationManager.AppSettings["UserID"];
        //    connInfo.Password = ConfigurationManager.AppSettings["Password"].Replace("123", "ndr2013");
        //}
        private static string ErrorMessageViewText(Exception e)
        {
            return "Error: " + e.Message;
        }

        public static string conString()
        {
            //string strCon = "ConfigurationManager.ConnectionStrings["PCASpensiondbConnectionString"].ConnectionString";
            //string conn = strCon.Replace("123", "123");
            string conn = "";
            return conn;

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

       

       
        public static void ChangeDateFormat(DateTimePicker dateTimePicker, System.Windows.Forms.CheckBox checkBox = null, string str = "dd-MMM-yyyy")
        {
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = str;
                }
                else
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = " ";
                }
            }
            else
            {
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = str;
            }
        }

        #region Validation

        public static bool ValidateNullFieldCheck(Dictionary<object, string> dictionary)
        {
            foreach (var row in dictionary)
            {

                Type type = row.Key.GetType();
                switch (type.Name)
                {
                    case "TextBox":
                        var sTextBoxBase = (TextBoxBase)row.Key;
                        if (sTextBoxBase.Text == "")
                        {
                            MessageBox.Show(row.Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;

                        }
                        break;
                    case "DateTimePicker":
                        var sDateTimePicker = (DateTimePicker)row.Key;
                        if (sDateTimePicker.Text == " ")
                        {
                            MessageBox.Show(row.Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;

                        }
                        break;
                    case "ComboBox":
                        var sComboBox = (ComboBox)row.Key;
                        if (sComboBox.Text == "")
                        {
                            MessageBox.Show(row.Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;

                        }
                        break;

                }

            }
            return true;
        }

        public static bool CheckIntValueField(object obj)
        {
            var type = obj.GetType();
            switch (type.Name)
            {
                case "TextBox":
                    var sTextBoxBase = (TextBoxBase)obj;
                    if (sTextBoxBase.Text != "")
                    {
                        Int64 l;
                        if (!Int64.TryParse(sTextBoxBase.Text, out l))
                        {
                            MessageBox.Show(sTextBoxBase.Text + "  is not a valid input. Please enter a valid number.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    break;
            }
            return true;
        }

        public static bool CheckDecimalValueField(object obj)
        {
            var type = obj.GetType();
            switch (type.Name)
            {
                case "TextBox":
                    var sTextBoxBase = (TextBoxBase)obj;
                    if (sTextBoxBase.Text != "")
                    {
                        Decimal l;
                        if (!Decimal.TryParse(sTextBoxBase.Text, out l))
                        {
                            MessageBox.Show(sTextBoxBase.Text + "  is not a valid input. Please enter a valid Amount.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    break;
            }
            return true;
        }

        #endregion


        #region Focus

        public static void ChangeFocus(object objUp, object objDown,object objLeft,object objRight, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Enter:
                    FocusTransfer(objDown);
                    break;
                case Keys.Up:
                    FocusTransfer(objUp);
                    break;
                case Keys.Left:
                    FocusTransfer(objLeft);
                    break;
                case Keys.Right:
                    FocusTransfer(objRight);
                    break;
            }
        }

        private static void FocusTransfer(object obj)
        {
            if (obj == null)
            {
                return;
            }
            var type = obj.GetType();
            switch (type.Name)
            {
                case "TextBox":
                    var sTextBoxBase = (TextBoxBase)obj;
                    sTextBoxBase.Focus();
                    break;
                case "DateTimePicker":
                    var sDateTimePicker = (DateTimePicker)obj;
                    sDateTimePicker.Focus();
                    break;
                case "ComboBox":
                    var sComboBox = (ComboBox)obj;
                    sComboBox.Focus();
                    break;
                case "Button":
                    var sButton = (ButtonBase)obj;
                    sButton.Focus();
                    break;
            }
        }

        #endregion


       


        #region BranchInfo

        
        public static void AutoLoadProductName()
        {

            string selectQuery = "SELECT [ProductCode] ,[ProductName] FROM [IMAS].[dbo].[ProductName]";
            var ds = ReturnDataSet(selectQuery);
            //var ddl = (ComboBox)obj;
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sc.Add(dr[1].ToString());

                }

            }

        }

        public static void AutoLoadProductModel()
        {

            string selectQuery = "SELECT [ModelCode],[ProductModelName] FROM [IMAS].[dbo].[ProductModel]";
            var ds = ReturnDataSet(selectQuery);
            //var ddl = (ComboBox)obj;
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    scM.Add(dr[1].ToString());

                }

            }

        }

        public static void AutoLoadAccHead()
        {

            string selectQuery = "SELECT [AccCode],[AccName] FROM [IMAS].[dbo].[AccHead]";
            var ds = ReturnDataSet(selectQuery);
            //var ddl = (ComboBox)obj;
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    scPT.Add(dr[1].ToString());

                }

            }

        }

        public static void LoadAutoCompleteProductName(object obj)
        {
            var txt = (TextBox)obj;
            txt.AutoCompleteCustomSource = sc;
        }

        public static void LoadAutoCompleteProductModel(object obj)
        {
            var txt = (TextBox)obj;
            txt.AutoCompleteCustomSource = scM;
        }



        public static void LoadAutoCompleteAccHead(object obj)
        {
            var txt = (TextBox)obj;
            txt.AutoCompleteCustomSource = scPT;
        }
       

       

        #endregion

        #region MonthInfo

        public static void GeneratePaymentMonth()
        {

            string loadID = "SELECT ISNULL(max([Month_Code])+1,1) FROM [pensiondb].[dbo].[Month_Info]";

            string insertMonth = "if not exists(SELECT  [Month_Code] ,[Payment_Month] FROM [pensiondb].[dbo].[Month_Info] where  YEAR([Payment_Month]) = YEAR(GETDATE()) and MONTH([Payment_Month]) = MONTH(GETDATE())) Begin INSERT [dbo].[Month_Info] ([Month_Code], [Payment_Month]) VALUES ('" + DBConnection.ReturnDataSet(loadID).Tables[0].Rows[0][0].ToString() + "', datename(MONTH,GETDATE())+','+DATENAME(YEAR,GETDATE())) End";
            DBConnection.ExecuteCommand(insertMonth);


        }

       

       

      

        #endregion

        public static string EncodedData(string originalData)
        {
            byte[] originalBytes;
            byte[] encodedBytes;
            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalData);
            encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }

    }
}
