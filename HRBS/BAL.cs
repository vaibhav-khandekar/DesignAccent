using HRBS.DAL;
using HRBS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBS.BAL
{
    public class HRBS
    {
        // AdminBAL.cs
        public class AdminBAL
        {
            AdminDAL objAdminDAL = new AdminDAL();
            AdminDTO objAdminDTO = new AdminDTO();

            public AdminDTO HRBSAdminLogin(string Email, string Password)
            {
                objAdminDTO = objAdminDAL.HRBSAdminLogin(Email, Password);
                return objAdminDTO;
            }

            public AdminDTO HRBSAdminLogout(string Email, string Password)
            {
                objAdminDTO = objAdminDAL.HRBSAdminLogout(Email, Password);
                return objAdminDTO;
            }

            public AdminDTO adminDashboard(string startDate, string endDate)
            {
                objAdminDTO = objAdminDAL.adminDashboard(startDate, endDate);
                return objAdminDTO;
            }
        }

        // AssignToCustomerBAL.cs
        public class AssignToCustomerBAL
        {
            AssignToCustomerDAL objAssignToCustomerDAL = new AssignToCustomerDAL();
            AssignToCustomerDTO objAssignToCustomerDTO = new AssignToCustomerDTO();

            public AssignToCustomerDTO InsertCustomerToAssign(string Action, string Customres, string MangerId/*, string TelecallerId, string DoctorId, string CourierPersonId*/)
            {
                objAssignToCustomerDTO = objAssignToCustomerDAL.InsertCustomerToAssign(Action, Customres, MangerId/*, TelecallerId, DoctorId, CourierPersonId*/);
                return objAssignToCustomerDTO;
            }

            public AssignToCustomerDTO AssignCustomerToTelecaller(string Action, string Customres, string TelecallerId)
            {
                objAssignToCustomerDTO = objAssignToCustomerDAL.AssignCustomerToTelecaller(Action, Customres, TelecallerId);
                return objAssignToCustomerDTO;
            }

            public AssignToCustomerDTO AssignCustomerToDoctor(string Action, string Customres, string DoctorId)
            {
                objAssignToCustomerDTO = objAssignToCustomerDAL.AssignCustomerToDoctor(Action, Customres, DoctorId);
                return objAssignToCustomerDTO;
            }

            public AssignToCustomerDTO AssignCustomerToCourier(string Action, string Customres, string CourierPersonId)
            {
                objAssignToCustomerDTO = objAssignToCustomerDAL.AssignCustomerToCourier(Action, Customres, CourierPersonId);
                return objAssignToCustomerDTO;
            }
        }

        // AttendanceLogBAL.cs
        public class AttendanceLogBAL
        {
            AttendanceLogDAL objAttendanceLogDAL = new AttendanceLogDAL();
            AttendanceLogDTO objAttendanceLogDTO = new AttendanceLogDTO();
            public AttendanceLogDTO InsertPunchINSelfie(string EmployeeCode, /*string PunchInLat, string PunchInLong, string Address, string PunchInFrom, string BatteryLevel, string DeviceName, string AndroidOS, string LocationFrom,*/ string PunchinPic)
            {
                objAttendanceLogDTO = objAttendanceLogDAL.InsertPunchINSelfie(EmployeeCode, /*PunchInLat, PunchInLong, Address,  PunchInFrom, BatteryLevel, DeviceName, AndroidOS, LocationFrom,*/ PunchinPic);
                return objAttendanceLogDTO;
            }

            public AttendanceLogDTO updatePunchOutSelfie(string EmployeeCode,/* string PunchOutLat, string PunchOutLong, string Address, string PunchOutFrom, string BatteryLevel, string DeviceName, string AndroidOS, string LocationFrom,*/ string PunchoutPic)
            {
                objAttendanceLogDTO = objAttendanceLogDAL.updatePunchOutSelfie(EmployeeCode,/* PunchOutLat, PunchOutLong, Address, PunchOutFrom, BatteryLevel, DeviceName, AndroidOS, LocationFrom,*/ PunchoutPic);
                return objAttendanceLogDTO;
            }
        }

        // CustomerByWebBAL.cs
        public class CustomerByWebBAL
        {
            CustomerByWebDAL objCustomerByWebDAL = new CustomerByWebDAL();
            CustomerByWebDTO objCustomerByWebDTO = new CustomerByWebDTO();

            public CustomerByWebDTO Insert(string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
            {
                objCustomerByWebDTO = objCustomerByWebDAL.Insert(full_name, date, contact_no, email_id, gender, city, age, query, source);
                return objCustomerByWebDTO;
            }

            public CustomerByWebDTO Update(int id, string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
            {
                objCustomerByWebDTO = objCustomerByWebDAL.Update(id, full_name, date, contact_no, email_id, gender, city, age, query, source);
                return objCustomerByWebDTO;
            }
        }

        // DataBindBAL.cs
        public class DataBindBAL
        {
            DataBindDAL objDataBindDAL = new DataBindDAL();
            DataBindDTO objDataBindDTO = new DataBindDTO();

            public DataBindDTO CustomerDetail(string Operation)
            {
                objDataBindDTO = objDataBindDAL.CustomerDetail(Operation);
                return objDataBindDTO;
            }
        }

        // DoctorBAL.cs
        public class DoctorBAL
        {
            DoctorDAL objDoctorDAL = new DoctorDAL();
            DoctorDTO objDoctorDTO = new DoctorDTO();


            public DoctorDTO Registration(string Operation, string full_name, string email_id, string password, string contact_no)
            {
                objDoctorDTO = objDoctorDAL.Registration(Operation, full_name, email_id, password, contact_no);
                return objDoctorDTO;
            }

            public DoctorDTO RegisteredAll(string Operation, int doctor_id, string full_name, string email_id, string contact_no)
            {
                objDoctorDTO = objDoctorDAL.RegisteredAll(Operation, doctor_id, full_name, email_id, contact_no);
                return objDoctorDTO;
            }

            public DoctorDTO RegisteredById(string Operation, int doctor_id, string full_name, string email_id, string contact_no)
            {
                objDoctorDTO = objDoctorDAL.RegisteredById(Operation, doctor_id, full_name, email_id, contact_no);
                return objDoctorDTO;
            }

            public DoctorDTO Update(string Operation, int doctor_id, string full_name, string email_id, string contact_no, string password)
            {
                objDoctorDTO = objDoctorDAL.Update(Operation, doctor_id, full_name, email_id, contact_no, password);
                return objDoctorDTO;
            }

            public DoctorDTO Delete(int doctor_id, string Operation)
            {
                objDoctorDTO = objDoctorDAL.Delete(doctor_id, Operation);
                return objDoctorDTO;
            }

            #region Reports By Doctor
            public DoctorDTO DoctorReports(string doctor_id)
            {
                objDoctorDTO = objDoctorDAL.DoctorReports(doctor_id);
                return objDoctorDTO;
            }
            #endregion
        }

        // EmployeeBAL.cs
        public class EmployeeBAL
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();

            public EmployeeDTO CourierRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO = objEmployeeDAL.CourierRegistration(Operation, full_name, email_id, password, designation_id, Gender, contact_no);
                return objEmployeeDTO;
            }
            public EmployeeDTO ManagerRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO = objEmployeeDAL.ManagerRegistration(Operation, full_name, email_id, password, designation_id, Gender, contact_no);
                return objEmployeeDTO;
            }

            public EmployeeDTO AllManagerRegistered(string Operation, int designation_id/*, int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                objEmployeeDTO = objEmployeeDAL.AllManagerRegistered(Operation, designation_id/*, employee_id, full_name, email_id, password,  Gender, Contact_no*/);
                return objEmployeeDTO;
            }

            public EmployeeDTO ManagerRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                objEmployeeDTO = objEmployeeDAL.ManagerRegisteredByID(Operation, employee_id/*, full_name, email_id, password, designation_id, Gender, Contact_no*/);
                return objEmployeeDTO;
            }

            public EmployeeDTO ManagerUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO = objEmployeeDAL.ManagerUpdate(Operation, employee_id, full_name, email_id, password, designation_id, Gender, contact_no);
                return objEmployeeDTO;
            }

            public EmployeeDTO ManagerDelete(int employee_id, string Operation)
            {
                objEmployeeDTO = objEmployeeDAL.ManagerDelete(employee_id, Operation);
                return objEmployeeDTO;
            }

            public EmployeeDTO DoctorRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO = objEmployeeDAL.DoctorRegistration(Operation, full_name, email_id, password, designation_id, Gender, contact_no);
                return objEmployeeDTO;
            }

            public EmployeeDTO AllDoctorRegistered(string Operation, int designation_id/*, int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                objEmployeeDTO = objEmployeeDAL.AllDoctorRegistered(Operation, designation_id/*, employee_id, full_name, email_id, password,  Gender, Contact_no*/);
                return objEmployeeDTO;
            }

            public EmployeeDTO DoctorRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                objEmployeeDTO = objEmployeeDAL.DoctorRegisteredByID(Operation, employee_id/*, full_name, email_id, password, designation_id, Gender, Contact_no*/);
                return objEmployeeDTO;
            }

            public EmployeeDTO DoctorUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO = objEmployeeDAL.DoctorUpdate(Operation, employee_id, full_name, email_id, password, designation_id, Gender, contact_no);
                return objEmployeeDTO;
            }

            public EmployeeDTO DoctorDelete(int employee_id, string Operation)
            {
                objEmployeeDTO = objEmployeeDAL.DoctorDelete(employee_id, Operation);
                return objEmployeeDTO;
            }

            public EmployeeDTO TelecallerRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO = objEmployeeDAL.TelecallerRegistration(Operation, full_name, email_id, password, designation_id, Gender, contact_no);
                return objEmployeeDTO;
            }

            public EmployeeDTO AllTelecallerRegistered(string Operation, int designation_id/*, int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                objEmployeeDTO = objEmployeeDAL.AllTelecallerRegistered(Operation, designation_id/*, employee_id, full_name, email_id, password,  Gender, Contact_no*/);
                return objEmployeeDTO;
            }

            public EmployeeDTO TelecallerRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                objEmployeeDTO = objEmployeeDAL.TelecallerRegisteredByID(Operation, employee_id/*, full_name, email_id, password, designation_id, Gender, Contact_no*/);
                return objEmployeeDTO;
            }

            public EmployeeDTO TelecallerUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                objEmployeeDTO = objEmployeeDAL.TelecallerUpdate(Operation, employee_id, full_name, email_id, password, designation_id, Gender, contact_no);
                return objEmployeeDTO;
            }

            public EmployeeDTO TelecallerDelete(int employee_id, string Operation)
            {
                objEmployeeDTO = objEmployeeDAL.TelecallerDelete(employee_id, Operation);
                return objEmployeeDTO;
            }
        }

        // ManagerBAL.cs
        public class ManagerBAL
        {
            ManagerDAL objManagerDAL = new ManagerDAL();
            ManagerDTO obManajerDTO = new ManagerDTO();

            public ManagerDTO managerOperation(string managerId, string fullName, string emailId, string password, string operation)
            {
                obManajerDTO = objManagerDAL.managerOperation(managerId, fullName, emailId, password, operation);
                return obManajerDTO;
            }

            #region Reports By Manager

            public ManagerDTO ManagerReports(string managerId, string startDate, string endDate)
            {
                obManajerDTO = objManagerDAL.ManagerReports(managerId, startDate, endDate);
                return obManajerDTO;
            }
            #endregion
        }

        // TelecallerBAL.cs
        public class TelecallerBAL
        {
            TelecallerDAL objTelecallerDAL = new TelecallerDAL();
            TelecallerDTO objTelecallerDTO = new TelecallerDTO();


            //public TelecallerDTO Registration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            //{
            //    objTelecallerDTO = objTelecallerDAL.Registration( Operation, full_name, email_id, password,  designation_id, Gender,  contact_no);
            //    return objTelecallerDTO;
            //}

            public TelecallerDTO RegisteredAll(string Operation, int caller_id, string full_name, string email_id, string contact_no)
            {
                objTelecallerDTO = objTelecallerDAL.RegisteredAll(Operation, caller_id, full_name, email_id, contact_no);
                return objTelecallerDTO;
            }

            public TelecallerDTO RegisteredById(string Operation, int caller_id, string full_name, string email_id, string contact_no)
            {
                objTelecallerDTO = objTelecallerDAL.RegisteredById(Operation, caller_id, full_name, email_id, contact_no);
                return objTelecallerDTO;
            }

            public TelecallerDTO Update(string Operation, int caller_id, string full_name, string email_id, string contact_no, string password)
            {
                objTelecallerDTO = objTelecallerDAL.Update(Operation, caller_id, full_name, email_id, contact_no, password);
                return objTelecallerDTO;
            }

            public TelecallerDTO Delete(int caller_id, string Operation)
            {
                objTelecallerDTO = objTelecallerDAL.Delete(caller_id, Operation);
                return objTelecallerDTO;
            }
            public TelecallerDTO TelecallerLogin(string email_id, string password)
            {
                objTelecallerDTO = objTelecallerDAL.TelecallerLogin(email_id, password);
                return objTelecallerDTO;
            }
        }
    }
}
