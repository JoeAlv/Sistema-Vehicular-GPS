using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];

            if (user != null)
            {
                if (user.RoleID != 1)
                {
                    Response.Redirect("404.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
           
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            clearInputs();
        }

        protected void BtnAddUser_Click(object sender, EventArgs e)
        {             
            User user = new User();
            user.UserID = inputUserID.Text;
            user.email = inputEmail.Text;
            user.passwd = "123cr456";
            user.remember_token = RandomToken();
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

            ReferenceWSUser.IwcfUsersClient userClient = new ReferenceWSUser.IwcfUsersClient();
            userClient.AddUser(user);
            userClient.Close();

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a ingresado al usuario " + user.UserID, DateTime.Now);
            aux.Close();

            Response.Write("<script>window.onload = function() {"
            + "showMsg('El usuario ha sido agregado', 'success', 4000);"
            + "}</script>");

            clearInputs();
        }

        private void clearInputs() {
            //Loop through all the control present on the web page/form        
            foreach (Control ctrl in form1.Controls)
            {
                //check for all the TextBox controls on the page and clear them
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)(ctrl)).Text = string.Empty;
                }
                //check for all the Label controls on the page and clear them
                else if (ctrl.GetType() == typeof(Label))
                {
                    ((Label)(ctrl)).Text = string.Empty;
                }
                //check for all the DropDownList controls on the page and reset it to the very first item e.g. "-- Select One --"
                else if (ctrl.GetType() == typeof(DropDownList))
                {
                    ((DropDownList)(ctrl)).SelectedIndex = 0;
                }
                //check for all the CheckBox controls on the page and unchecked the selection
                else if (ctrl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)(ctrl)).Checked = false;
                }
                //check for all the CheckBoxList controls on the page and unchecked all the selections
                else if (ctrl.GetType() == typeof(CheckBoxList))
                {
                    ((CheckBoxList)(ctrl)).ClearSelection();
                }
                //check for all the RadioButton controls on the page and unchecked the selection
                else if (ctrl.GetType() == typeof(RadioButton))
                {
                    ((RadioButton)(ctrl)).Checked = false;
                }
                //check for all the RadioButtonList controls on the page and unchecked the selection
                else if (ctrl.GetType() == typeof(RadioButtonList))
                {
                    ((RadioButtonList)(ctrl)).ClearSelection();
                }
            }
        }

        // Generate a random string with a given size
        private static string RandomToken()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();

            char ch;
            char nm;

            for (int i = 0; i < 15; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                nm = Convert.ToChar(Convert.ToInt32(Math.Floor(36 * random.NextDouble() + 55)));
                builder.Append(ch);
                builder.Append(nm);
            }
            return builder.ToString();
        }
    }
}