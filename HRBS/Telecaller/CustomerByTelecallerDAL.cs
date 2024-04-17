using HRBS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBS.DAL
{
    public class CustomerByTelecallerDAL : DALBASE
    {
        CustomerByTelecallerDTO objCustomerByTelecallerDTO = new CustomerByTelecallerDTO();

        // Insert Customer By Telecaller
        public CustomerByTelecallerDTO Insert(string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
        {
            objCustomerByTelecallerDTO.CustomerByTelecallerList = new List<CustomerByTelecallerDTO.CustomerByTelecallerEntity>();
            using (command = db.GetStoredProcCommand(""))
            {
                db.AddInParameter(command, "@Action", DbType.String, "Insert");
                db.AddInParameter(command, "@full_name", DbType.String, full_name);
                db.AddInParameter(command, "@date", DbType.Date, date);
                db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                db.AddInParameter(command, "@Email_id", DbType.String, email_id);
                db.AddInParameter(command, "@gender", DbType.String, gender);
                db.AddInParameter(command, "@city", DbType.String, city);
                db.AddInParameter(command, "@age", DbType.String, age);
                db.AddInParameter(command, "@query", DbType.String, query);
                db.AddInParameter(command, "@source ", DbType.String, source);

                object obj = db.ExecuteScalar(command);
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (obj.ToString() == null)
                    {
                        objCustomerByTelecallerDTO.ErrorMessage = "Unsuccessful";
                    }
                    else if (obj.ToString() == "Success")
                    {
                        objCustomerByTelecallerDTO.ErrorMessage = "Success";
                    }
                    else
                    {
                        objCustomerByTelecallerDTO.ErrorMessage = "Something went wrong";
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("Insert", "CustomerByTelecallerDAL", ex.ToString());
                }
                return objCustomerByTelecallerDTO;
            }
        }

        // Update Customer By Telecaller
        public CustomerByTelecallerDTO Update(int id, string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
        {
            objCustomerByTelecallerDTO.CustomerByTelecallerList = new List<CustomerByTelecallerDTO.CustomerByTelecallerEntity>();
            using (command = db.GetStoredProcCommand(""))
            {
                db.AddInParameter(command, "@Action", DbType.String, "Update");
                db.AddInParameter(command, "@Id", DbType.Int32, id);
                db.AddInParameter(command, "@full_name", DbType.String, full_name);
                db.AddInParameter(command, "@date", DbType.Date, date);
                db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                db.AddInParameter(command, "@Email_id", DbType.String, email_id);
                db.AddInParameter(command, "@gender", DbType.String, gender);
                db.AddInParameter(command, "@city", DbType.String, city);
                db.AddInParameter(command, "@age", DbType.String, age);
                db.AddInParameter(command, "@query", DbType.String, query);
                db.AddInParameter(command, "@source ", DbType.String, source);

                object obj = db.ExecuteScalar(command);
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objCustomerByTelecallerDTO.ErrorMessage = "Unsuccessful";
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            objCustomerByTelecallerDTO.CustomerByTelecallerList.Add(new CustomerByTelecallerDTO.CustomerByTelecallerEntity
                            {
                                id = Convert.ToInt32(reader["id"]),
                                full_name = Convert.ToString(reader["full_name"]),
                                date = Convert.ToDateTime(reader["date"]),
                                contact_no = Convert.ToString(reader["contact_no"]),
                                email_id = Convert.ToString(reader["email_id"]),
                                gender = Convert.ToString(reader["gender"]),
                                city = Convert.ToString(reader["city"]),
                                age = Convert.ToString(reader["age"]),
                                query = Convert.ToString(reader["query"]),
                                source = Convert.ToString(reader["source"])
                            }
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("Update", "CustomerByTelecallerDAL", ex.ToString());
                    throw;
                }
                return objCustomerByTelecallerDTO;
            }
        }

        // Delete Customer By Telecaller
        public CustomerByTelecallerDTO Delete(int id)
        {
            objCustomerByTelecallerDTO.CustomerByTelecallerList = new List<CustomerByTelecallerDTO.CustomerByTelecallerEntity>();
            using (command = db.GetStoredProcCommand(""))
            {
                db.AddInParameter(command, "@Action", DbType.String, "Delete");
                db.AddInParameter(command, "@id", DbType.Int32, Convert.ToInt32(id));
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objCustomerByTelecallerDTO.ErrorMessage = "Unsuccessful";
                    }
                    else
                    {
                        objCustomerByTelecallerDTO.ErrorMessage = "Success";
                        while (reader.Read())
                        {
                            objCustomerByTelecallerDTO.Retval = Convert.ToString(reader["retval"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("Delete", "CustomerByTelecallerDAL", ex.ToString());
                    throw;
                }
                return objCustomerByTelecallerDTO;
            }
        }

        // Get All Customers
        public CustomerByTelecallerDTO AllCustomers()
        {
            objCustomerByTelecallerDTO.CustomerByTelecallerList = new List<CustomerByTelecallerDTO.CustomerByTelecallerEntity>();
            using (command = db.GetStoredProcCommand(""))
            {
                db.AddInParameter(command, "@Action", DbType.String, "Select");
                
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objCustomerByTelecallerDTO.ErrorMessage = "Unsuccessful";
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            objCustomerByTelecallerDTO.CustomerByTelecallerList.Add(new CustomerByTelecallerDTO.CustomerByTelecallerEntity
                            {
                                id = Convert.ToInt32(reader["id"]),
                                full_name = Convert.ToString(reader["full_name"]),
                                email_id = Convert.ToString(reader["email_id"]),
                                contact_no = Convert.ToString(reader["contact_no"]),
                                city = Convert.ToString(reader["city"]),
                                age = Convert.ToString(reader["age"]),
                                gender = Convert.ToString(reader["gender"])
                            });
                        }
                        objCustomerByTelecallerDTO.ErrorMessage = "Success";
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("AllCustomers", "CustomerByTelecallerDAL", ex.ToString());
                    throw;
                }
                return objCustomerByTelecallerDTO;
            }
        }

        // Get Customer By Id
        public CustomerByTelecallerDTO GetCustomerById(int id)
        {
            objCustomerByTelecallerDTO.CustomerByTelecallerList = new List<CustomerByTelecallerDTO.CustomerByTelecallerEntity>();
            using (command = db.GetStoredProcCommand(""))
            {
                db.AddInParameter(command, "@Action", DbType.String, "Select");
                db.AddInParameter(command, "@id", DbType.Int32, Convert.ToInt32(id));
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objCustomerByTelecallerDTO.ErrorMessage = "Unsuccessful";
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            objCustomerByTelecallerDTO.CustomerByTelecallerList.Add(new CustomerByTelecallerDTO.CustomerByTelecallerEntity
                            {
                                id = Convert.ToInt32(reader["id"]),
                                full_name = Convert.ToString(reader["full_name"]),
                                email_id = Convert.ToString(reader["email_id"]),
                                contact_no = Convert.ToString(reader["contact_no"]),
                                city = Convert.ToString(reader["city"]),
                                age = Convert.ToString(reader["age"]),
                                gender = Convert.ToString(reader["gender"])
                            });
                        }
                        objCustomerByTelecallerDTO.ErrorMessage = "Success";
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("GetCustomerById", "CustomerByTelecallerDAL", ex.ToString());
                    throw;
                }
                return objCustomerByTelecallerDTO;
            }
        }
    }
}