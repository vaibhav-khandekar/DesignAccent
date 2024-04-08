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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string path = @"";
            byte[] imgData = System.IO.File.ReadAllBytes("C:/Vaibhav/1.png");
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1KT7THJ\SQLEXPRESS;Initial Catalog=Employees;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into iamges (image_data) values (@image_data)", con);
            cmd.Parameters.AddWithValue("@image_data", imgData);

            // Execute the command
            int rowsAffected = cmd.ExecuteNonQuery();

            // Check if the insertion was successful
            if (rowsAffected > 0)
            {
                Console.WriteLine("Image inserted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to insert image.");
            }
        }
    }
}
