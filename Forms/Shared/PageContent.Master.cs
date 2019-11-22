using System;

namespace WebVehicles.Forms.Shared
{
    public partial class PageContent : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user = (User)Session["CurrentUser"];

                if (user != null)
                {
                    username.Text = user.UserID;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('Sesión no disponible', 'warning', 4000);"
                    + "}</script>");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("Login.aspx");
                Response.Write("<script>window.onload = function() {"
                + "showMsg('Error de sesión', 'danger', 4000);"
                + "}</script>");
            }
        }

        protected void Btn_signout_click(object sender, EventArgs e)
        {
            SignOut();
        }

        private void SignOut()
        {
            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 1, "El usuario a cerrado la sesión", DateTime.Now);
            aux.Close();

            Session["CurrentUser"] = null;
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

    }
}