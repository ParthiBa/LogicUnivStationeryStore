using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Dep.Delegation
{
    public partial class delegateAuthorityUI : System.Web.UI.Page
    {
    

        protected void Page_Load(object sender, EventArgs e)
        {

            DelegateAuthorityController sub = new DelegateAuthorityController();
            List<string> ddValues = sub.ddPageLoad();
            //foreach (string name in ddValues)
            //{
            //    ddAuthorizeTo.Items.Add(name);
            //}

            ddAuthorizeTo.DataSource = sub.ddPageLoad();
            ddAuthorizeTo.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            DelegateAuthorityController sub = new DelegateAuthorityController(ddAuthorizeTo.Text, txtFromDate.Text, txtToDate.Text);
            //ClientScript.RegisterStartupScript(Page.GetType(), "update Responsibility", "alert('Record Updated Successfully');", true); // How to refresh after popup????
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }

        protected void ddAuthorizeTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}