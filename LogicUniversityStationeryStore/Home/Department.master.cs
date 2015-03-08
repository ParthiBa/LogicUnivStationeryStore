using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.Helper;

namespace LogicUniversityStationeryStore.Home
{
    public partial class Department : System.Web.UI.MasterPage
    {


        public void getRepMenu()
        {

         

        }


      
        protected void Page_Load(object sender, EventArgs e)
        {
            string empId = "Z00662";
            String role = LinqHelper.GetRole(empId);
            if(role.Equals("deptEmp"))
            {
            
             }
            else if (role.Equals("deptHead"))
            {
           
            }
            else
            {
               
            }

        }

        public void setPageOnRole()
        {
            string empId = "Z00662";
            String role = LinqHelper.GetRole(empId);
            if (role.Equals("deptEmp"))
            {

               // DeptEmployeeMenu.Visible = true;
                 
            }
            else if (role.Equals("deptHead"))
            {

                //DeptHeadsMenu.Visible = true;
            }
            else
            {
               // DeptRepsMenu.Visible = true;
            }

        }

      
    }
}