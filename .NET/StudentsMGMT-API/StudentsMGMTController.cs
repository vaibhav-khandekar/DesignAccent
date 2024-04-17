using StudentsMGMT.BAL;
using StudentsMGMT.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StudentsMGMT.Controllers
{
    public class StudentsMGMTController : Controller
    {
        StudentsMGMTBAL objSMBAL = new StudentsMGMTBAL();
        StudentsMGMTDAL objSMDAL = new StudentsMGMTDAL();
        // GET: StudentsMGMT
        string Request = "";
        string Response = "";
        string Exception = "";

        JsonResult retobj = null;
        public JsonResult GetStudentsDetails()
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objSMBAL.GetStudentsDetails(), JsonRequestBehavior.AllowGet);
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
        public JsonResult AddStudentDetails(string StdName, string StdLocation, string StdAge)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objSMBAL.AddStudentDetails(StdName, StdLocation, StdAge), JsonRequestBehavior.AllowGet);
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
        public JsonResult UpdateStudentDetails(int StdID, string StdName, string StdLocation, string StdAge)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objSMBAL.UpdateStudentDetails(StdID, StdName, StdLocation, StdAge), JsonRequestBehavior.AllowGet);
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
        public JsonResult DeleteEmployeeDetails(int StdID)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objSMBAL.DeleteStudentDetails(StdID), JsonRequestBehavior.AllowGet);
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
