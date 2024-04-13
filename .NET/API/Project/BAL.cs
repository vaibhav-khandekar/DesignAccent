using Employees.DAL;
using Employees.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BAL
{
    public class EmployeesBAL
    {
        EmployeesDAL objEmpDAL = new EmployeesDAL();
        EmployeesDTO objEmpDTO = new EmployeesDTO();
        public EmployeesDTO GetEmployeeDetails()
        {
            objEmpDTO = objEmpDAL.GetEmployeeDetails();
            return objEmpDTO;
        }

        /*
        public EmployeesDTO AddEmployeeDetails(string ModelName)
        {
            objEmpDTO = objEmpDAL.AddEmployeeDetails(ModelName);
            return objEmpDTO;
        }
        public EmployeesDTO UpdateEmployeeDetails(string ModelID, string ModelName)
        {
            objEmpDTO = objEmpDAL.UpdateEmployeeDetails(ModelID, ModelName);
            return objEmpDTO;
        }
        public EmployeesDTO DeleteEmployeeDetails(string ModelID)
        {
            objEmpDTO = objEmpDAL.DeleteEmployeeDetails(ModelID);
            return objEmpDTO;
        }
        */
    }
}
