using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.Home
{
    public partial class StationeryMaster : System.Web.UI.MasterPage
    {

        public Menu getClerkMenu()
        {
            return ClerkMenu;

        }

        public Menu getSupervisorMenu()
        {

            return SupervisorMenu;
        }

        public Menu getManagerMenu()
        {

            return ManagerMenu;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}