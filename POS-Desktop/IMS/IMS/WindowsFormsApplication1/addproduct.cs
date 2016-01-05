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
    public partial class addproduct : Form
    {
        public addproduct()
        {
            InitializeComponent();
        }

        private void addproduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iMSDataSet.product_name' table. You can move, or remove it, as needed.
            this.product_nameTableAdapter.Fill(this.iMSDataSet.product_name);

        }

        private void btnaddproduct_Click(object sender, EventArgs e)
        {
            string addproductcmd = "INSERT INTO [IMS].[dbo].[product_name] ([product_name]) VALUES ('" + txtproduct.Text.Trim() + "')";
            dbadmin.ExecuteCommand(addproductcmd);
            this.product_nameTableAdapter.Fill(this.iMSDataSet.product_name);
        }
    }
}
