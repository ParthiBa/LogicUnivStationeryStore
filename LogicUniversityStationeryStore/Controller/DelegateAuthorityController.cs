using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Controller
{
    public class DelegateAuthorityController
    {

        string authorizeTo;
        string fromDate;
        string toDate;
               
        
        public DelegateAuthorityController(string s,string fromDate, string toDate)
        {
            this.authorizeTo = s;
            this.fromDate = fromDate;
            this.toDate = toDate;
            
            submitbutton();     
        }

        public DelegateAuthorityController()
        {
            
        }

        public List<string> ddPageLoad()
        {
            List<string> AuthorizeToList = new List<string>();
            var employeeList = (from o in EntityBroker.getMyEntities().Employees
                                where o.deptCode == "CPSC" && (o.empRole == "depEmp" || o.empRole == "depTempHead")
                                select o.empName).ToList();

            foreach (string name in employeeList)
            {
                AuthorizeToList.Add(name);
            }
            return AuthorizeToList;
        }
            
        protected void submitbutton()
        {

            var employeeAu = (from o in EntityBroker.getMyEntities().Employees
                              where o.empRole == "depTempHead" && o.deptCode == "CPSC"
                              select o);

            Employee emp2 = employeeAu.FirstOrDefault<Employee>();
            if (emp2 != null)
            {
                emp2.empRole = "depEmp";
                emp2.authorizeStart = null;
                emp2.authorizeEnd = null;
                EntityBroker.getMyEntities().SaveChanges();
            }

            var employeeList = from o in EntityBroker.getMyEntities().Employees
                               where o.empName == authorizeTo
                               select o;
            Employee emp1 = employeeList.FirstOrDefault<Employee>();
            emp1.empRole = "depTempHead";
            emp1.authorizeStart = Convert.ToDateTime(fromDate);
            emp1.authorizeEnd = Convert.ToDateTime(toDate);
            EntityBroker.getMyEntities().SaveChanges();
        }
    }
}