using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmSalesReport : Form
    {
        DataSet _ds = null;

        LocalReport report = new LocalReport();
        public frmSalesReport()
        {
            InitializeComponent();
        }

        private void frmReportWindow_Load(object sender, EventArgs e)
        {

            this.rptViewerSales.RefreshReport();
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
                    rptDataSource = new ReportDataSource("DSSales", rptDataSet.Tables[0]);
                    rptViewerSales.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SalesReportById.rdlc");
                }

                rptViewerSales.LocalReport.DataSources.Clear();
                rptViewerSales.LocalReport.DataSources.Add(rptDataSource);


                #region---Paper Size Setup

                PrinterSettings printerSetting = new PrinterSettings();
                IQueryable<PaperSize> paperSizes = printerSetting.PaperSizes.Cast<PaperSize>().AsQueryable();
                PaperSize A4 = paperSizes.Where(paperSize => paperSize.Kind == PaperKind.A4).FirstOrDefault();
                printerSetting.DefaultPageSettings.PaperSize = A4;
                rptViewerSales.PrinterSettings = printerSetting;

                #endregion


                #region --Display Mode Setup

                rptViewerSales.SetDisplayMode(DisplayMode.PrintLayout);
                rptViewerSales.ZoomMode = ZoomMode.Percent;
                rptViewerSales.ZoomPercent = 100;


                #endregion



                DisableExportFormats(rptViewerSales);
                DisableUnwantedExportFormat(rptViewerSales, "PDF");

                //string Location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Upload\");

                //Byte[] mybytes = report.Render("PDF");
                //using (FileStream fs = File.Create(Location + ReportParameter.REPORT_NAME + ".pdf"))
                //{
                //    fs.Write(mybytes, 0, mybytes.Length);
                //}

                rptViewerSales.LocalReport.Refresh();


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


        private DataSet GetDataset(int _rptType,int salesId)
        {
            _ds = new DataSet();
            string connectionString = @"Data Source=localhost;Initial Catalog=IMS;User ID=sa;Password=leads@123";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("rpt_sales_info_by_id", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (_rptType == 1)
                {
                    cmd.Parameters.AddWithValue("@salesId", salesId);
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
