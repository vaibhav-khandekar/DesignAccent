using Employees.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL
{
    public class EmployeesDAL : DALBASE
    {
        EmployeesDTO objEmpDTO = new EmployeesDTO();
        public EmployeesDTO GetEmployeeDetails()
        {
            objEmpDTO.Employee_List = new List<EmployeesDTO.EmployeeEntity>();
            using (command = db.GetStoredProcCommand("[SP_EmpData]"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "SELECT");
            }
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                if (reader == null)
                {
                    objEmpDTO.Message = "Unsuccessfull";
                    objEmpDTO.Code = (int)ErrorCode.ErrorType.DATANOTFOUND;
                }
                else
                {
                    string Retval = "";
                    while (reader.Read())
                    {
                        Retval = reader["Retval"].ToString();
                        if (Retval == "SUCCESS")
                        {
                            objEmpDTO.Employee_List.Add(new EmployeesDTO.EmployeeEntity
                            {
                                EmpID = reader["EmpID"].ToString(),
                                EmpName = reader["EmpName"].ToString(),
                                EmpSalary = reader["EmpSalary"].ToString(),
                                EmpAge = reader["EmpAge"].ToString(),
                            });
                            objEmpDTO.Message = "Successful";
                            objEmpDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                        }
                        else
                        {
                            objEmpDTO.Message = "No Records Found";
                            objEmpDTO.Code = (int)ErrorCode.ErrorType.DATANOTFOUND;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objEmpDTO.Message = "Unsuccessful";
                objEmpDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("GetEmployeeDetails", "EmployeesDAL", ex.ToString());
            }
            return objEmpDTO;
        }
    }
}
