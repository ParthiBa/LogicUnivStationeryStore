using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.Helper;

namespace LogicUniversityStationeryStore.Dep.Delegation
{
    public partial class delegateAuthorityUI : System.Web.UI.Page
    {
        DelegateAuthorityController sub = new DelegateAuthorityController();

        protected void Page_Load(object sender, EventArgs e)
        {

            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);
            string deptId = "";
            //   string deptId = Session["dept"].ToString();
            string employeeId = Request.Cookies["User"].Value.ToString();
            sub.setValues(deptId, employeeId);

            if (!IsPostBack)
            {


                List<string> ddValues = sub.ddPageLoad();
                foreach (string name in ddValues)
                {
                    ddAuthorizeTo.Items.Add(name);
                }

                //ddAuthorizeTo.DataSource = sub.ddPageLoad();
                //ddAuthorizeTo.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


                      

            string auth = ddAuthorizeTo.Text;

            bool result = sub.submitbutton(auth, txtFromDate.Text, txtToDate.Text);

            if (result)
            {
                
               
                NotificationHelper mail = new NotificationHelper();
                mail.sendEmail("mikelogichead@gmail.com", "MikeLogicHead123", "MickeyZoolEmp@gmail.com", NotificationHelper.SelectedtempHeadOfDepartment(), "Department Representative notification");
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                //ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Record saved sucessfully');", true);
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Authorized to other person during this period');", true);

        }

        protected void ddAuthorizeTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}