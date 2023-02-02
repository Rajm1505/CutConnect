using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;


public partial class ShopDetails : System.Web.UI.Page
{
    string conStr = @"server=localhost;user id=root;database=cutconnect";

    protected void Page_Load(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "select * from shop where shop_id=@shop_id";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@shop_id", Request.QueryString["id"]);


        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            nameinfo.InnerText = reader["name"].ToString();
            addressinfo.InnerText = reader["address"].ToString();
            emailinfo.InnerText = reader["email"].ToString();
            phoneinfo.InnerText = reader["phone"].ToString();
            countryinfo.InnerText = reader["country"].ToString();
            pincodeinfo.InnerText = reader["pincode"].ToString();
            opentimeinfo.InnerText = reader["open_time"].ToString();
            citystateinfo.InnerText = reader["city"].ToString() + ", " + reader["state"].ToString();

        }
        reader.Close();
        conn.Close();

        MySqlConnection conn2 = new MySqlConnection(conStr);
        conn2.Open();

        string sql2 = "select serviceid, name, price from services where shopid=@shopid";
        Console.WriteLine(sql2);
        MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
        cmd2.Parameters.AddWithValue("@shopid", Request.QueryString["id"]);


        MySqlDataReader reader2 = cmd2.ExecuteReader();
        
        while (reader2.Read())
        {
            GenerateControls(Convert.ToInt32(reader2["serviceid"]), reader2["name"].ToString(), reader2["price"].ToString(),sender);
        }

    }

    private void GenerateControls(int serviceid,string name, string price,object sender)
    {


        HtmlGenericControl span = new HtmlGenericControl("span");
        HtmlGenericControl p1 = new HtmlGenericControl("p");
        HtmlGenericControl p2 = new HtmlGenericControl("p");
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        HtmlGenericControl div2 = new HtmlGenericControl("div");

        //HtmlGenericControl a1 = new HtmlGenericControl("a");
        Button btnEdit = new Button();
        Button btnDelete = new Button();

        span.Attributes.Add("class", "list-group-item list-group-item   w-75 m-auto mt-5");

        div1.Attributes.Add("class", "align-items-center d-flex");
        div2.Attributes.Add("class", "align-items-center d-flex");

        p1.Attributes.Add("class", "me-auto h3 ");
        p1.InnerText = name;

        p2.Attributes.Add("class", "h4 ms-auto text-success opacity-75 ");
        p2.InnerText = price + " Rs";

        div1.Controls.Add(p1);
        div1.Controls.Add(p2);

        btnEdit.Attributes.Add("runat", "server");
        btnEdit.Attributes.Add("class", "btn btn-info me-3");
        btnEdit.Text = "Edit";
        btnEdit.CommandName = "ServiceEditBtn";
        btnEdit.CommandArgument = "<%#Eval(" + serviceid + ")%>";

        btnDelete.Attributes.Add("runat", "server");
        btnDelete.Attributes.Add("class", "btn btn-danger");
        btnDelete.Text = "Delete";

        div2.Controls.Add(btnEdit);
        div2.Controls.Add(btnDelete);

        //div2.Controls.Add(p2);

        //a1.Attributes.Add("href", "ShopDetails.aspx?id=" + serviceid);
        //a1.Attributes.Add("class", "btn btn-dark float-end align-items-center");


        span.Controls.Add(div1);
        span.Controls.Add(div2);

        ServicesPanel.Controls.Add(span);
    }

    protected void EditShop_Click(object sender, EventArgs e)
    {
        ShopDetailsPanel.Visible = false;
        AddServicesPanel.Visible = false;
        EditShopDetailsPanel.Visible = true;
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "select * from shop where shop_id=@shop_id";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@shop_id", Request.QueryString["id"]);


        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            name.Text = reader["name"].ToString();
            address.Text = reader["address"].ToString();
            email.Text = reader["email"].ToString();
            phone.Text = reader["phone"].ToString();
            country.Text = reader["country"].ToString();
            pincode.Text = reader["pincode"].ToString();
            open_time.Text = reader["open_time"].ToString();
            city.Text = reader["city"].ToString() ;
            state.Text =  reader["state"].ToString();

        }
    }

    protected void SaveShop_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "update shop set name = @name,email=@email,address=@address,phone=@phone,city=@city,state=@state,country=@country,pincode=@pincode,open_time=@opentime where shop_id = @shop_id"; 
        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@name", name.Text);
        cmd.Parameters.AddWithValue("@email", email.Text);
        cmd.Parameters.AddWithValue("@address", address.Text);
        cmd.Parameters.AddWithValue("@phone", phone.Text);
        cmd.Parameters.AddWithValue("@city", city.Text);
        cmd.Parameters.AddWithValue("@state", state.Text);
        cmd.Parameters.AddWithValue("@country", country.Text);
        cmd.Parameters.AddWithValue("@pincode", pincode.Text);
        cmd.Parameters.AddWithValue("@opentime", open_time.Text);
        cmd.Parameters.AddWithValue("@shop_id", Request.QueryString["id"]);

        cmd.ExecuteNonQuery();
        Response.Redirect("ShopDetails.aspx?id="+Request.QueryString["id"]);

    }

    protected void DeleteShop_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "delete from shop where shop_id = @shop_id";
        MySqlCommand cmd = new MySqlCommand(sql, conn);

       
        cmd.Parameters.AddWithValue("@shop_id", Request.QueryString["id"]);

        cmd.ExecuteNonQuery();
        Response.Redirect("BarberDashboard.aspx");
    }

    protected void AddShopPanelToggleOff_Click(object sender, EventArgs e)
    {


    }

    


    protected void AddServicePanelToggleOn_Click(object sender, EventArgs e)
    {
        AddServicesPanel.Visible = true;

    }
    protected void AddServiceButton_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "insert into services(shopid,name,price) values(@shopid,@name,@price)";
        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@name", servicename.Text);
        cmd.Parameters.AddWithValue("@price", price.Text);
        cmd.Parameters.AddWithValue("@shopid", Request.QueryString["id"]);

        cmd.ExecuteNonQuery();
        Response.Redirect("ShopDetails.aspx?id=" + Request.QueryString["id"]);
    }
}