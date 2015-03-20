using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.CustomControl;

namespace LogicUniversityStationeryStore.Dep
{
    public partial class CreateDisburListUI : System.Web.UI.Page
    {
        int count = 0;
        String empNo;
        String empDeptCode;    
  
        DisbursementController dbsController = new DisbursementController();
        RetrievalController rtController = new RetrievalController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);


            if (Request.Cookies["User"] != null)
            {
                empNo = Request.Cookies["User"].Value.ToString();
            }    
            if (!IsPostBack)
            {
                BindingDropDown(); //bind drop down list
            }
        }
        public void BindingDropDown()
        {
            EntityBroker broker = new EntityBroker();
                var q = (from dp in broker.getEntities().Departments
                         where dp.name != "Stationery Store"
                         select new
                         {
                             Name = dp.name,
                             Code = dp.code
                         }).Distinct().ToList();

                ddlDepName.DataSource = q;
                ddlDepName.DataBind();
                broker.dispose();
        }
        protected void ddlDepName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlDepName.SelectedItem.Text != "--Select a department--")
            {
                EntityBroker broker = new EntityBroker();
                DateTime deliverDate = dbsController.getDeliveryDate(ddlDepName.SelectedValue);
                Department dep = dbsController.getDepartmentData(ddlDepName.SelectedValue);

                lblRepName.Text = dep.contactName;
                //lblCollectionPoint.Text = dep.collectionPt.ToString();
                int CollectionPoint = Convert.ToInt32(dep.collectionPt);
                lblCollectionPoint.Text = dbsController.getCollectionName(CollectionPoint);
                lblDeliveryDate.Text = deliverDate.ToShortDateString();


                //--for grid Data Binding case--//    
                var query = (from s in  broker.getEntities().Stationeries
                             join rbd in broker.getEntities().RequestByDepts on s.code equals rbd.stationeryCode
                             join dl in broker.getEntities().DisbursementLists on rbd.deliveryID equals dl.id
                             where dl.clerkEmpNo == empNo && dl.deptCode == ddlDepName.SelectedValue && dl.status == "Accepted"
                             group rbd by new
                             {
                                 rbd.stationeryCode,
                                 Desp = s.description,
                                 RBDdelId = rbd.deliveryID,
                                 Id = rbd.id

                             } into sc
                             select new
                            {
                                SDescription = sc.Key.Desp,
                                OldRetrievedQty = sc.Sum(rbd1 => rbd1.retrievedQuantity),
                                DisbursedQty =sc.Sum(rbd2=>rbd2.disbursedQuantity),
                                deliverID = sc.Key.RBDdelId,
                                RBDId = sc.Key.Id
                            }).ToList();


                //--gridBinding--//
                GrdDisbursementList.DataSource = query;
                GrdDisbursementList.DataBind();

                //when has record to show              
                 if (query.Count != 0)
                  {
                      btnSave.Visible = true;
                  }
                //when no record to show
                 if(query.Count == 0)
                 {
                     btnSave.Visible = false;
                 }               
                btnCancel.Visible = true;

                foreach (GridViewRow r in GrdDisbursementList.Rows)
                {
                    Label lblRetrievedQty = (Label)r.FindControl("lblRetrievedQty");//to set maximnum qty can enter
                    Label lblDisbursedQty = (Label)r.FindControl("lblDisbursedQty");

                    WebUserControl1 DisbursedQty = (WebUserControl1)r.FindControl("spinner1");
                    DisbursedQty.setLimit("0", lblRetrievedQty.Text);
                    if (lblDisbursedQty.Text == "")
                    {
                        DisbursedQty.txtQty = lblRetrievedQty.Text;
                    }
                    else
                    {
                        DisbursedQty.txtQty = lblDisbursedQty.Text;//for first time appear just bind qty amount in text box
                    }
                }
                broker.dispose();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select a department!');", true);
            }
           

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            if (ddlDepName.SelectedItem.Text == "--Select a department--")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select a department!');", true);
            }
            else
            {
                EntityBroker broker = new EntityBroker();
                List<String> SDescription = new List<string>();//for notify purpose
                int RequestedId = 0;
                int collectionP = 0; //for update collectionPoint purpose
                foreach (GridViewRow r in GrdDisbursementList.Rows)
                {
                    Label lblRetrievedQty = (Label)r.FindControl("lblRetrievedQty");//to check condition that compare between DisburseQty and RetrieveQty
                    WebUserControl1 DisbursedQty = (WebUserControl1)r.FindControl("spinner1");

                    Label lblStationeryDes = (Label)r.FindControl("lblStationeryDes");//for notify purpose
                    Label lblRBDId = (Label)r.FindControl("lblRBDId");//for checking condition purpose only
                    Label lbldeliverID = (Label)r.FindControl("lbldeliverID");//for checking condition purpose only

                    int RBDId = Convert.ToInt32(lblRBDId.Text);
                    int deliver = Convert.ToInt32(lbldeliverID.Text);
                    int RetrieveQ = Convert.ToInt32(lblRetrievedQty.Text);
                    int DisburseQ = Convert.ToInt32(DisbursedQty.txtQty);

                    RequestByDept rdb = broker.getEntities().RequestByDepts.FirstOrDefault(rd => rd.id == RBDId);

                    if (DisburseQ < RetrieveQ)
                    {
                        SDescription.Add(lblStationeryDes.Text);//for notify purpose

                        if (count == 0)//for only one request record saved purpose
                        {
                            //empDeptCode = rtController.getDepartmentOfLoginPerson(empNo);//get login employee department to assign into Request Table
                            int delId = rdb.deliveryID;
                            empDeptCode = rtController.getOriginalDepartmentCode(delId);

                            //save new Request
                            Request newr = dbsController.insertNewRequest(empDeptCode, empNo, delId);
                            broker.getEntities().Requests.Add(newr);
                            RequestedId = newr.id;
                            count++;
                        }
                        //save new Request Detail                         
                        String SCode = rdb.stationeryCode;
                        RequestDetail newRd = dbsController.insertNewRequestDetail(RequestedId, SCode, RetrieveQ, DisburseQ);
                        broker.getEntities().RequestDetails.Add(newRd);

                        //update Inventory quantity according to stationeryCode
                        Inventory i = broker.getEntities().Inventories.FirstOrDefault(iv => iv.stationeryCode == rdb.stationeryCode);
                        i.quantity = i.quantity + (RetrieveQ - DisburseQ);

                        rdb.disbursedQuantity = Convert.ToInt32(DisbursedQty.txtQty);   //update disbursedQty in RequestByDepartment

                        DisbursementList dl = broker.getEntities().DisbursementLists.FirstOrDefault(dL => dL.id == deliver && dL.clerkEmpNo == empNo);
                        dl.status = "Delivered";   //Update DisbursementList status as Delivered


                        ////Update CollectionPoint to clean ClerkEmpNo
                        collectionP = Convert.ToInt32(dl.collectionPt);
                        var cp = broker.getEntities().CollectionPoints.Where(cp1 => cp1.id == collectionP).ToList();
                        foreach (var c in cp)
                        {
                            c.clerkEmpNo = null;
                        }

                    }
                    else
                    {
                        rdb.disbursedQuantity = Convert.ToInt32(DisbursedQty.txtQty);   //update disbursedQty in RequestByDepartment

                        DisbursementList dl = broker.getEntities().DisbursementLists.FirstOrDefault(dL => dL.id == deliver && dL.clerkEmpNo == empNo);
                        dl.status = "Delivered";   //Update DisbursementList status as Delivered

                        //Update CollectionPoint to clean ClerkEmpNo
                        collectionP = Convert.ToInt32(dl.collectionPt);
                        var cp = broker.getEntities().CollectionPoints.Where(cp1 => cp1.id == collectionP).ToList();
                        foreach (var c in cp)
                        {
                            c.clerkEmpNo = null;
                        }

                    }

                }
                broker.getEntities().SaveChanges();
                dbsController.NotifyToStoreClerk(SDescription); //notify the store clerk by sending mail
                broker.dispose();
                //show alert box and go to home page
                if (GrdDisbursementList.Rows.Count > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Saving successful!'); window.location = '" + Page.ResolveUrl("~/Home/StationeryClerkHome.aspx") + "';", true);
                }
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/StationeryClerkHome.aspx");
        }

        protected void GrdDisbursementList_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 
     
    }
}