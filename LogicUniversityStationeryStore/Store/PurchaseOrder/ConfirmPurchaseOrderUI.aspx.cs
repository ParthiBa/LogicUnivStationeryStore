using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.CustomControl;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.Store.PurchaseOrder
{
    public partial class ConfirmPurchase : System.Web.UI.Page
    {
        NewPurchaseController newPController = new NewPurchaseController();
        string supplier;
        string orderId;
        string orderBy;
        string orderDate;
        string DeDate;
        string supCode;
        string despCode;
        int OID;
        string maxQty = "10";
        string currentValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            //catch data values from list of purchaseOrder page
            getDataFromListPage();
            if (!IsPostBack)           {
               
                //get temp data table from controller
                DataTable dt = newPController.bindGrdConfirmPurchaseOrder(OID);
                //bind temptable to grid and bind labels 
                BindControls(dt);
            }
        }
        public void getDataFromListPage()
        {
            //catch value that passed from ListOfPurchaseOrder.aspx page
            if (Request.QueryString["Supplier"] != null)
            {
                supplier = Request.QueryString["Supplier"].ToString();
            }
            if (Request.QueryString["OrderID"] != null)
            {
                orderId = Request.QueryString["OrderID"].ToString();
            }
            if (Request.QueryString["OrderBy"] != null)
            {
                orderBy = Request.QueryString["OrderBy"].ToString();
            }
            if (Request.QueryString["OrderDate"] != null)
            {
                orderDate = Request.QueryString["OrderDate"].ToString();
            }
            if (Request.QueryString["DeliveryDate"] != null)
            {
                DeDate = Request.QueryString["DeliveryDate"].ToString();
            }
            if (Request.QueryString["SupCode"] != null)
            {
                supCode = Request.QueryString["SupCode"].ToString();
            }
            OID = Convert.ToInt32(orderId);

            //ClientScript.RegisterStartupScript(this.GetType(), "ScriptKey", string.Format("bindDate('{0}')", DeDate), true);

        }
        private DataTable GridItemTempTable
        {
            get
            {
                if(ViewState["PurchaseOrder"]==null)
                {
                    this.CreateTempTable();
                }
                return (DataTable)ViewState["PurchaseOrder"];
            }
            set
            {
                //create temporary table
                DataTable TempGridItemTable = value;
               
                //add key column
                DataColumn keyColumn = new DataColumn("Key", typeof(int));
                TempGridItemTable.Columns.Add(keyColumn);
                //tempory storage
                ViewState["PurchaseOrder"] = value;
            }
        }
        private void CreateTempTable()
        {
            OID = Convert.ToInt32(orderId);
            DataTable dt = new DataTable();
            dt = newPController.bindGrdConfirmPurchaseOrder(OID);
           
            ViewState["PurchaseOrder"] = dt;          
           
        }    
              
        //bind grid item
        private void grdConfirmPurchaseOrder_DataBind()
        {
            //set grid item's data source
            grdConfirmPurchaseOrder.DataSource = this.GridItemTempTable;
            //bind grid item
            this.grdConfirmPurchaseOrder.DataBind();
            
        }
        private void BindControls(DataTable dt)
        {
            lblOrderNo.Text = orderId;
            lblOrderBy.Text = orderBy;
            lblOrderDate.Text = orderDate;
            lblSupplier.Text = supplier;

            this.GridItemTempTable = dt;
            this.grdConfirmPurchaseOrder_DataBind();           

        }
        protected void grdConfirmPurchaseOrder_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdConfirmPurchaseOrder.EditIndex = -1;
            this.grdConfirmPurchaseOrder_DataBind();
        }

        protected void grdConfirmPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView rv = e.Row.DataItem as DataRowView;
            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                WebUserControl1 spinner2 = e.Row.FindControl("spinner2") as WebUserControl1;
                Label lblItemDesp = e.Row.FindControl("lblItemDesp") as Label;
                //set maximum value for quantity
                despCode = newPController.getDespCode(lblItemDesp.Text);
                maxQty = newPController.getMaxQty(despCode);
                if (spinner2 != null)
                {
                    spinner2.setLimit("1", maxQty);
                    spinner2.setValue(currentValue);
                }
            }
        }

        protected void grdConfirmPurchaseOrder_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //set grdConfirmPurchaseOrder's edit index by current editing index
            grdConfirmPurchaseOrder.EditIndex = e.NewEditIndex;
            GridViewRow r = grdConfirmPurchaseOrder.Rows[e.NewEditIndex];

            Label qty = (Label)r.FindControl("lblQuantity");
            currentValue = qty.Text;
            this.grdConfirmPurchaseOrder_DataBind();
            
        }

        protected void grdConfirmPurchaseOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["PurchaseOrder"];
            GridViewRow row =grdConfirmPurchaseOrder.Rows[e.RowIndex];
            dt.Rows[row.DataItemIndex]["Quantity"] = ((WebUserControl1)row.Cells[0].FindControl("spinner2")).getValue();

            //after edit quanity calcualte total amount again 
            decimal q1 = Convert.ToDecimal(((WebUserControl1)row.Cells[0].FindControl("spinner2")).getValue());
            decimal p1 = Convert.ToDecimal(dt.Rows[row.DataItemIndex]["Price"]);
            decimal amt = q1 * p1;

            dt.Rows[row.DataItemIndex]["Amount"] = Convert.ToString(amt);

            grdConfirmPurchaseOrder.EditIndex = -1;
            this.grdConfirmPurchaseOrder_DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            OID = Convert.ToInt32(orderId);
            newPController.CancelOrder(OID);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Cancel Order Successful.'); window.location = '" + Page.ResolveUrl("~/Store/PurchaseOrder/ListOfPurchaseOrderUI.aspx") + "';", true);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string stationeryCode;
            int qty;
            int id;
            decimal d;

            //if user don't choose delivery date ,show msg let to choose it first
            if (deliveryDate.Value == "")
            {               
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please choose delivery Date!');", true);
            }
            else
            {
                DateTime date = Convert.ToDateTime(deliveryDate.Value);
                foreach (GridViewRow r in grdConfirmPurchaseOrder.Rows)
                {
                    Label lblItemDesp = (Label)r.FindControl("lblItemDesp");
                    stationeryCode = newPController.getDespCode(lblItemDesp.Text);

                    Label lblItemid = (Label)r.FindControl("lblItemID");
                    id = Convert.ToInt32(lblItemid.Text);

                    Label lblQuantity = (Label)r.FindControl("lblQuantity");
                    qty = Convert.ToInt32(lblQuantity.Text);

                    Label lblamount = (Label)r.FindControl("lblAmount");
                    d = Convert.ToDecimal(lblamount.Text);

                    OID = Convert.ToInt32(orderId);
                    newPController.ConfirmOrder(OID, stationeryCode, date, qty,id,d);

                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Confirm Order Successful.'); window.location = '" + Page.ResolveUrl("~/Store/PurchaseOrder/ListOfPurchaseOrderUI.aspx") + "';", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Store/PurchaseOrder/ListOfPurchaseOrderUI.aspx");
        }


    }
}