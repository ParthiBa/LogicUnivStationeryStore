using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Dep
{
    public partial class CreateDiscrepUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string AdjustmentID = Request.Params["id"];
            int AdjustmentId = Convert.ToInt32(AdjustmentID);
            var q = from x in EntityBroker.getMyEntites().StockAdjustmentDetails
            
        }
    }
}