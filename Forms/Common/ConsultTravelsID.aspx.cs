using System;
using System.Data;
using System.Web.UI;

namespace WebVehicles.Forms.Common
{
    public partial class ConsultTravelsID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LimpiarTexto();
        }

        protected void BtnBuscarT_click(object sender, EventArgs e)
        {
            
            ReferenceWSTravel.IwcfTravelsClient travelClient = new ReferenceWSTravel.IwcfTravelsClient();
            Travel travel = travelClient.FindTravel(Convert.ToInt32(TxtTravelID.Text));
            travelClient.Close();

            if (travel != null)
            {
                TxtUserID.Text = travel.UserID;
                TxtVehicleID.Text = travel.VehicleID;
                TxtContidionID.Text = travel.ConditionID.ToString();
                TxtCreated_at.Text = travel.created_at.ToString("dd/MM/yyyy");

                //ReferenceWSLocation.IwcfLocationsClient locationClient = new ReferenceWSLocation.IwcfLocationsClient();
                LogLocations locationClient = new LogLocations();
                DataTable dt = locationClient.ListLocationsTravelID(travel.TravelID);
                travelClient.Close();

                GridViewLocationsTravelID.DataSource = dt;
                GridViewLocationsTravelID.DataBind();

                Response.Write("<script>window.onload = function() {showMsg('El viaje se ha encuentrado correctamente', 'success', 2000);}</script>");
            }
            else
            {
                Response.Write("<script>window.onload = function() {showMsg('El viaje " + TxtTravelID.Text + " no se encuentra', 'warning', 2000);}</script>");
                LimpiarTexto();
            }
        }

        private void LimpiarTexto()
        {
            TxtUserID.Text = "[Cédula del usuario]";
            TxtVehicleID.Text = "[Placa del vehiculo]";
            TxtContidionID.Text = "[Estado]";
            TxtCreated_at.Text = "[Ingreso]";
        }

        protected void BtnImprimir_click(object sender, EventArgs e)
        {

            Session["Formula"] = "{Travels.TravelID} = " + TxtTravelID.Text + "";
            Session["Reporte"] = "ReportTravelsID.rpt";
            string _open = "window.open('ReportViewer.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 2, "El usuario a generado un reporte de viajes por ID", DateTime.Now);
            aux.Close();
        }
    }
}