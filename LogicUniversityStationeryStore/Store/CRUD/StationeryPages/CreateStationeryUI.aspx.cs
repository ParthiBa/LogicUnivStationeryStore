using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.CRUD.StationeryPages
{
    public partial class createStationeryUI : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);
           
            if (!IsPostBack)
            {

                StationeryCRUDController pageload = new StationeryCRUDController();
                List<string> dd = pageload.ddPageLoad();
                foreach (string name in dd)
                {
                    DDSupplier1.Items.Add(name);
                    DDSupplier2.Items.Add(name);
                    DDSupplier3.Items.Add(name);

                }

            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            StationeryCRUDController cre = new StationeryCRUDController(txtCode.Text, txtCategory.Text, txtDescription.Text, txtReorderLevel.Text, txtReorderQty.Text,
                                                                         txtUnitOfMeasure.Text, txtPrice1.Text, txtPrice2.Text, txtPrice3.Text, DDSupplier1.Text,
                                                                         DDSupplier2.Text, DDSupplier3.Text);
            cre.callCreate();


            Button2_Click(sender, e);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('New stationery Information Successfully added');", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StationeryCRUDController clear1 = new StationeryCRUDController();
            string b = clear1.clear();

            txtCode.Text = b;
            txtCategory.Text = b;
            txtDescription.Text = b;
            txtReorderLevel.Text = b;
            txtReorderQty.Text = b;
            txtUnitOfMeasure.Text = b;
            txtPrice1.Text = b;
            txtPrice2.Text = b;
            txtPrice3.Text = b;
            //DDSupplier1.Text = b;
            //DDSupplier2.Text = b;
            //DDSupplier3.Text = b;
        }
    }
}