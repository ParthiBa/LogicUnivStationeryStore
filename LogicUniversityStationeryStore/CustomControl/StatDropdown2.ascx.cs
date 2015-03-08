using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.CustomControl
{
    public partial class StatDropdown2 : System.Web.UI.UserControl
    {
        public string uniqueKey;
        private EventHandler txtChanged;
        public string getValues()
        {
            return txtGetValue.Text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            uniqueKey = Guid.NewGuid().ToString("N");
            Page.ClientScript.RegisterStartupScript(this.GetType(), uniqueKey, "setLimit" + uniqueKey + "(x);", true);
        }

        protected void txtGetValue_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}