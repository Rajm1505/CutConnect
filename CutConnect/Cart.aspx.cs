using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;

public partial class Cart : System.Web.UI.Page
{
    string conStr = @"server=localhost;user id=root;database=cutconnect";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["role"].ToString() == "b")
        {
            Response.Redirect("BarberDashboard.aspx");
        }
       

        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();

        string sql = "SELECT s.serviceid, s.name,s.price from services as s, cart as c where c.user_id = @userid and c.service_id = s.serviceid ";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@userid", Session["userid"]);




        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            
            GenerateControls(Convert.ToInt32(reader["serviceid"]), reader["name"].ToString(), reader["price"].ToString());
        }
        reader.Close();
        string sql2 = "SELECT shopid, SUM(s.price) as total from services as s, cart as c where c.user_id = @userid and c.service_id = s.serviceid ";
        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
        cmd2.Parameters.AddWithValue("@userid", Session["userid"]);
        MySqlDataReader reader2 =  cmd2.ExecuteReader();
        reader2.Read();
        TotalCartPrice.Visible = true;
        TotalCartPrice.InnerText = reader2["total"].ToString();
        Session["shopid"] = reader2["shopid"].ToString();

        reader2.Close();
        conn.Close();

    }

    private void GenerateControls(int serviceid, string name, string price)
    {


        HtmlGenericControl span = new HtmlGenericControl("span");
        HtmlGenericControl p1 = new HtmlGenericControl("p");
        HtmlGenericControl p2 = new HtmlGenericControl("p");
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        HtmlGenericControl div2 = new HtmlGenericControl("div");

        //HtmlGenericControl a1 = new HtmlGenericControl("a");

        span.Attributes.Add("class", "list-group-item list-group-item   w-75 m-auto mt-5");

        div1.Attributes.Add("class", "align-items-center d-flex");
        div2.Attributes.Add("class", "align-items-center d-flex");

        p1.Attributes.Add("class", "me-auto h3 ");
        p1.InnerText = name;

        p2.Attributes.Add("class", "h4 ms-auto text-success opacity-75 ");
        p2.InnerText = price + " Rs";

        div1.Controls.Add(p1);
        div1.Controls.Add(p2);

        //btnBook.CommandArgument = "<%#Eval(" + serviceid + ")%>";

        span.Controls.Add(div1);

        CartItemsPanel.Controls.Add(span);
    }

    

    protected void BookServicesBtn_Click(object sender, EventArgs e)
    {
        BookingFormPanel.Visible = true;
        CloseBookServicesBtn.Visible = true;
        BookServicesBtn.Visible = false;
    }

    protected void ConfirmBookingBtn_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql1 = "select service_id from cart where user_id  = @userid";
        MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
        cmd1.Parameters.AddWithValue("@userid", Session["userid"]);
        MySqlDataReader reader = cmd1.ExecuteReader();
        string serviceid_list = "";
        while (reader.Read())
        {

            serviceid_list += reader["service_id"] + ",";
            
        }
        reader.Close();
        string sql2 = "insert into booking(shop_id,serviceid_list,total_price,status,appointment_datetime,userid) values(@shop_id,@serviceid_list,@totalprice,'Pending',@appdt,@userid)";
        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

        cmd2.Parameters.AddWithValue("@shop_id", Session["shopid"]);
        cmd2.Parameters.AddWithValue("@serviceid_list", serviceid_list);

        cmd2.Parameters.AddWithValue("@totalprice", Convert.ToInt32(TotalCartPrice.InnerText));
        cmd2.Parameters.AddWithValue("@appdt", appointmentdatetime.Value);
        cmd2.Parameters.AddWithValue("@userid", Session["userid"]);

        cmd2.ExecuteNonQuery();


        string sql3 = "delete from cart where user_id = @userid";
        MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

        cmd3.Parameters.AddWithValue("@userid", Session["userid"]);

        cmd3.ExecuteNonQuery();
        Response.Redirect("Cart.aspx");

    }

    protected void CloseBookServicesBtn_Click(object sender, EventArgs e)
    {
        BookingFormPanel.Visible = false;
        BookServicesBtn.Visible = true;
        CloseBookServicesBtn.Visible = false;
    }
}