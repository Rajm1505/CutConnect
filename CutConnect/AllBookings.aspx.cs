using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;


public partial class AllBookings : System.Web.UI.Page
{
    string conStr = @"server=localhost;user id=root;database=cutconnect";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["role"].ToString() == "c")
        {
            Response.Redirect("CustomerDashboard.aspx");
        }


        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();

        string sql = "SELECT s.name,b.appointment_datetime from booking as b, shop as s where b.shop_id = s.shop_id and s.userid = @userid";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@userid", Session["userid"]);




        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            GenerateControls((reader["name"]).ToString(), reader["appointment_datetime"].ToString());
        }
        reader.Close();
        conn.Close();

    }

    private void GenerateControls(string name, string appointment_datetime)
    {


        HtmlGenericControl span = new HtmlGenericControl("span");
        HtmlGenericControl p1 = new HtmlGenericControl("p");
        HtmlGenericControl p2 = new HtmlGenericControl("p");
        HtmlGenericControl a = new HtmlGenericControl("a");
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        HtmlGenericControl div2 = new HtmlGenericControl("div");

        //HtmlGenericControl a1 = new HtmlGenericControl("a");

        span.Attributes.Add("class", "list-group-item list-group-item   w-75 m-auto mt-5");

        div1.Attributes.Add("class", "align-items-center d-flex");
        div2.Attributes.Add("class", "align-items-center d-flex");

        p1.Attributes.Add("class", "me-auto h3 ");
        p1.InnerText = name;

        p2.Attributes.Add("class", "h4 ms-auto text-success opacity-75 ");
        p2.InnerText = appointment_datetime;
        a.Attributes.Add("class", "btn btn-dark");
        a.InnerText = "View Booking";




        div1.Controls.Add(p1);
        div1.Controls.Add(p2);
        div2.Controls.Add(a);


        //btnBook.CommandArgument = "<%#Eval(" + serviceid + ")%>";

        span.Controls.Add(div1);
        span.Controls.Add(div2);
        

        AllBookingsPanel.Controls.Add(span);

    }


}