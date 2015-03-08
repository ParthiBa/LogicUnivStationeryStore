using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.DAO;
using System.Drawing;

namespace LogicUniversityStationeryStore
{
    public partial class About : Page
    {

    //    LogicUniversityEntities cte = new LogicUniversityEntities();
     
        protected void Page_Load(object sender, EventArgs e)
        {
         //   var query= from x in EntityBroker.getMyEntities().Suppliers 
         //              select x;
        //    lblValue.Text = query.First<Supplier>().supplierName;

            Button br = (Button)Master.FindControl("masterbutton");
            br.BackColor = Color.Blue;
        }
    }
}