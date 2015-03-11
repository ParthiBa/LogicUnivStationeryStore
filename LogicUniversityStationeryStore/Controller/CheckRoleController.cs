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
                ManagerMenu.Visible = true;

            }
            else if (role.Equals("storeSup"))
            {
                SupervisorMenu.Enabled = true;
                SupervisorMenu.Visible = true;
            }
            else
            {
                ClerkMenu.Enabled = true;
                ClerkMenu.Visible = true;

            }


           

        }

        public static void setDepartmentMaster(DepartMentMaster master, string role)
        {
            Menu DeptEmpMenu = master.getDepartmentEmployeeMenu();
            Menu DeptRepresntativeMenu = master.getDepartmentRepMenu();
            Menu DeptHeadMenu = master.getDepartmentHeadMenu();

            if (role.Equals("deptHead") || role.Equals("depTempHead")) //if (role.Equals("deptHead") || (role.Equals("tempHod")))
            {
                DeptHeadMenu.Enabled = true;
                DeptHeadMenu.Visible = true;
                if(role.Equals("depTempHead"))
                {
                    MenuItem authItem = DeptHeadMenu.FindItem("Authorize");
                    authItem.Enabled = false;
                    authItem.Selectable = false;
                    authItem.ToolTip = "You are not authorised to  Authorise others";
                }

            }
            else if (role.Equals("deptRep"))
            {
                DeptRepresntativeMenu.Enabled = true;
                DeptRepresntativeMenu.Visible = true;
            }
            else
            {
                DeptEmpMenu.Enabled = true;
                DeptEmpMenu.Visible = true;

            }



        }



    }
}