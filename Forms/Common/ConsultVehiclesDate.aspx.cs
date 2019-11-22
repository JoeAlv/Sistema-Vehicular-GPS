using System;
using System.Web.UI;

namespace WebVehicles.Forms.Common
{
    public partial class ConsultVehiclesDate : System.Web.UI.Page
    {
        private LogVehicles logvehicles = new LogVehicles();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];
            if (user.RoleID != 1)
            {
                Response.Redirect("404.aspx");
            }
            GridViewVehicles.DataSource = logvehicles.ListVehicles();
            GridViewVehicles.DataBind();
        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            DateTime Fecha1 = Convert.ToDateTime(TxtFechaInicio.Text);
            DateTime Fecha2 = Convert.ToDateTime(TxtFechaFinal.Text);
            GridViewVehicles.DataSource = logvehicles.ListVehicleDate(Fecha1, Fecha2);
            GridViewVehicles.DataBind();

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a consultado la lista vehiculos por fecha", DateTime.Now);
            aux.Close();
        }

        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            DateTime Fecha1 = Convert.ToDateTime(TxtFechaInicio.Text);
            DateTime Fecha2 = Convert.ToDateTime(TxtFechaFinal.Text);

            Session["Formula"] = "{Vehicles.created_at} >= date(" + Fecha1.Year + "," + Fecha1.Month + "," + Fecha1.Day + ") And {Vehicles.created_at} <=date(" + Fecha2.Year + "," + Fecha2.Month + "," + Fecha2.Day + ")";
            Session["Reporte"] = "ReportVehiclesDate.rpt";
            Session["Fecha1"] = Convert.ToDateTime(TxtFechaInicio.Text);
            Session["Fecha2"] = Convert.ToDateTime(TxtFechaFinal.Text);
            string _open = "window.open('ReportViewer.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a generado un reporte de vehiculos por fecha", DateTime.Now);
            aux.Close();
        }
    }
}