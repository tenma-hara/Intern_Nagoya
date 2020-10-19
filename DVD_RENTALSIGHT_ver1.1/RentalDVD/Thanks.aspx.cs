using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Written by Kamiya
namespace RentalDVD
{
    public partial class Thanks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbMessage.Text = string.Format("{0}さま。ご利用ありがとうございました。",Session["UserName"]);
        }
        protected void Back_Click(object sender, EventArgs e){


            Response.Redirect("Rental.aspx");

        }
    }
}