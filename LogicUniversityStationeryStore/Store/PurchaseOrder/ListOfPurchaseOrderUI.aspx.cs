using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Store.PurchaseOrder
{
    public partial class PurchaseOrderList : System.Web.UI.Page
    {
        NewPurchaseController newPController = new NewPurchaseController();
        protected void Page_Load(object sender, EventArgs e)
        {
            //set  Master Page
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);


            if (!IsPostBack)
            {
                BindGrid();
            }
        }
      public void BindGrid()
        {
            grdListPurchaseOrder.DataSource = newPController.bindGrdListPurchaseOrder();
            grdListPurchaseOrder.DataBind();

          //if status is Delivered or Cancelled ,linkbutton turn black color
         foreach (GridViewRow r in grdListPurchaseOrder.Rows)
         {
             LinkButton lnkbtn = (LinkButton)r.FindControl("LnkBtnStatus");
             Label lblDeliveryDate = (Label)r.FindControl("lblDeliveryDate");
             //in pending case 
             if(lblDeliveryDate.Text=="")
             {
                 lblDeliveryDate.Text = "-";
             }             
             if (lnkbtn.Text == "Delivered" || lnkbtn.Text == "Cancelled")
             {
                 lnkbtn.ForeColor = System.Drawing.Color.Black;
             }
         }
        }

      protected void LnkBtnStatus_Click(object sender, EventArgs e)
      {          
          var v = (Control)sender;
          GridViewRow row = (GridViewRow)v.NamingContainer;
        
          LinkButton lnkbtn     = (LinkButton)row.FindControl("LnkBtnStatus");
          Label lblOrderNo      = (Label)row.FindControl("lblOrderNo");
          Label lblOrderDate    = (Label)row.FindControl("lblOrderDate");
          Label lblDeliveryDate = (Label)row.FindControl("lblDeliveryDate");
          Label lblOrderBy      = (Label)row.FindControl("lblOrderBy");
          Label lblSupplier     = (Label)row.FindControl("lblSupplier");
          Label lblSupCode      = (Label)row.FindControl("lblSupCode");        
          
           if(lnkbtn.Text == "Pending")
           {               
               String url = "~/Store/PurchaseOrder/ConfirmPurchaseOrderUI.aspx?OrderID="+lblOrderNo.Text+"&&OrderDate="+lblOrderDate.Text+"&&DeliveryDate="+lblDeliveryDate.Text+"&&OrderBy="+lblOrderBy.Text+"&&Supplier="+lblSupplier.Text+"&&SupCode="+lblSupCode.Text;
               Response.Redirect(url);
           }
           else
           {
               lnkbtn.ForeColor = System.Drawing.Color.Black;
           }    

      }
    }
}