using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Validation.BAL;
using Validation.DAL;
using Validation.DTO;

namespace Validation.Controllers
{
    public class ValidationController : Controller
    {
        ValidationBAL objBAL = new ValidationBAL();
        ValidationDTO objDTO = new ValidationDTO();

        string Request = "";
        string Response = "";
        string Exception = "";

        JsonResult retobj = null;

        // Get Details
        public JsonResult GetDetails()
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objBAL.GetDetails(), JsonRequestBehavior.AllowGet);
                retobj.MaxJsonLength = int.MaxValue;
                Response = new JavaScriptSerializer().Serialize(retobj);
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
            return retobj;
        }

        // Add Details
        public JsonResult AddDetails(string FullName, string EmailAddress, string MobileNumber, string Statee, string City, string Gender)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objBAL.AddDetails(FullName, EmailAddress, MobileNumber, Statee, City, Gender), JsonRequestBehavior.AllowGet);
                retobj.MaxJsonLength = int.MaxValue;
                Response = new JavaScriptSerializer().Serialize(retobj);
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
            return retobj;
        }

        // Update Details
        public JsonResult UpdateDetails(int ID, string FullName, string EmailAddress, string MobileNumber, string Statee, string City, string Gender)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objBAL.UpdateDetails(ID, FullName, EmailAddress, MobileNumber, Statee, City, Gender), JsonRequestBehavior.AllowGet);
                retobj.MaxJsonLength = int.MaxValue;
                Response = new JavaScriptSerializer().Serialize(retobj);
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
            return retobj;
        }

        // Delete Details
        public JsonResult DeleteDetails(int ID)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objBAL.DeleteDetails(ID), JsonRequestBehavior.AllowGet);
                retobj.MaxJsonLength = int.MaxValue;
                Response = new JavaScriptSerializer().Serialize(retobj);
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
            return retobj;
        }
    }
}
