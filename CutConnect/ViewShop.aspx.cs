﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;

public partial class ViewShop : System.Web.UI.Page
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
            GenerateControls(Convert.ToInt32(reader2["serviceid"]), reader2["name"].ToString(), reader2["price"].ToString(), sender);
        }

    }

    private void GenerateControls(int serviceid, string name, string price, object sender)
    {


        HtmlGenericControl span = new HtmlGenericControl("span");
        HtmlGenericControl p1 = new HtmlGenericControl("p");
        HtmlGenericControl p2 = new HtmlGenericControl("p");
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        HtmlGenericControl div2 = new HtmlGenericControl("div");

        //HtmlGenericControl a1 = new HtmlGenericControl("a");
        Button BookServiceBtn = new Button();

        span.Attributes.Add("class", "list-group-item list-group-item   w-75 m-auto mt-5");

        div1.Attributes.Add("class", "align-items-center d-flex");
        div2.Attributes.Add("class", "align-items-center d-flex");

        p1.Attributes.Add("class", "me-auto h3 ");
        p1.InnerText = name;

        p2.Attributes.Add("class", "h4 ms-auto text-success opacity-75 ");
        p2.InnerText = price + " Rs";

        div1.Controls.Add(p1);
        div1.Controls.Add(p2);

        BookServiceBtn.Attributes.Add("runat", "server");
        BookServiceBtn.Attributes.Add("class", "btn btn-dark me-3");
        BookServiceBtn.UseSubmitBehavior = false;
        BookServiceBtn.ID = "BookServiceBtn" + serviceid;

        BookServiceBtn.Text = "Add to Cart";
        BookServiceBtn.CommandArgument = serviceid.ToString();
        BookServiceBtn.Click += new EventHandler(BookServiceBtn_OnClick);


        //btnBook.CommandArgument = "<%#Eval(" + serviceid + ")%>";



        div2.Controls.Add(BookServiceBtn);


        span.Controls.Add(div1);
        span.Controls.Add(div2);

        ServicesPanel.Controls.Add(span);
    }


    protected void BookServiceBtn_OnClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if(btn.Text != "Booked")
        {

        int serviceid = Convert.ToInt32(btn.ID.Substring(14));

        MySqlConnection conn = new MySqlConnection(conStr); 
        conn.Open();
            
        string sql = "select cart_id from cart where user_id = @userid";
        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@userid",Session["userid"]);

        MySqlDataReader reader =  cmd.ExecuteReader();
            
            if (!reader.Read())
            {
                reader.Close();
                insertIntoCart(serviceid);
                
                
                string sql2 = "select sh.shop_id, sh.name as name from services as se, shop as sh where se.serviceid = @serviceid and sh.shop_id = se.shopid";
                MySqlCommand cmd3 = new MySqlCommand(sql2, conn);
                cmd3.Parameters.AddWithValue("@serviceid", serviceid);
                MySqlDataReader reader2 = cmd3.ExecuteReader();
                reader2.Read();
                Session["shopid"] = reader2["shop_id"];
                Session["shopname"] = reader2["name"];
                
                btn.Text = "Added";
            }
            else
            {
                reader.Close();
                string sql2 = "select shopid from services where serviceid = @serviceid";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@serviceid", serviceid);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                if(reader2["shopid"].ToString() != Session["shopid"].ToString())
                {
                    failmsg.InnerText = "You already have services of "+ Session["shopname"] + "in Cart. Cannot Add Services from another shop!";
                }
                else
                {
                    insertIntoCart(serviceid);
                }

            }
            conn.Close();
        }
        void insertIntoCart(int serviceid)
        {
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            string sql2 = "insert into cart(service_id,user_id) values(@service_id,@userid) ON DUPLICATE KEY UPDATE service_id = @service_id";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

            cmd2.Parameters.AddWithValue("@service_id", serviceid);
            cmd2.Parameters.AddWithValue("@userid", Session["userid"]);

            cmd2.ExecuteNonQuery();
            conn.Close();
            btn.Text = "Added";

        }
    }

   
}

    


