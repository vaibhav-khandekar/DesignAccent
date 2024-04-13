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
        public EmployeesDTO AddEmployeeDetails(string EmpName, string EmpSalary, string EmpAge)
        {
            using (command = db.GetStoredProcCommand("[SP_EmpData]"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "INSERT");
                db.AddInParameter(command, "@EmpName", DbType.String, EmpName);
                db.AddInParameter(command, "@EmpSalary", DbType.String, EmpSalary);
                db.AddInParameter(command, "@EmpAge", DbType.String, EmpAge);
            }
            try
            {
                string inserted = (string)db.ExecuteScalar(command);

                if (inserted == "SUCCESS")
                {
                    objEmpDTO.Message = "Successful";
                    objEmpDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                }
                else if (inserted == "EXISTS")
                {
                    objEmpDTO.Message = "Exists";
                    objEmpDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                }
                else
                {
                    objEmpDTO.Message = "Unsuccessful";
                    objEmpDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                }
            }
            catch (Exception ex)
            {
                objEmpDTO.Message = "Exception";
                objEmpDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("AddEmployeeDetails", "EmployeesDAL", ex.ToString());
            }
            return objEmpDTO;
        }
        public EmployeesDTO UpdateEmployeeDetails(int EmpID, string EmpName, string EmpSalary, string EmpAge)
        {
            using (command = db.GetStoredProcCommand("[SP_EmpData]"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "UPDATE");
                db.AddInParameter(command, "@EmpID", DbType.String, EmpID);
                db.AddInParameter(command, "@EmpName", DbType.String, EmpName);
                db.AddInParameter(command, "@EmpSalary", DbType.String, EmpSalary);
                db.AddInParameter(command, "@EmpAge", DbType.String, EmpAge);
            }
            try
            {
                string updated = (string)db.ExecuteScalar(command);

                if (updated == "SUCCESS")
                {
                    objEmpDTO.Message = "Successful";
                    objEmpDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                }
                else
                {
                    objEmpDTO.Message = "Unsuccessful";
                    objEmpDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                }
            }
            catch (Exception ex)
            {
                objEmpDTO.Message = "Exception";
                objEmpDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("UpdateEmployeeDetails", "EmployeesDAL", ex.ToString());
            }
            return objEmpDTO;
        }
        public EmployeesDTO DeleteEmployeeDetails(int EmpID)
        {
            using (command = db.GetStoredProcCommand("[SP_EmpData]"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "DELETE");
                db.AddInParameter(command, "@EmpID", DbType.String, EmpID);
            }
            try
            {
                string deleted = (string)db.ExecuteScalar(command);

                if (deleted == "SUCCESS")
                {
                    objEmpDTO.Message = "Successful";
                    objEmpDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                }
                else
                {
                    objEmpDTO.Message = "Unsuccessful";
                    objEmpDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                }
            }
            catch (Exception ex)
            {
                objEmpDTO.Message = "Exception";
                objEmpDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("DeleteEmployeeDetails", "EmployeesDAL", ex.ToString());
            }
            return objEmpDTO;
        }
    }
}
