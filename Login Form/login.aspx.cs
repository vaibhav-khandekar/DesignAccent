using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1KT7THJ\SQLEXPRESS;Initial Catalog=Employees;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Employee where EmpID=@EmpID and EmpName=@EmpName", con);
            cmd.Parameters.AddWithValue("@EmpID", TextBox1.Text);
            cmd.Parameters.AddWithValue("@EmpName", TextBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('empid and empname not available')", true);
            }
        }
    }
}
