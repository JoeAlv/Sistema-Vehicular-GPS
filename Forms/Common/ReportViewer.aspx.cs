using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreReporte = Convert.ToString(Session["Reporte"]);
            string stringFormula = Convert.ToString(Session["Formula"]);
            string ruta = "~/Reports/" + nombreReporte;

            ReportDocument document = new ReportDocument();
            document.Load(Server.MapPath(ruta));

            if (stringFormula.Length > 0)
            {
                CrystalReportViewer1.SelectionFormula = stringFormula;
            }
            CrystalReportViewer1.ReportSource = document;
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.RefreshReport();
        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }
    }
}