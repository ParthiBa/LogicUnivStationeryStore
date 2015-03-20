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
    public partial class ChangeRep : System.Web.UI.Page
    {
        DelegateAuthorityController DAC = new DelegateAuthorityController();
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);
            string employeeId = Request.Cookies["User"].Value.ToString();
            DAC.setValues("", employeeId);
            txtCurrentRep.Text = DAC.ChangeRepPageload().empName;
            if (!IsPostBack)
            {

                List<string> dd = DAC.ddChangeRepPageLoad();
                foreach (string name in dd)
                {
                    ddAuthTo.Items.Add(name);
                }

            }
        }

        protected void btnChangeRep_Click(object sender, EventArgs e)
        {
         
            bool result = DAC.btnChangeRepOnClick(ddAuthTo.Text, txtCurrentRep.Text);

            if (result)
            {
                NotificationHelper mail = new NotificationHelper();
              mail.sendEmail("mikelogichead@gmail.com", "MikeLogicHead123", "MickeyZoolEmp@gmail.com", NotificationHelper.SelectedDepartmentRepresentative(), "department Representative");
              ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Rep role has been changed'); window.location = '" + Page.ResolveUrl("~/Home/DeptHeadHome.aspx") + "';", true);

              string USerName = Request.Cookies["UserName"].Value.ToString();
                if(txtCurrentRep.Text.Equals(USerName))
                {
                    Response.Cookies["UserRole"].Value = "deptEmp";
                }



                //ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Recored saved sucessfully');", true);
             //   Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Error occured please try again');", true);

        }


    }
}