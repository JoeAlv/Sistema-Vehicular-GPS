using System;
using System.Web.UI;

namespace WebVehicles.Forms.Common
{
    public partial class ConsultVehiclesID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];
            if (user.RoleID != 1)
            {
                Response.Redirect("404.aspx");
            }
            LimpiarTexto();
        }

        protected void BtnBuscar_click(object sender, EventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            LogVehicles logvehicles = new LogVehicles();
            vehicle = logvehicles.FindVehicles(TxtVehicleID.Text);

            if (vehicle != null)
            {
                TxtType.Text = vehicle.type;
                TxtBrand.Text = vehicle.brand;
                TxtYear.Text = vehicle.year.Year.ToString();
                TxtEngine.Text = vehicle.engine;
                TxtTransmission.Text = vehicle.transmission;
                TxtFuel.Text = vehicle.fuel;
                TxtFuelTank.Text = vehicle.fueltank.ToString() + "gl";
                TxtConditionID.Text = vehicle.ConditionID.ToString();
            }
            else
            {
                Response.Write("<script>window.onload = function() {showMsg('El vehiculo " + TxtVehicleID.Text + " no se encuentra', 'warning', 2000);}</script>");
                LimpiarTexto();
            }
        }

        private void LimpiarTexto()
        {
            TxtType.Text = "[Tipo]";
            TxtBrand.Text = "[Marca]";
            TxtYear.Text = "[Modelo]";
            TxtEngine.Text = "[Motor]";
            TxtTransmission.Text = "[Transmisión]";
            TxtFuel.Text = "[Combustible]";
            TxtFuelTank.Text = "[Tanque]";
            TxtConditionID.Text = "[Estado]";
        }

        protected void BtnImprimir_click(object sender, EventArgs e)
        {
            Session["Formula"] = "{Vehicles.VehicleID} = '" + TxtVehicleID.Text + "'";
            Session["Reporte"] = "ReportVehiclesID.rpt";
            string _open = "window.open('ReportViewer.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a generado un reporte de vehiculo por placa", DateTime.Now);
            aux.Close();
        }
    }
}