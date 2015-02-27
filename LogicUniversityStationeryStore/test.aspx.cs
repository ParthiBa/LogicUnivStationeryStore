using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;


namespace LogicUniversityStationeryStore
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            var q = from x in EntityBroker.getMyEntites().Departments
                    select x;

            lblT.Text = q.First<Department>().deptRep;
        //    NotificationHelper helper= new NotificationHelper();
           /// if(helper.sendEmail("x","y","z"))
            {
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Sent Mail" + "');", true);
            }
        
        }
    }
}