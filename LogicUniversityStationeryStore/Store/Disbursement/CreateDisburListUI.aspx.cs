using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Dep
{
    public partial class CreateDisburListUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }           

        protected void ddlDepName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisbursementController d = new DisbursementController();
          
            DateTime deliverDate = d.getDeliveryDate(ddlDepName.SelectedValue);
            Department dep = d.getDepartmentData(ddlDepName.SelectedItem.Text);   
        

            lblRepName.Text = dep.contactName;
            lblCollectionPoint.Text = dep.collectionPt;
            lblDeliveryDate.Text =deliverDate.ToShortDateString();

            

            //--for grid Data Binding case--        
                     
            var query1 = (from dl in EntityBroker.getMyEntities().DisbursementLists
                          join r in EntityBroker.getMyEntities().Requests on dl.id equals r.deliveryID
                          join rd in EntityBroker.getMyEntities().RequestDetails on r.id equals rd.requestID
                          join s in EntityBroker.getMyEntities().Stationeries on rd.stationeryCode equals s.code
                          where dl.clerkEmpNo == "SC0001"
                                && r.deptCode == ddlDepName.SelectedValue && dl.deliveryDate == deliverDate

                          group rd by s.description into sc  //--Sum(rd.NeededQuantity) over partition By(s.description)--                                           
                          select new
                          {
                              Description = sc.Key,//--select stationery description--
                              Quantity = sc.Sum(rd1 => rd1.neededQuantity)     //--sum(rd.NeededQuantity)--

                          }).ToList();

            //--gridBinding--
            GrdDisbursementList.DataSource = query1;
            GrdDisbursementList.DataBind();
        }

   

     
    }
}