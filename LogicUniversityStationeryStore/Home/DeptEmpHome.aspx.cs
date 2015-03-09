using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Home
{
    public partial class DeptEmpHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);
        }
    }
}