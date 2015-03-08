using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.Store.Disbursement
{
    public partial class ListOfApprovedRequestUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkView_Command(object sender, CommandEventArgs e)
        {
            Session["dept"] = e.CommandArgument.ToString();
            Response.Redirect("AcceptRequestUI.aspx");
        }

       

   
    }
}