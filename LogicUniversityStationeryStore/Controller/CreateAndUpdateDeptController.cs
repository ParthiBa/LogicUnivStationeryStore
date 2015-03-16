using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.Controller
{
    public class CreateAndUpdateDeptController
    {
        public void createDept(string codeB, string nameB, string contactB, string telB, string faxB, string drop1, string drop2, string drop1name, string drop2name)
        {
            using (LogicUniversityEntities4Perm ctx = EntityBroker.getMyEntities())
            {
                LogicUniversityStationeryStore.Department createdpt = new LogicUniversityStationeryStore.Department();
                createdpt.code = codeB;
                createdpt.name = nameB;
                createdpt.contactName = contactB;
                createdpt.telNo = Convert.ToString(telB);
                createdpt.faxNo = Convert.ToString(faxB);
                createdpt.deptHead = drop1;
                createdpt.deptRep = drop2;
                createdpt.collectionPt = null;
                //ctx.AddToLogicUniversityStationeryStore.Department(createdpt);
                //LogicUniversityStationeryStore.Department.Add(createdpt);


                string headName = drop1name;
                Employee head = ctx.Employees.Where(x => x.empName == headName).FirstOrDefault();
                createdpt.Employee = head;
                createdpt.deptHead = head.empNo;

                string representativName = drop2name;
                Employee rep = ctx.Employees.Where(x => x.empName == representativName).FirstOrDefault();
                createdpt.Employee1 = rep;
                createdpt.deptRep = rep.empNo;

                ctx.Departments.Add(createdpt);
                ctx.SaveChanges();
            }
        }
        public void updateDept(string codeB, string nameB, string contactB, string telB, string drop1, string drop2, string faxB, string drop1name, string drop2name)
        {
            LogicUniversityEntities4Perm ctx = new LogicUniversityEntities4Perm();
            // Department department = ctx.Departments.Where(d => d.code == codebox.Text).FirstOrDefault();
            LogicUniversityStationeryStore.Department department = ctx.Departments.Where(d => d.code == codeB).FirstOrDefault();

            if (department != null)
            {
                department.code = codeB;
                department.name = nameB;
                department.contactName = contactB;
                if (!string.IsNullOrEmpty(telB))
                {
                    department.telNo = Convert.ToString(telB);
                }
                if (!string.IsNullOrEmpty(faxB))
                {
                    department.faxNo = Convert.ToString(faxB);
                }


                string headName = drop2name;
                Employee head = ctx.Employees.Where(x => x.empName == headName).FirstOrDefault();
                department.Employee = head;
                department.deptHead = head.empNo;


                string representativName = drop1name;
                Employee rep = ctx.Employees.Where(x => x.empName == representativName).FirstOrDefault();
                department.Employee1 = rep;
                department.deptRep = rep.empNo;


                ctx.SaveChanges();


            }
        }
        public DeptInfor retre(string dcode)
        {
            using (LogicUniversityEntities4Perm ctx = new LogicUniversityEntities4Perm())
            {
                var dpt = ctx.Departments.FirstOrDefault(m => m.code == dcode);
                Employee a = ctx.Employees.Where(x => x.empNo == dpt.deptHead).FirstOrDefault();
                Employee b = ctx.Employees.Where(x => x.empNo == dpt.deptRep).FirstOrDefault();
                DeptInfor dept = new DeptInfor();
                if (dpt != null)
                {
                    dept.Code = dpt.code;
                    dept.Name = dpt.name;
                    dept.HempName = a.empName;
                    dept.ContactName = dpt.contactName;
                    dept.TelNo = dpt.telNo;
                    dept.FaxNo = dpt.faxNo;
                    dept.RempName = b.empName;
                } return dept;
            }
        }

        public List<Department> getDataforDepartmentLIst()
        {

            using (LogicUniversityEntities4Perm ctx = new LogicUniversityEntities4Perm())
            {

                var q = from x in ctx.Departments
                        select x;

                return q.ToList<Department>();


            }


        }


        public List<Employee> giveListforemp(string dcode)
        {

            using (LogicUniversityEntities4Perm ctx = new LogicUniversityEntities4Perm())
            {

                var q = from x in ctx.Employees
                        where x.deptCode.Equals(dcode)
                        select x;
                return q.ToList<Employee>();

            }


        }
    }
}