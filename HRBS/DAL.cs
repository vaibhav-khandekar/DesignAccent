using HRBS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBS.DAL
{
    public class HRBS
    {
        // AdminDAL.cs
        public class AdminDAL : DALBASE
        {
            AdminDTO objAdminDTO = new AdminDTO();
            public AdminDTO HRBSAdminLogin(string Email, string Password)
            {
                try
                {
                    objAdminDTO.AdminList = new List<AdminDTO.AdminEntity>();
                    using (command = db.GetStoredProcCommand("SP_AdminLogin"))
                    {
                        db.AddInParameter(command, "@Action", DbType.String, "HRBSAdminLogin");
                        db.AddInParameter(command, "@Email", DbType.String, Email);
                        db.AddInParameter(command, "@Password", DbType.String, Password);

                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objAdminDTO.Message = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string retval = Convert.ToString(reader["retval"]);
                                if (retval == "Success")
                                {
                                    objAdminDTO.AdminList.Add(new AdminDTO.AdminEntity
                                    {
                                        ID = Convert.ToInt32(reader["ID"]),
                                        Email = Convert.ToString(reader["Email"]),
                                        Password = Convert.ToString(reader["Password"])
                                    });
                                    objAdminDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                                    objAdminDTO.Message = "Success";
                                }
                                else if (retval == "Incorrect Password")
                                {
                                    objAdminDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                                    objAdminDTO.Message = "Wrong Password";
                                }
                                else if (retval == "Not Exists")
                                {
                                    objAdminDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                                    objAdminDTO.Message = "User does not exist";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("HRBSAdminLogin", "AdminDAL", ex.ToString());
                }
                return objAdminDTO;
            }

            public AdminDTO HRBSAdminLogout(string Email, string Password)
            {
                try
                {
                    objAdminDTO.AdminList = new List<AdminDTO.AdminEntity>();
                    using (command = db.GetStoredProcCommand("SP_AdminLogin"))
                    {
                        db.AddInParameter(command, "@Action", DbType.String, "HRBSAdminLogout");
                        db.AddInParameter(command, "@Email", DbType.String, Email);
                        db.AddInParameter(command, "@Password", DbType.String, Password);

                        object obj = db.ExecuteScalar(command);

                        if (obj == null)
                        {
                            objAdminDTO.Message = "Unsuccessful";
                        }
                        else if (obj.ToString() == "Logout")
                        {
                            objAdminDTO.Message = "Logout";
                        }
                        else
                        {
                            objAdminDTO.Message = "Error";
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("HRBSAdminLogout", "AdminDAL", ex.ToString());
                }
                return objAdminDTO;
            }

            #region Admin Dashboard Details

            public AdminDTO adminDashboard(string startDate, string endDate)
            {
                try
                {
                    objAdminDTO.AllCustomerList = new List<AdminDTO.CustomerEntity>();
                    using (command = db.GetStoredProcCommand("SP_getCounts"))
                    {
                        db.AddInParameter(command, "@Action", DbType.String, "getAllCustomers");
                        db.AddInParameter(command, "@startDate", DbType.String, startDate);
                        db.AddInParameter(command, "@endDate", DbType.String, endDate);


                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objAdminDTO.Message = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string retval = Convert.ToString(reader["retval"]);
                                if (retval == "Success")
                                {
                                    objAdminDTO.AllCustomerList.Add(new AdminDTO.CustomerEntity
                                    {
                                        customerId = Convert.ToInt32(reader["id"]),
                                        fullName = Convert.ToString(reader["full_name"]),
                                        enquiryDate = Convert.ToString(reader["date"]),
                                        contactNo = Convert.ToString(reader["contact_no"]),
                                        emailId = Convert.ToString(reader["email_id"]),
                                        gender = Convert.ToString(reader["gender"]),
                                        city = Convert.ToString(reader["city"]),
                                        age = Convert.ToString(reader["age"]),
                                        query = Convert.ToString(reader["query"]),
                                        assigned_manager = Convert.ToString(reader["assigned_manager"]),
                                        manager_status = Convert.ToString(reader["manager_status"]),
                                        assigned_executive = Convert.ToString(reader["assigned_executive"]),
                                        executive_status = Convert.ToString(reader["executive_status"]),
                                        assigned_doctor = Convert.ToString(reader["assigned_doctor"]),
                                        doctrore_status = Convert.ToString(reader["doctrore_status"]),
                                        assigned_delivery_man = Convert.ToString(reader["assigned_delivery_man"]),
                                        delivery_status = Convert.ToString(reader["delivery_status"]),
                                        source = Convert.ToString(reader["source"])

                                    });
                                    objAdminDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                                    objAdminDTO.Message = "Success";
                                }
                                else
                                {
                                    objAdminDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                                    objAdminDTO.Message = "Something went Wrong";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("adminDashboard", "AdminDAL", ex.ToString());
                }
                return objAdminDTO;
            }
            #endregion
        }

        // AssignToCustomerDAL.cs
        public class AssignToCustomerDAL : DALBASE
        {
            AssignToCustomerDTO objAssignToCustomerDTO = new AssignToCustomerDTO();

            public AssignToCustomerDTO InsertCustomerToAssign(string Action, string Customres, string MangerId/*, string TelecallerId, string DoctorId, string CourierPersonId*/)
            {
                // objAssignToCustomerDTO.AssignToCustomerList = new List<AssignToCustomerDTO.AssignToCustomerEntity>();
                using (command = db.GetStoredProcCommand("SP_assignCustomer"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, Action);
                    db.AddInParameter(command, "@Customres", DbType.String, Customres);
                    db.AddInParameter(command, "@MangerId", DbType.String, MangerId);
                    //db.AddInParameter(command, "@TelecallerId", DbType.String, TelecallerId);
                    //db.AddInParameter(command, "@DoctorId", DbType.String, DoctorId);
                    //db.AddInParameter(command, "@CourierPersonId", DbType.String, CourierPersonId);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (obj.ToString() == null)
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "Success")
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Success";
                        }
                        else
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("InsertCustomerToAssign", "AssignToCustomerDAL", ex.ToString());
                    }
                    return objAssignToCustomerDTO;
                }
            }

            public AssignToCustomerDTO AssignCustomerToTelecaller(string Action, string Customres, string TelecallerId/*, string MangerId,  string DoctorId, string CourierPersonId*/)
            {
                // objAssignToCustomerDTO.AssignToCustomerList = new List<AssignToCustomerDTO.AssignToCustomerEntity>();
                using (command = db.GetStoredProcCommand("SP_assignCustomer"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, Action);
                    db.AddInParameter(command, "@Customres", DbType.String, Customres);
                    // db.AddInParameter(command, "@MangerId", DbType.String, MangerId);
                    db.AddInParameter(command, "@TelecallerId", DbType.String, TelecallerId);
                    //db.AddInParameter(command, "@DoctorId", DbType.String, DoctorId);
                    //db.AddInParameter(command, "@CourierPersonId", DbType.String, CourierPersonId);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (obj.ToString() == null)
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "Success")
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Success";
                        }
                        else
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("AssignCustomerToTelecaller", "AssignToCustomerDAL", ex.ToString());
                    }
                    return objAssignToCustomerDTO;
                }
            }

            public AssignToCustomerDTO AssignCustomerToDoctor(string Action, string Customres, string DoctorId/*, string TelecallerId, string MangerId,   string CourierPersonId*/)
            {
                // objAssignToCustomerDTO.AssignToCustomerList = new List<AssignToCustomerDTO.AssignToCustomerEntity>();
                using (command = db.GetStoredProcCommand("SP_assignCustomer"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, Action);
                    db.AddInParameter(command, "@Customres", DbType.String, Customres);
                    // db.AddInParameter(command, "@MangerId", DbType.String, MangerId);
                    //db.AddInParameter(command, "@TelecallerId", DbType.String, TelecallerId);
                    db.AddInParameter(command, "@DoctorId", DbType.String, DoctorId);
                    //db.AddInParameter(command, "@CourierPersonId", DbType.String, CourierPersonId);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (obj.ToString() == null)
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "Success")
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Success";
                        }
                        else
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("AssignCustomerToDoctor", "AssignToCustomerDAL", ex.ToString());
                    }
                    return objAssignToCustomerDTO;
                }
            }

            public AssignToCustomerDTO AssignCustomerToCourier(string Action, string Customres, string CourierPersonId/* string DoctorId, string TelecallerId, string MangerId,  */)
            {
                // objAssignToCustomerDTO.AssignToCustomerList = new List<AssignToCustomerDTO.AssignToCustomerEntity>();
                using (command = db.GetStoredProcCommand("SP_assignCustomer"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, Action);
                    db.AddInParameter(command, "@Customres", DbType.String, Customres);
                    // db.AddInParameter(command, "@MangerId", DbType.String, MangerId);
                    //db.AddInParameter(command, "@TelecallerId", DbType.String, TelecallerId);
                    db.AddInParameter(command, "@CourierPersonId", DbType.String, CourierPersonId);
                    //db.AddInParameter(command, "@CourierPersonId", DbType.String, CourierPersonId);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (obj.ToString() == null)
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "Success")
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Success";
                        }
                        else
                        {
                            objAssignToCustomerDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("AssignCustomerToDoctor", "AssignToCustomerDAL", ex.ToString());
                    }
                    return objAssignToCustomerDTO;
                }
            }
        }

        // AttendanceLogDAL.cs
        public class AttendanceLogDAL : DALBASE
        {
            AttendanceLogDTO objAttendanceLogDTO = new AttendanceLogDTO();

            public AttendanceLogDTO InsertPunchINSelfie(string EmployeeCode,/* string PunchInLat, string PunchInLong, string Address, string PunchInFrom, string BatteryLevel, string DeviceName, string AndroidOS, string LocationFrom,*/ string PunchinPic)
            {
                AttendanceLogDTO AttendanceMaster = new AttendanceLogDTO();
                AttendanceMaster.AttendanceLogList = new List<AttendanceLogDTO.AttendanceLogEntities>();
                using (command = db.GetStoredProcCommand("SP_telecallerAttendence"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "PunchIn");
                    db.AddInParameter(command, "@CallerId", DbType.String, EmployeeCode);
                    // db.AddInParameter(command, "@PunchInLat", DbType.String, PunchInLat);
                    // db.AddInParameter(command, "@PunchInLong", DbType.String, PunchInLong);
                    // db.AddInParameter(command, "@PunchInAddress", DbType.String, Address);
                    // db.AddInParameter(command, "@PunchInFrom", DbType.String, PunchInFrom);
                    // db.AddInParameter(command, "@BatteryLevel", DbType.String, BatteryLevel);
                    // db.AddInParameter(command, "@DeviceName", DbType.String, DeviceName);
                    // db.AddInParameter(command, "@AndroidOS", DbType.String, AndroidOS);
                    //db.AddInParameter(command, "@LocationFrom", DbType.String, LocationFrom);
                    db.AddInParameter(command, "@punch_in_pic", DbType.String, PunchinPic);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader.Read())
                        {
                            string retval = Convert.ToString(reader["retval"]);
                            if (reader == null)
                            {
                                AttendanceMaster.Message = ErrorCode.ErrorType.NOTEXISTS.ToString();
                                AttendanceMaster.Code = (int)ErrorCode.ErrorType.NOTEXISTS;
                                AttendanceMaster.Status = "NULL";
                            }
                            else if (retval == "Success")
                            {
                                AttendanceMaster.AttendanceLogList.Add(new AttendanceLogDTO.AttendanceLogEntities
                                {
                                    Employeecode = Convert.ToString(reader["Employeecode"]),
                                    Date = Convert.ToString(reader["Date"]),
                                    Punchin_pic = Convert.ToString(reader["Punchin_pic"])
                                });
                                AttendanceMaster.Message = ErrorCode.ErrorType.SUCCESS.ToString();
                                AttendanceMaster.Code = (int)ErrorCode.ErrorType.SUCCESS;
                                AttendanceMaster.Status = "Success";
                            }
                        }
                        else
                        {
                            AttendanceMaster.Message = ErrorCode.ErrorType.ERROR.ToString();
                            AttendanceMaster.Code = (int)ErrorCode.ErrorType.ERROR;
                            AttendanceMaster.Status = "Error";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("InsertPunchINSelfie", "AttendanceLogDAL", ex.ToString());
                        AttendanceMaster.Message = "Error";
                        AttendanceMaster.Code = (int)ErrorCode.ErrorType.ERROR;
                        return AttendanceMaster;
                    }
                    return AttendanceMaster;
                }
            }

            public AttendanceLogDTO updatePunchOutSelfie(string EmployeeCode,/* string PunchOutLat, string PunchOutLong, string Address, string PunchOutFrom, string BatteryLevel, string DeviceName, string AndroidOS, string LocationFrom,*/ string PunchoutPic)
            {
                AttendanceLogDTO AttendanceMaster = new AttendanceLogDTO();
                AttendanceMaster.AttendanceLogList = new List<AttendanceLogDTO.AttendanceLogEntities>();
                using (command = db.GetStoredProcCommand("SP_telecallerAttendence"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "PunchOut");
                    db.AddInParameter(command, "@CallerId", DbType.String, EmployeeCode);
                    // db.AddInParameter(command, "@PunchOutLat", DbType.String, PunchOutLat);
                    // db.AddInParameter(command, "@PunchOutLong", DbType.String, PunchOutLong);
                    // db.AddInParameter(command, "@PunchOutAddress", DbType.String, Address);
                    // db.AddInParameter(command, "@PunchOutFrom", DbType.String, PunchOutFrom);
                    // db.AddInParameter(command, "@BatteryLevel", DbType.String, BatteryLevel);
                    // db.AddInParameter(command, "@DeviceName", DbType.String, DeviceName);
                    // db.AddInParameter(command, "@AndroidOS", DbType.String, AndroidOS);
                    //db.AddInParameter(command, "@LocationFrom", DbType.String, LocationFrom);
                    db.AddInParameter(command, "@punch_out_pic", DbType.String, PunchoutPic);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader.Read())
                        {
                            string retval = Convert.ToString(reader["retval"]);
                            if (reader == null)
                            {
                                AttendanceMaster.Message = ErrorCode.ErrorType.NOTEXISTS.ToString();
                                AttendanceMaster.Code = (int)ErrorCode.ErrorType.NOTEXISTS;
                                AttendanceMaster.Status = "NULL";
                            }
                            else if (retval == "Punched out Successfully")
                            {
                                AttendanceMaster.AttendanceLogList.Add(new AttendanceLogDTO.AttendanceLogEntities
                                {
                                    Date = Convert.ToString(reader["Date"]),
                                    Punch_out = Convert.ToString(reader["Punch_out"]),
                                    Punch_in = Convert.ToString(reader["Punch_in"])
                                });
                                AttendanceMaster.Message = ErrorCode.ErrorType.SUCCESS.ToString();
                                AttendanceMaster.Code = (int)ErrorCode.ErrorType.SUCCESS;
                                AttendanceMaster.Status = "Punched out Successfully";
                            }
                        }
                        else
                        {
                            AttendanceMaster.Message = ErrorCode.ErrorType.ERROR.ToString();
                            AttendanceMaster.Code = (int)ErrorCode.ErrorType.ERROR;
                            AttendanceMaster.Status = "Error";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("updatePunchOutSelfie", "AttendanceLogDAL", ex.ToString());

                        AttendanceMaster.Message = "Error";
                        AttendanceMaster.Code = (int)ErrorCode.ErrorType.ERROR;
                        return AttendanceMaster;
                    }
                    return AttendanceMaster;
                }
            }
        }

        // CustomerByWebDAL.cs
        public class CustomerByWebDAL : DALBASE
        {
            CustomerByWebDTO objCustomerByWebDTO = new CustomerByWebDTO();

            public CustomerByWebDTO Insert(string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
            {
                objCustomerByWebDTO.CusromerByWebList = new List<CustomerByWebDTO.CustomerByWebEntity>();
                using (command = db.GetStoredProcCommand("customerByEnquiry"))
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
                            objCustomerByWebDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "Success")
                        {
                            objCustomerByWebDTO.ErrorMessage = "Success";
                        }
                        else
                        {
                            objCustomerByWebDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("Insert", "CustomerByWebDAL", ex.ToString());
                    }
                    return objCustomerByWebDTO;
                }
            }

            public CustomerByWebDTO Update(int id, string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
            {
                objCustomerByWebDTO.CusromerByWebList = new List<CustomerByWebDTO.CustomerByWebEntity>();
                using (command = db.GetStoredProcCommand("customerByEnquiry"))
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
                            objCustomerByWebDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objCustomerByWebDTO.CusromerByWebList.Add(new CustomerByWebDTO.CustomerByWebEntity
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
                        ErrorLog("Update", "CustomerByWebDAL", ex.ToString());
                        throw;
                    }
                    return objCustomerByWebDTO;
                }
            }
        }

        // DataBindDAL.cs
        public class DataBindDAL : DALBASE
        {
            DataBindDTO objDataBindDTO = new DataBindDTO();

            public DataBindDTO CustomerDetail(string Operation)
            {
                objDataBindDTO.DataBindList = new List<DataBindDTO.DataBindEntity>();
                using (command = db.GetStoredProcCommand("SP_CustomerDetails"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "getCustomersAdmin");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    //db.AddInParameter(command, "", DbType.String, );
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objDataBindDTO.Message = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objDataBindDTO.DataBindList.Add(new DataBindDTO.DataBindEntity
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    date = Convert.ToString(reader["date"]),
                                    contact_no = Convert.ToString(reader["contact_no"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    gender = Convert.ToString(reader["gender"]),
                                    city = Convert.ToString(reader["city"]),
                                    age = Convert.ToString(reader["age"]),
                                    query = Convert.ToString(reader["query"]),
                                    assigned_manager = Convert.ToString(reader["assigned_manager"]),
                                    manager_status = Convert.ToString(reader["manager_status"]),
                                    assigned_executive = Convert.ToString(reader["assigned_executive"]),
                                    executive_status = Convert.ToString(reader["executive_status"]),
                                    assigned_doctor = Convert.ToString(reader["assigned_doctor"]),
                                    doctrore_status = Convert.ToString(reader["doctrore_status"]),
                                    assigned_delivery_man = Convert.ToString(reader["assigned_delivery_man"]),
                                    delivery_status = Convert.ToString(reader["delivery_status"]),
                                    source = Convert.ToString(reader["source"])

                                });
                            }
                            objDataBindDTO.Message = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("CustomerDetail", "DataBindDAL", ex.ToString());
                        throw;
                    }
                    return objDataBindDTO;
                }
            }
        }

        // DoctorDAL.cs
        public class DoctorDAL : DALBASE
        {
            DoctorDTO objDoctorDTO = new DoctorDTO();

            public DoctorDTO Registration(string Operation, string full_name, string email_id, string password, string contact_no)
            {
                objDoctorDTO.DoctorList = new List<DoctorDTO.DoctorEntity>();
                using (command = db.GetStoredProcCommand("SP_DoctorsDetails"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctors");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@FullName", DbType.String, full_name);
                    db.AddInParameter(command, "@EmailId", DbType.String, email_id);
                    db.AddInParameter(command, "@Password", DbType.String, password);
                    db.AddInParameter(command, "@ContactNo", DbType.String, contact_no);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (obj.ToString() == null)
                        {
                            objDoctorDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "Registered")
                        {
                            objDoctorDTO.ErrorMessage = "Success";
                        }
                        else
                        {
                            objDoctorDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("Registration", "DoctorDAL", ex.ToString());
                    }
                    return objDoctorDTO;
                }
            }

            public DoctorDTO RegisteredAll(string Operation, int doctor_id, string full_name, string email_id, string contact_no)
            {
                objDoctorDTO.DoctorList = new List<DoctorDTO.DoctorEntity>();
                using (command = db.GetStoredProcCommand("SP_DoctorsDetails"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctors");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@DoctorId", DbType.Int32, doctor_id);
                    db.AddInParameter(command, "@FullName", DbType.String, full_name);
                    db.AddInParameter(command, "@EmailId", DbType.String, email_id);
                    db.AddInParameter(command, "@ContactNo", DbType.String, contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objDoctorDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objDoctorDTO.DoctorList.Add(new DoctorDTO.DoctorEntity
                                {
                                    doctor_id = Convert.ToInt32(reader["doctor_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    contact_no = Convert.ToString(reader["contact_no"])
                                }
                                    );

                            }
                            objDoctorDTO.ErrorMessage = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("RegisteredAll", "DoctorDAL", ex.ToString());
                        throw;
                    }
                    return objDoctorDTO;
                }
            }

            public DoctorDTO RegisteredById(string Operation, int doctor_id, string full_name, string email_id, string contact_no)
            {
                objDoctorDTO.DoctorList = new List<DoctorDTO.DoctorEntity>();
                using (command = db.GetStoredProcCommand("SP_DoctorsDetails"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctors");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@DoctorId", DbType.Int32, doctor_id);
                    db.AddInParameter(command, "@FullName", DbType.String, full_name);
                    db.AddInParameter(command, "@EmailId", DbType.String, email_id);
                    db.AddInParameter(command, "@ContactNo", DbType.String, contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objDoctorDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objDoctorDTO.DoctorList.Add(new DoctorDTO.DoctorEntity
                                {
                                    doctor_id = Convert.ToInt32(reader["doctor_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    contact_no = Convert.ToString(reader["contact_no"])
                                }

                                    );
                            }
                            objDoctorDTO.ErrorMessage = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("RegisteredById", "DoctorDAL", ex.ToString());
                        throw;
                    }
                    return objDoctorDTO;
                }
            }

            public DoctorDTO Update(string Operation, int doctor_id, string full_name, string email_id, string contact_no, string password)
            {
                objDoctorDTO.DoctorList = new List<DoctorDTO.DoctorEntity>();
                using (command = db.GetStoredProcCommand("SP_DoctorsDetails"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctors");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@DoctorId", DbType.Int32, doctor_id);
                    db.AddInParameter(command, "@FullName", DbType.String, full_name);
                    db.AddInParameter(command, "@EmailId", DbType.String, email_id);
                    db.AddInParameter(command, "@ContactNo", DbType.String, contact_no);
                    db.AddInParameter(command, "@Password", DbType.String, password);
                }
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objDoctorDTO.ErrorMessage = "Unsuccessful";
                    }
                    else
                    {
                        objDoctorDTO.ErrorMessage = "Success";
                        while (reader.Read())
                        {
                            objDoctorDTO.Retval = Convert.ToString(reader["retval"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("Update", "DoctorDAL", ex.ToString());
                    throw;
                }
                return objDoctorDTO;
            }

            public DoctorDTO Delete(int doctor_id, string Operation)
            {
                objDoctorDTO.DoctorList = new List<DoctorDTO.DoctorEntity>();
                using (command = db.GetStoredProcCommand("SP_DoctorsDetails"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctors");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@DoctorId", DbType.Int32, Convert.ToInt32(doctor_id));
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objDoctorDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            objDoctorDTO.ErrorMessage = "Success";
                            while (reader.Read())
                            {
                                objDoctorDTO.Retval = Convert.ToString(reader["retval"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("Delete", "DoctorDAL", ex.ToString());
                        throw;
                    }
                    return objDoctorDTO;
                }
            }

            #region Reports By Doctor
            public DoctorDTO DoctorReports(string doctor_id)
            {
                try
                {
                    objDoctorDTO.DoctorCustomerList = new List<DoctorDTO.CustomerEntity>();
                    using (command = db.GetStoredProcCommand("SP_getCounts"))
                    {
                        db.AddInParameter(command, "@Action", DbType.String, "getAllCustomerAssignedToDoctor");
                        db.AddInParameter(command, "@doctor_id", DbType.Int32, doctor_id);

                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objDoctorDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string retval = Convert.ToString(reader["retval"]);
                                if (retval == "Success")
                                {
                                    objDoctorDTO.DoctorCustomerList.Add(new DoctorDTO.CustomerEntity
                                    {
                                        customerId = Convert.ToInt32(reader["id"]),
                                        fullName = Convert.ToString(reader["full_name"]),
                                        enquiryDate = Convert.ToString(reader["date"]),
                                        contactNo = Convert.ToString(reader["contact_no"]),
                                        emailId = Convert.ToString(reader["email_id"]),
                                        gender = Convert.ToString(reader["gender"]),
                                        city = Convert.ToString(reader["city"]),
                                        age = Convert.ToString(reader["age"]),
                                        query = Convert.ToString(reader["query"]),
                                        assigned_manager = Convert.ToString(reader["assigned_manager"]),
                                        manager_status = Convert.ToString(reader["manager_status"]),
                                        assigned_executive = Convert.ToString(reader["assigned_executive"]),
                                        executive_status = Convert.ToString(reader["executive_status"]),
                                        assigned_doctor = Convert.ToString(reader["assigned_doctor"]),
                                        doctrore_status = Convert.ToString(reader["doctrore_status"]),
                                        assigned_delivery_man = Convert.ToString(reader["assigned_delivery_man"]),
                                        delivery_status = Convert.ToString(reader["delivery_status"]),
                                        source = Convert.ToString(reader["source"])
                                    });
                                    objDoctorDTO.ErrorCode = (int)ErrorCode.ErrorType.SUCCESS;
                                    objDoctorDTO.ErrorMessage = "Success";
                                }
                                else
                                {
                                    objDoctorDTO.ErrorCode = (int)ErrorCode.ErrorType.ERROR;
                                    objDoctorDTO.ErrorMessage = "Something went wrong";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("DoctorReports", "DoctorDAL", ex.ToString());
                }
                return objDoctorDTO;
            }
            #endregion
        }

        // EmployeeDAL.cs
        public class EmployeeDAL : DALBASE
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();

            public EmployeeDTO CourierRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Courier");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);

                        if (obj.ToString() == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "CourierRegistered")
                        {
                            objEmployeeDTO.ErrorMessage = "Successful";
                        }
                        else if (obj.ToString() == "Email already exist")
                        {
                            objEmployeeDTO.ErrorMessage = "Email already exist";
                        }
                        else
                        {
                            objEmployeeDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("CourierRegistration", "EmployeeDAL", ex.ToString());
                    }
                    return objEmployeeDTO;
                }
            }

            public EmployeeDTO TelecallerRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);

                        if (obj.ToString() == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "TelecallerRegistered")
                        {
                            objEmployeeDTO.ErrorMessage = "Successful";
                        }
                        else if (obj.ToString() == "Email already exist")
                        {
                            objEmployeeDTO.ErrorMessage = "Email already exist";
                        }
                        else
                        {
                            objEmployeeDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("TelecallerRegistration", "EmployeeDAL", ex.ToString());
                    }
                    return objEmployeeDTO;
                }

            }

            public EmployeeDTO ManagerRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Manager");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);

                        if (obj.ToString() == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "ManagerRegistered")
                        {
                            objEmployeeDTO.ErrorMessage = "Successful";
                        }
                        else if (obj.ToString() == "Email already exist")
                        {
                            objEmployeeDTO.ErrorMessage = "Email already exist";
                        }
                        else
                        {
                            objEmployeeDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("ManagerRegistration", "EmployeeDAL", ex.ToString());
                    }
                    return objEmployeeDTO;
                }

            }

            public EmployeeDTO AllManagerRegistered(string Operation, int designation_id/*, int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Manager");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    //db.AddInParameter(command, "@employee_id",DbType.String, employee_id);
                    //db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    //db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    //db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    //db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    //db.AddInParameter(command, "@Contact_no", DbType.String, Contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objEmployeeDTO.EmployeeList.Add(new EmployeeDTO.EmployeeEntity
                                {
                                    employee_id = Convert.ToInt32(reader["employee_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    password = Convert.ToString(reader["password"]),
                                    designation_id = Convert.ToInt32(reader["designation_id"]),
                                    Gender = Convert.ToString(reader["Gender"]),
                                    Contact_no = Convert.ToString(reader["contact_no"])
                                });
                            }
                            objEmployeeDTO.ErrorMessage = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("AllManagerRegistered", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }

            }

            public EmployeeDTO ManagerRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Manager");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    //db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    //db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    //db.AddInParameter(command, "@password", DbType.String, password);
                    //db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    //db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    //db.AddInParameter(command, "@Contact_no", DbType.String, Contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objEmployeeDTO.EmployeeList.Add(new EmployeeDTO.EmployeeEntity
                                {
                                    employee_id = Convert.ToInt32(reader["employee_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    password = Convert.ToString(reader["password"]),
                                    designation_id = Convert.ToInt32(reader["designation_id"]),
                                    Gender = Convert.ToString(reader["Gender"]),
                                    Contact_no = Convert.ToString(reader["contact_no"])
                                });
                            }
                            objEmployeeDTO.ErrorMessage = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("ManagerRegisteredByID", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }

            }

            public EmployeeDTO ManagerUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Manager");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                }
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objEmployeeDTO.ErrorMessage = "Unsuccessful";
                    }
                    else
                    {
                        objEmployeeDTO.ErrorMessage = "Success";
                        while (reader.Read())
                        {
                            objEmployeeDTO.Retval = Convert.ToString(reader["retval"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("ManagerUpdate", "EmployeeDAL", ex.ToString());
                    throw;
                }
                return objEmployeeDTO;
            }

            public EmployeeDTO ManagerDelete(int employee_id, string Operation)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Manager");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            objEmployeeDTO.ErrorMessage = "Success";
                            while (reader.Read())
                            {
                                objEmployeeDTO.Retval = Convert.ToString(reader["retval"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("ManagerDelete", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }
            }

            public EmployeeDTO DoctorRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctor");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                    object obj = db.ExecuteScalar(command);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);

                        if (obj.ToString() == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else if (obj.ToString() == "DoctorRegistered")
                        {
                            objEmployeeDTO.ErrorMessage = "Successful";
                        }
                        else if (obj.ToString() == "Email already exist")
                        {
                            objEmployeeDTO.ErrorMessage = "Email already exist";
                        }
                        else
                        {
                            objEmployeeDTO.ErrorMessage = "Something went wrong";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("DoctorRegistration", "EmployeeDAL", ex.ToString());
                    }
                    return objEmployeeDTO;
                }

            }
            public EmployeeDTO AllDoctorRegistered(string Operation, int designation_id/*, int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctor");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    //db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    //db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    //db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    //db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    //db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    //db.AddInParameter(command, "@Contact_no", DbType.String, Contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objEmployeeDTO.EmployeeList.Add(new EmployeeDTO.EmployeeEntity
                                {
                                    employee_id = Convert.ToInt32(reader["employee_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    password = Convert.ToString(reader["password"]),
                                    designation_id = Convert.ToInt32(reader["designation_id"]),
                                    Gender = Convert.ToString(reader["Gender"]),
                                    Contact_no = Convert.ToString(reader["contact_no"])
                                });
                            }
                            objEmployeeDTO.ErrorMessage = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("AllDoctorRegistered", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }

            }
            public EmployeeDTO DoctorRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctor");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    //db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    //db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    //db.AddInParameter(command, "@password", DbType.String, password);
                    //db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    //db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    //db.AddInParameter(command, "@Contact_no", DbType.String, Contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objEmployeeDTO.EmployeeList.Add(new EmployeeDTO.EmployeeEntity
                                {
                                    employee_id = Convert.ToInt32(reader["employee_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    password = Convert.ToString(reader["password"]),
                                    designation_id = Convert.ToInt32(reader["designation_id"]),
                                    Gender = Convert.ToString(reader["Gender"]),
                                    Contact_no = Convert.ToString(reader["contact_no"])
                                });
                            }
                            objEmployeeDTO.ErrorMessage = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("DoctorRegisteredByID", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }

            }

            public EmployeeDTO DoctorUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctor");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                }
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objEmployeeDTO.ErrorMessage = "Unsuccessful";
                    }
                    else
                    {
                        objEmployeeDTO.ErrorMessage = "Success";
                        while (reader.Read())
                        {
                            objEmployeeDTO.Retval = Convert.ToString(reader["retval"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("DoctorUpdate", "EmployeeDAL", ex.ToString());
                    throw;
                }
                return objEmployeeDTO;
            }

            public EmployeeDTO DoctorDelete(int employee_id, string Operation)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Doctor");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            objEmployeeDTO.ErrorMessage = "Success";
                            while (reader.Read())
                            {
                                objEmployeeDTO.Retval = Convert.ToString(reader["retval"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("DoctorDelete", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }
            }



            public EmployeeDTO AllTelecallerRegistered(string Operation, int designation_id/*, int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    //db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    //db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    //db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    //db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    //db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    //db.AddInParameter(command, "@Contact_no", DbType.String, Contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objEmployeeDTO.EmployeeList.Add(new EmployeeDTO.EmployeeEntity
                                {
                                    employee_id = Convert.ToInt32(reader["employee_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    password = Convert.ToString(reader["password"]),
                                    designation_id = Convert.ToInt32(reader["designation_id"]),
                                    Gender = Convert.ToString(reader["Gender"]),
                                    Contact_no = Convert.ToString(reader["contact_no"])
                                });
                            }
                            objEmployeeDTO.ErrorMessage = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("AllTelecallerRegistered", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }

            }

            public EmployeeDTO TelecallerRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    //db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    //db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    //db.AddInParameter(command, "@password", DbType.String, password);
                    //db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    //db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    //db.AddInParameter(command, "@Contact_no", DbType.String, Contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objEmployeeDTO.EmployeeList.Add(new EmployeeDTO.EmployeeEntity
                                {
                                    employee_id = Convert.ToInt32(reader["employee_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    password = Convert.ToString(reader["password"]),
                                    designation_id = Convert.ToInt32(reader["designation_id"]),
                                    Gender = Convert.ToString(reader["Gender"]),
                                    Contact_no = Convert.ToString(reader["contact_no"])
                                });
                            }
                            objEmployeeDTO.ErrorMessage = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("TelecallerRegisteredByID", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }

            }

            public EmployeeDTO TelecallerUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    db.AddInParameter(command, "@full_name", DbType.String, full_name);
                    db.AddInParameter(command, "@email_id", DbType.String, email_id);
                    db.AddInParameter(command, "@password", DbType.String, password);
                    db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
                    db.AddInParameter(command, "@Gender", DbType.String, Gender);
                    db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
                }
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objEmployeeDTO.ErrorMessage = "Unsuccessful";
                    }
                    else
                    {
                        objEmployeeDTO.ErrorMessage = "Success";
                        while (reader.Read())
                        {
                            objEmployeeDTO.Retval = Convert.ToString(reader["retval"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("TelecallerUpdate", "EmployeeDAL", ex.ToString());
                    throw;
                }
                return objEmployeeDTO;
            }

            public EmployeeDTO TelecallerDelete(int employee_id, string Operation)
            {
                objEmployeeDTO.EmployeeList = new List<EmployeeDTO.EmployeeEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@employee_id", DbType.String, employee_id);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objEmployeeDTO.ErrorMessage = "Unsuccessful";
                        }
                        else
                        {
                            objEmployeeDTO.ErrorMessage = "Success";
                            while (reader.Read())
                            {
                                objEmployeeDTO.Retval = Convert.ToString(reader["retval"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("TelecallerDelete", "EmployeeDAL", ex.ToString());
                        throw;
                    }
                    return objEmployeeDTO;
                }
            }
        }

        // ManagerDAL.cs
        public class ManagerDAL : DALBASE
        {
            ManagerDTO obManajerDTO = new ManagerDTO();
            public ManagerDTO managerOperation(string managerId, string fullName, string emailId, string password, string operation)
            {
                obManajerDTO.ManagerList = new List<ManagerDTO.ManagerEntity>();
                using (command = db.GetStoredProcCommand(""))

                {
                    db.AddInParameter(command, "@Action", DbType.String, "Manager");
                    db.AddInParameter(command, "@Manager_Id", DbType.String, "managerId");
                    db.AddInParameter(command, "@FullName", DbType.String, "fullName");
                    db.AddInParameter(command, "@EmailId", DbType.String, "emailId");
                    db.AddInParameter(command, "@Password", DbType.String, "password");
                    db.AddInParameter(command, "@Operation", DbType.String, "operation");

                }
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        obManajerDTO.Message = "Unsuccessfull";
                        obManajerDTO.Code = (int)ErrorCode.ErrorType.DATANOTFOUND;
                    }
                    else if (reader.ToString() == "Registered")
                    {
                        obManajerDTO.Message = "Registered";
                        obManajerDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                    }
                    else if (reader.ToString() == "Updated")
                    {
                        obManajerDTO.Message = "Updated";
                        obManajerDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                    }
                    else if (reader.ToString() == "Deleted")
                    {
                        obManajerDTO.Message = "Deleted";
                        obManajerDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            obManajerDTO.ManagerList.Add(new ManagerDTO.ManagerEntity
                            {
                                managerId = (int)(reader["manager_id"]),
                                fullName = Convert.ToString(reader["full_name"]),
                                emailId = Convert.ToString(reader["email_id"]),

                            });
                        }
                        obManajerDTO.Message = "Success";
                        obManajerDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                    }
                }
                catch (Exception ex)
                {
                    obManajerDTO.Message = "Exception";
                    obManajerDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                    ErrorLog("ManagerDAL", "managerOperation", ex.ToString());
                }
                return obManajerDTO;
            }

            #region Reports By Manager

            public ManagerDTO ManagerReports(string managerId, string startDate, string endDate)
            {
                try
                {
                    obManajerDTO.ManagerCustomerList = new List<ManagerDTO.CustomerEntity>();
                    using (command = db.GetStoredProcCommand("SP_getCounts"))
                    {
                        db.AddInParameter(command, "@Action", DbType.String, "getAllCustomerAssignedToManager");
                        db.AddInParameter(command, "@managerId", DbType.Int32, managerId);
                        db.AddInParameter(command, "@startDate", DbType.String, startDate);
                        db.AddInParameter(command, "@endDate", DbType.String, endDate);

                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            obManajerDTO.Message = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string retval = Convert.ToString(reader["retval"]);
                                if (retval == "Success")
                                {
                                    obManajerDTO.ManagerCustomerList.Add(new ManagerDTO.CustomerEntity
                                    {
                                        customerId = Convert.ToInt32(reader["id"]),
                                        fullName = Convert.ToString(reader["full_name"]),
                                        enquiryDate = Convert.ToString(reader["date"]),
                                        contactNo = Convert.ToString(reader["contact_no"]),
                                        emailId = Convert.ToString(reader["email_id"]),
                                        gender = Convert.ToString(reader["gender"]),
                                        city = Convert.ToString(reader["city"]),
                                        age = Convert.ToString(reader["age"]),
                                        query = Convert.ToString(reader["query"]),
                                        assigned_manager = Convert.ToString(reader["assigned_manager"]),
                                        manager_status = Convert.ToString(reader["manager_status"]),
                                        assigned_executive = Convert.ToString(reader["assigned_executive"]),
                                        executive_status = Convert.ToString(reader["executive_status"]),
                                        assigned_doctor = Convert.ToString(reader["assigned_doctor"]),
                                        doctrore_status = Convert.ToString(reader["doctrore_status"]),
                                        assigned_delivery_man = Convert.ToString(reader["assigned_delivery_man"]),
                                        delivery_status = Convert.ToString(reader["delivery_status"]),
                                        source = Convert.ToString(reader["source"])
                                    });
                                    obManajerDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                                    obManajerDTO.Message = "Success";
                                }
                                else
                                {
                                    obManajerDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                                    obManajerDTO.Message = "Something went wrong";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("ManagerReports", "ManagerDAL", ex.ToString());
                }
                return obManajerDTO;
            }
            #endregion
        }

        // TelecallerDAL.cs
        public class TelecallerDAL : DALBASE
        {
            TelecallerDTO objTelecallerDTO = new TelecallerDTO();

            //public TelecallerDTO Registration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            //{
            //    objTelecallerDTO.TelecallerList = new List<TelecallerDTO.TelecallerEntity>();
            //    using (command = db.GetStoredProcCommand("SP_RegisterAll"))
            //    {
            //        db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
            //        db.AddInParameter(command, "@Operation", DbType.String, Operation);
            //        db.AddInParameter(command, "@full_name", DbType.String, full_name);
            //        db.AddInParameter(command, "@email_id", DbType.String, email_id);
            //        db.AddInParameter(command, "@password", DbType.String, password);
            //        db.AddInParameter(command, "@designation_id", DbType.String, designation_id);
            //        db.AddInParameter(command, "@Gender", DbType.String, Gender);
            //        db.AddInParameter(command, "@Contact_no", DbType.String, contact_no);
            //        object obj = db.ExecuteScalar(command);
            //        try
            //        {
            //            IDataReader reader = db.ExecuteReader(command);

            //            if (obj.ToString() == null)
            //            {
            //                objTelecallerDTO.ErrorMessage = "Unsuccessful";
            //            }
            //            else if (obj.ToString() == "Registered")
            //            {
            //                objTelecallerDTO.ErrorMessage = "Success";
            //            }
            //            else if (obj.ToString() == "Email already exist")
            //            {
            //                objTelecallerDTO.ErrorMessage = "Email already exist";
            //            }
            //            else
            //            {
            //                objTelecallerDTO.ErrorMessage = "Something went wrong";
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            ErrorLog("Registration", "TelecallerDAL", ex.ToString());
            //        }
            //        return objTelecallerDTO;
            //    }
            //}

            public TelecallerDTO RegisteredAll(string Operation, int caller_id, string full_name, string email_id, string contact_no)
            {
                objTelecallerDTO.TelecallerList = new List<TelecallerDTO.TelecallerEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@CallerId", DbType.Int32, caller_id);
                    db.AddInParameter(command, "@FullName", DbType.String, full_name);
                    db.AddInParameter(command, "@EmailId", DbType.String, email_id);
                    db.AddInParameter(command, "@ContactNo", DbType.String, contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {

                            objTelecallerDTO.Message = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objTelecallerDTO.TelecallerList.Add(new TelecallerDTO.TelecallerEntity
                                {
                                    caller_id = Convert.ToInt32(reader["caller_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    contact_no = Convert.ToString(reader["contact_no"])
                                });
                            }
                            objTelecallerDTO.Message = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("RegisteredAll", "TelecallerDAL", ex.ToString());
                        throw;
                    }
                    return objTelecallerDTO;
                }
            }

            public TelecallerDTO RegisteredById(string Operation, int caller_id, string full_name, string email_id, string contact_no)
            {
                objTelecallerDTO.TelecallerList = new List<TelecallerDTO.TelecallerEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@CallerId", DbType.Int32, caller_id);
                    db.AddInParameter(command, "@FullName", DbType.String, full_name);
                    db.AddInParameter(command, "@EmailId", DbType.String, email_id);
                    db.AddInParameter(command, "@ContactNo", DbType.String, contact_no);
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objTelecallerDTO.Message = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                objTelecallerDTO.TelecallerList.Add(new TelecallerDTO.TelecallerEntity
                                {
                                    caller_id = Convert.ToInt32(reader["caller_id"]),
                                    full_name = Convert.ToString(reader["full_name"]),
                                    email_id = Convert.ToString(reader["email_id"]),
                                    contact_no = Convert.ToString(reader["contact_no"])
                                }

                                    );
                            }
                            objTelecallerDTO.Message = "Success";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("RegisteredById", "TelecallerDAL", ex.ToString());
                        throw;
                    }
                    return objTelecallerDTO;
                }
            }

            public TelecallerDTO Update(string Operation, int caller_id, string full_name, string email_id, string contact_no, string password)
            {
                objTelecallerDTO.TelecallerList = new List<TelecallerDTO.TelecallerEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@CallerId", DbType.Int32, caller_id);
                    db.AddInParameter(command, "@FullName", DbType.String, full_name);
                    db.AddInParameter(command, "@EmailId", DbType.String, email_id);
                    db.AddInParameter(command, "@ContactNo", DbType.String, contact_no);
                    db.AddInParameter(command, "@Password", DbType.String, password);
                }
                try
                {
                    IDataReader reader = db.ExecuteReader(command);
                    if (reader == null)
                    {
                        objTelecallerDTO.Message = "Unsuccessful";
                    }
                    else
                    {
                        objTelecallerDTO.Message = "Success";
                        while (reader.Read())
                        {
                            objTelecallerDTO.Retval = Convert.ToString(reader["retval"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog("Update", "TelecallerDAL", ex.ToString());
                    throw;
                }
                return objTelecallerDTO;
            }

            public TelecallerDTO Delete(int caller_id, string Operation)
            {
                objTelecallerDTO.TelecallerList = new List<TelecallerDTO.TelecallerEntity>();
                using (command = db.GetStoredProcCommand("SP_RegisterAll"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "Telecaller");
                    db.AddInParameter(command, "@Operation", DbType.String, Operation);
                    db.AddInParameter(command, "@CallerId", DbType.Int32, Convert.ToInt32(caller_id));
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objTelecallerDTO.Message = "Unsuccessful";
                        }
                        else
                        {
                            objTelecallerDTO.Message = "Success";
                            while (reader.Read())
                            {
                                objTelecallerDTO.Retval = Convert.ToString(reader["retval"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog("Delete", "TelecallerDAL", ex.ToString());
                        throw;
                    }
                    return objTelecallerDTO;
                }
            }

            public TelecallerDTO TelecallerLogin(string email_id, string password)
            {
                objTelecallerDTO.TelecallerList = new List<TelecallerDTO.TelecallerEntity>();
                using (command = db.GetStoredProcCommand("SP_telecallerLogin"))
                {
                    db.AddInParameter(command, "@Action", DbType.String, "telecallerLogin");
                    db.AddInParameter(command, "@emailId", DbType.String, email_id);
                    db.AddInParameter(command, "@password", DbType.String, password);
                    // db.AddInParameter(command, "", DbType.String, );
                    try
                    {
                        IDataReader reader = db.ExecuteReader(command);
                        if (reader == null)
                        {
                            objTelecallerDTO.Message = "Unsuccessful";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string retval = Convert.ToString(reader["retval"]);
                                if (retval == "LoginSuccess")
                                {

                                    objTelecallerDTO.TelecallerList.Add(new TelecallerDTO.TelecallerEntity
                                    {
                                        caller_id = Convert.ToInt32(reader["caller_id"]),
                                        full_name = Convert.ToString(reader["full_name"]),
                                        email_id = Convert.ToString(reader["email_id"]),
                                        password = Convert.ToString(reader["password"]),
                                        designation_id = Convert.ToInt32(reader["designation_id"]),
                                        Gender = Convert.ToString(reader["Gender"]),
                                        contact_no = Convert.ToString(reader["contact_no"]),
                                        Punchdate = Convert.ToString(reader["Punchdate"]),
                                        Punch_In = Convert.ToString(reader["Punch_In"]),
                                        Punch_Out = Convert.ToString(reader["Punch_Out"])
                                    });
                                    objTelecallerDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                                    objTelecallerDTO.Message = "LoginSuccess";
                                }
                                else if (retval == "Wrong Password")
                                {
                                    objTelecallerDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                                    objTelecallerDTO.Message = "Wrong Password";
                                }
                                else if (retval == "NOTEXISTS")
                                {
                                    objTelecallerDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                                    objTelecallerDTO.Message = "NOTEXISTS";
                                }
                                else if (retval == "Already Login")
                                {
                                    objTelecallerDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                                    objTelecallerDTO.Message = "Already Login";
                                }
                                else
                                {
                                    objTelecallerDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                                    objTelecallerDTO.Message = "Unsuccessful";
                                }
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        ErrorLog("TelecallerLogin", "TelecallerDAL", ex.ToString());
                        throw;
                    }
                    return objTelecallerDTO;
                }
            }
        }
    }
}
