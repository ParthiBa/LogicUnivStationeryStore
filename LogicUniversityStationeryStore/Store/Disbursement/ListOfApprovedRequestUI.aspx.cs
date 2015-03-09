using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.Disbursement
{
    public partial class ListOfApprovedRequestUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);
        }

        protected void lnkView_Command(object sender, CommandEventArgs e)
        {
            Session["dept"] = e.CommandArgument.ToString();
            Response.Redirect("AcceptRequestUI.aspx");
        }

       

   
    }
}