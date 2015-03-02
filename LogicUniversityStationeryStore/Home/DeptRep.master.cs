using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.Home
{
    public partial class DeptRep1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeptRepMenu.Visible = false;

        }

        protected void DeptRepMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}