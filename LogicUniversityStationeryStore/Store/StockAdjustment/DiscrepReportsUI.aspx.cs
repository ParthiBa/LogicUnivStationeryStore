using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Dep
{
    public partial class DiscrepReportsUI : System.Web.UI.Page
    {

        string clientid="SC0001";
       


        protected void Page_Load(object sender, EventArgs e)
        {
 var q = (from x in EntityBroker.getMyEntities().StockAdjustments
                                       where x.Employee1.empNo == clientid
                                       select new { x.id, x.status }).ToList();

 //var q = (from x in EntityBroker.getMyEntites().StockAdjustments
 //         where x.Employee.empNo == clientid
 //         select new { x.id, x.status }).ToList<StockAdjustment>();

 List<StockAdjustment> list =  EntityBroker.getMyEntities().StockAdjustments.Where(x => x.Employee1.empNo == clientid).ToList<StockAdjustment>();

           Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+list);
           grdListOfOrderCLrk.DataSource = q;
           grdListOfOrderCLrk.DataBind();



             }
    }
}