using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string path = Server.MapPath("/Images/" + fileName);
            FileUpload1.SaveAs(path);

            byte[] imgData = FileUpload1.FileBytes;
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1KT7THJ\SQLEXPRESS;Initial Catalog=Vaibhav;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Images (image_data) VALUES (@image_data)", con))
                {
                    cmd.Parameters.AddWithValue("@image_data", imgData);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (rowsAffected > 0)
                    {
                        Response.Write("Image inserted successfully.");
                    }
                    else
                    {
                        Response.Write("Failed to insert image.");
                    }
                }
            }
        }
    }
}
