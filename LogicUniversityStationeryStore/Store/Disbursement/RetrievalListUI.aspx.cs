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
    public partial class RetrievalListUI : System.Web.UI.Page
    {
        String empNo;
        protected void Page_Load(object sender, EventArgs e)
        {



            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);



            if (Request.Cookies["User"] != null)
            {
                empNo = Request.Cookies["User"].Value.ToString();
            }    
            //empNo ="SC0001";
            BindingGrid();
            
        }     

        protected void lnkbtnBreakDownbyDept_Click(object sender, EventArgs e)
        {
            var v = (Control)sender;
            GridViewRow row = (GridViewRow)v.NamingContainer;
            Label lblItemNo = (Label)row.FindControl("lblitemNo");
            Label QtyRetrieve = (Label)row.FindControl("lblQtyRetrieved");
           

            Label lblUnitOfMeasure = (Label)row.FindControl("lblUnitOfMeasure");//for pass Unit of measure to RetrievalDetailUI
            String url = "~/Store/Disbursement/RetrievalDetailUI.aspx?stationeryCode=" + lblItemNo.Text + "&&empNo=" + empNo + "&&DisbursedQty=" + QtyRetrieve.Text + "&&UnitOfMeasure=" + lblUnitOfMeasure.Text;
            Response.Redirect(url);
        }
        public void BindingGrid()
        {
            var RetrieveList = (from i in EntityBroker.getMyEntities().Inventories
                                join s in EntityBroker.getMyEntities().Stationeries on i.stationeryCode equals s.code
                                join rdb in EntityBroker.getMyEntities().RequestByDepts on s.code equals rdb.stationeryCode
                                join dl in EntityBroker.getMyEntities().DisbursementLists on rdb.deliveryID equals dl.id
                                where dl.status == "Accepted" && dl.clerkEmpNo == empNo
                                orderby i.binNo descending
                                group rdb by new
                                {
                                    SCode = rdb.stationeryCode,                                                                   
                                    B = i.binNo,
                                    SDesp = s.description,
                                    qty = i.quantity,
                                    avaqty = i.availableQty,
                                    UOM = s.unitOfMeasure

                                } into RL
                                select new
                                {
                                    BinNo = RL.Key.B,
                                    ItemNo = RL.Key.SCode,
                                    StationeryDescription = RL.Key.SDesp,
                                    Qtyneeded = RL.Sum(qty => qty.neededQuantity),
                                    Rqty  =RL.Sum(rqty=>rqty.retrievedQuantity), //sum the retrievedQty from RequestByDepartment table
                                    Qty = RL.Key.qty,
                                    AvaQty = RL.Key.avaqty, //for check condition in highlighting row 
                                    UnitOM = RL.Key.UOM

                                }).ToList();


          
            GrdRetrievalList.DataSource = RetrieveList;
            GrdRetrievalList.DataBind();


            foreach (GridViewRow r in GrdRetrievalList.Rows)
            {
                Label lblRetrieveFromRBD = (Label)r.FindControl("lblRetrievefromRBD");
                Label lblQtyRetrieved = (Label)r.FindControl("lblQtyRetrieved");
                Label lblQtyNeeded =(Label)r.FindControl("lblQtyNeeded");
                if(lblRetrieveFromRBD.Text == "")
                {
                    lblQtyRetrieved.Text = lblQtyNeeded.Text;
                }
                else
                {
                    lblQtyRetrieved.Text = lblRetrieveFromRBD.Text;
                }
                             
            }
        }
        //highlight the row in the grid when Stock qty in inventory running low
       protected void hightLightRow(object sender,GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblQty = (Label)e.Row.FindControl("lblmaxQty");// original qty in inventory

                Label lblQtyNeeded = (Label)e.Row.FindControl("lblQtyNeeded");//cuz take lblQtyNeeded doesn't change the qty
                                        
                int QtyRetrieve = Convert.ToInt32(lblQtyNeeded.Text);
                int OriginQty = Convert.ToInt32(lblQty.Text);

                if (QtyRetrieve > OriginQty)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }

            }

        }
    }
}