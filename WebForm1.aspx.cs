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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1KT7THJ\SQLEXPRESS;Initial Catalog=Employees;Integrated Security=True");

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            {
                con.Open();
                string str = "insert into Employee values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('data inserted is successfully')", true);
                con.Close();
            }
        }

     
       
        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdToCheck = new SqlCommand("select count(EmpID) from Employee where EmpID='" + TextBox1.Text + "'", con);
            //SqlDataAdapter sd = new SqlDataAdapter(cmdToCheck);
            //DataTable dt = new DataTable();

           int id = Convert.ToInt32(cmdToCheck.ExecuteScalar());

            if (id > 0)
            {
                string str = "update Employee set EmpName='" + TextBox2.Text + "', EmpSalary='" + TextBox3.Text + "',EmpAge='" + TextBox4.Text + "'where EmpID='" + TextBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('data updated is successfully')", true);
                con.Close();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('row is not available')", true);
            }
        }

        
        protected void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdToCheck = new SqlCommand("select count(EmpID) from Employee where EmpID='" + TextBox1.Text + "'", con);
            //SqlDataAdapter sd = new SqlDataAdapter(cmdToCheck);
            //DataTable dt = new DataTable();
            int id = Convert.ToInt32(cmdToCheck.ExecuteScalar());
            if (id > 0)
                {
                    SqlCommand cmd = new SqlCommand("delete from Employee where EmpID='" + TextBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('data deleted is successfully')", true);
                    con.Close();
                }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('row is not availableeeeee')", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["trial"].ConnectionString;
            string query = "SELECT * FROM Employee";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Employee");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}
