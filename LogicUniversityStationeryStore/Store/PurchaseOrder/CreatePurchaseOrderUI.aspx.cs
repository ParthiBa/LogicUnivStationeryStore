using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.CustomControl;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.PurchaseOrder
{
    public partial class CreatePurchaseOrderUI : System.Web.UI.Page
    {
        //declare variables & controllers
        string currentValue;
        string empId ;
        string maxQty = "5";

        NewPurchaseController newPController = new NewPurchaseController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["User"]!=null)
            {
                empId = Request.Cookies["User"].Value.ToString();
                string role = Request.Cookies["User"].Value.ToString();
                CheckRoleController.setStationaryMaster(this.Master, role);
            }

            GrdPurchaseOrder.RowDataBound += new GridViewRowEventHandler(this.GrdPurchaseOrder_RowDataBound);

            if (!IsPostBack)
            {
                BindingDropDownList();               
                spinner1.setLimit("1", "1000");

            }
        }

        //binding drop down list
        public void BindingDropDownList()
        {
            ddlSupplier.DataSource = newPController.getSupplier();
            ddlSupplier.DataBind();           
        }

        //binding database
        private void BindData()
        {
            DataTable dt = (DataTable)ViewState["CurrentCreate"];
            GrdPurchaseOrder.DataSource = dt;
            GrdPurchaseOrder.DataBind();
        }

        //add button click event
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = true;
            ddlSupplier.Enabled = false;
            string itemN = ddlItemDescription.SelectedValue;
            string itemDesp = ddlItemDescription.SelectedItem.Text;
            string qty = spinner1.getValue();

            string unitOfMeasure = newPController.getUnitOfMeasure(ddlItemDescription.SelectedValue);//get unit of measure according to the item Description
            decimal p = newPController.getPrice(ddlItemDescription.SelectedValue, ddlSupplier.SelectedValue);
            decimal q = Convert.ToDecimal(qty);
            decimal amt = q * p;
            string amount = Convert.ToString(amt);
            string price = Convert.ToString(p);
            setIntitialRow(itemN, itemDesp, qty, unitOfMeasure, price, amount);
        }

        //set initial data row
        private void setIntitialRow(string itemNO, string itemDesp, string qty, string UOM, string price, string amount)
        {
            if (ViewState["CurrentCreate"] == null)
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("ItemNo", typeof(string)));
                dt.Columns.Add(new DataColumn("Description", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
                dt.Columns.Add(new DataColumn("UOM", typeof(string)));
                dt.Columns.Add(new DataColumn("Price", typeof(string)));
                dt.Columns.Add(new DataColumn("Amount", typeof(string)));

                dr = dt.NewRow();
                dr["ItemNo"] = itemNO;
                dr["Description"] = itemDesp;
                dr["Quantity"] = qty;
                dr["UOM"] = UOM;
                dr["Price"] = price;
                dr["Amount"] = amount;
                dt.Rows.Add(dr);

                ViewState["CurrentCreate"] = dt;
                GrdPurchaseOrder.DataSource = dt;
                GrdPurchaseOrder.DataBind();
            }
            else
            {
                DataTable dt = (DataTable)ViewState["CurrentCreate"];
                DataRow dr = null;
                dr = dt.NewRow();
                dr["ItemNo"] = itemNO;
                dr["Description"] = itemDesp;
                dr["Quantity"] = qty;
                dr["UOM"] = UOM;
                dr["Price"] = price;
                dr["Amount"] = amount;
                dt.Rows.Add(dr);
                ViewState["CurrentCreate"] = dt;
                GrdPurchaseOrder.DataSource = dt;
                GrdPurchaseOrder.DataBind();

            }

        }

        //row data bound
        protected void GrdPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView rv = e.Row.DataItem as DataRowView;
            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                WebUserControl1 spinner2 = e.Row.FindControl("spinner2") as WebUserControl1;
                //set maximum value for quantity
                maxQty = newPController.getMaxQty(ddlItemDescription.SelectedValue);
                if (spinner2 != null)
                {
                    spinner2.setLimit("1", maxQty);
                    spinner2.setValue(currentValue);
                }
            }
        }
      
        //row editing
        protected void GrdPurchaseOrder_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdPurchaseOrder.EditIndex = e.NewEditIndex;
            GridViewRow r = GrdPurchaseOrder.Rows[e.NewEditIndex];

            Label qty = (Label)r.FindControl("lblQuantity");
            currentValue = qty.Text;          
            BindData();
        }
        //canel editing
        protected void GrdPurchaseOrder_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdPurchaseOrder.EditIndex = -1;
            BindData();
        }              

        //row delete
        protected void GrdPurchaseOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentCreate"];
            dt.Rows.Remove(dt.Rows[e.RowIndex]);
            GrdPurchaseOrder.DataSource = dt;
            GrdPurchaseOrder.DataBind();
        }

        //row update
        protected void GrdPurchaseOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentCreate"];
            GridViewRow row = GrdPurchaseOrder.Rows[e.RowIndex];
            dt.Rows[row.DataItemIndex]["Quantity"] = ((WebUserControl1)row.Cells[1].FindControl("spinner2")).getValue();

            //after edit quanity calcualte total amount again 
            decimal q1 = Convert.ToDecimal(((WebUserControl1)row.Cells[1].FindControl("spinner2")).getValue());
            decimal p1 = Convert.ToDecimal(dt.Rows[row.DataItemIndex]["Price"]);
            decimal amt = q1 * p1;

            dt.Rows[row.DataItemIndex]["Amount"] = Convert.ToString(amt);

            GrdPurchaseOrder.EditIndex = -1;
            BindData();
        }

        //save to database
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentCreate"];
            if (deliveryDate.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please choose delivery Date!');", true);
            }
            else
            {
                DateTime date = Convert.ToDateTime(deliveryDate.Value); //get value from html input type date

                //create new purchase order and purchase Order detail
                newPController.createPurchaseOrder(empId, date, ddlSupplier.SelectedValue);
                newPController.createPurchaseOrderDetail(dt);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Request Has been added Sucessfully '); window.location = '" + Page.ResolveUrl("~/Store/PurchaseOrder/ListOfPurchaseOrderUI.aspx") + "';", true);
            }
        }

        //drop down list selected index changed event
        protected void ddlItemDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            maxQty = newPController.getMaxQty(ddlItemDescription.SelectedValue);
            spinner1.setLimit("0", maxQty);
            btnAddNew.Visible = true;
            //show unit of measure here 
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblItemDescriptionTitle.Visible = true;
            ddlItemDescription.Visible = true;
            lblQuantityTitle.Visible = true;
            spinner1.Visible = true;
            //btnAddNew.Visible = true;

            ddlItemDescription.DataSource = newPController.getItemDescription(ddlSupplier.SelectedValue);//only select according to supplier 
            ddlItemDescription.DataBind();
         }
    }
    
}