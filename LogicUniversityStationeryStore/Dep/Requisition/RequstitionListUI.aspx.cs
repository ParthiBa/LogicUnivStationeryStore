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
        string id = "E00151";
        ApproveRequestController ARcontroller = new ApproveRequestController();
        bool isHead;
        protected void Page_Load(object sender, EventArgs e)
        {
             isHead = ARcontroller.checkhead(id);
             var q = ARcontroller.ListofRequests(id);
             grdPendingRequest.DataSource = q;
             grdPendingRequest.DataBind();
        }
    }
}