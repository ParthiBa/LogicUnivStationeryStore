using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore;
 

namespace LogicUniversity
{
    public partial class CollectionPoint1 : System.Web.UI.Page
    {
        CollectionPointbyOrderController cpoc = new CollectionPointbyOrderController();
        DisbursementList itm;
        int orderid; 
        protected void Page_Load(object sender, EventArgs e)
        {
          
          orderid = Convert.ToInt32(Request.QueryString["erid"]);
          itm = cpoc.getDisbursementInfo(orderid);
            DateTime time1 = DateTime.Now;
            DateTime time2 = cpoc.getDisbursementInfo(orderid).deliveryDate;
            if (DateTime.Compare(time1, time2) < 0)
            {
                this.UpdateBtn.Enabled = false;
            }
            else {
                this.UpdateBtn.Enabled = true;
            }
           

            if (itm != null)
            {
                ClerkIdLbl.Text = itm.clerkEmpNo;
                OrderIDLbl.Text = itm.id.ToString();
                DateLbl.Text = itm.deliveryDate.ToString();
            }


            CPGridView.DataSource = cpoc.getCollectionPointInfo(); 
            CPGridView.DataBind();

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            string selectRadio = Request.Form["MyRadioBTN"];
           
            itm = cpoc.getDisbursementInfo(orderid);
            itm.collectionPt = Convert.ToInt32(selectRadio);
           
            cpoc.getDeptInfo(orderid).collectionPt =Convert.ToInt32( selectRadio);
            cpoc.SaveChange();


        }

        protected void CPGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}