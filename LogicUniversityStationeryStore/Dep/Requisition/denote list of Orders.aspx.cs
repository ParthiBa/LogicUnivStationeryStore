using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore
{
    public partial class denote_list_of_Orders : System.Web.UI.Page
    {
        //string empId = Convert.ToString(Session["userName"]);

        string empId = "C00243";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //LOGICUNIVERSITYEntities ctx = new LOGICUNIVERSITYEntities();
            //var employee = from o in ctx.Employees
            //               where o.empNo == empId
            //               select o;
            //var requests = from o in ctx.Requests
            //               where o.deptCode == employee.FirstOrDefault().deptCode && o.status == "Pending"
            //               select new {o.dateOfApp, o.Employee.empName, o.id };
            ////foreach (Request r in requests) {
            ////    Response.Write(" "+r.deptCode);
            ////}
            //RequestGridView.DataSource = requests.ToList();
            //RequestGridView.DataBind();
            
        }

        protected void grdSearchResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Request Date";
                e.Row.Cells[1].Text = "Requested By";
                e.Row.Cells[2].Text = "Requisition Order Id";
            }
        }
         
    }
}