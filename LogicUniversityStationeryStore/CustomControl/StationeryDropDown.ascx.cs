using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.CustomControl
{
    public partial class StationeryDropDown : System.Web.UI.UserControl
    {


         public String getValues()
        {
            return txtGetValue.Text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }




    }
}