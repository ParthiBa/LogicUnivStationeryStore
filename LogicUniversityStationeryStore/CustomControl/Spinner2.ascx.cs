using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.CustomControl
{
    public partial class Spinner2 : System.Web.UI.UserControl
    {
        private string Max;
        private string Min;
        public string uniqueKey;
        public string tempUniqueKey;
        public event EventHandler txtSpinChanged;
        

        public void setLimit(string minum, string maxium)
        {
            this.RangeValidatortxt.MaximumValue = maxium;
            this.RangeValidatortxt.MinimumValue = minum;
            Max = maxium;
            Min = minum;
            this.RangeValidatortxt.ErrorMessage = "Enter between " + minum + "and " + maxium;
            //   Page.ClientScript.RegisterClientScriptBlock(this.GetType(), uniqueKey, "setLimit" + uniqueKey + "(" + minum + "," + maxium + ");", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), uniqueKey, "setLimit" + uniqueKey + "(" + minum + "," + maxium + ");", true);

        }
        public void setLimitQuantity(string minum, string maxium,string quantity)
        {

            this.RangeValidatortxt.MaximumValue = maxium;
            this.RangeValidatortxt.MinimumValue = minum;
            this.RangeValidatortxt.ErrorMessage = "Enter between " + minum + "and " + maxium;
     
            Max = maxium;
            Min = minum;
         //   if(!Page.ClientScript.IsStartupScriptRegistered(uniqueKey))
           Page.ClientScript.RegisterStartupScript(this.GetType(), uniqueKey, "setRangeLimit" + uniqueKey + "(" + minum + "," + maxium + ");", true);

        }


        public string getValues()
        {
            return txtNumberOfItems.Text;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                uniqueKey = tempUniqueKey;
                Console.WriteLine(">>>>>> " + uniqueKey);
                // Page.ClientScript.RegisterStartupScript(this.GetType(), uniqueKey, "setLimit" + uniqueKey + "(" + Min + "," + Max + ");", true);
            }
            else
            {
                uniqueKey = Guid.NewGuid().ToString("N");
                tempUniqueKey = uniqueKey;
                // Page.ClientScript.RegisterStartupScript(this.GetType(), uniqueKey, "setLimit" + uniqueKey + "(" + Min + "," + Max + ");", true);
            }
           
        }

        protected void txtNumberOfItems_TextChanged(object sender, EventArgs e)
        {
            txtSpinChanged(sender, e);
        }

        internal decimal getValueInt()
        {
            return Convert.ToDecimal(txtNumberOfItems.Text);
        }
    }
}