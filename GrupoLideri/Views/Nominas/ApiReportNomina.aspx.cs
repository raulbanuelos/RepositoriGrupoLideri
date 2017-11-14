using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrupoLideri.Views.Nominas
{
    public partial class ApiReportNomina : ViewUserControl
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        RenderReport();
        //    }
        //}

        //protected void Page_init(object sender, EventArgs e)
        //{
        //    Context.Handler = Page;
        //}

        //private void RenderReport()
        //{
        //    appReportViewer.Reset();

        //    appReportViewer.LocalReport.EnableExternalImages = true;

        //    appReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/ReportNomina.rdlc");

        //    //If you want to add parameters to your can add below code.
        //    //appReportViewer.LocalReport.SetParameters(new ReportParameter("", ""));

        //    DataTable dtReportData = new DataTable();

        //    dtReportData = GetData();

        //    ReportDataSource rdc = new ReportDataSource("DataSet1", dtReportData);

        //    appReportViewer.LocalReport.DataSources.Add(rdc);

        //    appReportViewer.LocalReport.Refresh();

        //}

        //private DataTable GetData()
        //{
        //    DataTable result = new DataTable();

        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JudaPRDConnectionString"].ConnectionString);
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_GET_NOM_COMISIONES", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(result);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return result;
        //}
    }
}