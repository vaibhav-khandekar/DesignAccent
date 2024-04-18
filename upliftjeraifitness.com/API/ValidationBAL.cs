using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.DAL;
using Validation.DTO;

namespace Validation.BAL
{
    public class ValidationBAL
    {
        ValidationDAL objDAL = new ValidationDAL();
        ValidationDTO objDTO = new ValidationDTO();

        // Get Details
        public ValidationDTO GetDetails()
        {
            objDTO = objDAL.GetDetails();
            return objDTO;
        }

        // Add Details
        public ValidationDTO AddDetails(string FullName, string EmailAddress, string MobileNumber, string Statee, string City, string Gender)
        {
            objDTO = objDAL.AddDetails(FullName, EmailAddress, MobileNumber, Statee, City, Gender);
            return objDTO;
        }

        // Update Details
        public ValidationDTO UpdateDetails(int ID, string FullName, string EmailAddress, string MobileNumber, string Statee, string City, string Gender)
        {
            objDTO = objDAL.UpdateDetails(ID, FullName, EmailAddress, MobileNumber, Statee, City, Gender);
            return objDTO;
        }

        // Delete Details
        public ValidationDTO DeleteDetails(int ID)
        {
            objDTO = objDAL.DeleteDetails(ID);
            return objDTO;
        }
    }
}
