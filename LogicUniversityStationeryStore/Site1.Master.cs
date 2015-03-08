using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        public Button btn
        {
            get { return masterbutton;}
            set { masterbutton = value;  }
        
        
        }


        public string sayHello()
        {


            return "whatis";
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}