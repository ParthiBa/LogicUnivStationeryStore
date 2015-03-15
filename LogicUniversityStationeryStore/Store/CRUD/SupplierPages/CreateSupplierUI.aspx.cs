using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Store.CRUD.SupplierPages
{
    public partial class createSupplierUI : System.Web.UI.Page
    {
 

           
       // logicEntities3 context = new logicEntities3();

        protected void Page_Load(object sender, EventArgs e)
        {

            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            SupplierCRUDController create = new SupplierCRUDController(txtSupCode.Text, txtSupName.Text, txtGST.Text, txtConName.Text, txtPhone.Text, txtFaxNo.Text, txtAddress.Text, txtEmail.Text);
            create.callCreate();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('New Supplier Information Successfully added');", true);
            btnClear_Click(sender, e);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            SupplierCRUDController clear = new SupplierCRUDController();
            string b = clear.clear();
            txtSupCode.Text = b;
            txtSupName.Text = b;
            txtGST.Text = b;
            txtConName.Text = b;
            txtPhone.Text = b;
            txtFaxNo.Text = b;
            txtAddress.Text = b;
            txtEmail.Text = b;
        }
    }
}