using HRBS.BAL;
using HRBS.DAL;
using HRBS.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HRBS_Api.Controllers
{
    public class HRBSController : Controller
    {
        // AdminController.cs
        public class AdminController : Controller
        {
            AdminDTO objAdminDTO = new AdminDTO();
            AdminBAL objAdminBAL = new AdminBAL();

            string Request = "";
            string Response = "";
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string Exception = "";

            public JsonResult HRBSAdminLogin(string Email, string Password)
            {
                try
                {
                    JsonResult retObj = Json(objAdminBAL.HRBSAdminLogin(Email, Password));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult HRBSAdminLogout(string Email, string Password)
            {
                try
                {
                    JsonResult retObj = Json(objAdminBAL.HRBSAdminLogout(Email, Password));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }


            public JsonResult adminDashboard(string startDate, string endDate)
            {
                try
                {
                    JsonResult retObj = Json(objAdminBAL.adminDashboard(startDate, endDate));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
        }

        // AssignToCustomerController.cs
        public class AssignToCustomerController : Controller
        {
            AssignToCustomerDTO objAssignToCustomerDTO = new AssignToCustomerDTO();
            AssignToCustomerBAL objAssignToCustomerBAL = new AssignToCustomerBAL();

            string Request = "";
            string Response = "";
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string Exception = "";

            public JsonResult InsertCustomerToAssign(string Action, string Customres, string MangerId/*, string TelecallerId, string DoctorId, string CourierPersonId*/)
            {
                try
                {
                    JsonResult retObj = Json(objAssignToCustomerBAL.InsertCustomerToAssign(Action, Customres, MangerId/*, TelecallerId, DoctorId, CourierPersonId*/));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }


            public JsonResult AssignCustomerToTelecaller(string Action, string Customres, string TelecallerId)
            {
                try
                {
                    JsonResult retObj = Json(objAssignToCustomerBAL.AssignCustomerToTelecaller(Action, Customres, TelecallerId));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult AssignCustomerToDoctor(string Action, string Customres, string DoctorId)
            {
                try
                {
                    JsonResult retObj = Json(objAssignToCustomerBAL.AssignCustomerToDoctor(Action, Customres, DoctorId));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult AssignCustomerToCourier(string Action, string Customres, string CourierPersonId)
            {
                try
                {
                    JsonResult retObj = Json(objAssignToCustomerBAL.AssignCustomerToCourier(Action, Customres, CourierPersonId));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
        }

        // AttendanceLogController.cs
        public class AttendanceLogController : Controller
        {
            AttendanceLogBAL _objBLMaster = new AttendanceLogBAL();
            AttendanceLogDTO objAttendanceLogDTO = new AttendanceLogDTO();
            AttendanceLogBAL objAttendanceLogBAL = new AttendanceLogBAL();

            string Request = "";
            string Response = "";
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string Exception = "";

            public JsonResult InsertPunchINSelfie(string EmployeeCode, /*string PunchInLat, string PunchInLong, string Address, string PunchInFrom, string BatteryLevel, string DeviceName, string AndroidOS,*/ string PunchinPic)
            {
                string request = EmployeeCode + "||" + /*PunchInLat + "||" + PunchInLong + "||" + Address + "||" + PunchInFrom + "||" + BatteryLevel + "||" + DeviceName + "||" + AndroidOS + "||" +*/ PunchinPic;
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string MethodName = MethodBase.GetCurrentMethod().Name;
                try
                {
                    string LocationFrom = "App";
                    //switch (AndroidOS)
                    //{

                    //    case "1":
                    //        AndroidOS = "Jelly Bean";
                    //        break;
                    //    case "2":
                    //        AndroidOS = "Jelly Bean";
                    //        break;
                    //    case "3":
                    //        AndroidOS = "KitKat";
                    //        break;
                    //    case "4":
                    //        AndroidOS = "KitKat";
                    //        break;
                    //    case "5":
                    //        AndroidOS = "Lollipop";
                    //        break;
                    //    case "6":
                    //        AndroidOS = "Lollipop";
                    //        break;
                    //    case "7":
                    //        AndroidOS = "Marshmallow";
                    //        break;
                    //    case "8":
                    //        AndroidOS = "Nougat";
                    //        break;
                    //    case "9":
                    //        AndroidOS = "Nougat";
                    //        break;
                    //    case "10":
                    //        AndroidOS = "Oreo";
                    //        break;
                    //    case "11":
                    //        AndroidOS = "Oreo";
                    //        break;
                    //    case "12":
                    //        AndroidOS = "Pie";
                    //        break;
                    //    case "13":
                    //        AndroidOS = "Android 10";
                    //        break;
                    //    case "14":
                    //        AndroidOS = "Android 11";
                    //        break;
                    //    case "15":
                    //        AndroidOS = "Android12";
                    //        break;
                    //    case "16":
                    //        AndroidOS = "Android12L";
                    //        break;
                    //    case "17":
                    //        AndroidOS = "Android13";
                    //        break;
                    //}
                    //if (Address == "" || Address == null)
                    //{
                    //    Address = GetLocation(PunchInLat, PunchInLong);
                    //    LocationFrom = "API";
                    //}
                    //if (Address == "" || Address == null || Address == "Borkou, Chad" || Address == "Kanem, Chad" || Address == "Kufra District, Libya" || Address == "Gazabure, Nigeria" || Address == "Gudumbali West, Nigeria")
                    //{
                    //    Address = GetLocation(PunchInLat, PunchInLong);
                    //}
                    //if (Address == "" || Address == null || Address == "Borkou, Chad" || Address == "Kanem, Chad" || Address == "Kufra District, Libya" || Address == "Gazabure, Nigeria" || Address == "Gudumbali West, Nigeria")
                    //{
                    //    Address = "Latitude : " + PunchInLat + " / Longitude : " + PunchInLong;
                    //}

                    string imagename = "";
                    string PunchInPic = "";
                    string timeStamp = GetTimestamp(DateTime.Now);
                    if (PunchinPic.Length > 50)
                    {
                        Random r = new Random();
                        Random r2 = new Random();
                        imagename = timeStamp.ToString() + ".jpg";
                        PunchInPic = imagename;

                        byte[] btyeArray = Convert.FromBase64String(PunchinPic);
                        MemoryStream ms = new MemoryStream(btyeArray, 0, btyeArray.Length);
                        ms.Write(btyeArray, 0, btyeArray.Length);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                        image.Save(Server.MapPath(@"~/Content/PunchIn/" + imagename), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }


                    JsonResult retObj = Json(_objBLMaster.InsertPunchINSelfie(EmployeeCode, /* PunchInLat, PunchInLong, Address, PunchInFrom, BatteryLevel, DeviceName, AndroidOS,LocationFrom,*/ PunchInPic));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;

                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }


            public JsonResult updatePunchOutSelfie(string EmployeeCode,/* string PunchOutLat, string PunchOutLong, string Address, string PunchOutFrom, string BatteryLevel, string DeviceName, string AndroidOS, string LocationFrom,*/ string PunchoutPic)
            {
                string request = EmployeeCode + "||" + /*PunchOutLat + "||" + PunchOutLong + "||" + Address + "||" + PunchOutFrom + "||" + BatteryLevel + "||" + DeviceName + "||" + AndroidOS + "||" +*/ PunchoutPic;
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string MethodName = MethodBase.GetCurrentMethod().Name;
                try
                {
                    string LocationFrom = "App";

                    string imagename = "";
                    string PunchOutPic = "";
                    string timeStamp = GetTimestamp(DateTime.Now);
                    if (PunchoutPic.Length > 50)
                    {
                        Random r = new Random();
                        Random r2 = new Random();
                        imagename = timeStamp.ToString() + ".jpg";
                        PunchOutPic = imagename;

                        byte[] btyeArray = Convert.FromBase64String(PunchoutPic);
                        MemoryStream ms = new MemoryStream(btyeArray, 0, btyeArray.Length);
                        ms.Write(btyeArray, 0, btyeArray.Length);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                        image.Save(Server.MapPath(@"~/Content/PunchOut/" + imagename), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                    JsonResult retObj = Json(_objBLMaster.updatePunchOutSelfie(EmployeeCode,/* PunchOutLat, PunchOutLong, Address, PunchOutFrom, BatteryLevel, DeviceName, AndroidOS, LocationFrom,*/ PunchOutPic));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;

                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
            public string GetLocation(string latitude, string longitude)
            {

                string location = "";
                string URI = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitude + "," + longitude + "&key=AIzaSyDnFyVHpZisFyyphKqlw4vS7IvcM50PMwM&sensor=false";
                var request = (HttpWebRequest)WebRequest.Create(URI);

                request.Method = "GET";

                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var content = string.Empty;


                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                        {

                            content = sr.ReadToEnd();


                            String str = content;


                            RootObject w = (RootObject)JsonConvert.DeserializeObject(str, typeof(RootObject));

                            for (int i = 0; i < w.results.Count; i++)
                            {
                                if (w.results != null)
                                {
                                    location = w.results[i].formatted_address;
                                }
                                if (location != "" || location != null)
                                {
                                    break;
                                }
                            }


                        }
                    }
                }
                return location;
            }

            public static String GetTimestamp(DateTime value)
            {
                return value.ToString("yyyyMMddHHmmssffff");
            }
            public class Southwest2
            {
                public double lat { get; set; }
                public double lng { get; set; }
            }
            public class Northeast2
            {
                public double lat { get; set; }
                public double lng { get; set; }
            }
            public class Southwest
            {
                public double lat { get; set; }
                public double lng { get; set; }
            }
            public class Northeast
            {
                public double lat { get; set; }
                public double lng { get; set; }
            }
            public class Viewport
            {
                public Northeast2 northeast { get; set; }
                public Southwest2 southwest { get; set; }
            }
            public class Location
            {
                public double lat { get; set; }
                public double lng { get; set; }
            }
            public class Bounds
            {
                public Northeast northeast { get; set; }
                public Southwest southwest { get; set; }
            }
            public class PlusCode2
            {
                public string compound_code { get; set; }
                public string global_code { get; set; }
            }
            public class Geometry
            {
                public Bounds bounds { get; set; }
                public Location location { get; set; }
                public string location_type { get; set; }
                public Viewport viewport { get; set; }
            }
            public class AddressComponent
            {
                public string long_name { get; set; }
                public string short_name { get; set; }
                public List<string> types { get; set; }
            }

            public class Result
            {
                public List<AddressComponent> address_components { get; set; }
                public string formatted_address { get; set; }
                public Geometry geometry { get; set; }
                public string place_id { get; set; }
                public List<string> types { get; set; }
                public PlusCode2 plus_code { get; set; }
            }


            public class PlusCode
            {
                public string compound_code { get; set; }
                public string global_code { get; set; }
            }

            public class RootObject
            {
                public PlusCode plus_code { get; set; }
                public List<Result> results { get; set; }
                public string status { get; set; }
            }
        }

        // CustomerByWebController.cs
        public class CustomerByWebController : Controller
        {
            CustomerByWebDTO objCustomerByWebDTO = new CustomerByWebDTO();
            CustomerByWebBAL objCustomerByWebBAL = new CustomerByWebBAL();

            string Request = "";
            string Response = "";
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string Exception = "";


            public JsonResult Insert(string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
            {
                try
                {
                    JsonResult retObj = Json(objCustomerByWebBAL.Insert(full_name, date, contact_no, email_id, gender, city, age, query, source));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult Update(int id, string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
            {
                try
                {
                    JsonResult retObj = Json(objCustomerByWebBAL.Update(id, full_name, date, contact_no, email_id, gender, city, age, query, source));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
        }

        // CustomerController.cs


        // DataBindController.cs
        public class DataBindController : Controller
        {
            DataBindDAL objDataBindDAL = new DataBindDAL();
            DataBindBAL objDataBindBAL = new DataBindBAL();

            string Request = "";
            string Response = "";
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string Exception = "";

            public JsonResult CustomerDetail(string Operation)
            {
                try
                {
                    JsonResult retObj = Json(objDataBindBAL.CustomerDetail(Operation));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
        }

        // DoctorController.cs
        public class DoctorController : Controller
        {
            DoctorDTO objDoctorDTO = new DoctorDTO();
            DoctorBAL objDoctorBAL = new DoctorBAL();

            string Request = "";
            string Response = "";
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string Exception = "";

            public JsonResult Registration(string Operation, string full_name, string email_id, string password, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objDoctorBAL.Registration(Operation, full_name, email_id, password, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult RegisteredAll(string Operation, int doctor_id, string full_name, string email_id, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objDoctorBAL.RegisteredAll(Operation, doctor_id, full_name, email_id, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
            public JsonResult RegisteredById(string Operation, int doctor_id, string full_name, string email_id, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objDoctorBAL.RegisteredById(Operation, doctor_id, full_name, email_id, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
            public JsonResult Update(string Operation, int doctor_id, string full_name, string email_id, string contact_no, string password)
            {
                try
                {
                    JsonResult retObj = Json(objDoctorBAL.Update(Operation, doctor_id, full_name, email_id, contact_no, password));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult Delete(int doctor_id, string Operation)
            {
                try
                {
                    JsonResult retObj = Json(objDoctorBAL.Delete(doctor_id, Operation));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            #region Reports By Doctor
            public JsonResult DoctorReports(string doctor_id)
            {
                try
                {
                    JsonResult retObj = Json(objDoctorBAL.DoctorReports(doctor_id));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
            #endregion
        }

        // EmployeeController.cs
        public class EmployeeController : Controller
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBAL objEmployeeBAL = new EmployeeBAL();

            string Request = "";
            string Response = "";
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string Exception = "";

            public JsonResult CourierRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.CourierRegistration(Operation, full_name, email_id, password, designation_id, Gender, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
            public JsonResult ManagerRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.ManagerRegistration(Operation, full_name, email_id, password, designation_id, Gender, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult AllManagerRegistered(string Operation, int designation_id/*, int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.AllManagerRegistered(Operation, designation_id/*, employee_id, full_name, email_id, password,  Gender, Contact_no*/));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult ManagerRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.ManagerRegisteredByID(Operation, employee_id/*, full_name, email_id, password, designation_id, Gender, Contact_no*/));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult ManagerUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.ManagerUpdate(Operation, employee_id, full_name, email_id, password, designation_id, Gender, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult ManagerDelete(int employee_id, string Operation)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.ManagerDelete(employee_id, Operation));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult DoctorRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.DoctorRegistration(Operation, full_name, email_id, password, designation_id, Gender, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult AllDoctorRegistered(string Operation, int designation_id/*, int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.AllDoctorRegistered(Operation, designation_id/*, employee_id, full_name, email_id, password,  Gender, Contact_no*/));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult DoctorRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.DoctorRegisteredByID(Operation, employee_id/*, full_name, email_id, password, designation_id, Gender, Contact_no*/));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult DoctorUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.DoctorUpdate(Operation, employee_id, full_name, email_id, password, designation_id, Gender, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult DoctorDelete(int employee_id, string Operation)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.DoctorDelete(employee_id, Operation));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult TelecallerRegistration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.TelecallerRegistration(Operation, full_name, email_id, password, designation_id, Gender, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult AllTelecallerRegistered(string Operation, int designation_id/*,  int employee_id, string full_name, string email_id, string password,  string Gender, string Contact_no*/)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.AllTelecallerRegistered(Operation, designation_id/*, employee_id, full_name, email_id, password,  Gender, Contact_no*/));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult TelecallerRegisteredByID(string Operation, int employee_id/*, string full_name, string email_id, string password, int designation_id, string Gender, string Contact_no*/)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.TelecallerRegisteredByID(Operation, employee_id/*, full_name, email_id, password, designation_id, Gender, Contact_no*/));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult TelecallerUpdate(string Operation, string employee_id, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.TelecallerUpdate(Operation, employee_id, full_name, email_id, password, designation_id, Gender, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult TelecallerDelete(int employee_id, string Operation)
            {
                try
                {
                    JsonResult retObj = Json(objEmployeeBAL.TelecallerDelete(employee_id, Operation));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }
        }

        // HomeController.cs
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.Title = "Home Page";

                return View();
            }
        }

        // ManagerController.cs
        public class ManagerController : Controller
        {

            string Request = null;
            string Response = null;
            string Exception = null;
            JsonResult retObj = null;

            ManagerBAL objManagerBAL = new ManagerBAL();

            public JsonResult managerOperation(string managerId, string fullName, string emailId, string password, string operation)
            {
                string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string MethodName = MethodBase.GetCurrentMethod().Name;

                try
                {
                    retObj = Json(objManagerBAL.managerOperation(managerId, fullName, emailId, password, operation), JsonRequestBehavior.AllowGet);
                    retObj.MaxJsonLength = int.MaxValue;
                    Response = new JavaScriptSerializer().Serialize(retObj);
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs(MethodName, ClassName, Request, Response, Exception);
                }
                return retObj;
            }


            #region Reports By Manager
            public JsonResult ManagerReports(string managerId, string startDate, string endDate)
            {
                string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string MethodName = MethodBase.GetCurrentMethod().Name;
                try
                {
                    retObj = Json(objManagerBAL.ManagerReports(managerId, startDate, endDate), JsonRequestBehavior.AllowGet);
                    retObj.MaxJsonLength = int.MaxValue;
                    Response = new JavaScriptSerializer().Serialize(retObj);
                }

                catch (Exception ex)
                {
                    Exception = ex.ToString();
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs(MethodName, ClassName, Request, Response, Exception);
                }
                return retObj;
            }
            #endregion
        }

        // TelecallerController.cs
        public class TelecallerController : Controller
        {
            TelecallerDTO objTelecallerDTO = new TelecallerDTO();
            TelecallerBAL objTelecallerBAL = new TelecallerBAL();

            string Request = "";
            string Response = "";
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string Exception = "";



            //public JsonResult Registration(string Operation, string full_name, string email_id, string password, int designation_id, string Gender, string contact_no)
            //{
            //    try
            //    {
            //        JsonResult retObj = Json(objTelecallerBAL.Registration( Operation, full_name, email_id, password, designation_id, Gender, contact_no));
            //        Response = new JavaScriptSerializer().Serialize(retObj);
            //        return retObj;
            //    }
            //    catch (Exception ex)
            //    {
            //        Exception = ex.ToString();
            //        throw ex;
            //    }
            //    finally
            //    {
            //        RequestResponseLog res = new RequestResponseLog();
            //        res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
            //    }


            //}


            public JsonResult RegisteredAll(string Operation, int caller_id, string full_name, string email_id, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objTelecallerBAL.RegisteredAll(Operation, caller_id, full_name, email_id, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }


            public JsonResult RegisteredById(string Operation, int caller_id, string full_name, string email_id, string contact_no)
            {
                try
                {
                    JsonResult retObj = Json(objTelecallerBAL.RegisteredById(Operation, caller_id, full_name, email_id, contact_no));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }


            public JsonResult Update(string Operation, int caller_id, string full_name, string email_id, string contact_no, string password)
            {
                try
                {
                    JsonResult retObj = Json(objTelecallerBAL.Update(Operation, caller_id, full_name, email_id, contact_no, password));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }


            public JsonResult Delete(int caller_id, string Operation)
            {
                try
                {
                    JsonResult retObj = Json(objTelecallerBAL.Delete(caller_id, Operation));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            public JsonResult TelecallerLogin(string email_id, string password)
            {
                try
                {
                    JsonResult retObj = Json(objTelecallerBAL.TelecallerLogin(email_id, password));
                    Response = new JavaScriptSerializer().Serialize(retObj);
                    return retObj;
                }
                catch (Exception ex)
                {
                    Exception = ex.ToString();
                    throw ex;
                }
                finally
                {
                    RequestResponseLog res = new RequestResponseLog();
                    res.RequestResponseLogs("Method Name :" + MethodName, "Class Name: " + ClassName, Request, Response, Exception);
                }
            }

            // ValuesController.cs
            // GET api/values
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET api/values/5
            public string Get(int id)
            {
                return "value";
            }

            // POST api/values
            public void Post([FromBody] string value)
            {
            }

            // PUT api/values/5
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/values/5
            public void Delete(int id)
            {
            }
        }
    }
}
