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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
            LoadModel();
        }
        private void LoadModel()
        {
            DataTable dt = dbadmin.ReturnDataTable(string.Format("SELECT [model_id],[model_name] FROM [IMS].[dbo].[model_name1] "));
            dt.Rows.Add(0, "---Select Model Name---");
            cmbModelName.DataSource = dt;
            cmbModelName.DisplayMember = "model_name";
            cmbModelName.ValueMember = "model_id";
            cmbModelName.Text = "---Select Model Name---";
            cmbModelName.SelectedValue = 0;
        }
        private void Sales_Load(object sender, EventArgs e)
        {
            loadproduct();
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
            if (ddlproduct.SelectedValue.ToString() != "System.Data.DataRowView" && ddlproduct.Text != "---Select Product Name---")
            {
                DataTable dt = dbadmin.ReturnDataTable(string.Format("SELECT [brand_name_id],[brand_name] FROM [IMS].[dbo].[brand_name] where [product_name_id]='{0}'", ddlproduct.SelectedValue));
                dt.Rows.Add(0, "---Select Brand Name---");
                ddlbrand.DataSource = dt;
                ddlbrand.DisplayMember = "brand_name";
                ddlbrand.ValueMember = "brand_name_id";
                ddlbrand.Text = "---Select Brand Name---";
            }
        }

        private void ddlbrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlbrand.SelectedValue.ToString() != "System.Data.DataRowView" && ddlbrand.Text != "---Select Brand Name---")
            {
                DataTable dt = dbadmin.ReturnDataTable(string.Format("SELECT [model_id],[model_name] FROM [IMS].[dbo].[model_name1] where product_name_id='{0}' and brand_name_id='{1}'", ddlproduct.SelectedValue, ddlbrand.SelectedValue));
                dt.Rows.Add(0, "---Select Model Name---");
                ddlmodel.DataSource = dt;
                ddlmodel.DisplayMember = "model_name";
                ddlmodel.ValueMember = "model_id";
                ddlmodel.Text = "---Select Model Name---";
                ddlmodel.SelectedValue = 0;
            }
        }

        private string saleID()
        {
            return dbadmin.ReturnDataSet("SELECT isnull(max([sale_id])+1,1) FROM [IMS].[dbo].[salesinfo]").Tables[0].Rows[0][0].ToString();
        }

        private void btnAddPurchageProduct_Click(object sender, EventArgs e)
        {

            if ((Convert.ToDecimal(dbadmin.ReturnDataSet(string.Format("SELECT isnull(sum([Total_Quantity]),0) FROM [IMS].[dbo].[purchage_product] where model_id='{0}'", ddlmodel.SelectedValue)).Tables[0].Rows[0][0]) - Convert.ToDecimal(dbadmin.ReturnDataSet(string.Format("SELECT isnull(sum([quantity]),0) FROM [IMS].[dbo].[salesinfo] where model_id='{0}'", ddlmodel.SelectedValue)).Tables[0].Rows[0][0])) > 0)
            {
                string addbrandtcmd = string.Format("INSERT INTO [IMS].[dbo].[salesinfo] ([sale_id],[model_id],[discount],[quantity],[netprice]) VALUES ('{0}','{1}','{2}','{3}','{4}')", saleID(), ddlmodel.SelectedValue, ((txtDiscount.Text.Trim() == "") ? "0" : txtDiscount.Text.Trim()), ((txtQuantity.Text.Trim() == "") ? "0" : txtQuantity.Text.Trim()), ((txtNetPrice.Text.Trim() == "") ? "0" : txtNetPrice.Text.Trim()));
                if (!dbadmin.ExecuteCommand(addbrandtcmd)) return;
                MessageBox.Show("Update successfully.");
            }
            else
            {
                MessageBox.Show("Number of quantity is higher than available quantity");
            }

        }

        private void ddlmodel_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlmodel.SelectedValue.ToString() != "System.Data.DataRowView" && ddlmodel.Text != "---Select Model Name---")
            {

                DataSet ds = dbadmin.ReturnDataSet(string.Format("SELECT [model_id],[sales_price],[Total_Quantity] FROM [IMS].[dbo].[purchage_product] where model_id='{0}'", ddlmodel.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtunitprice.Text = ds.Tables[0].Rows[0][1].ToString();
                }
            }

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            netaount();
        }

        private void netaount()
        {
            if (txtQuantity.Text.Trim() != "")
            {
                txtNetPrice.Text = Convert.ToString(Convert.ToDecimal(txtunitprice.Text.Trim()) * Convert.ToDecimal(txtQuantity.Text.Trim()));
            }
            else
            {
                txtNetPrice.Text = "";
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Trim() != "")
            {
                txtNetPrice.Text = Convert.ToString(Convert.ToDecimal(txtunitprice.Text.Trim()) * Convert.ToDecimal(txtQuantity.Text.Trim()) - Convert.ToDecimal(txtunitprice.Text.Trim()) * Convert.ToDecimal(txtQuantity.Text.Trim()) * Convert.ToDecimal(txtDiscount.Text.Trim()) / 100);
            }
            else
            {
                netaount();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            int modelId = cmbModelName.SelectedItem != "" ? Convert.ToInt32(cmbModelName.SelectedValue) : 0;
           frmReportWindow frm=new frmReportWindow();
           frm.LoadReport(1, 1, modelId);
           frm.Show();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            int salesid = 0;
            if(!String.IsNullOrEmpty(this.txtSalesId.Text))
            {
                salesid = Convert.ToInt32(this.txtSalesId.Text);
            }


            //int modelId = cmbModelName.SelectedItem != "" ? Convert.ToInt32(cmbModelName.SelectedValue) : 0;
            frmReportWindow frm = new frmReportWindow();
            frm.LoadReport(2, 1, salesid);
            frm.Show();

        }
       


    }
}
