using HRBS.BAL;
using HRBS.DAL;
using HRBS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HRBS_Api.Controllers
{
    public class CustomerByTelecallerController : Controller
    {
        CustomerByTelecallerBAL objCustomerByTelecallerBAL = new CustomerByTelecallerBAL();
        CustomerByTelecallerDTO objCustomerByTelecallerDTO = new CustomerByTelecallerDTO();

        string Request = "";
        string Response = "";
        string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
        string MethodName = MethodBase.GetCurrentMethod().Name;
        string Exception = "";

        // Insert Customer By Telecaller
        public JsonResult Insert(string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
        {
            try
            {
                JsonResult retObj = Json(objCustomerByTelecallerBAL.Insert(full_name, date, contact_no, email_id, gender, city, age, query, source));
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

        // Update Customer By Telecaller
        public JsonResult Update(int id, string full_name, DateTime date, string contact_no, string email_id, string gender, string city, string age, string query, string source)
        {
            try
            {
                JsonResult retObj = Json(objCustomerByTelecallerBAL.Update(id, full_name, date, contact_no, email_id, gender, city, age, query, source));
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

        // Delete Customer By Telecaller
        public JsonResult Delete(int id)
        {
            try
            {
                JsonResult retObj = Json(objCustomerByTelecallerBAL.Delete(id));
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

        // Get All Customers
        public JsonResult AllCustomers()
        {
            try
            {
                JsonResult retObj = Json(objCustomerByTelecallerBAL.AllCustomers());
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

        // Get Customer By Id
        public JsonResult GetCustomerById(int id)
        {
            try
            {
                JsonResult retObj = Json(objCustomerByTelecallerBAL.GetCustomerById(id));
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
}
