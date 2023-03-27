using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            NavLogin.Visible = false;
            NavRegister.Visible = false;
            if (Session["role"].ToString() == "c")
            {
                NavDashboard.HRef = "CustomerDashboard.aspx";
                NavDashboard.InnerText = "Find Shops";
                NavCart.Visible = true;
                NavMyBookings.Visible = true;

            }
            else if (Session["role"].ToString() == "b")
            {
                NavDashboard.HRef = "BarberDashboard.aspx";
                NavDashboard.InnerText = "Shops";
                ManageBookings.Visible = true;
            }
        }
        else
        {
            NavDashboard.Visible = true;
            NavLogout.Visible = false;

        }

    }

    

    protected void NavLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }

   
}
