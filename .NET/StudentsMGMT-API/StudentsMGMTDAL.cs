using StudentsMGMT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMGMT.DAL
{
    public class StudentsMGMTDAL : DALBASE
    {
        StudentsMGMTDTO objSMDTO = new StudentsMGMTDTO();
        public StudentsMGMTDTO GetStudentsDetails()
        {
            objSMDTO.Student_List = new List<StudentsMGMTDTO.StudentEntity>();
            using (command = db.GetStoredProcCommand("[SP_StdData]"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "SELECT");
            }
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                if (reader == null)
                {
                    objSMDTO.Message = "Unsuccessfull";
                    objSMDTO.Code = (int)ErrorCode.ErrorType.DATANOTFOUND;
                }
                else
                {
                    string Retval = "";
                    while (reader.Read())
                    {
                        Retval = reader["Retval"].ToString();
                        if (Retval == "SUCCESS")
                        {
                            objSMDTO.Student_List.Add(new StudentsMGMTDTO.StudentEntity
                            {
                                StdID = reader["StdID"].ToString(),
                                StdName = reader["StdName"].ToString(),
                                StdLocation = reader["StdLocation"].ToString(),
                                StdAge = reader["StdAge"].ToString(),
                            });
                            objSMDTO.Message = "Successful";
                            objSMDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                        }
                        else
                        {
                            objSMDTO.Message = "No Records Found";
                            objSMDTO.Code = (int)ErrorCode.ErrorType.DATANOTFOUND;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objSMDTO.Message = "Unsuccessful";
                objSMDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("GetStudentsDetails", "StudentsMGMTDAL", ex.ToString());
            }
            return objSMDTO;
        }
        public StudentsMGMTDTO AddStudentDetails(string StdName, string StdLocation, string StdAge)
        {
            using (command = db.GetStoredProcCommand("[SP_StdData]"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "INSERT");
                db.AddInParameter(command, "@StdName", DbType.String, StdName);
                db.AddInParameter(command, "@StdLocation", DbType.String, StdLocation);
                db.AddInParameter(command, "@StdAge", DbType.String, StdAge);
            }
            try
            {
                string inserted = (string)db.ExecuteScalar(command);

                if (inserted == "SUCCESS")
                {
                    objSMDTO.Message = "Successful";
                    objSMDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                }
                else if (inserted == "EXISTS")
                {
                    objSMDTO.Message = "Exists";
                    objSMDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                }
                else
                {
                    objSMDTO.Message = "Unsuccessful";
                    objSMDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                }
            }
            catch (Exception ex)
            {
                objSMDTO.Message = "Exception";
                objSMDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("AddStudentDetails", "StudentsMGMTDAL", ex.ToString());
            }
            return objSMDTO;
        }
        public StudentsMGMTDTO UpdateStudentDetails(int StdID, string StdName, string StdLocation, string StdAge)
        {
            using (command = db.GetStoredProcCommand("[SP_StdData]"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "UPDATE");
                db.AddInParameter(command, "@StdID", DbType.String, StdID);
                db.AddInParameter(command, "@StdName", DbType.String, StdName);
                db.AddInParameter(command, "@StdLocation", DbType.String, StdLocation);
                db.AddInParameter(command, "@StdAge", DbType.String, StdAge);
            }
            try
            {
                string updated = (string)db.ExecuteScalar(command);

                if (updated == "SUCCESS")
                {
                    objSMDTO.Message = "Successful";
                    objSMDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                }
                else
                {
                    objSMDTO.Message = "Unsuccessful";
                    objSMDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                }
            }
            catch (Exception ex)
            {
                objSMDTO.Message = "Exception";
                objSMDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("UpdateStudentDetails", "StudentsMGMTDAL", ex.ToString());
            }
            return objSMDTO;
        }
        public StudentsMGMTDTO DeleteStudentDetails(int StdID)
        {
            using (command = db.GetStoredProcCommand("[SP_StdData]"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "DELETE");
                db.AddInParameter(command, "@StdID", DbType.String, StdID);
            }
            try
            {
                string deleted = (string)db.ExecuteScalar(command);

                if (deleted == "SUCCESS")
                {
                    objSMDTO.Message = "Successful";
                    objSMDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                }
                else
                {
                    objSMDTO.Message = "Unsuccessful";
                    objSMDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                }
            }
            catch (Exception ex)
            {
                objSMDTO.Message = "Exception";
                objSMDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("DeleteStudentDetails", "StudentsMGMTDAL", ex.ToString());
            }
            return objSMDTO;
        }
    }
}
