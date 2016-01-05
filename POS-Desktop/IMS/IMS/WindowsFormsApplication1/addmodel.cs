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
    public partial class addmodel : Form
    {
        public addmodel()
        {
            InitializeComponent();
        }

        private void loadproduct()
        {
            DataTable dt = dbadmin.ReturnDataTable("SELECT [product_name_id],[product_name] FROM [IMS].[dbo].[product_name]");
            dt.Rows.Add(0, "---Select Product Name---");
            ddlproduct.DataSource = dt;
            ddlproduct.DisplayMember = "product_name";
            ddlproduct.ValueMember = "product_name_id";
            ddlproduct.Text = "---Select Product Name---";
        }

        private void addmodel_Load(object sender, EventArgs e)
        {
            loadproduct();
        }

        private void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
            if (ddlproduct.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataTable dt = dbadmin.ReturnDataTable("SELECT [brand_name_id],[brand_name] FROM [IMS].[dbo].[brand_name] where [product_name_id]='" + ddlproduct.SelectedValue + "'");
                dt.Rows.Add(0,"---Select Brand Name---");
                ddlbrand.DataSource = dt;
                ddlbrand.DisplayMember = "brand_name";
                ddlbrand.ValueMember = "brand_name_id";
                ddlbrand.Text = "---Select Brand Name---";
            }
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            string addbrandtcmd = string.Format("INSERT INTO [IMS].[dbo].[model_name1] ([product_name_id],[brand_name_id],[model_name]) VALUES ('{0}','{1}','{2}')", ddlproduct.SelectedValue, ddlbrand.SelectedValue, textBox1.Text.Trim());
            if(!dbadmin.ExecuteCommand(addbrandtcmd)) return;
            MessageBox.Show("Model Update successfully.");
        }
    }
}
