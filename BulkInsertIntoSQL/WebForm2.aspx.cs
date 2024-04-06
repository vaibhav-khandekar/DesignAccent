using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //create data table
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("EmpID", typeof(string)));
            tbl.Columns.Add(new DataColumn("EmpName", typeof(string)));
            tbl.Columns.Add(new DataColumn("EmpSalary", typeof(string)));
            tbl.Columns.Add(new DataColumn("EmpAge", typeof(string)));

            //create connection for Excel file
            string path = Server.MapPath("C:/Vaibhav/EmpFile.xlsx");
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", path);
            OleDbConnection oledbconn = new OleDbConnection(constr);

            //create connection for SQL file
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1KT7THJ\SQLEXPRESS;Initial Catalog=Employees;Integrated Security=True");

            //excel query
            string myexceldataquery = string.Format("select EmpID,EmpName,EmpSalary,EmpAge from [Sheet1$]");
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            
            while(dr.Read())
            {
                DataRow row = tbl.NewRow();
                row["EmpID"] = dr["EmpID"].ToString();
                row["EmpName"] = dr["EmpName"].ToString();
                row["EmpSalary"] = dr["EmpSalary"].ToString();
                row["EmpAge"] = dr["EmpAge"].ToString();
                tbl.Rows.Add(row);
            }

            //create object of SqlBulkCopy which help to insert
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assign Destination table name
            objbulk.DestinationTableName = "Employee";

            //mapping columns of DataTable to Database Table
            objbulk.ColumnMappings.Add("EmpID", "EmpID");
            objbulk.ColumnMappings.Add("EmpName", "EmpName");
            objbulk.ColumnMappings.Add("EmpSalary", "EmpSalary");
            objbulk.ColumnMappings.Add("EmpAge", "EmpAge");
            con.Open();
           
            oledbconn.Close();
            //insert bulk Records into DataBase.
            objbulk.WriteToServer(tbl);
            con.Close();
        }
    }
}
