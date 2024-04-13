using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DTO
{
    public class EmployeesDTO
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public class EmployeeEntity
        {
            public string EmpID { get; set; }
            public string EmpName { get; set; }
            public string EmpSalary { get; set; }
            public string EmpAge { get; set; }

        }
        public List<EmployeesDTO.EmployeeEntity> Employee_List { get; set; }
    }
}
