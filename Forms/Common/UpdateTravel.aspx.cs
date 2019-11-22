using System;

namespace WebVehicles.Forms.Common
{
    public partial class UpdateTravel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];
            if (user.RoleID != 1)
            {
                Response.Redirect("404.aspx");
            }
            DesHabilitarBotones();
            inputTravelID.Focus();
        }

        protected void BtnBuscarT_Click(object sender, EventArgs e)
        {
            GetTravel(inputTravelID.Text);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesHabilitarBotones();
            inputVehicleID.Focus();
        }

        protected void BtnUpdateTravel_Click(object sender, EventArgs e)
        {
            Travel travelaux = (Travel)Session["CurrentTravel"];
            Travel travel = new Travel();

            travel.UserID = inputUserID.Text;
            travel.VehicleID = inputVehicleID.Text;
            travel.ConditionID = Convert.ToInt32(inputConditionID.Text);
            travel.created_at = travelaux.created_at;

            Session["CurrentTravel"] = null;

            ReferenceWSTravel.IwcfTravelsClient travelClient = new ReferenceWSTravel.IwcfTravelsClient();
            travelClient.UpdateTravel(travel);
            travelClient.Close();

            User userAux = (User)Session["CurrentUser"];
            ReferenceWSUser.IwcfUsersClient aux = new ReferenceWSUser.IwcfUsersClient();
            aux.InsertUserLog(userAux.UserID, 3, "El usuario a actualizado el viaje " + travel.VehicleID, DateTime.Now);
            aux.Close();

            Response.Write("<script>window.onload = function() {"
            + "showMsg('El viaje ha sido actualizado', 'success', 4000);"
            + "}</script>");
        }

        private void GetTravel(string TravelID)
        {

            if (TravelID != "")
            {
                ReferenceWSTravel.IwcfTravelsClient travelClient = new ReferenceWSTravel.IwcfTravelsClient();
                Travel travel = travelClient.FindTravel(Convert.ToInt32(TravelID));
                travelClient.Close();

                if (travel != null)
                {
                    Session["CurrentTravel"] = travel;
                    inputUserID.Text = travel.UserID;
                    inputVehicleID.Text = travel.VehicleID;
                    inputConditionID.SelectedValue = travel.ConditionID.ToString();


                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('El viaje ha sido encontrado', 'success', 3000);"
                    + "}</script>");
                    HabilitarBotones();
                }
                else {
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('El viaje no ha sido encontrado', 'warning', 2000);"
                    + "}</script>");
                    DesHabilitarBotones();
                }
            }
            else
            {
                Response.Write("<script>window.onload = function() {"
                + "showMsg('Error con el ID del viaje', 'warning', 2000);"
                + "}</script>");
                DesHabilitarBotones();
            }
        }

        private void HabilitarBotones()
        {
            BtnUpdateTravel.Enabled = true;
            BtnCancelar.Enabled = true;
        }

        private void DesHabilitarBotones()
        {
            BtnUpdateTravel.Enabled = true;
            BtnCancelar.Enabled = true;
        }
    }
}