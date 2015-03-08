
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore
{
    public partial class LogInUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            boxEmail.Text = string.Empty;
            boxPass.Text = string.Empty;

            if (Request.Cookies["UserName"] != null)
            {
                Response.Cookies["User"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["UserRole"].Expires = DateTime.Now.AddDays(-1);
                Session.Clear();
            }
           }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = Base64Encode(boxEmail.Text);
            string password = Base64Encode(boxPass.Text);
            LoginController login = new LoginController();
            bool check=login.login(email,password,Response);
            if (check == false)
            { 
            Page.ClientScript.RegisterStartupScript(this.GetType(),"script","alert('Incorrect Email or Password');",true);
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
     
    }
}