namespace WindowsFormsApplication1
{
    partial class Sales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNetPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtunitprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlmodel = new System.Windows.Forms.ComboBox();
            this.btnsalesProduct = new System.Windows.Forms.Button();
            this.ddlbrand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlproduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbModelName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSalesId);
            this.groupBox1.Controls.Add(this.btnSalesReport);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNetPrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiscount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtunitprice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ddlmodel);
            this.groupBox1.Controls.Add(this.btnsalesProduct);
            this.groupBox1.Controls.Add(this.ddlbrand);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ddlproduct);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(35, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 323);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "(%)";
            // 
            // txtNetPrice
            // 
            this.txtNetPrice.Location = new System.Drawing.Point(358, 197);
            this.txtNetPrice.Name = "txtNetPrice";
            this.txtNetPrice.Size = new System.Drawing.Size(96, 20);
            this.txtNetPrice.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Net Price";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(358, 164);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(96, 20);
            this.txtQuantity.TabIndex = 15;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Sales Id";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(174, 201);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(76, 20);
            this.txtDiscount.TabIndex = 12;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Discount";
            // 
            // txtunitprice
            // 
            this.txtunitprice.Location = new System.Drawing.Point(174, 164);
            this.txtunitprice.Name = "txtunitprice";
            this.txtunitprice.Size = new System.Drawing.Size(97, 20);
            this.txtunitprice.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Unit Price";
            // 
            // ddlmodel
            // 
            this.ddlmodel.FormattingEnabled = true;
            this.ddlmodel.Location = new System.Drawing.Point(174, 125);
            this.ddlmodel.Name = "ddlmodel";
            this.ddlmodel.Size = new System.Drawing.Size(280, 21);
            this.ddlmodel.TabIndex = 8;
            this.ddlmodel.SelectedIndexChanged += new System.EventHandler(this.ddlmodel_SelectedIndexChanged);
            // 
            // btnsalesProduct
            // 
            this.btnsalesProduct.Location = new System.Drawing.Point(112, 282);
            this.btnsalesProduct.Name = "btnsalesProduct";
            this.btnsalesProduct.Size = new System.Drawing.Size(138, 23);
            this.btnsalesProduct.TabIndex = 7;
            this.btnsalesProduct.Text = "Submit";
            this.btnsalesProduct.UseVisualStyleBackColor = true;
            this.btnsalesProduct.Click += new System.EventHandler(this.btnAddPurchageProduct_Click);
            // 
            // ddlbrand
            // 
            this.ddlbrand.FormattingEnabled = true;
            this.ddlbrand.Location = new System.Drawing.Point(174, 92);
            this.ddlbrand.Name = "ddlbrand";
            this.ddlbrand.Size = new System.Drawing.Size(280, 21);
            this.ddlbrand.TabIndex = 6;
            this.ddlbrand.SelectedIndexChanged += new System.EventHandler(this.ddlbrand_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Model";
            // 
            // ddlproduct
            // 
            this.ddlproduct.FormattingEnabled = true;
            this.ddlproduct.Location = new System.Drawing.Point(174, 48);
            this.ddlproduct.Name = "ddlproduct";
            this.ddlproduct.Size = new System.Drawing.Size(280, 21);
            this.ddlproduct.TabIndex = 3;
            this.ddlproduct.SelectedIndexChanged += new System.EventHandler(this.ddlproduct_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "product Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brand Name";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(140, 92);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(144, 23);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Genarate Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Model Name";
            // 
            // cmbModelName
            // 
            this.cmbModelName.FormattingEnabled = true;
            this.cmbModelName.Location = new System.Drawing.Point(140, 43);
            this.cmbModelName.Name = "cmbModelName";
            this.cmbModelName.Size = new System.Drawing.Size(144, 21);
            this.cmbModelName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReport);
            this.groupBox2.Controls.Add(this.cmbModelName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(589, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 152);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reports";
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.Location = new System.Drawing.Point(316, 282);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(138, 23);
            this.btnSalesReport.TabIndex = 19;
            this.btnSalesReport.Text = "Sales Report";
            this.btnSalesReport.UseVisualStyleBackColor = true;
            this.btnSalesReport.Click += new System.EventHandler(this.btnSalesReport_Click);
            // 
            // txtSalesId
            // 
            this.txtSalesId.Location = new System.Drawing.Point(358, 243);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(96, 20);
            this.txtSalesId.TabIndex = 20;
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 711);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1016, 750);
            this.Name = "Sales";
            this.Text = "Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sales_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtunitprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlmodel;
        private System.Windows.Forms.Button btnsalesProduct;
        private System.Windows.Forms.ComboBox ddlbrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlproduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNetPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbModelName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.Button btnSalesReport;
    }
}