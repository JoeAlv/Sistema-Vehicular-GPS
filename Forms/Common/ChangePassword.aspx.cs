using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Change_click(object sender, EventArgs e)
        {
            btnChange.Enabled = false;
            string passwd = inputPW.Text;
            string confirm = inputCF.Text;
            if (passwd == confirm)
            {
                User userAux = (User)Session["AuxUser"];
                if (userAux != null)
                {
                    changePass(userAux, passwd);
                    Response.Redirect("Login.aspx");
                }

            }
            else {
                Response.Write("<script>window.onload = function() {"
                + "showMsg('Las contraseñas no coinciden', 'warning', 2000);"
                + "}</script>");
                btnChange.Enabled = true;
            }

        }

        private void changePass(User user, string pass)
        {
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.UpdatePassword(user, pass);
            aux.InsertUserLog(user.UserID, 2, "El usuario a realizado el cambio de contraseña", DateTime.Now);
            aux.Close();
        }
    }
}