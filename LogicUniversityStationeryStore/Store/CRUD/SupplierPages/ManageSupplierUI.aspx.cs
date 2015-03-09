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
    public partial class manageSupplierUI : System.Web.UI.Page
    {
        //logicEntities3 context = new logicEntities3();
       
        
        protected void Page_Load(object sender, EventArgs e)
        {

            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);
           
            if (!IsPostBack)
            {
                SupplierCRUDController pageload = new SupplierCRUDController();
                List<string> dd = pageload.ddPageLoad();
                foreach (string name in dd)
                {
                    ddSupCode.Items.Add(name);
                }
        
            }
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtSupName.Text)) || (string.IsNullOrEmpty(txtSupName.Text)) || (string.IsNullOrEmpty(txtGST.Text)) || (string.IsNullOrEmpty(txtPhone.Text)) || (string.IsNullOrEmpty(txtFaxNo.Text)) || (string.IsNullOrEmpty(txtAddress.Text)))
            {
                string myStringVariable = "Fields cannot be Empty";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else
            {
                SupplierCRUDController update = new SupplierCRUDController(ddSupCode.Text, txtSupName.Text, txtGST.Text, txtConName.Text, txtPhone.Text, txtFaxNo.Text, txtAddress.Text, txtEmail.Text);
                update.callUpdate();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            SupplierCRUDController clear1 = new SupplierCRUDController();
            string b = clear1.clear();

            txtSupName.Text = b;
            txtGST.Text = b;
            txtConName.Text = b;
            txtPhone.Text = b;
            txtFaxNo.Text = b;
            txtAddress.Text = b;
            txtEmail.Text = b;
        }


        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            SupplierCRUDController SupRet = new SupplierCRUDController(ddSupCode.Text);
            List<Supplier> retr = SupRet.retriveBtn();

            foreach (Supplier s in retr)
            {
                txtSupName.Text = s.supplierName;
                txtGST.Text = s.registrationNo;
                txtConName.Text = s.contactName;
                txtPhone.Text = s.telNo;
                txtFaxNo.Text = s.faxNo;
                txtAddress.Text = s.address;
                txtEmail.Text = s.email;
            }

            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            GSTRegExp.Enabled = true;
            RequiredFieldValidator9.Enabled = true;
            ConNameRegExp.Enabled = true;
            RequiredFieldValidator10.Enabled = true;
            phoneRegExp.Enabled = true;
            RequiredFieldValidator11.Enabled = true;
            FaxRegExp.Enabled = true;
            RequiredFieldValidator12.Enabled = true;
            EmailRegExp.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}