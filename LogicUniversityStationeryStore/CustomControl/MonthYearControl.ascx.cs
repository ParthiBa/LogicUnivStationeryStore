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
            string dateText = month.SelectedItem.Text +" "+ year.Text;
            string dateValue=month.SelectedItem.Value+" "+year.Text;
            ListItem add = new ListItem(dateText, dateValue);
            if (!listDate.Items.Contains(add))
            {
                listDate.Items.Add(add);
            }
        }

        protected void btnRemoveMY_Click(object sender, EventArgs e)
        {
            int SelItemCount = listDate.Items.Count;
            for (int i = 0; i < SelItemCount; i++)
            {
               listDate.Items.Remove(listDate.SelectedItem);
            }
        }

        public string[] getDate()
        {

            string[] date =new string[listDate.Items.Count];
                for (int i = 0; i <listDate.Items.Count; i++)
                {
                    string add = listDate.Items[i].Value;
                    if(add!="")
                    date[i] =add;
                }
            return date;
        }
      
    }
}