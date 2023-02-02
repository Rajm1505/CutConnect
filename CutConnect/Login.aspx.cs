using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Register : System.Web.UI.Page
{
    string conStr = @"server=localhost;user id=root;database=cutconnect";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {

        if (Session["role"].ToString() == "b")
        {
            Response.Redirect("BarberDashboard.aspx");
        }
        else if (Session["role"].ToString() == "c")
        {
            Response.Redirect("CustomerDashboard.aspx");
        }
        }
        

    }

    protected void Btn_Login_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "select userid,role from user where email=@email and password=@password";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@email", email.Value);
        cmd.Parameters.AddWithValue("@password", password.Value);


        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Session["email"] = email.Value;
            Session["userid"] = reader["userid"];
            if(reader["role"].ToString() == "c")
            {
                Session["role"] = "c";
                Response.Redirect("CustomerDashboard.aspx");
            }
            else
            {
                Session["role"] = "b";
                Response.Redirect("BarberDashboard.aspx");

            }
        }
        else
        {
            faillabel.Text = "Email or Password is incorrect!";
        }
        conn.Close();
    }
}