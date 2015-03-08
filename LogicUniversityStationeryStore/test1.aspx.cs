using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spinner1.setLimit("1", "10");
          ClientScript.RegisterStartupScript(this.GetType(), "scro", "setupDropDown();", true);
          StationeryDropDown11.txtChanged += new EventHandler(gotValueFromdropDown);
        }


        void gotValueFromdropDown(object sebder,EventArgs e)
        {
            Label1.Text = StationeryDropDown11.getValues();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "hello", "alertaa()");
        }
    }
}