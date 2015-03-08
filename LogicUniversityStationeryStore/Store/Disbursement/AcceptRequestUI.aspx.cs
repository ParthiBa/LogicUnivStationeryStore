using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.Store.Disbursement
{
    public partial class AcceptRequestUI : System.Web.UI.Page
    {
        AcceptRequestController disCtrl = new AcceptRequestController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dept = Session["dept"].ToString();
                lblDeptName.Text = disCtrl.getDeptBySession(dept);
                lblCollPoint.Text = disCtrl.getCollPBySession(dept);
                RequestByDeptView.DataSource = disCtrl.getApprovedReq(dept);
                RequestByDeptView.DataBind();
            }
        }

        protected void BtnAccept_Click(object sender, EventArgs e)
        {

            string clerk = "SC0001"; //test data, change to: string clerk=Request.Cookies["User"].Value;
            string dept = Session["dept"].ToString();
            string XOL = "Science School";//test data,delete when data fill in database-Department-collectionPt:string XOL=dep.collectionPt
            string delivDate = boxDeliverDate.Text;
            
           if (disCtrl.createAndUpdate(dept, clerk, XOL, delivDate) == true) //create disbursement & update request
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Requsition Accepted!');window.location='ListOfApprovedRequestUI.aspx'", true);
                Session.Clear();
            }
            else 
            {
                Label3.Text = "**Please Choose Delivery Date**";    
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Session["dept"] = string.Empty;
            Response.Redirect("ListOfApprovedRequestUI.aspx");
        }
            }
  }
 

      
    
