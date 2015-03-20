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
        int collpointid = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

            orderid = Convert.ToInt32(Request.QueryString["erid"]);
            itm = cpoc.getDisbursementInfo(orderid);
            if (itm.status.Equals("Delivered") && itm.deliveryDate < DateTime.Now)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Page has expired, sorry '); window.location = '" + Page.ResolveUrl("~/LogInUI") + "';", true);

            }
            else
            {
                DateTime time1 = DateTime.Now;
                DateTime time2 = cpoc.getDisbursementInfo(orderid).deliveryDate;
                if (DateTime.Compare(time1, time2) > 0)
                {
                    this.UpdateBtn.Enabled = false;
                    Label4.Text = "Item has been delivered, you can not change the collection point";
                }
                else
                {
                    this.UpdateBtn.Enabled = true;
                }


                if (itm != null)
                {
                    ClerkIdLbl.Text = itm.clerkEmpNo;
                    OrderIDLbl.Text = itm.id.ToString();
                    DateLbl.Text = itm.deliveryDate.ToString();
                }


                CPGridView.DataSource = cpoc.getCollectionPointInfo(orderid);
                CPGridView.DataBind();

            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            orderid = Convert.ToInt32(Request.QueryString["erid"]);
            int selectRadio = Convert.ToInt32(Request.Form["MyRadioBTN"]);
           
           // itm = cpoc.getDisbursementInfo(orderid);
           // itm.collectionPt = selectRadio;
            cpoc.getDeptInfo(orderid, selectRadio);

            ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Collection Point is Updated '); window.location = '" + Page.ResolveUrl("~/LogInUI") + "';", true);


        }

        protected void CPGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}