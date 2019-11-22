using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class AddTravel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];

            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void BtnBuscarU_Click(object sender, EventArgs e)
        {
            GetUser(inputUserID.Text);
        }

        protected void BtnBuscarV_Click(object sender, EventArgs e)
        {
            GetVehicle(inputVehicleID.Text);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesHabilitarBotones();
            inputUserID.Focus();
        }

        protected void BtnAddTravel_Click(object sender, EventArgs e)
        {
            User user = (User)Session["CurrentUser"];
            Travel travel = new Travel();
            travel.TravelID = 1;
            if (user.RoleID == 1)
            {
                travel.UserID = inputUserID.Text;
            }
            else {
                travel.UserID = user.UserID;
            }
            travel.VehicleID = inputVehicleID.Text;
            travel.ConditionID = Convert.ToInt32(inputConditionID.Text);
            travel.created_at = DateTime.Now;

            ReferenceWSTravel.IwcfTravelsClient travelClient = new ReferenceWSTravel.IwcfTravelsClient();
            travelClient.AddTravel(travel);
            travelClient.Close();

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 4, "El usuario a ingresado un viaje: " + travel.TravelID, DateTime.Now);
            aux.Close();

            Response.Write("<script>window.onload = function() {"
            + "showMsg('El viaje ha sido correctamente agregado: #" + travel.TravelID +", 'success', 3000);"
            + "}</script>");

            clearInputs();
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
                    inputName.Text = user.name + " " + user.lastname;
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('Se encontró correctamente este usuario ', 'success', 2000);"
                    + "}</script>");
                }
                else
                {
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('No se encontró este usuario ', 'warning', 2000);"
                    + "}</script>");
                    DesHabilitarBotones();
                }
            }
            else
            {
                Response.Write("<script>window.onload = function() {"
                    + "showMsg('Error al insertar la cédula del usuario', 'warning', 2000);"
                    + "}</script>");
                DesHabilitarBotones();
            }
        }

        private void GetVehicle(string VehicleID)
        {

            if (VehicleID != "")
            {
                ReferenceWSVehicle.IwcfVehiclesClient vehicleClient = new ReferenceWSVehicle.IwcfVehiclesClient();
                Vehicle vehicle = vehicleClient.FindVehicle(VehicleID);
                vehicleClient.Close();

                if (vehicle != null)
                {
                    inputBrand.Text = vehicle.brand;
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('Se encontró correctamente este vehiculo ', 'success', 2000);"
                    + "}</script>");
                    HabilitarBotones();
                }
                else
                {
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('No se encontró este vehiculo ', 'warning', 2000);"
                    + "}</script>");
                    DesHabilitarBotones();
                }
            }
            else
            {
                Response.Write("<script>window.onload = function() {"
                    + "showMsg('Error al insertar la placa del vehiculo', 'warning', 2000);"
                    + "}</script>");
                DesHabilitarBotones();
            }
        }

        private void HabilitarBotones()
        {
            BtnAddTravel.Enabled = true;
            BtnCancelar.Enabled = true;
        }

        private void DesHabilitarBotones()
        {
            BtnAddTravel.Enabled = true;
            BtnCancelar.Enabled = true;
        }

        private void clearInputs()
        {
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
    }
}