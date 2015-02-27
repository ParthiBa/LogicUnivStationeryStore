using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.customControl
{
    public partial class MonthYearControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                for (int i = 1990; i <= DateTime.Now.Year; i++)
                {
                    year.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }


        protected void btnAddMY_Click(object sender, EventArgs e)
        {
            String date = month.Text + year.Text;
            ListBox1.Items.Add(new ListItem(date));
        }

        protected void btnRemoveMY_Click(object sender, EventArgs e)
        {
            int SelItemCount = ListBox1.Items.Count;
            for (int i = 0; i < SelItemCount; i++)
            {
                ListBox1.Items.Remove(ListBox1.SelectedItem);
            }
        }

   
    }
}