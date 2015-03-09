using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Dep.Requisition
{
    public partial class RequstitionListUI : System.Web.UI.Page
    {


        string empid = "";
        ApproveRequestController ARcontroller = new ApproveRequestController();
        bool isHead;
        protected void Page_Load(object sender, EventArgs e)
        {


            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);



            if (Request.Cookies["User"] != null)
            {
                empid = Request.Cookies["User"].Value.ToString();
            }
            isHead = ARcontroller.checkhead(empid);
            var q = ARcontroller.ListofRequests(empid);
             grdPendingRequest.DataSource = q;
             grdPendingRequest.DataBind();
        }
    }
}