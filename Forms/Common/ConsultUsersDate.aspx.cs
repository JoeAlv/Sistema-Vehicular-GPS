using System;
using System.Web.UI;

namespace WebVehicles.Forms.Common
{
    public partial class ConsultUsersDate : System.Web.UI.Page
    {
        private LogUsers logusers = new LogUsers();
        protected void Page_Load(object sender, EventArgs e)
        {

            User user = new User();
            user = (User)Session["CurrentUser"];
            if (user.RoleID != 1)
            {
                Response.Redirect("404.aspx");
            }
            if (!Page.IsPostBack)
            {
                GridViewUsers.DataSource = logusers.ListUser();
                GridViewUsers.DataBind();
            }
        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            DateTime Fecha1 = Convert.ToDateTime(TxtFechaInicio.Text);
            DateTime Fecha2 = Convert.ToDateTime(TxtFechaFinal.Text);
            GridViewUsers.DataSource = logusers.ListUserDate(Fecha1, Fecha2);
            GridViewUsers.DataBind();

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a consultado la lista usuarios por fecha", DateTime.Now);
            aux.Close();
        }

        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            DateTime Fecha1 = Convert.ToDateTime(TxtFechaInicio.Text);
            DateTime Fecha2 = Convert.ToDateTime(TxtFechaFinal.Text);

            //Session["Formula"] = "{Users.created_at} = '" + TxtFechaInicio.Text + " 00:00' ";
            Session["Formula"] = "{Users.created_at} >= date("+Fecha1.Year+","+Fecha1.Month+","+Fecha1.Day+ ") And {Users.created_at} <=date(" + Fecha2.Year + "," + Fecha2.Month + "," + Fecha2.Day + ")";
            //Session["Formula"] = "{Users.created_at} <='" + TxtFechaInicio.Text + "' And {Users.created_at} >='" + TxtFechaFinal.Text + "'";
            Session["Reporte"] = "ReportUsersDate.rpt";
            Session["Fecha1"] = Convert.ToDateTime(TxtFechaInicio.Text);
            Session["Fecha2"] = Convert.ToDateTime(TxtFechaFinal.Text);
            string _open = "window.open('ReportViewer.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a generado un reporte de usuarios por fecha", DateTime.Now);
            aux.Close();
        }
    }
}