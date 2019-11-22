using System;

namespace WebVehicles.Forms.Common
{
    public partial class Travels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnDelTravel_Click(object sender, EventArgs e)
        {
            if (DeleteTravel(Convert.ToInt32(inputTravelID.Text)))
            {
                User userAux = (User)Session["CurrentUser"];
                ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
                aux.InsertUserLog(userAux.UserID, 2, "El usuario a eliminado el viaje: " + inputTravelID.Text, DateTime.Now);
                aux.Close();

                Response.Write("<script>window.onload = function() {"
                + "showMsg('El viaje fue correctamente eliminado', 'success', 3000);"
                + "}</script>");
            }
            else
            {
                Response.Write("<script>window.onload = function() {"
                + "showMsg('Error al intentar eliminar usuario', 'warning', 2000);"
                + "}</script>");
            }



        }
        public bool DeleteTravel(int TravelID)
        {
            try
            {
                ReferenceWSTravel.IwcfTravelsClient travelClient = new ReferenceWSTravel.IwcfTravelsClient();
                travelClient.DeleteTravel(TravelID);
                travelClient.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }
    }
}