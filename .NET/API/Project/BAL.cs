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
        public EmployeesDTO AddEmployeeDetails(string EmpName, string EmpSalary, string EmpAge)
        {
            objEmpDTO = objEmpDAL.AddEmployeeDetails(EmpName, EmpSalary, EmpAge);
            return objEmpDTO;
        }
        public EmployeesDTO UpdateEmployeeDetails(int EmpID, string EmpName, string EmpSalary, string EmpAge)
        {
            objEmpDTO = objEmpDAL.UpdateEmployeeDetails(EmpID, EmpName, EmpSalary, EmpAge);
            return objEmpDTO;
        }
        public EmployeesDTO DeleteEmployeeDetails(int EmpID)
        {
            objEmpDTO = objEmpDAL.DeleteEmployeeDetails(EmpID);
            return objEmpDTO;
        }
    }
}
