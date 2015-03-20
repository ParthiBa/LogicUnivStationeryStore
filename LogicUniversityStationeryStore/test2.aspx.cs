using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Store.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversityStationeryStore
{
    public partial class test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string d1="2015-03-01";
            //string d2 = "2015-03-31";
            //DateTime date1 = Convert.ToDateTime(d1);           
            //DateTime date2 = Convert.ToDateTime(d2);

            //string cate = "Exercise";
            //var query = (from p in EntityBroker.getMyEntities().PurchaseOrders
            //             join po in EntityBroker.getMyEntities().PurchaseOrderDetails on p.id equals po.orderID
            //             join s in EntityBroker.getMyEntities().Stationeries on po.stationeryCode equals s.code
            //             where s.category == cate && p.dateOfDelivery >= date1 && p.dateOfDelivery <= date2
            //             group new { p, po, s } by new { s.category, p.dateOfDelivery, po.receivedQuantity } into g
            //             select new ReorderObj { Category = g.Key.category, DateOfDelivery = g.Key.dateOfDelivery.Value, ReceivedQuantity = g.Key.receivedQuantity.Value }).Distinct(); 
            //GridView1.DataSource = query.ToList();
            //GridView1.DataBind();
        }
    }
}