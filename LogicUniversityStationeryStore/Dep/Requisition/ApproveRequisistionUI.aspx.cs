using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Dep.Requisition
{
    public partial class ApproveRequisistionUI : System.Web.UI.Page
    {

        ApproveRequestController ARController;
        string RequestId;
        bool isId;
        List<KeyValuePair<String, int>> lessQuantityList = new List<KeyValuePair<string, int>>();
        bool isLessQuantity = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            RequiredFieldValidator1.Enabled = false;



            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);


            ARController = new ApproveRequestController();
            TxtReason.Visible = false;
            btnOkReject.Visible = false;
        
            if(Request.QueryString["rid"]==null)
            {
                isId = false;
            }
            else
            {
                RequestId = Request.QueryString["rid"];
                isId = true;
            }
   
          if(isId==false)
          {
              GrdViewItems.Enabled = false;
              lblShowEmpName.Visible = false;
              lblEmployeeName.Visible = false;
              btnApprove.Enabled = false;
              btnReject.Enabled = false;
             

          }
          else
          {
              GrdViewItems.Enabled = true;
              lblShowEmpName.Visible = true;
              lblEmployeeName.Visible = true;
              btnApprove.Enabled = true;
              btnReject.Enabled = true;

            lblShowEmpName.Text= ARController.findEmpName(Convert.ToInt32(RequestId));

            GrdViewItems.DataSource = ARController.getValueForGrid(Convert.ToInt32(RequestId));
            GrdViewItems.DataBind();

          }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
              foreach(GridViewRow row in GrdViewItems.Rows)
              {

                 //  lbltest1.Text = row.Cells[1].Text;

                  int needeedQuantity = Convert.ToInt32(((Label)row.Cells[2].FindControl("lblQuantity")).Text);
                  int AvailableQuantity = Convert.ToInt32(((Label)row.Cells[3].FindControl("lblAvailableQuantity")).Text);
                  string stationaeryCode = (((Label)row.Cells[0].FindControl("lblItemId")).Text);
//lbltest1.Text = AvailableQuantity.ToString();
                 // lbltest2.Text= stationaeryCode;

                  if(needeedQuantity > AvailableQuantity)
                  {
                      KeyValuePair<string, int> rd = new KeyValuePair<string, int>(stationaeryCode, needeedQuantity);
                      lessQuantityList.Add(rd);
                      //lbltest2.Text = "hello";
                      isLessQuantity = true;
                  }

                  if(AvailableQuantity >= needeedQuantity)
                  {
                     
                       
                  }

                 
                  //lbltest2.Text = AvailableQuantity.ToString();



              }

              if (isLessQuantity)
              {
                  ARController.CreateAdvanceRequest(lessQuantityList);
              }
            else
              {
                  ARController.approveCurrentRequest();
              }


              ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Request has been Approved!'); window.location = '" + Page.ResolveUrl("~/Home/DeptHeadHome.aspx") + "';", true);

         //     Response.Redirect();

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            TxtReason.Enabled = true;
            TxtReason.Visible = true;
            btnOkReject.Enabled = true;
            btnOkReject.Visible = true;
        }

        protected void btnOkReject_Click(object sender, EventArgs e)
        {

            RequiredFieldValidator1.Enabled = true;
            ARController.rejectCurrentRequest(TxtReason.Text);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Request has been rejected!'); window.location = '" + Page.ResolveUrl("~/Home/DeptHeadHome.aspx") + "';", true);

         //   ClientScript.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Request has been rejected'); window.location='" + Page.ResolveUrl(" ~/Dep/RequstitionListUI.aspx"), true);

            //Respons.Redirect();

           
        }

        protected void TxtReason_TextChanged(object sender, EventArgs e)
        {
            if(TxtReason.Text!="" )
            {
                btnOkReject.Enabled = false;
            }
            else
            {
                btnOkReject.Enabled = true;
            }
        }
    }
}