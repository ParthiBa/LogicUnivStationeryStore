using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.Home
{
    public partial class DepartMentMaster : System.Web.UI.MasterPage
    {


        public Menu getDepartmentHeadMenu()
        {


            return this.DeptHeadsMenu;
        }

        public Menu getDepartmentEmployeeMenu()
        {
            return this.DeptEmployeeMenu;
        }

        public Menu getDepartmentRepMenu()
        {

            return this.DeptRepsMenu;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DeptRepsMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}