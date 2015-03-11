using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.StockAdjustment
{
    public partial class ApproveStockAdjustment : System.Web.UI.Page
    {

        string supervisorId;
        string role;
        string pageVarialble;
        UpdateAdjustmentController UAcontroller = new UpdateAdjustmentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            supervisorId = Request.Cookies["User"].Value.ToString();
            role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);

            int Reportid = Convert.ToInt32(Request.QueryString["id"].ToString());

            string status=UAcontroller.getCuurentRequest(Reportid,supervisorId);


            if (role.Equals("storeMan"))
            {
                pageVarialble = "~/Home/StationeryManagerHome.aspx";
            }
         
            {
                pageVarialble = "~/Home/StationerySupervisorHome.aspx";
            }


            txtReviewReason.Visible = false;
            btnRjectSubmit.Visible = false;
            btnRjectSubmit.Enabled = false;
            if(status.Equals("Pending"))
            {
                btnReject.Visible = true;
                btnApprove.Visible =true;
                btnApprove.Enabled = true;
                btnReject.Enabled = true;
            }
            else
            {
                btnReject.Visible = false;
                btnApprove.Visible = false;
                btnApprove.Enabled = false;
                btnReject.Enabled = false;

                lblApprovedPerson.Visible = true;
                lblShowPersonName.Visible = true;

               

              if(status.Equals("Approved"))
              {
                  lblApprovedPerson.Text = "This request was approved by:";
              }
              else
              {
                  lblRejectedReason.Visible = true;
                  lblApprovedPerson.Text = "This request was rejected by";
                  lblDispReson.Visible = true;
                  lblDispReson.Text = UAcontroller.getRjectedReason();
              }
                     lblShowPersonName.Text=UAcontroller.getStockAdjustmentReviwedByName();
              

            }

            grdStockAdjustmentDetailsView.DataSource = UAcontroller.getStockAdjustmentDetails(Reportid);
            grdStockAdjustmentDetailsView.DataBind();






        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (role.Equals("storeSup") || role.Equals("storeMan"))
            {

                txtReviewReason.Visible = true;
                btnRjectSubmit.Visible = true;
                btnRjectSubmit.Enabled = true;

            }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

            if (role.Equals("storeSup") || role.Equals("storeMan"))
            {
                UAcontroller.ApproveCurrentRequest();

                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert1", "alert('Request has been Approved!'); window.location = '" + Page.ResolveUrl(pageVarialble) + "';", true);

            }

        }

        protected void btnRjectSubmit_Click(object sender, EventArgs e)
        {
            if(txtReviewReason.Text.Equals(""))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert123", "alert('Please add the reason if you want to reject '); ", true);
            }
            else
            {

                UAcontroller.RejectCurrentRequest();

                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert2", "alert('Request has been rejected'); window.location = '" + Page.ResolveUrl(pageVarialble) + "';", true);
            }
        }


    }
}