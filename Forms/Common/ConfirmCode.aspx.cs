using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class ConfirmCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User userAux = (User)Session["AuxUser"];
            if (userAux != null)
            {
                LblName.Text = userAux.name + " " + userAux.lastname;
            }
        }

     

        protected void Btn_confirm_click(object sender, EventArgs e)
        {
            string code = inputCode.Text;
            Confirm(code);
        }

        private void Confirm(string code)
        {
            try
            {
                User userAux = (User)Session["AuxUser"];
                string codeAux = (String)Session["AuxToken"];

                if (userAux != null)
                {
                    if (userAux.ConditionID == 1)
                    {
                        if (code == codeAux)
                        {
                            Response.Redirect("ChangePassword.aspx");
                        }
                        else
                        {
                            Response.Write("<script>window.onload = function() {"
                            + "showMsg('Los códigos no coinciden', 'warning', 2000);"
                            + "}</script>");
                        }
                    }
                    else if (userAux.ConditionID == 2)
                    {
                        Response.Write("<script>window.onload = function() {"
                        + "showMsg('El usuario se encuentra inactivo', 'warning', 2000);"
                        + "}</script>");
                    }
                    else if (userAux.ConditionID == 3)
                    {
                        Response.Write("<script>window.onload = function() {"
                        + "showMsg('El usuario se encuentra suspendido', 'warning', 2000);"
                        + "}</script>");
                    }

                }
                else
                {
                    Response.Write("<script>window.onload = function() {"
                    + "showMsg('El usuario incorrecto', 'warning', 2000);"
                    + "}</script>");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Write("<script>window.onload = function() {"
                + "showMsg('Error de Conexión!', 'danger', 4000);"
                + "}</script>");
            }
        }
    }
}