using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class AddLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["CurrentUser"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(inputTravelID.Text);
            GetTravel(id);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesHabilitarBotones();
            inputTravelID.Focus();

        }

        protected void BtnAddLocation_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.name = inputName.Text;
            location.address = inputAddress.Text;
            location.latitude = inputLatitude.Text;
            location.longitude = inputLongitude.Text;
            location.TravelID = Convert.ToInt32(inputTravelID.Text);

            ReferenceWSLocation.IwcfLocationsClient locationClient = new ReferenceWSLocation.IwcfLocationsClient();
            locationClient.AddLocation(location);
            locationClient.Close();

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 4, "El usuario a ingresado una localización al viaje: " + location.TravelID, DateTime.Now);
            aux.Close();

            Response.Write("<script>window.onload = function() {"
            + "showMsg('La localización ha sido correctamente agregada', 'success', 3000);"
            + "}</script>");

            clearInputs();
        }

        private void GetTravel(int TravelID)
        {

            if (TravelID > 0)
            {
                
                ReferenceWSTravel.IwcfTravelsClient travelClient = new ReferenceWSTravel.IwcfTravelsClient();
                Travel travel = travelClient.FindTravel(TravelID);
                travelClient.Close();

                if (travel != null)
                {
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('Se encontró correctamente este viaje ', 'success', 2000);"
                    + "}</script>");
                    HabilitarBotones();
                } else
                {
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('No se encontró este viaje ', 'warning', 2000);"
                    + "}</script>");
                    DesHabilitarBotones();
                }
            }
            else
            {
                Response.Write("<script>window.onload = function() {"
                    + "showMsg('Error al insertar el Id del Viaje', 'warning', 2000);"
                    + "}</script>");
                DesHabilitarBotones();
            }
        }

        private void HabilitarBotones()
        {
            BtnAddLocation.Enabled = true;
            BtnCancelar.Enabled = true;
        }

        private void DesHabilitarBotones()
        {
            BtnAddLocation.Enabled = true;
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