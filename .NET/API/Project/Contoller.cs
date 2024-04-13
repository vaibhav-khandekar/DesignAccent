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
        EmployeesBAL objEmpBAL = new EmployeesBAL();
        EmployeesDAL objEmpDAL = new EmployeesDAL();
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
                retobj = Json(objEmpBAL.GetEmployeeDetails(), JsonRequestBehavior.AllowGet);
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
        public JsonResult AddEmployeeDetails(string EmpName, string EmpSalary, string EmpAge)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objEmpBAL.AddEmployeeDetails(EmpName, EmpSalary, EmpAge), JsonRequestBehavior.AllowGet);
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
        public JsonResult UpdateEmployeeDetails(int EmpID, string EmpName, string EmpSalary, string EmpAge)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objEmpBAL.UpdateEmployeeDetails(EmpID, EmpName, EmpSalary, EmpAge), JsonRequestBehavior.AllowGet);
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
        public JsonResult DeleteEmployeeDetails(int EmpID)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objEmpBAL.DeleteEmployeeDetails(EmpID), JsonRequestBehavior.AllowGet);
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
