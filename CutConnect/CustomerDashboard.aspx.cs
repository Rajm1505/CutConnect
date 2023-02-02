using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
public partial class CustomerDashboard1 : System.Web.UI.Page
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

        SelectedCity.InnerText = "Selected City - " + CityList.Text;
        if (CityList.Text == "")
        {
            FailMessage.Text = "Please Select a City";
            SelectedCity.InnerText  = "Selected City - None";
        }
        
    }



        protected void BtnFilterCity_Click(object sender, EventArgs e)
        {
        //mysqlconnection conn = new mysqlconnection(constr);
        //conn.open();


        //string sql;
        //mysqlcommand cmd;
            
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            string sql = "select shop_id, name, city from shop where city=@city  ORDER BY created_at DESC";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@city", CityList.Text);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GenerateControls(Convert.ToInt32(reader["shop_id"]), reader["name"].ToString(), reader["city"].ToString());
            }
            conn.Close();
        FailMessage.Visible = false;
            
        }
    

        protected void GenerateControls(int shopid, string name, string city)
        {



            HtmlGenericControl span = new HtmlGenericControl("span");
            HtmlGenericControl p1 = new HtmlGenericControl("p");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            HtmlGenericControl div2 = new HtmlGenericControl("div");

            HtmlGenericControl p2 = new HtmlGenericControl("p");
            HtmlGenericControl a1 = new HtmlGenericControl("a");
            HtmlGenericControl i = new HtmlGenericControl("i");


            span.Attributes.Add("class", "list-group-item list-group-item-action mb-3 w-75 m-auto mt-5 mb-3");
            p1.Attributes.Add("class", "float-start h3 ");
            p1.InnerText = name;

            div1.Attributes.Add("class", "align-items-center d-flex");
            div2.Attributes.Add("class", "align-items-center d-flex");


            p2.Attributes.Add("class", " opacity-75 ");
            p2.InnerText = city;

            div1.Controls.Add(p1);
            div2.Controls.Add(p2);

            a1.Attributes.Add("href", "ViewShop.aspx?id=" + shopid);
            a1.Attributes.Add("class", "btn btn-dark float-end align-items-center");

            a1.InnerText = "View Shop";
            span.Controls.Add(a1);
            span.Controls.Add(div1);
            span.Controls.Add(div2);



            ShopsInCityPanel.Controls.Add(span);



        }
}
    
    
