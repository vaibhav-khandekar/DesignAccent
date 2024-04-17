using HRBS.DAL;
using HRBS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBS.BAL
{
    public class CustomerByTelecallerBAL
    {
        CustomerByTelecallerDAL objCustomerByTelecallerDAL = new CustomerByTelecallerDAL();
        CustomerByTelecallerDTO objCustomerByTelecallerDTO = new CustomerByTelecallerDTO();

        // Insert Customer By Telecaller
        public CustomerByTelecallerDTO Insert(string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
        {
            objCustomerByTelecallerDTO = objCustomerByTelecallerDAL.Insert(full_name, date, contact_no, email_id, gender, city, age, query, source);
            return objCustomerByTelecallerDTO;
        }

        // Update Customer By Telecaller
        public CustomerByTelecallerDTO Update(int id, string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
        {
            objCustomerByTelecallerDTO = objCustomerByTelecallerDAL.Update(id, full_name, date, contact_no, email_id, gender, city, age, query, source);
            return objCustomerByTelecallerDTO;
        }

        // Delete Customer By Telecaller
        public CustomerByTelecallerDTO Delete(int id)
        {
            objCustomerByTelecallerDTO = objCustomerByTelecallerDAL.Delete(id);
            return objCustomerByTelecallerDTO;
        }

        // Get All Customers
        public CustomerByTelecallerDTO AllCustomers()
        {
            objCustomerByTelecallerDTO = objCustomerByTelecallerDAL.AllCustomers();
            return objCustomerByTelecallerDTO;
        }

        // Get Customer By Id
        public CustomerByTelecallerDTO GetCustomerById(int id)
        {
            objCustomerByTelecallerDTO = objCustomerByTelecallerDAL.GetCustomerById(id);
            return objCustomerByTelecallerDTO;
        }
    }
}