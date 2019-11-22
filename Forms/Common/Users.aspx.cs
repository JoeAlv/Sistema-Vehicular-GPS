using System;
using System.Web.Services;

namespace WebVehicles.Forms.Common
{
    public partial class Users : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["CurrentUser"];
            if(user!=null)  {
               if (user.RoleID != 1) {
                    Response.Redirect("404.aspx");
                }
            } else {
                Response.Redirect("Login.aspx");
            }
        }


        protected void BtnDelUser_Click(object sender, EventArgs e)
        {
            if (DeleteUser(inputUserID.Text))
            {
                User userAux = (User)Session["CurrentUser"];
                ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
                aux.InsertUserLog(userAux.UserID, 2, "El usuario a eliminado al usuario: " + inputUserID.Text, DateTime.Now);
                aux.Close();

                Response.Write("<script>window.onload = function() {"
                + "showMsg('El usuario fue correctamente eliminado', 'success', 3000);"
                + "}</script>");
            }
            else
            {
                Response.Write("<script>window.onload = function() {"
                + "showMsg('Error al intentar eliminar usuario', 'warning', 2000);"
                + "}</script>");
            }



        }
        public bool DeleteUser(string UserID)
        {
            try {
                ReferenceWSUser.IwcfUsersClient userClient = new ReferenceWSUser.IwcfUsersClient();
                userClient.DeleteUser(UserID);
                userClient.Close();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return false;
            }
            
        }

    }
}