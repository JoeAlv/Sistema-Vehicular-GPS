using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_login_click(object sender, EventArgs e)
        {
            string username = inputID.Text;
            string password = inputPW.Text;
            Log_in(username, password);
        }

        private void Log_in(string identification, string password)
        {
            try
            {
                User user = new User();
                ReferenceWSUser.IwcfUsersClient userClient = new ReferenceWSUser.IwcfUsersClient();
                user = userClient.ValidateUser(identification, password);
                userClient.Close();

                if (user != null)
                {
                    if (user.ConditionID == 1)
                    {
                        Session["CurrentUser"] = user;
                        Session["Imsg"] = 0;
                        ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
                        aux.InsertUserLog(user.UserID, 1,"El usuario a inicializado una sesión",DateTime.Now);
                        aux.Close();
                        Response.Redirect("Index.aspx");
                    }
                    else if (user.ConditionID == 2)
                    {
                        Response.Write("<script>window.onload = function() {"
                        + "showMsg('El usuario se encuentra inactivo', 'warning', 4000);"
                        + "}</script>");
                    }
                    else if (user.ConditionID == 3)
                    {
                        Response.Write("<script>window.onload = function() {"
                        + "showMsg('El usuario se encuentra suspendido', 'warning', 4000);"
                    + "}</script>");
                    }
                    
                } else {
                    Response.Write("<script>window.onload = function() {"
                        + "showMsg('El usuario y/o la contraseña son incorrectos', 'warning', 4000);"
                    + "}</script>");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
                Response.Write("<script>window.onload = function() {"
                    + "showMsg('Error de Conexión!', 'danger', 4000).delay(2000);"
                    + "}</script>");
            }
        }
    }
}