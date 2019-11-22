using System;

namespace WebVehicles.Forms.Common
{
    public partial class _404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Back_click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}