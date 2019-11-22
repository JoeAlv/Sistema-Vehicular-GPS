using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVehicles.Forms.Common
{
    public partial class RecoveryPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User userAux = (User)Session["AuxUser"];
            if (userAux != null)
            {
                LblName.Text = userAux.name + " " + userAux.lastname;
            }
        }

        protected void Btn_recovery_click(object sender, EventArgs e)
        {
            string email = inputEmail.Text;
            Recovery(email);
        }

        private void Recovery(string email)
        {
            try
            {
                User userAux = (User)Session["AuxUser"];

                if (userAux != null)
                {
                    if (userAux.ConditionID == 1)
                    {
                        if (email == userAux.email)
                        {
                            Session["AuxToken"] = SendMail(userAux.email);
                            Response.Redirect("ConfirmCode.aspx");
                        }
                        else {
                            Response.Write("<script>window.onload = function() {"
                       + "showMsg('Los correos no coinciden', 'warning', 2000);"
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

        private string SendMail(string email)
        {
            string auxPass = RandomToken();
            // Gmail Address from where you send the mail
            var fromAddress = "ealfarov02@gmail.com";
            // any address where the email will be sending
            var toAddress = email;
            //Password of your gmail address
            const string fromPassword = "Ealfarito021294";
            // Passing the values and make a email formate to display
            string subject = "Password recovery - Sistema Registro Vehicular";
            string body = "Se ha solicitado una nueva contraseña. \n";
            body += " Código temporal: '" + auxPass + "'  \n";
            body += "" + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
            return auxPass;
        }

        private static string RandomToken()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char nm;

            for (int i = 0; i < 7; i++)
            {
                nm = Convert.ToChar(Convert.ToInt32(Math.Floor(30 * random.NextDouble() + 50)));
                builder.Append(nm);
            }
            return builder.ToString();
        }

        
    }
}