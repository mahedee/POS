using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class addbrand : Form
    {
        public addbrand()
        {
            InitializeComponent();
        }

        private void addbrand_Load(object sender, EventArgs e)
        {
            loadproduct();
        }

        private void loadproduct()
        {
            DataTable dt=dbadmin.ReturnDataTable("SELECT [product_name_id],[product_name] FROM [IMS].[dbo].[product_name]");
            dt.Rows.Add(0,"---Select Product Name---");
            ddlproduct.DataSource = dt;
            ddlproduct.DisplayMember = "product_name";
            ddlproduct.ValueMember = "product_name_id";
            ddlproduct.Text = "---Select Product Name---";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string addbrandtcmd = string.Format("INSERT INTO [IMS].[dbo].[brand_name] ([brand_name],[product_name_id]) VALUES ('{0}',{1})", txtbrand.Text.Trim(),ddlproduct.SelectedValue);
            dbadmin.ExecuteCommand(addbrandtcmd);
        }
    }
}
