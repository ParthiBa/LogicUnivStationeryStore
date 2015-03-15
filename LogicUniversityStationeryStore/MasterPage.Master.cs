using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

    
        public void setOff()
        {
            lbLogOut.Visible = false;
            lbLogOut.Enabled = false;
      
            lblLoginName.Visible = false;
            Label1.Visible = false;
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null)
                {
                    lblLoginName.Text = Request.Cookies["UserName"].Value;
                    lbLogOut.Visible = true;
                    lbLogOut.Text = "LogOut";
                }
            }

        }

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            lblLoginName.Text = "Guest";
            if (Request.Cookies["UserName"] != null)
            {
                Response.Cookies["User"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["UserRole"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Clear();
            Response.Write("<script>window.location.href='/LogInUI.aspx'</script>");
        }
    }
}