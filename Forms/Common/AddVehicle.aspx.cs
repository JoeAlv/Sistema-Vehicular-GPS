using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class AddVehicle : System.Web.UI.Page
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

        protected void BtnAddVehicle_Click(object sender, EventArgs e)
        {
            ReferenceWSVehicle.IwcfVehiclesClient vehicleClient = new ReferenceWSVehicle.IwcfVehiclesClient();
            Vehicle Auxvehicle = vehicleClient.FindVehicle(inputVehicleID.Text);
            vehicleClient.Close();

            if (Auxvehicle == null)
            {
                Vehicle vehicle = new Vehicle();
                vehicle.VehicleID = inputVehicleID.Text;
                vehicle.type = inputType.Text;
                vehicle.brand = inputBrand.Text;
                vehicle.year = Convert.ToDateTime("01-01-" + inputYear.Text);
                vehicle.engine = inputEngine.Text;
                vehicle.transmission = inputTransmission.Text;
                vehicle.fuel = inputFuel.Text;
                vehicle.fueltank = Convert.ToInt32(inputFuelTank.Text);
                vehicle.created_at = Convert.ToDateTime(DateTime.Now);
                vehicle.ConditionID = Convert.ToInt32(inputConditionID.Text);

                try
                {
                    ReferenceWSVehicle.IwcfVehiclesClient vehicleClient2 = new ReferenceWSVehicle.IwcfVehiclesClient();
                    vehicleClient2.AddVehicle(vehicle);
                    vehicleClient2.Close();
                    Response.Write("<script>window.onload = function() {"
                + "showMsg('El vehiculo ha sido agregado', 'success', 4000);"
                + "}</script>");

                    User userAux = (User)Session["CurrentUser"];
                    ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
                    aux.InsertUserLog(userAux.UserID, 4, "El usuario a ingresado un vehiculo: " + vehicle.VehicleID, DateTime.Now);
                    aux.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('Error al intentar ingresar vehiculo', 'warning', 2000);"
                    + "}</script>");
                }
            }
            else {
                Response.Write("<script>window.onload = function() {"
           + "showMsg('La placa de este vehiculo ya se encuentra registrada', 'warning', 4000);"
           + "}</script>");
            }
            
           
            clearInputs();
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