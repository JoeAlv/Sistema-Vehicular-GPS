using System;
using System.Web.UI;

namespace WebVehicles.Forms.Common
{
    public partial class ConsultUsersID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];
            if (user.RoleID != 1)
            {
                Response.Redirect("404.aspx");
            }
            LimpiarTexto();
        }

        protected void BtnBuscar_click(object sender, EventArgs e)
        {
     
            User user = new User();
            LogUsers logusers = new LogUsers();
            user = logusers.FindUsers(TxtUserID.Text);

            if (user != null) {
                TxtFullname.Text = user.name + " " + user.lastname;
                TxtEmail.Text = user.email;
                TxtPhone.Text = user.phone;
                TxtNationality.Text = user.nationality;
                TxtDateofborn.Text = user.dateofborn.ToShortDateString();
                TxtConditionID.Text = user.ConditionID.ToString();
                TxtRoleID.Text = user.RoleID.ToString();
                TxtDriverLicenseID.Text = user.DriverLicenseID.ToString();
            } else {
                Response.Write("<script>window.onload = function() {showMsg('El usuario "+ TxtUserID.Text + " no se encuentra', 'warning', 2000);}</script>");
                LimpiarTexto();
            }
        }

        private void LimpiarTexto()
        {
            TxtFullname.Text = "[Nombre completo]";
            TxtEmail.Text = "[Correo]";
            TxtPhone.Text = "[Telefono]";
            TxtNationality.Text = "[Nacionalidad]";
            TxtDateofborn.Text = "[Cumpleaños]";
            TxtConditionID.Text = "[Estado]";
            TxtRoleID.Text = "[Rol]";
            TxtDriverLicenseID.Text = "[Licencia de conducir]";
        }

        protected void BtnImprimir_click(object sender, EventArgs e)
        {
            Session["Formula"] = "{Users.UserID} = '" + TxtUserID.Text + "'";
            Session["Reporte"] = "ReportUsersID.rpt";
            string _open = "window.open('ReportViewer.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a generado un reporte de usuario por cédula", DateTime.Now);
            aux.Close();
        }
    }
}