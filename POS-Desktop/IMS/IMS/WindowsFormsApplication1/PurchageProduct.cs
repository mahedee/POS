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
    public partial class PurchageProduct : Form
    {
        public PurchageProduct()
        {
            InitializeComponent();
        }

        private void btnAddPurchageProduct_Click(object sender, EventArgs e)
        {


            string addbrandtcmd = string.Format("INSERT INTO [IMS].[dbo].[purchage_product] ([model_id],[purchage_price],[sales_price],[Total_Quantity]) VALUES ('{0}','{1}','{2}','{3}')", ddlmodel.SelectedValue, txtunitprice.Text.Trim(), txtsalesprice.Text.Trim(),txtTotalQuantity.Text.Trim());
            if(!dbadmin.ExecuteCommand(addbrandtcmd)) return;
            MessageBox.Show("Update successfully.");
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

        private void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (ddlproduct.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataTable dt = dbadmin.ReturnDataTable(string.Format("SELECT [brand_name_id],[brand_name] FROM [IMS].[dbo].[brand_name] where [product_name_id]='{0}'", ddlproduct.SelectedValue));
                dt.Rows.Add(0, "---Select Brand Name---");
                ddlbrand.DataSource = dt;
                ddlbrand.DisplayMember = "brand_name";
                ddlbrand.ValueMember = "brand_name_id";
                ddlbrand.Text = "---Select Brand Name---";
            }
        }

        private void PurchageProduct_Load(object sender, EventArgs e)
        {
            loadproduct();
        }

        private void ddlbrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlbrand.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataTable dt = dbadmin.ReturnDataTable(string.Format("SELECT [model_id],[model_name] FROM [IMS].[dbo].[model_name1] where product_name_id='{0}' and brand_name_id='{1}'", ddlproduct.SelectedValue, ddlbrand.SelectedValue));
                dt.Rows.Add(0, "---Select Model Name---");
                ddlmodel.DataSource = dt;
                ddlmodel.DisplayMember = "model_name";
                ddlmodel.ValueMember = "model_id";
                ddlmodel.Text = "---Select Brand Name---";
            }


        }


    }
}
