using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.DAO;
using System.Web.UI;

namespace LogicUniversityStationeryStore
{
    public class LoginController
    {

        public bool login(string email, string password, HttpResponse Response)
        {
            string useremail=Base64Decode(email);
            string userpass=Base64Decode(password);
            var data = from x in EntityBroker.getMyEntities().Employees
                        where x.email == useremail && x.empPassword == userpass
                        select x;
             Employee emp = data.FirstOrDefault();
             if (emp != null)
             {
                 Response.Cookies["UserRole"].Value = emp.empRole;
                 Response.Cookies["User"].Value = emp.empNo;
                 Response.Cookies["UserName"].Value = emp.empName;
                 Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
                 if (emp.empRole == "deptEmp")
                 {
                     Response.Redirect("Home/DeptEmpHome.aspx");
                 }
                 else if (emp.empRole == "deptRep")
                 {
                     Response.Redirect("Home/DeptRepHome.aspx");
                 }
                 else if (emp.empRole == "deptHead")
                 {
                     Response.Redirect("Home/DeptHeadHome.aspx");
                 }
                 else if (emp.empRole == "storeClerk")
                 {
                     Response.Redirect("Home/StationeryClerkHome.aspx");
                 }
                 else if (emp.empRole == "storeMan")
                 {
                     Response.Redirect("Home/StationeryManagerHome.aspx");
                 }
                 else if (emp.empRole == "storeSup")
                 {
                     Response.Redirect("Home/StationerySupervisorHome.aspx");
                 }
                 else if (emp.empRole == "depTempHead")
                 {
                     DateTime time1 = DateTime.Now;
                     DateTime time2 = Convert.ToDateTime(emp.authorizeEnd);
                     if (DateTime.Compare(time1, time2) > 0)
                     {
                         emp.empRole = "depEmp";
                         emp.authorizeEnd = null;
                         emp.authorizeStart = null;
                         Response.Redirect("Home/DeptEmpHome.aspx");
                     }
                     else
                     {
                         Response.Redirect("Home/DeptHeadHome.aspx");
                     }
                 }
                 return true;
             }
             else if (emp == null)
             {
                //show alert message box('Incorrect Email or Password')

                return  false;
             }
             return true;
        }

        public bool checkEmployee(string useremail,string userpass)
        {
            var data = from x in EntityBroker.getMyEntities().Employees
                       where x.email == useremail && x.empPassword == userpass
                       select x;
            if(data==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


            public static string Base64Decode(string base64EncodedData) {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }

    }
}