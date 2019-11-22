using System;
using System.Web.Services;

namespace WebVehicles.Forms.Common
{
    public partial class Vehicles : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["CurrentUser"];
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
          

        }

        protected void BtnDelVehicle_Click(object sender, EventArgs e)
        {
            int i = DeleteVehicle(inputVehicleID.Text);

            if (i == 1)
            {
                User userAux = (User)Session["CurrentUser"];
                ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
                aux.InsertUserLog(userAux.UserID, 3, "El usuario a eliminado al vehiculo: " + inputVehicleID.Text, DateTime.Now);
                aux.Close();

                Response.Write("<script>window.onload = function() {"
                + "showMsg('El vehiculo  fue correctamente eliminado', 'success', 3000);"
                + "}</script>");
            }
            else {
                Response.Write("<script>window.onload = function() {"
                + "showMsg('Error al intentar eliminar vehiculo', 'warning', 2000);"
                + "}</script>");
            }
            

        
        }
        public int DeleteVehicle(string VehicleID)
        {
            ReferenceWSVehicle.IwcfVehiclesClient vehicleClient = new ReferenceWSVehicle.IwcfVehiclesClient();
            int i = vehicleClient.DeleteVehicle(VehicleID);
            vehicleClient.Close();
            return i;
        }

    }
}

