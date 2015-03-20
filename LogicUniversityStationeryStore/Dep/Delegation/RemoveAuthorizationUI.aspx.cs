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
        DelegateAuthorityController rem = new DelegateAuthorityController();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string employeeId = Request.Cookies["User"].Value.ToString();
            rem.setValues("", employeeId);


            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);

            if (!IsPostBack)
            {

                List<string> ddValues = rem.ddRemovePageLoad();
                foreach (string name in ddValues)
                {
                    ddAuthorisedPerson.Items.Add(name);
                }

                if ((ddAuthorisedPerson.Text.Equals(""))&&(ddAuthorisedPerson.Items.Count==0))
                {
                    btnRemoveAuth.Enabled = false;
                    ddAuthorisedPerson.Enabled = false;
                    lblMessage2.Enabled = true;
                    lblMessage2.Visible = false;
                    lblMessage2.Text = "No temporaryHead in this Department";
                    Employee emp = rem.getTempHeadEmployee(ddAuthorisedPerson.Text);
                    if (emp != null)
                    {
                        if (emp.authorizeEnd != null)
                        {
                            txtStartDate.Text = emp.authorizeStart.ToString();
                            txtEndDate.Text = emp.authorizeEnd.ToString();

                        }
                    }
                    else
                    {
                        lblMessage2.Visible = true;
                    }

                }
            }

            if(ddAuthorisedPerson.Items.Count==1)
            {
                Employee emp = rem.getTempHeadEmployee(ddAuthorisedPerson.Items[0].Text);

                if (emp.authorizeEnd != null)
                {
                    txtStartDate.Text = emp.authorizeStart.Value.ToShortDateString();
                    txtEndDate.Text = emp.authorizeEnd.Value.ToShortDateString();
                }
            }
        }



        protected void ddAuthorisedPerson_TextChanged(object sender, EventArgs e)
        {
            
         
            Employee emp = rem.getTempHeadEmployee(ddAuthorisedPerson.Text);

            if(emp.authorizeEnd!=null)
            {
                txtStartDate.Text = emp.authorizeStart.Value.ToShortDateString();
            txtEndDate.Text = emp.authorizeEnd.Value.ToShortDateString();
            }
        }

        protected void btnRemoveAuth_Click(object sender, EventArgs e)
        {


            bool result = rem.RemoveAuthorizationButton(ddAuthorisedPerson.Text);
            if (result)
            {
                NotificationHelper mail = new NotificationHelper();
                mail.sendEmail("mikelogichead@gmail.com", "MikeLogicHead123", "MickeyZoolEmp@gmail.com", NotificationHelper.RemovedtempHeadOfDepartment(), "change in employee status");
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                //ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Recored saved sucessfully');", true);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Removed that person from authority'); window.location = '" + Page.ResolveUrl("~/Home/DeptHeadHome.aspx") + "';", true);

            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Error occured please try again');", true);
           
           
        }

        
    }
}