using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.CRUD.Department
{
    public partial class DepartmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);

            CreateAndUpdateDeptController controller = new CreateAndUpdateDeptController();

            GridView1.DataSource = controller.getDataforDepartmentLIst();
        GridView1.DataBind();
        }

        protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {

        }
    }
}