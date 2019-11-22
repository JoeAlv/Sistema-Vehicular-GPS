using System;

namespace WebVehicles.Forms.Common
{
    public partial class Index : System.Web.UI.Page
    {
        private LogRoles logroles = new LogRoles();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            Role role = new Role();
            user = (User)Session["CurrentUser"];
            role = logroles.FindRole(user.RoleID);

            if (DateTime.Now.Hour < 12)
            {
                welcome.Text = "Buenos dias ";
            }
            else if (DateTime.Now.Hour < 18)
            {
                welcome.Text = "Buenas tardes ";
            }
            else
            {
                welcome.Text = "Buenas noches ";
            }
            welcome.Text += user.name + " " + user.lastname;

            // Rol Message
            rol.Text = role.title;
        }
    }
}