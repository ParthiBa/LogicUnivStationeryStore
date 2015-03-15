using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Store.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.Controller
{
    public class ReorderTrendController
    {
        public List<ReorderObj> getItems(string cate, DateTime date1, DateTime date2)
        {
            var query = (from dl in EntityBroker.getMyEntities().DisbursementLists
                         join r in EntityBroker.getMyEntities().Requests on dl.id equals r.deliveryID
                         join rd in EntityBroker.getMyEntities().RequestDetails on r.deliveryID equals rd.requestID
                         join s in EntityBroker.getMyEntities().Stationeries on rd.stationeryCode equals s.code
                         where s.category == cate && dl.deliveryDate >= date1 && dl.deliveryDate <= date2
                         group new { dl, r, rd, s } by new { s.category, dl.deliveryDate.Month, rd.neededQuantity, dl.deliveryDate.Year } into g
                         select new ReorderObj { Category = g.Key.category, Month = g.Key.Month, Year = g.Key.Year, NeededQuantity = g.Where(y => y.s.category == g.Key.category).Sum(y => y.rd.neededQuantity) }).Distinct();
            var q = (from k in query
                     select new ReorderObj { Category = k.Category, Month = k.Month, Year = k.Year, NeededQuantity = query.Where(y => y.Category == k.Category).Sum(y => y.NeededQuantity) }).Distinct();
            return q.ToList();

        }

    }
}