using System;

namespace WebVehicles.Forms.Common
{
    public partial class UpdateVehicle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];

            if (user.RoleID != 1) {
                Response.Redirect("404.aspx");
            }

            DesHabilitarBotones();
            inputVehicleID.Focus();
        }

        protected void BtnBuscar_click(object sender, EventArgs e)
        {
            GetVehicle(inputVehicleID.Text);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesHabilitarBotones();
            inputVehicleID.Focus();
        }

        protected void BtnUpdateVehicle_Click(object sender, EventArgs e)
        {
            Vehicle vehicleAux = (Vehicle)Session["CurrentVehicle"];
            Vehicle vehicle = new Vehicle();

            vehicle.VehicleID = inputVehicleID.Text;
            vehicle.type = inputType.Text;
            vehicle.brand = inputBrand.Text;
            vehicle.year = Convert.ToDateTime(inputYear.Text);
            vehicle.engine = inputEngine.Text;
            vehicle.transmission = inputTransmission.Text;
            vehicle.fuel = inputFuel.Text;
            vehicle.fueltank = Convert.ToInt32(inputFuelTank.Text);
            vehicle.created_at = vehicleAux.created_at;
            vehicle.ConditionID = Convert.ToInt32(inputConditionID.Text);

            Session["CurrentVehicle"] = null;

            ReferenceWSVehicle.IwcfVehiclesClient vehicleClient = new ReferenceWSVehicle.IwcfVehiclesClient();
            vehicleClient.UpdateVehicle(vehicle);
            vehicleClient.Close();

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 3, "El usuario a actualizado al vehiculo " + vehicle.VehicleID, DateTime.Now);
            aux.Close();

            Response.Write("<script>window.onload = function() {"
            + "showMsg('El vehiculo ha sido actualizado', 'success', 4000);"
            + "}</script>");
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
                    Session["CurrentVehicle"] = vehicle;
                    inputVehicleID.Text = vehicle.VehicleID;
                    inputType.SelectedValue = vehicle.type;
                    inputBrand.SelectedValue = vehicle.brand;
                    inputYear.Text = vehicle.year.ToString("dd/MM/yyyy");
                    inputEngine.SelectedValue = vehicle.engine;
                    inputTransmission.SelectedValue = vehicle.transmission;
                    inputFuel.SelectedValue = vehicle.fuel;
                    inputFuelTank.Text = vehicle.fueltank.ToString();
                    inputConditionID.SelectedValue = vehicle.ConditionID.ToString();

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
            BtnUpdateVehicle.Enabled = true;
            BtnCancel.Enabled = true;
        }

        private void DesHabilitarBotones()
        {
            BtnUpdateVehicle.Enabled = true;
            BtnCancel.Enabled = true;
        }
    }
}