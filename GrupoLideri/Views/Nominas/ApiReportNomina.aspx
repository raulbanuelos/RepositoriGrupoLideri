<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApiReportNomina.aspx.cs" Inherits="GrupoLideri.Views.Nominas.ApiReportNomina" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderReport();
            }
        }

        private void RenderReport()
        {
            appReportViewer.Reset();

            appReportViewer.LocalReport.EnableExternalImages = true;

            appReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/ReportNomina.rdlc");

            System.Data.DataTable dtReportData = new System.Data.DataTable();

            dtReportData = GetData();

            ReportDataSource rdc = new ReportDataSource("DataSet1", dtReportData);

            appReportViewer.LocalReport.DataSources.Add(rdc);

            appReportViewer.LocalReport.Refresh();
        }

        private System.Data.DataTable GetData()
        {
            System.Data.DataTable result = new System.Data.DataTable();

            System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["JudaPRDConnectionString"].ConnectionString);

            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SP_GET_NOM_COMISIONES", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);
                adapter.Fill(result);

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="false" />

        <rsweb:ReportViewer ID="appReportViewer" runat="server" BackColor="White" Height="1200px" Width="951" ZoomMode="PageWidth" BorderColor="White" AsyncRendering="false" ShowExportControls="false">

        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
