using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_forget_click(object sender, EventArgs e)
        {
            string username = inputID.Text;
            Forget(username);
        }

        private void Forget(string identification)
        {
            try
            {
                User userAux = new User();
                ReferenceWSUser.IwcfUsersClient userClient = new ReferenceWSUser.IwcfUsersClient();
                userAux = userClient.FindUser(identification);
                userClient.Close();

                if (userAux != null)
                {
                    if (userAux.ConditionID == 1)
                    {
                        Session["AuxUser"] = userAux;
                        Response.Redirect("RecoveryPassword.aspx");
                    }
                    else if (userAux.ConditionID == 2)
                    {
                        Response.Write("<script>window.onload = function() {"
                        + "showMsg('El usuario se encuentra inactivo', 'warning', 4000);"
                        + "}</script>");
                    }
                    else if (userAux.ConditionID == 3)
                    {
                        Response.Write("<script>window.onload = function() {"
                        + "showMsg('El usuario se encuentra suspendido', 'warning', 4000);"
                        + "}</script>");
                    }

                }
                else
                {
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('El usuario es incorrecto', 'warning', 4000);"
                    + "}</script>");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Write("<script>window.onload = function() {"
                    + "showMsg('Error de Conexión!', 'danger', 4000).delay(2000);"
                    + "}</script>");
            }
        }
    }
}