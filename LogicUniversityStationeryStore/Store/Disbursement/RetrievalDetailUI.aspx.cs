using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.CustomControl;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.Disbursement
{
    public partial class RetrievalDetailUI : System.Web.UI.Page
    {
        //declare variables
        String StationeryCode;
        String empNo;     
        String DisbursedQty;// catch from Retrieved Qty that come from RetrievalListUI.aspx
        String UnitOfMeasure;
        String empDeptCode;      
        int count = 0;

        RetrievalController rtController = new RetrievalController();
        protected void Page_Load(object sender, EventArgs e)
        {



            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);


            RetrievalController rc = new RetrievalController();
            //catch value that passed from RetrievalListUI.aspx page
            if (Request.QueryString["stationeryCode"] != null)
            {
                StationeryCode = Request.QueryString["stationeryCode"].ToString();
            }          
            if(Request.QueryString["empNo"]!=null)
            {
                empNo = Request.QueryString["empNo"].ToString();
            }     
            if(Request.QueryString["DisbursedQty"]!=null)
            {
                DisbursedQty = Request.QueryString["DisbursedQty"].ToString();
            }
            if (Request.QueryString["UnitOfMeasure"]!=null)
            {
                UnitOfMeasure = Request.QueryString["UnitOfMeasure"].ToString();
            }

            lblStationeryCode.Text = StationeryCode;//bind grid outside label
            lblStationeryDesp.Text = rc.getStationeryDescription(StationeryCode); //get stationery description
            lblUnitOfMeasure.Text = UnitOfMeasure;
            if (!IsPostBack)
            {
                BindingGrid();
            }
         
        }
        public void BindingGrid()
        {
            var RetrieveDetail =(from dl in EntityBroker.getMyEntities().DisbursementLists
                                 join rbd in EntityBroker.getMyEntities().RequestByDepts on dl.id equals rbd.deliveryID
                                 join d in EntityBroker.getMyEntities().Departments on dl.deptCode equals d.code
                                 where rbd.stationeryCode == StationeryCode && dl.status =="Accepted" && dl.clerkEmpNo == empNo
                                 orderby d.name
                                 group rbd by new
                                 {
                                     DepName =d.name,
                                     SCode =rbd.stationeryCode,      
                                     neededQuantity =rbd.neededQuantity,
                                     Deliver= dl.id,
                                     RetrivedQty = rbd.retrievedQuantity,
                                     //rdbID = rbd.id,
                                     DepCode = d.code                                    
                                   
                                  } into RD
                                  select new
                                  {
                                      DeptName = RD.Key.DepName,                                     
                                      QtyNeeded =RD.Key.neededQuantity,
                                      DeliverId =RD.Key.Deliver,
                                      RetrievedQty = RD.Key.RetrivedQty,                                     
                                      deptCode = RD.Key.DepCode  //for Checking condition of inserting new Request                                    

                                  }).ToList();
      
            GrdRetrievalDetail.DataSource = RetrieveDetail;
            GrdRetrievalDetail.DataBind();

            foreach (GridViewRow r in GrdRetrievalDetail.Rows)
            {                
                //to take the Needed qty to set the maximum value that store clerk can enter
                Label lblNeededQty = (Label)r.FindControl("lblNeededQty");
               
                //for purpose to bind current Retrieve Value show in text box 
                Label lblRetrievedFromRBD = (Label)r.FindControl("lblRetrievedFromRBD");

                //bindng in usercontrol textbox
                WebUserControl1 ucActualQty = (WebUserControl1)r.FindControl("spinner1");
                ucActualQty.setLimit("0", lblNeededQty.Text);//set minimum value and maximum value               
          
                if (lblRetrievedFromRBD.Text == "")
                {
                    ucActualQty.txtQty = lblNeededQty.Text;
                }
                else
                {
                    ucActualQty.txtQty = lblRetrievedFromRBD.Text;
                }              
            }

        }    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Store/Disbursement/RetrievalListUI.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int RequestedId = 0;//for pass the value and check in RequestDetail
            int DeliveryID =0;
            foreach (GridViewRow r in GrdRetrievalDetail.Rows)
            {              
                //for checking condition to update RequestByDepartment Table according to deliveryID(disbursementList) and stationeryCode(come from RetrievalListUI page)
                 Label lblDeliverId = (Label)r.FindControl("lblDeliverId");
                 DeliveryID =Convert.ToInt32(lblDeliverId.Text);

                Label lblNeededQty =(Label)r.FindControl("lblNeededQty");
                WebUserControl1 ucActualQty = (WebUserControl1)r.FindControl("spinner1");

                //update RequestByDepartment Table according to deliveryID(disbursementList) and stationeryCode(come from RetrievalListUI page)
                RequestByDept rdb = EntityBroker.getMyEntities().RequestByDepts.FirstOrDefault(rd => rd.deliveryID==DeliveryID && rd.stationeryCode==StationeryCode);                           
               
                //for checking codition when Actual quantity is lower than needed quantity
                 int actualQty = Convert.ToInt16(ucActualQty.txtQty);
                 int NeededQty = Convert.ToInt16(lblNeededQty.Text);                 

                //check the condition of Actual quantity is lower than needed quantity
                if (actualQty < NeededQty)
                {
                    if(count == 0)//for only one request record saved purpose
                    {
                    empDeptCode = rtController.getDepartmentOfLoginPerson(empNo);//get login employee department to assign into Request Table
                    int delId = rdb.deliveryID;//for checking condition to create new request
                        
                    Request newr = rtController.insertNewRequest(empDeptCode, empNo, delId);
                    EntityBroker.getMyEntities().Requests.Add(newr);                    
                    RequestedId = newr.id;  //for pass the value and check in RequestDetail                    

                    //send messages to other clerk when Advanced request happen
                    rtController.NotifyToStoreClerk(lblStationeryDesp.Text);

                    count++;
                    }
                    
                    //save new Request Detail                                                
                    String SCode =rdb.stationeryCode;
                    RequestDetail newRd = rtController.insertNewRequestDetail(RequestedId, SCode, NeededQty, actualQty);
                    EntityBroker.getMyEntities().RequestDetails.Add(newRd);                 
                   
                    //update Inventory quantity according to stationeryCode
                    Inventory i = EntityBroker.getMyEntities().Inventories.FirstOrDefault(iv => iv.stationeryCode == SCode);                    
                    i.quantity -= actualQty; 

                    //update RequestByDepartment
                    rdb.retrievedQuantity  = Convert.ToInt16(ucActualQty.txtQty);                 
                   
                }
                else
                {
                    //update Inventory quantity according to stationeryCode
                    Inventory i = EntityBroker.getMyEntities().Inventories.FirstOrDefault(iv => iv.stationeryCode == rdb.stationeryCode);
                    i.quantity -= actualQty; 

                    //update RequestByDepartment
                    rdb.retrievedQuantity = Convert.ToInt16(ucActualQty.txtQty);                    
                }                
            }            
            EntityBroker.getMyEntities().SaveChanges();
            GrdRetrievalDetail.EditIndex = -1;
            BindingGrid();
          

            
           //show alert box and go to next page
            if (GrdRetrievalDetail.Rows.Count > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Update Successful!'); window.location = '" + Page.ResolveUrl("~/default.aspx") + "';", true);
               
            }      
           
        }
      
     }
   }
