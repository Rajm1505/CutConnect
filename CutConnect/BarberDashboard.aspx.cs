using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class BarberDashboard : System.Web.UI.Page
{
    string conStr = @"server=localhost;user id=root;database=cutconnect";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["message"] != null)
        {
        message.InnerText = Session["message"].ToString();
        Session.Remove("message");
        }

        
        if (Session["role"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["role"].ToString() == "c")
        {
            Response.Redirect("CustomerDashboard.aspx");
        }
        addNewShopPanel.Visible = false;


        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "select shop_id, name, city from shop where userid=@userid ORDER BY shop_id DESC";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@userid", Session["userid"].ToString());


        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            GenerateControls(Convert.ToInt32(reader["shop_id"]), reader["name"].ToString(), reader["city"].ToString());
        }

    }

    private void GenerateControls(int shopid, string name, string city)
    {

        

        HtmlGenericControl span = new HtmlGenericControl("span");
        HtmlGenericControl p1 = new HtmlGenericControl("p");
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        HtmlGenericControl div2 = new HtmlGenericControl("div");
       
           
        HtmlGenericControl p2 = new HtmlGenericControl("p");
        HtmlGenericControl a1 = new HtmlGenericControl("a");

       
        span.Attributes.Add("class", "list-group-item list-group-item-action mb-3 w-75 m-auto mt-5 mb-3");
        p1.Attributes.Add("class", "float-start h3 ");
        p1.InnerText = name;

        div1.Attributes.Add("class", "align-items-center d-flex");
        div2.Attributes.Add("class", "align-items-center d-flex");
       
        
        p2.Attributes.Add("class", " opacity-75 ");
        p2.InnerText = city;

        div1.Controls.Add(p1);
        div2.Controls.Add(p2);
        
        a1.Attributes.Add("href", "ShopDetails.aspx?id="+ shopid);
        a1.Attributes.Add("class", "btn btn-dark float-end align-items-center");

        a1.InnerText = "Shop Details";
        span.Controls.Add(a1);
        span.Controls.Add(div1);
        span.Controls.Add(div2);

        
        
        ListedShopsPanel.Controls.Add(span);



    }
    protected void AddShopPanelToggleOn_Click(object sender, EventArgs e)
    {
        addNewShopPanel.Visible = true;
        AddShopPanelToggleOff.Visible = true;
        AddShopPanelToggleOn.Visible = false;
    }
    protected void AddShopPanelToggleOff_Click(object sender, EventArgs e)
    {
        addNewShopPanel.Visible = false;
        AddShopPanelToggleOff.Visible = false;
        AddShopPanelToggleOn.Visible = true;
    }

    protected void AddShop_Click(object sender, EventArgs e)
    {

        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "insert into shop(name,email,address,phone,city,state,country,pincode,open_time,userid) values(@name,@email,@address,@phone,@city,@state,@country,@pincode,@opentime,@userid)";
        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@name", name.Value);
        cmd.Parameters.AddWithValue("@email", email.Value);
        cmd.Parameters.AddWithValue("@address", address.Value);
        cmd.Parameters.AddWithValue("@phone", phone.Value);
        cmd.Parameters.AddWithValue("@city", city.Value);
        cmd.Parameters.AddWithValue("@state", state.Value);
        cmd.Parameters.AddWithValue("@country",  country.Value);
        cmd.Parameters.AddWithValue("@pincode", pincode.Value);
        cmd.Parameters.AddWithValue("@opentime", opentime.Value);
        cmd.Parameters.AddWithValue("@userid", Session["userid"].ToString());

        cmd.ExecuteNonQuery();
        conn.Close();
        Session["message"] = "Shop Created Successfully!";
        

        if (IsPostBack)
        {
            Response.Redirect("BarberDashboard.aspx");
        }

    }
}