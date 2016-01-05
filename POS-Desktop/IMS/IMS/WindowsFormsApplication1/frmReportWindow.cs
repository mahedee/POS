using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmReportWindow : Form
    {
        DataSet _ds = null;

        LocalReport report = new LocalReport();
        public frmReportWindow()
        {
            InitializeComponent();
        }

        private void frmReportWindow_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
        }

        public void LoadReport(int rptType, int _FormateType,int modelId)
        {

            try
            {
                DataSet rptDataSet = null;
                ReportDataSource rptDataSource = null;

                if (rptType == 1)
                {
                    rptDataSet = GetDataset(rptType, modelId);
                    rptDataSource = new ReportDataSource("ReportDS", rptDataSet.Tables[0]);
                    rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SalesReport.rdlc");
                }

                if (rptType == 2)
                {
                    rptDataSet = GetDataset(rptType, modelId);
                    rptDataSource = new ReportDataSource("ReportDS", rptDataSet.Tables[0]);
                    rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SalesReportById.rdlc");
                }
                

                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.DataSources.Add(rptDataSource);


                #region---Paper Size Setup

                PrinterSettings printerSetting = new PrinterSettings();
                IQueryable<PaperSize> paperSizes = printerSetting.PaperSizes.Cast<PaperSize>().AsQueryable();
                PaperSize A4 = paperSizes.Where(paperSize => paperSize.Kind == PaperKind.A4).FirstOrDefault();
                printerSetting.DefaultPageSettings.PaperSize = A4;
                rptViewer.PrinterSettings = printerSetting;

                #endregion


                #region --Display Mode Setup

                rptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                rptViewer.ZoomMode = ZoomMode.Percent;
                rptViewer.ZoomPercent = 100;


                #endregion



                DisableExportFormats(rptViewer);
                DisableUnwantedExportFormat(rptViewer, "PDF");

                //string Location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Upload\");

                //Byte[] mybytes = report.Render("PDF");
                //using (FileStream fs = File.Create(Location + ReportParameter.REPORT_NAME + ".pdf"))
                //{
                //    fs.Write(mybytes, 0, mybytes.Length);
                //}

                rptViewer.LocalReport.Refresh();


                //Process process = new Process();
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //process.StartInfo = startInfo;

                //startInfo.FileName = Location + ReportParameter.REPORT_NAME + ".pdf";
                //process.Start();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private DataSet GetDataset(int _rptType,int modelId)
        {
            _ds = new DataSet();
            string connectionString = @"Data Source=localhost;Initial Catalog=IMS;User ID=sa;Password=leads@123";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = null;


            try
            {
                if (_rptType == 1)
                {
                    cmd = new SqlCommand("spSales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@modelID", modelId);
                    con.Open(); 
                    cmd.ExecuteNonQuery();
                    cmd.CommandTimeout = 30000;
                }

                else if (_rptType == 2)
                {
                    cmd = new SqlCommand("rpt_sales_info_by_id", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@salesId", modelId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmd.CommandTimeout = 30000;
                }
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(_ds);
                con.Close();
            }
            catch
            {
                con.Close();
                SqlConnection.ClearAllPools();
            }
            return _ds;
        }
       
      
        public void DisableUnwantedExportFormat(ReportViewer ReportViewerID, string strFormatName)
        {
            FieldInfo info;

            foreach (RenderingExtension extension in ReportViewerID.LocalReport.ListRenderingExtensions())
            {
                if (extension.Name == strFormatName)
                {
                    info = extension.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
                    info.SetValue(extension, true);
                }
            }

        }

        public void DisableExportFormats(ReportViewer ReportViewerID)
        {
            FieldInfo info;

            foreach (RenderingExtension extension in ReportViewerID.LocalReport.ListRenderingExtensions())
            {
                info = extension.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
                info.SetValue(extension, false);
            }

        }
    }
}
