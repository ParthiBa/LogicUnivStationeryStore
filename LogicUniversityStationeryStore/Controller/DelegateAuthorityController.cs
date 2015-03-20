
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;
using System.Data.Entity;

namespace LogicUniversityStationeryStore.Controller
{
    public class DelegateAuthorityController
    {

        LinqHelper Helper = new LinqHelper();
        string authorizeTo;
        DateTime fromDate;
        DateTime toDate;
        string deptID;
        Employee CurrentEmployee;
        List<string> AuthorizeToList;
        public DelegateAuthorityController()//Default Constructor//
        {
            AuthorizeToList = new List<string>();
        }


        public void setValues(string deptid,string EmployeeId)
        {
            this.deptID = deptid;
           CurrentEmployee = LinqHelper.findEmpbyId(EmployeeId);

        }

        public List<string> ddPageLoad()//Delegate Authority Page Load//
        {
          
            var employeeList = (from o in EntityBroker.
                                    
                                    getMyEntities().Employees
                                where o.deptCode==CurrentEmployee.deptCode && (o.empRole == "deptEmp")
                                select o.empName).ToList();

            foreach (string name in employeeList)
            {
                AuthorizeToList.Add(name);
            }
            return AuthorizeToList;
        }
        
        public bool submitbutton(string authorizeTo, string fromDate, string toDate)//Delegate Authority//
        {
            this.fromDate = Convert.ToDateTime(fromDate);
            this.toDate = Convert.ToDateTime(toDate);
            var employeeAu = (from o in EntityBroker.getMyEntities().Employees
                              where o.empRole == "depTempHead" && o.deptCode == CurrentEmployee.deptCode
                              select o).ToList();

            if (employeeAu.Count() == 0)
            {
                var employee = (from o in EntityBroker.getMyEntities().Employees
                                where o.empRole == "deptEmp" && o.deptCode == CurrentEmployee.deptCode && o.empName == authorizeTo
                                               select o).FirstOrDefault();
              
                    employee.empRole = "depTempHead";
                    employee.authorizeStart = Convert.ToDateTime(fromDate);
                    employee.authorizeEnd = Convert.ToDateTime(toDate);
                    EntityBroker.getMyEntities().SaveChanges();
                    return true;  
            }

            else
            {
                foreach (Employee e in employeeAu)
                {
                    if (!((this.fromDate < e.authorizeStart && this.toDate < e.authorizeStart) || (this.fromDate > e.authorizeEnd && this.toDate > e.authorizeEnd)))
                    {
                        return false;
                    }
                }

                var employee = (from o in EntityBroker.getMyEntities().Employees
                                where o.empRole == "deptEmp" && o.deptCode == CurrentEmployee.deptCode && o.empName == authorizeTo
                                select o).FirstOrDefault();

                employee.empRole = "depTempHead";
                employee.authorizeStart = Convert.ToDateTime(fromDate);
                employee.authorizeEnd = Convert.ToDateTime(toDate);
                EntityBroker.getMyEntities().SaveChanges();
                return true;
            }

        }
        
        public Employee getTempHeadEmployee(string empName)//Remove Authorization//
        {
            var employee = (from o in EntityBroker.getMyEntities().Employees
                            where o.deptCode == CurrentEmployee.deptCode && o.empName == empName
                            select o).FirstOrDefault();

            return employee;
        }
        public List<string> ddRemovePageLoad()//Remove Delegation Page load//
        {
            List<string> RemoveAuthorizeToList = new List<string>();
            var employeeList = (from o in EntityBroker.getMyEntities().Employees
                                where o.deptCode == CurrentEmployee.deptCode && (o.empRole == "depTempHead")
                                select o.empName).ToList();

            foreach (string name in employeeList)
            {
                RemoveAuthorizeToList.Add(name);
            }
            return RemoveAuthorizeToList;

        }

        public bool RemoveAuthorizationButton(string empName)//Remove Authorization//
        {
            bool status = Convert.ToBoolean("true");
            if (status)
            {
                var employee = from o in EntityBroker.getMyEntities().Employees
                               where o.empName == empName
                               select o;
                Employee emp1 = employee.FirstOrDefault<Employee>();
                emp1.empRole = "deptEmp";
                emp1.authorizeStart = null;
                emp1.authorizeEnd = null;
                EntityBroker.getMyEntities().SaveChanges();
                return true;
            }
            else
                return false;

        }

        public Employee ChangeRepPageload()//Change Department rep//
        {
            var employee = (from o in EntityBroker.getMyEntities().Employees
                            where o.empRole == "deptRep" && o.deptCode == CurrentEmployee.deptCode
                            select o).FirstOrDefault();
            return employee;

        }

        public List<string> ddChangeRepPageLoad()//Change Department rep//
        {
            List<string> empList = new List<string>();

            var empName = (from o in EntityBroker.getMyEntities().Employees
                           where o.empRole == "deptEmp" && o.deptCode == CurrentEmployee.deptCode
                           select o.empName);

            foreach (string name in empName)
            {
                empList.Add(name);
            }
            return empList;

        }

        public bool btnChangeRepOnClick(string name, string existingRep)//Change Department rep//
        {
            bool status = Convert.ToBoolean("true");
            if (status)
            {
                var emp = from o in EntityBroker.getMyEntities().Employees
                          where o.empRole == "deptEmp" && o.deptCode == CurrentEmployee.deptCode && o.empName == name
                          select o;
                Employee emp1 = emp.FirstOrDefault<Employee>();
                emp1.empRole = "deptRep";

                var dep = from o in EntityBroker.getMyEntities().Departments
                          where o.code.Equals(CurrentEmployee.deptCode)
                          select o;
                Department depa = dep.FirstOrDefault<Department>();
                depa.deptRep = emp1.empNo;


                EntityBroker.getMyEntities().SaveChanges();/// remove from here

                var emp2 = from o in EntityBroker.getMyEntities().Employees
                           where o.empRole == "deptRep" && o.deptCode == CurrentEmployee.deptCode && o.empName == existingRep
                           select o;
                Employee emp3 = emp2.FirstOrDefault<Employee>();
                emp3.empRole = "deptEmp";



                EntityBroker.getMyEntities().SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}