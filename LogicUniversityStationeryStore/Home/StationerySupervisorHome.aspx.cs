using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Home
{
    public partial class StationerySupervisorHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserRole"] != null)
            {
                string role = Request.Cookies["UserRole"].Value.ToString();
                CheckRoleController.setStationaryMaster(this.Master, role);
            }
        }
    }
}