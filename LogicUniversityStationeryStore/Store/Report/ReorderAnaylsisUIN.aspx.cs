using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.Report
{
    public partial class ReorderAnaylsisUIN : System.Web.UI.Page
    {
        ReorderRep rep2;
        protected void Page_Init(object sender, EventArgs e)
        {

            rep2 = (ReorderRep)Session["myreorder"];
            CrystalReporttest1.ReportSource = rep2;


        }



        protected void Page_Load(object sender, EventArgs e)
        {

            lbMessage.Text = string.Empty;
        }


        protected void lkAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in ChxCate.Items)
            {
                li.Selected = true;
            }
        }

        protected void lkNone_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in ChxCate.Items)
            {
                li.Selected = false;
            }
        }

        protected void btnRodAly_Click(object sender, EventArgs e)
        {
            string[] time = MonthYearControl1.getDate();
            List<string> catgList = new List<string>();
            List<string> date = new List<string>();
            List<ReorderObj> totorder = new List<ReorderObj>();

            ListItem item = new ListItem();
            if (item != null)
            {
                item.Selected = true;
            }

            if (ChxCate.SelectedIndex != -1 && time.Length > 0)
            {
                foreach (ListItem li in ChxCate.Items)
                {
                    if (li.Selected)
                    {
                        catgList.Add(li.Value);
                    }
                    else
                        continue;
                }

                date = time.ToList();
            }
            else
            {
                string mess = "Please choose at least one ITEM and DATE!";
                lbMessage.Text = mess;
            }


            List<ReorderObj> list = new List<ReorderObj>();
            foreach (string de in catgList)
            {
                foreach (string da in date)
                {
                    if (da != null)
                    {
                        string cate = de.ToString();
                        string MY = da.ToString();

                        string[] datetime = MY.Split(' ');//split the month and year string ;

                        string date1 = datetime[2] + "-" + datetime[0];
                        string date2 = datetime[2] + "-" + datetime[1];

                        DateTime d1 = Convert.ToDateTime(date1);
                        DateTime d2 = Convert.ToDateTime(date2);

                        ReorderTrendController red = new ReorderTrendController();
                        totorder = red.getItems(cate, d1, d2);
                        list.AddRange(totorder);
                    }

                }

            }

            ReportSet set = new ReportSet();

            ReorderRep rep2 = new ReorderRep();
            Session["myreorder"] = rep2;

            rep2.SetDataSource(list);
            CrystalReporttest1.ReportSource = rep2;

        }
    }
}