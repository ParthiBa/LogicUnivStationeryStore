using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;

namespace LogicUniversityStationeryStore.Dep.Delegation
{
    public partial class RemoveAuthorizationUI : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);

            if (!IsPostBack)
            {
                DelegateAuthorityController rem = new DelegateAuthorityController();
                List<string> ddValues = rem.ddRemovePageLoad();
                foreach (string name in ddValues)
                {
                    ddAuthorisedPerson.Items.Add(name);
                }

                Employee emp = rem.getTempHeadEmployee(ddAuthorisedPerson.Text);

                txtStartDate.Text = emp.authorizeStart.ToString();
                txtEndDate.Text = emp.authorizeEnd.ToString();
            }
        }



        protected void ddAuthorisedPerson_TextChanged(object sender, EventArgs e)
        {
            
            DelegateAuthorityController rem = new DelegateAuthorityController();
            Employee emp = rem.getTempHeadEmployee(ddAuthorisedPerson.Text);

            txtStartDate.Text = emp.authorizeStart.ToString();
            txtEndDate.Text = emp.authorizeEnd.ToString();
        }

        protected void btnRemoveAuth_Click(object sender, EventArgs e)
        {
            DelegateAuthorityController remBtn = new DelegateAuthorityController();

            bool result= remBtn.RemoveAuthorizationButton (ddAuthorisedPerson.Text);
            if (result)
            {
                NotificationHelper mail = new NotificationHelper();
                mail.sendEmail("mikelogichead@gmail.com", "MikeLogicHead123", "MickeyZoolEmp@gmail.com", NotificationHelper.RemovedtempHeadOfDepartment(), "change in employee status");
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                //ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Recored saved sucessfully');", true);

            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Error occured please try again');", true);
           
           
        }

        
    }
}