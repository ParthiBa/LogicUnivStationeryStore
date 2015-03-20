using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;

namespace LogicUniversityStationeryStore.Store.StockAdjustment
{
    public partial class CreateStockAdjustmentReportUI : System.Web.UI.Page
    {

        static LinqHelper LinqHelper = new LinqHelper();
        string clerkid;
        NewAdjustmentController NAController = new NewAdjustmentController();

      
        decimal price;
        protected void Page_Load(object sender, EventArgs e)
        {



            clerkid = Request.Cookies["User"].Value.ToString();
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);


            Spinner21.txtSpinChanged += new EventHandler(AmountChanged);
            ViewState["price"] = LinqHelper.findPricebtItemCode("C001");

            if (GrdDiscrepDetails.Rows.Count == 0)
            {
                btnSubmitAdjustment.Enabled = false;
            }
         //   spinner1.txtSpinChanged += new EventHandler(AmountChanged);
            if (!IsPostBack)
            {
          
                lblShowDate.Text = DateTime.Now.ToShortDateString();
                Spinner21.setLimit("-10000", "10000");


                stationaryDropDownList.DataSource = LinqHelper.getAllCategories();
                stationaryDropDownList.DataBind();

                ddlStationarItemsbyCat.DataSource = LinqHelper.getItemByCategory("Clip");
                ddlStationarItemsbyCat.DataBind();
            }
            string AdjustmentID = Request.Params["id"];
            if (AdjustmentID != null)
            {
                // update the Grid
                int AdjustmentId = Convert.ToInt32(AdjustmentID);
                // var q = from x in EntityBroker.getMyEntites().StockAdjustmentDetails
                var q = (from x in EntityBroker.getMyEntities().StockAdjustmentDetails
                         where x.reportID == AdjustmentId
                         select x).ToList();
                GrdDiscrepDetails.DataSource = q;
               // lblTest.Text = AdjustmentId.ToString();
                GrdDiscrepDetails.DataBind();
                


            }


            //StationeryDropDown1.ddlDropDownSelect += new EventHandler(NewItemSelected);
           // spin.setLimit("-1000", "1000");
          //  spinner1.setLimit("-1000", "1000");
        }

        protected void btnSubmitItem_Click(object sender, EventArgs e)
        {
            if (ViewState["currentAdjust"]==null)
            {


                SetInitialRow(ddlStationarItemsbyCat.SelectedValue,ddlStationarItemsbyCat.SelectedItem.Text, Spinner21.getValues(), txtReason.Text,Convert.ToDecimal(lblAmountDisp.Text));
            }
            else
            {
                addNextRow(ddlStationarItemsbyCat.SelectedValue, ddlStationarItemsbyCat.SelectedItem.Text, Spinner21.getValues(), txtReason.Text, Convert.ToDecimal(lblAmountDisp.Text));

            }
            btnSubmitAdjustment.Enabled = true;
        }

        protected void stationaryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlStationarItemsbyCat.DataSource = LinqHelper.getItemByCategory(stationaryDropDownList.SelectedValue);
            ddlStationarItemsbyCat.DataBind();

            lblUnitOfMeasure.Text = LinqHelper.getUnitOfMeasure(ddlStationarItemsbyCat.Items[0].Value);
            ViewState["price"] = LinqHelper.findPricebtItemCode(ddlStationarItemsbyCat.Items[0].Value);
        }

        protected void ddlStationarItemsbyCat_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblUnitOfMeasure.Text= LinqHelper.getUnitOfMeasure(ddlStationarItemsbyCat.SelectedValue);
            ViewState["price"] = LinqHelper.findPricebtItemCode(ddlStationarItemsbyCat.SelectedValue);
        }

        private void AmountChanged(object sender, EventArgs e)
        {
            price = (decimal)ViewState["price"];
            lblAmountDisp.Text=Convert.ToString(((price) * (Spinner21.getValueInt())));

           // Session["price"] = null;
        }

        //void NewItemSelected(object sender, EventArgs e)
        //{
        // //   string Cateogory = StationeryDropDown1.getValues();
        // //   var q = (from x in EntityBroker.getMyEntities().Stationeries
        //            // where x.category == Cateogory
        //           //  select new { x.code, x.category }).ToList();
        //    //     ddlStationarItemsbyCat.DataTextField = "category";
        //    //   ddlStationarItemsbyCat.DataValueField = "code";
        // //   ddlStationarItemsbyCat.DataSource = q;
        // //   ddlStationarItemsbyCat.DataBind();
        //}

        //protected void ddlStationarItemsbyCat_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblTest.Text = ddlStationarItemsbyCat.SelectedValue;
        //    var getItem = (from x in EntityBroker.getMyEntities().Stationeries
        //                 where x.code == ddlStationarItemsbyCat.SelectedValue
        //                 select  x).First() ;
        //    if(getItem.price1!=null)
        //    {
        //        price = (decimal)getItem.price1;

            
        //    }
        //    //lblUom.Text = getItem.unitOfMeasure;
        //}

        //protected void stationaryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var xa = stationaryDropDownList.SelectedValue;
        //    var quwe = from x in EntityBroker.getMyEntities().Stationeries
        //               where x.category == xa
        //               select new { x.code,x.description};
        //    ddlStationarItemsbyCat.DataSource = quwe.ToList();
        //    ddlStationarItemsbyCat.DataBind();
            


        //}


        private void SetInitialRow(string ItemCode,string stationaryItem,string quantity,string Reason,decimal amount)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("No", typeof(int)));
            dt.Columns.Add(new DataColumn("ItemNo", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
            dt.Columns.Add(new DataColumn("quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Reason", typeof(string)));
            dt.Columns.Add(new DataColumn("amount", typeof(decimal)));
            dr = dt.NewRow();
            dr["No"] = 1;
            dr["ItemNo"] = ItemCode;
            dr["ItemName"] = stationaryItem;
            dr["quantity"] = quantity;
            dr["Reason"] = Reason;
            dr["amount"] = amount;
            dt.Rows.Add(dr);
            ViewState["currentAdjust"] = dt;
            GrdDiscrepDetails.DataSource = dt;
            GrdDiscrepDetails.DataBind();

          

        }

        private void addNextRow(string ItemCode,string stationaryItem, string quantity, string Reason,decimal amount)
        {
            DataTable dt = null;
            dt = (DataTable)ViewState["currentAdjust"];
            DataRow dr = null;
            dr = dt.NewRow();
            dr["No"] = dt.Rows.Count + 1;
            dr["ItemNo"] = ItemCode;
            dr["ItemName"] = stationaryItem;
            dr["quantity"] = quantity;
            dr["Reason"] = Reason;
            dr["amount"] = amount;
            dt.Rows.Add(dr);
            ViewState["currentAdjust"] = dt;
            GrdDiscrepDetails.DataSource = dt;
            GrdDiscrepDetails.DataBind();



        }

        void dataBind()
        {
            DataTable dt;
            dt = (DataTable)ViewState["currentAdjust"];
            GrdDiscrepDetails.DataSource = dt;
            GrdDiscrepDetails.DataBind();


        }

  

        protected void GrdDiscrepDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


                DataTable  dt = (DataTable)ViewState["currentAdjust"];
                dt.Rows.Remove(dt.Rows[e.RowIndex]);
            GrdDiscrepDetails.DataSource = dt;
            GrdDiscrepDetails.DataBind();
        }

        protected void btnSubmitAdjustment_Click(object sender, EventArgs e)
        {
            NAController.createStockAdjustment(clerkid);
             DataTable  dt = (DataTable)ViewState["currentAdjust"];
             NAController.addStockAdjusmentDetails(dt);

             ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Request Has been added Sucessfully '); window.location = '" + Page.ResolveUrl("~/Home/StationeryClerkHome.aspx") + "';", true);
        }

  
    }
}