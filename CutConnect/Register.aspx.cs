using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class Login : System.Web.UI.Page
{
    string conStr = @"server=localhost;user id=root;database=cutconnect";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Btn_Register_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        string sql = "insert into user(name,email,password,phone,role) values(@name,@email,@password,@phone,@role)";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@name", name.Value);
        cmd.Parameters.AddWithValue("@email", email.Value);
        cmd.Parameters.AddWithValue("@password", password1.Value);
        cmd.Parameters.AddWithValue("@phone", phone.Value);
        cmd.Parameters.AddWithValue("@role", role.Value);

        cmd.ExecuteNonQuery();
        conn.Close();

    }
}