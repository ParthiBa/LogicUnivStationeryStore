using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore.Store.Report
{
    public partial class RequisitionAnalysisUI : System.Web.UI.Page
    {
        RequisitionReport rep3;

        protected void Page_Init(object sender, EventArgs e)
        {
            rep3 = (RequisitionReport)Session["RequisitionRep"];

            if (rep3 != null)
            {
                CrystalReportViewer1.ReportSource = rep3;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage1.Text = string.Empty;
           // btnReqAly.Enabled = false;
            string role = Request.Cookies["UserRole"].Value.ToString();

            if (!IsPostBack)
            {
                if (role.Equals("storeMan"))
                    Button1.PostBackUrl = Page.ResolveUrl("~/Home/StationeryManagerHome");
                else if (role.Equals("storeSup"))
                    Button1.PostBackUrl = Page.ResolveUrl("~/Home/StationerySupervisorHome");
            }
        }


        protected void lkAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in chxDept.Items)
            {
                li.Selected = true;
            }
        }

        protected void lkNone_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in chxDept.Items)
            {
                li.Selected = false;
            }
        }


        protected void btnReqAly_Click(object sender, EventArgs e)
        {
            List<string> deptList = new List<string>();
            List<string> date = new List<string>();
            string[] time = MonthYearControl1.getDate();
            List<RequisitionObj> totlist = new List<RequisitionObj>();

            if (chxDept.SelectedIndex != -1 && time.Length > 0)
            {
                
                foreach (ListItem li in chxDept.Items)
                {
                    if (li.Selected)
                    {
                        deptList.Add(li.Value);
                    }
                    else
                        continue;
                }

                date = time.ToList();
               
            }
            else
            {
                string mess = "Please choose at least one ITEM and DATE!";
                lblMessage1.Text = mess;
                
            }


          List<RequisitionObj> list = new List<RequisitionObj>();
            foreach (string de in deptList)
            {
                foreach (string da in date)
                {
                    if(da!=null)
                    {
                    string dept = de.ToString();
                    string MY = da.ToString();
                  
                    string[] datetime = MY.Split(' ');//split the month and year string ;
                  
                    string date1 = datetime[2] + "-" + datetime[0];
                    string date2 = datetime[2] + "-" + datetime[1];

                    DateTime d1 =Convert.ToDateTime(date1);
                    DateTime d2 = Convert.ToDateTime(date2);
                    
                    //list.Add(getItems(dept, d1, d2));
                    RequisitionTrendController req = new RequisitionTrendController();
                    totlist=req.getItems(dept, d1, d2);
                    list.AddRange(totlist);
                    }
                   
                }
            
            }

            ReportSet set = new ReportSet();

            rep3 = new RequisitionReport();
                rep3.SetDataSource(list);
                Session["RequisitionRep"] = rep3;
                CrystalReportViewer1.ReportSource = rep3;
           
        }


       


        }

      
   }
