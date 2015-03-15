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
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);
            DelegateAuthorityController DAC = new DelegateAuthorityController();
            txtCurrentRep.Text = DAC.ChangeRepPageload().empName;
            if (!IsPostBack)
            {
                DelegateAuthorityController pageload = new DelegateAuthorityController();
                List<string> dd = pageload.ddChangeRepPageLoad();
                foreach (string name in dd)
                {
                    ddAuthTo.Items.Add(name);
                }

            }
        }

        protected void btnChangeRep_Click(object sender, EventArgs e)
        {
            DelegateAuthorityController DAC = new DelegateAuthorityController();
            bool result = DAC.btnChangeRepOnClick(ddAuthTo.Text, txtCurrentRep.Text);

            if (result)
            {
                NotificationHelper mail = new NotificationHelper();
                mail.sendEmail("mikelogichead@gmail.com", "MikeLogicHead123", "MickeyZoolEmp@gmail.com", NotificationHelper.SelectedDepartmentRepresentative(), "department Representative");
                //ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Recored saved sucessfully');", true);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "Authorization", "alert('Error occured please try again');", true);

        }


    }
}