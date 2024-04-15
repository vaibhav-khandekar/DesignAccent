using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBS.DTO
{
    public class HRBS
    {
        // AdminDTO.cs
        public class AdminDTO
        {
            public int Code { get; set; }
            public string Message { get; set; }
            public string Retval { get; set; }

            public class AdminEntity
            {
                public int ID { get; set; }
                public string Email { get; set; }
                public string Username { get; set; }
                public string Password { get; set; }

            }
            public class CustomerEntity
            {
                public int customerId { get; set; }
                public string fullName { get; set; }
                public string enquiryDate { get; set; }
                public string contactNo { get; set; }
                public string emailId { get; set; }
                public string gender { get; set; }
                public string city { get; set; }
                public string age { get; set; }
                public string query { get; set; }
                public string assigned_manager { get; set; }
                public string manager_status { get; set; }
                public string assigned_executive { get; set; }
                public string executive_status { get; set; }
                public string assigned_doctor { get; set; }
                public string doctrore_status { get; set; }
                public string assigned_delivery_man { get; set; }
                public string delivery_status { get; set; }
                public string source { get; set; }
            }
            public List<AdminDTO.AdminEntity> AdminList { get; set; }
            public List<AdminDTO.CustomerEntity> AllCustomerList { get; set; }
        }

        // AssignToCustomerDTO.cs
        public class AssignToCustomerDTO
        {
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string Retval { get; set; }

            public class AssignToCustomerEntity
            {
                //    public int id { get; set; }
                //    public string full_name { get; set; }
                //    public DateTime date { get; set; }
                //    public string contact_no { get; set; }
                //    public string email_id { get; set; }
                //    public string gender { get; set; }
                //    public string city { get; set; }
                //    public string age { get; set; }
                //    public string query { get; set; }
                //    public string assigned_manager { get; set; }
                //    public string manager_status { get; set; }
                //    public string assigned_executive { get; set; }
                //    public string executive_status { get; set; }
                //    public string assigned_doctor { get; set; }
                //    public string doctrore_status { get; set; }
                //    public string assigned_delivery_man { get; set; }
                //    public string delivery_status { get; set; }
                //    public string source { get; set; }
            }
            public List<AssignToCustomerDTO.AssignToCustomerEntity> AssignToCustomerList { get; set; }
        }

        // AttendanceLogDTO.cs
        public class AttendanceLogDTO
        {
            public string Message { get; set; }
            public int Code { get; set; }
            public string Retval { get; set; }
            public string Status { get; set; }

            public class AttendanceLogEntities
            {
                #region AttendanceLog
                public int ID { get; set; }
                public string Employeecode { get; set; }
                public string Punchin_pic { get; set; }
                public string Punchout_pic { get; set; }

                public string Punch_in { get; set; }
                public string PunchINLat { get; set; }
                public string PunchINLong { get; set; }
                public string Punch_out { get; set; }
                public string PunchOutLat { get; set; }
                public string PunchOutLong { get; set; }
                public string Date { get; set; }
                public string DesignationName { get; set; }
 
                public string Name { get; set; }

                public string TotalDistance { get; set; }
                public string TotalDuration { get; set; }
                public string TotalTime { get; set; }
                public string PunchInAddress { get; set; }
                public string PunchOutAddress { get; set; }
                public string PunchInFrom { get; set; }
                public string PunchOutFrom { get; set; }
                #endregion
            }
            public List<AttendanceLogDTO.AttendanceLogEntities> AttendanceLogList { get; set; }
        }

        // CustomerByWebDTO.cs
        public class CustomerByWebDTO
        {
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string Retval { get; set; }

            public class CustomerByWebEntity
            {

                public int id { get; set; }
                public string full_name { get; set; }
                public DateTime date { get; set; }
                public string contact_no { get; set; }
                public string email_id { get; set; }
                public string gender { get; set; }
                public string city { get; set; }
                public string age { get; set; }
                public string query { get; set; }
                public string assigned_manager { get; set; }
                public string manager_status { get; set; }
                public string assigned_executive { get; set; }
                public string executive_status { get; set; }
                public string assigned_doctor { get; set; }
                public string doctrore_status { get; set; }
                public string assigned_delivery_man { get; set; }
                public string delivery_status { get; set; }
                public string source { get; set; }
            }
            public List<CustomerByWebDTO.CustomerByWebEntity> CusromerByWebList { get; set; }
        }

        // DataBindDTO.cs
        public class DataBindDTO
        {
            public int Code { get; set; }
            public string Message { get; set; }
            public string Retval { get; set; }

            public class DataBindEntity
            {
                public int id { get; set; }
                public string full_name { get; set; }
                public string date { get; set; }
                public string contact_no { get; set; }
                public string email_id { get; set; }
                public string gender { get; set; }
                public string city { get; set; }
                public string age { get; set; }
                public string query { get; set; }
                public string assigned_manager { get; set; }
                public string manager_status { get; set; }
                public string assigned_executive { get; set; }
                public string executive_status { get; set; }
                public string assigned_doctor { get; set; }
                public string doctrore_status { get; set; }
                public string assigned_delivery_man { get; set; }
                public string delivery_status { get; set; }
                public string source { get; set; }


            }
            public List<DataBindDTO.DataBindEntity> DataBindList { get; set; }
        }

        // DoctorDTO.cs
        public class DoctorDTO
        {
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string Retval { get; set; }

            public class DoctorEntity
            {
                public int doctor_id { get; set; }
                public string full_name { get; set; }
                public string email_id { get; set; }
                public string password { get; set; }
                public string contact_no { get; set; }
            }
            public class CustomerEntity
            {
                public int doctor_id { get; set; }
                public int customerId { get; set; }
                public string fullName { get; set; }
                public string enquiryDate { get; set; }
                public string contactNo { get; set; }
                public string emailId { get; set; }
                public string gender { get; set; }
                public string city { get; set; }
                public string age { get; set; }
                public string query { get; set; }
                public string assigned_manager { get; set; }
                public string manager_status { get; set; }
                public string assigned_executive { get; set; }
                public string executive_status { get; set; }
                public string assigned_doctor { get; set; }
                public string doctrore_status { get; set; }
                public string assigned_delivery_man { get; set; }
                public string delivery_status { get; set; }
                public string source { get; set; }
            }
            public List<DoctorDTO.DoctorEntity> DoctorList { get; set; }
            public List<DoctorDTO.CustomerEntity> DoctorCustomerList { get; set; }
        }

        // EmployeeDTO.cs
        public class EmployeeDTO
        {
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string Retval { get; set; }

            public class EmployeeEntity
            {
                public int employee_id { get; set; }
                public string full_name { get; set; }
                public string email_id { get; set; }
                public string password { get; set; }
                public int designation_id { get; set; }
                public string Gender { get; set; }
                public string Contact_no { get; set; }
            }
            public List<EmployeeDTO.EmployeeEntity> EmployeeList { get; set; }
        }

        // ManagerDTO.cs
        public class ManagerDTO
        {
            public string Message { get; set; }
            public int Code { get; set; }
            public string Retval { get; set; }

            public class ManagerEntity
            {
                public int managerId { get; set; }
                public string fullName { get; set; }
                public string emailId { get; set; }
            }

            public class CustomerEntity
            {
                public int managerId { get; set; }
                public int customerId { get; set; }
                public string fullName { get; set; }
                public string enquiryDate { get; set; }
                public string contactNo { get; set; }
                public string emailId { get; set; }
                public string gender { get; set; }
                public string city { get; set; }
                public string age { get; set; }
                public string query { get; set; }
                public string assigned_manager { get; set; }
                public string manager_status { get; set; }
                public string assigned_executive { get; set; }
                public string executive_status { get; set; }
                public string assigned_doctor { get; set; }
                public string doctrore_status { get; set; }
                public string assigned_delivery_man { get; set; }
                public string delivery_status { get; set; }
                public string source { get; set; }
            }

            public List<ManagerDTO.ManagerEntity> ManagerList { get; set; }
            public List<ManagerDTO.CustomerEntity> ManagerCustomerList { get; set; }
        }

        // TelecallerDTO.cs
        public class TelecallerDTO
        {
            public string Message { get; set; }
            public int Code { get; set; }
            public string Retval { get; set; }

            public class ManagerEntity
            {
                public int managerId { get; set; }
                public string fullName { get; set; }
                public string emailId { get; set; }

            }

            public class CustomerEntity
            {
                public int managerId { get; set; }
                public int customerId { get; set; }
                public string fullName { get; set; }
                public string enquiryDate { get; set; }
                public string contactNo { get; set; }
                public string emailId { get; set; }
                public string gender { get; set; }
                public string city { get; set; }
                public string age { get; set; }
                public string query { get; set; }
                public string assigned_manager { get; set; }
                public string manager_status { get; set; }
                public string assigned_executive { get; set; }
                public string executive_status { get; set; }
                public string assigned_doctor { get; set; }
                public string doctrore_status { get; set; }
                public string assigned_delivery_man { get; set; }
                public string delivery_status { get; set; }
                public string source { get; set; }
            }
            public List<ManagerDTO.ManagerEntity> ManagerList { get; set; }
            public List<ManagerDTO.CustomerEntity> ManagerCustomerList { get; set; }
        }
    }
}
