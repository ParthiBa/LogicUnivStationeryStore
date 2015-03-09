using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Home;

namespace LogicUniversityStationeryStore.Controller
{
    public class CheckRoleController
    {

        public static void setStationaryMaster(StationeryMaster master,String role)
        {
            Menu SupervisorMenu = master.getSupervisorMenu();
            Menu ClerkMenu = master.getClerkMenu();
            Menu ManagerMenu = master.getManagerMenu();

            if (role.Equals("storeMan"))
            {
                ManagerMenu.Enabled = true;

            }
            else if (role.Equals("storeSup"))
            {
                SupervisorMenu.Enabled = true;
            }
            else
            {
                ClerkMenu.Enabled = true;

            }


           

        }

        public static void setDepartmentMaster(DepartMentMaster master, string role)
        {
            Menu DeptEmpMenu = master.getDepartmentEmployeeMenu();
            Menu DeptRepresntativeMenu = master.getDepartmentRepMenu();
            Menu DeptHeadMenu = master.getDepartmentHeadMenu();

            if (role.Equals("deptHead")) //if (role.Equals("deptHead") || (role.Equals("tempHod")))
            {
                DeptHeadMenu.Enabled = true;

            }
            else if (role.Equals("deptRep"))
            {
                DeptRepresntativeMenu.Enabled = true;
            }
            else
            {
                DeptEmpMenu.Enabled = true;

            }



        }



    }
}