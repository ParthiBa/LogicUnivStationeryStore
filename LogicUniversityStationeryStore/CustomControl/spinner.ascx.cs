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
        public string uniqueKey,tempUniqueKey;
        public event EventHandler txtSpinChanged;
       
        public void setValue(string text)
        {
            txtNumber.Text = text;
        }


        public String txtQty
        {

            get
            {

                if (txtNumber.Text == "")
                {
                    txtNumber.Text = "1";
                }

                return txtNumber.Text;
            }
            set
            {
                txtNumber.Text = value;
            }
        }


        public string getValue()
        {
            if(txtNumber.Text=="")
            {
                txtNumber.Text = "1";
            }

            return txtNumber.Text;
        }
        public int getValueInt()
        {
            return Convert.ToInt32(txtNumber.Text);
        }
        public void setLimit (string minum, string maxium)
        {
            this.setRange.MaximumValue = maxium;
            this.setRange.MinimumValue = minum;
            Max=maxium;
            Min=minum;
            this.setRange.ErrorMessage = "Enter between " + minum + "and " + maxium;
         //   Page.ClientScript.RegisterClientScriptBlock(this.GetType(), uniqueKey, "setLimit" + uniqueKey + "(" + minum + "," + maxium + ");", true);
          Page.ClientScript.RegisterStartupScript(this.GetType(), uniqueKey, "setLimit" + uniqueKey + "(" + minum + "," + maxium + ");", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           // uniqueKey = Guid.NewGuid().ToString("N");

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

        protected void txtNumber_TextChanged(object sender, EventArgs e)
        {
         //   txtSpinChanged(sender, e);
        }
    }
}