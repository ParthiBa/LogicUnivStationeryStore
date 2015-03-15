using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.CRUD.StationeryPages
{
    public partial class manageStationeryUI : System.Web.UI.Page
    {
        //  logicEntities1 context = new logicEntities1();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);
            if (!IsPostBack)
            {
                StationeryCRUDController RudRetrieve = new StationeryCRUDController();
                List<string> categoryList = RudRetrieve.rudPageLoad();

                foreach (string name in categoryList)
                {
                    ddCategory.Items.Add(name);
                }

                List<string> stationeryItem = RudRetrieve.ddCategoryChanged(categoryList[0]);
                foreach (string name in stationeryItem)
                {
                    ddDescription.Items.Add(name);
                }
            }
        }

        protected void btnRetrive_Click(object sender, EventArgs e)
        {
            ddSupplier1.Items.Clear();
            ddsupplier2.Items.Clear();
            ddSupplier3.Items.Clear();

            StationeryCRUDController RudRetrieve = new StationeryCRUDController();
            Stationery stationeryDetails = RudRetrieve.rudPageLoad(ddCategory.Text, ddDescription.Text);

            // txtSupCode.Text = supplierDetail.supplierCode;
            txtCode.Text = stationeryDetails.code;
            txtReorderLevel.Text = stationeryDetails.reorderLevel;
            txtReorderQty.Text = stationeryDetails.reorderQuantity;
            TxtUnitOfMeasure.Text = stationeryDetails.unitOfMeasure;
            txtPrice1.Text = Convert.ToString(stationeryDetails.price1);
            txtPrice2.Text = Convert.ToString(stationeryDetails.price2);
            txtPrice3.Text = Convert.ToString(stationeryDetails.price3);
            ddSupplier1.Items.Add(RudRetrieve.getSupplierName(stationeryDetails.supplier1));
            ddsupplier2.Items.Add(RudRetrieve.getSupplierName(stationeryDetails.supplier2));
            ddSupplier3.Items.Add(RudRetrieve.getSupplierName(stationeryDetails.supplier3));


            List<string> supp1 = RudRetrieve.getAllSupplierName(stationeryDetails.supplier1);
            foreach (string n in supp1)
            {
                ddSupplier1.Items.Add(n);
            }
            List<string> supp2 = RudRetrieve.getAllSupplierName(stationeryDetails.supplier2);
            foreach (string n in supp2)
            {
                ddsupplier2.Items.Add(n);
            }
            List<string> supp3 = RudRetrieve.getAllSupplierName(stationeryDetails.supplier3);
            foreach (string n in supp3)
            {
                ddSupplier3.Items.Add(n);
            }


            // Visibility
            lblCode.Visible = true;
            lblReorderLevel.Visible = true;
            lblReorderQty.Visible = true;
            lblUnitOfMeasure.Visible = true;
            lblPrice1.Visible = true;
            lblPrice.Visible = true;
            lblprice3.Visible = true;
            lblSupplier1.Visible = true;
            lblSupplier2.Visible = true;
            Suppler3.Visible = true;

            txtCode.Visible = true;
            txtReorderLevel.Visible = true;
            txtReorderQty.Visible = true;
            TxtUnitOfMeasure.Visible = true;
            txtPrice1.Visible = true;
            txtPrice2.Visible = true;
            txtPrice3.Visible = true;
            ddSupplier1.Visible = true;
            ddsupplier2.Visible = true;
            ddSupplier3.Visible = true;

            enabled_btn(true);

        }

        protected void ddCategory_TextChanged(object sender, EventArgs e)
        {
            enabled_btn(false);
            ddDescription.Items.Clear();
            StationeryCRUDController RudRetrieve = new StationeryCRUDController();
            List<string> stationeryNames = RudRetrieve.ddCategoryChanged(ddCategory.Text);

            foreach (string name in stationeryNames)
            {
                ddDescription.Items.Add(name);
            }

            enabled_btn(false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            StationeryCRUDController update = new StationeryCRUDController();
            Stationery sta = new Stationery();

            sta.category = ddCategory.Text;
            sta.description = ddDescription.Text;
            sta.code = txtCode.Text;
            sta.reorderLevel = txtReorderLevel.Text;
            sta.reorderQuantity = txtReorderQty.Text;
            sta.unitOfMeasure = TxtUnitOfMeasure.Text;
            sta.price1 = Convert.ToDecimal(txtPrice1.Text);
            sta.price2 = Convert.ToDecimal(txtPrice2.Text);
            sta.price3 = Convert.ToDecimal(txtPrice3.Text);
            sta.supplier1 = ddSupplier1.Text;
            sta.supplier2 = ddsupplier2.Text;
            sta.supplier3 = ddSupplier3.Text;
            update.update(sta);
            btnClear_Click(sender, e);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Stationery Information Successfully Updated');", true);
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtReorderLevel.Text = "";
            txtReorderQty.Text = "";
            TxtUnitOfMeasure.Text = "";
            txtPrice1.Text = "";
            txtPrice2.Text = "";
            txtPrice3.Text = "";
            //ddSupplier1.ClearSelection();
            // ddsupplier2.ClearSelection();
            // ddSupplier3.ClearSelection();
            enabled_btn(false);
        }


        protected void enabled_btn(bool s)
        {
            ReqFieldValCode.Enabled = s;
            RequiredFieldValidator4.Enabled = s;
            ReorderRangeVal.Enabled = s;
            RequiredFieldValidator5.Enabled = s;
            ReorderQtyRangeVal.Enabled = s;
            RequiredFieldValidator6.Enabled = s;
            price1ReqFieldVal.Enabled = s;
            Price1RangeVal.Enabled = s;
            price2ReqFieldVal.Enabled = s;
            Price2RangeVal.Enabled = s;
            price3ReqFieldVal.Enabled = s;
            Price3RangeVal.Enabled = s;
            btnUpdate.Enabled = s;
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{

        //}
    }
}