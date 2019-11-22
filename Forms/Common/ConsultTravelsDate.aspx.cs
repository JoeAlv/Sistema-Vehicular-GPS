using System;
using System.Web.UI;

namespace WebVehicles.Forms.Common
{
    public partial class ConsultTravelsDate : System.Web.UI.Page
    {
        private LogTravels logtravels = new LogTravels();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];
            if (user.RoleID != 1)
            {
                Response.Redirect("404.aspx");
            }
            GridViewTravels.DataSource = logtravels.ListTravels();
            GridViewTravels.DataBind();
        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            DateTime Fecha1 = Convert.ToDateTime(TxtFechaInicio.Text);
            DateTime Fecha2 = Convert.ToDateTime(TxtFechaFinal.Text);
            GridViewTravels.DataSource = logtravels.ListTravelsDate(Fecha1, Fecha2);
            GridViewTravels.DataBind();

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 5, "El usuario a consultado la lista viajes por fecha", DateTime.Now);
            aux.Close();
        }

        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            DateTime Fecha1 = Convert.ToDateTime(TxtFechaInicio.Text);
            DateTime Fecha2 = Convert.ToDateTime(TxtFechaFinal.Text);

            Session["Formula"] = "{Travels.created_at} >= date(" + Fecha1.Year + "," + Fecha1.Month + "," + Fecha1.Day + ") And {Travels.created_at} <=date(" + Fecha2.Year + "," + Fecha2.Month + "," + Fecha2.Day + ")";
            Session["Reporte"] = "ReportTravelsDate.rpt";
            Session["Fecha1"] = Convert.ToDateTime(TxtFechaInicio.Text);
            Session["Fecha2"] = Convert.ToDateTime(TxtFechaFinal.Text);
            string _open = "window.open('ReportViewer.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a generado un reporte de viajes por fecha", DateTime.Now);
            aux.Close();
        }
    }
}