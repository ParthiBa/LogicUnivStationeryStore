using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.CustomControl
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {

        private string Max;
        private string Min;
        public string uniqueKey;
       
        public void setLimit (string minum, string maxium)
        {
            this.setRange.MaximumValue = maxium;
            this.setRange.MinimumValue = minum;
            Max=maxium;
            Min=minum;
            this.setRange.ErrorMessage = "Enter between " + minum + "and " + maxium;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            uniqueKey = Guid.NewGuid().ToString("N");
            Page.ClientScript.RegisterStartupScript(this.GetType(),uniqueKey,"setLimit"+uniqueKey+"("+Min+","+Max+");",true);
          
        }
    }
}