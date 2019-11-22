using System;

namespace WebVehicles.Forms.Common
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];

            if (user.RoleID != 1) {
                Response.Redirect("404.aspx");
            }
            DesHabilitarBotones();
            inputUserID.Focus();
        }

        protected void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserID = inputUserID.Text;
            user.email = inputEmail.Text;
            user.name = inputName.Text;
            user.lastname = inputLastname.Text;
            user.dateofborn = Convert.ToDateTime(inputDateofborn.Text);
            user.nationality = inputNationality.Text;
            user.phone = inputPhone.Text;
            user.created_at = Convert.ToDateTime(DateTime.Now);
            user.updated_at = Convert.ToDateTime(DateTime.Now);
            user.ConditionID = Convert.ToInt32(inputConditionID.Text);
            user.RoleID = Convert.ToInt32(inputRoleID.Text);
            user.DriverLicenseID = Convert.ToInt32(inputDriverLicenseID.Text);

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient userClient = new ReferenceWSUser.IwcfUsersClient();
            userClient.UpdateUser(user);
            userClient.InsertUserLog(userAux.UserID, 2, "El usuario a actualizado al usuario " + user.UserID, DateTime.Now);
            userClient.Close();

            Response.Write("<script>window.onload = function() {"
            + "showMsg('El usuario ha sido actualizado', 'success', 4000);"
            + "}</script>");
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesHabilitarBotones();
            inputUserID.Focus();
        }

        protected void BtnBuscar_click(object sender, EventArgs e)
        {
            GetUser(inputUserID.Text);
        }

        private void GetUser(string UserID)
        {

            if (UserID != "")
            {
                ReferenceWSUser.IwcfUsersClient userClient = new ReferenceWSUser.IwcfUsersClient();
                User user = userClient.FindUser(UserID);
                userClient.Close();

                if (user != null)
                {
                    inputName.Text = user.name;
                    inputLastname.Text = user.lastname;
                    inputEmail.Text = user.email;
                    inputPhone.Text = user.phone;
                    inputDateofborn.Text = user.dateofborn.ToString("dd/MM/yyyy");
                    inputNationality.SelectedValue = user.nationality;
                    inputConditionID.SelectedValue = user.ConditionID.ToString();
                    inputRoleID.SelectedValue = user.RoleID.ToString();
                    inputDriverLicenseID.SelectedValue = user.DriverLicenseID.ToString();

                    HabilitarBotones();
                }
            }
            else
            {
                DesHabilitarBotones();
            }
        }

        private void HabilitarBotones()
        {
            BtnUpdateUser.Enabled = true;
            BtnCancel.Enabled = true;
        }

        private void DesHabilitarBotones()
        {
            BtnUpdateUser.Enabled = true;
            BtnCancel.Enabled = true;
        }

    }
}