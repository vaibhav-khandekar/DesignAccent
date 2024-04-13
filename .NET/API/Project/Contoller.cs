using Employees.BAL;
using Employees.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Employees.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        EmployeesBAL objCarModelBAL = new EmployeesBAL();
        EmployeesDAL objCarModelDAL = new EmployeesDAL();
        string Request = "";
        string Response = "";
        string Exception = "";

        JsonResult retobj = null;
        public JsonResult GetEmployeeDetails()
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objCarModelBAL.GetEmployeeDetails(), JsonRequestBehavior.AllowGet);
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

        /*
        public JsonResult AddEmployeeDetails(string ModelName)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objCarModelBAL.AddEmployeeDetails(ModelName), JsonRequestBehavior.AllowGet);
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
        public JsonResult UpdateEmployeeDetails(string ModelID, string ModelName)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objCarModelBAL.UpdateEmployeeDetails(EmpID, EmpName), JsonRequestBehavior.AllowGet);
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
        public JsonResult DeleteEmployeeDetails(string ModelID)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objCarModelBAL.DeleteEmployeeDetails(EmpID), JsonRequestBehavior.AllowGet);
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
        */
    }
}
