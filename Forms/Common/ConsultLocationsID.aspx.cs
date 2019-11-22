using System;

namespace WebVehicles.Forms.Common
{
    public partial class ConsultLocationsID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LimpiarTexto();

        }

        protected void BtnBuscar_click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(TxtLocationID.Text);
            ReferenceWSLocation.IwcfLocationsClient locationClient = new ReferenceWSLocation.IwcfLocationsClient();
            Location location = locationClient.FindLocation(i);
            locationClient.Close();

            if (location != null)
            {
                inputName.Text = location.name;
                inputAddress.Text = location.address;
                inputLatitude.Text = location.latitude;
                inputLongitude.Text = location.longitude;
                TxtTravelID.Text = location.TravelID.ToString();
               
            }
            else
            {
                Response.Write("<script>window.onload = function() {showMsg('La localización " + TxtLocationID.Text + " no se encuentra', 'warning', 2000);}</script>");
                LimpiarTexto();
                
            }
        }

        private void LimpiarTexto()
        {
            //TxtTravelID.Text = "[ID Viaje]";
        }


    }
}