﻿using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Store.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.ENTITY;

namespace LogicUniversityStationeryStore.Controller
{
    public class RequisitionTrendController
    {
        public List<RequisitionObj> getItems(string dept, DateTime d1, DateTime d2)
        {
            var query = (from dl in EntityBroker.getMyEntities().DisbursementLists
                         where dl.deptCode == dept && dl.deliveryDate >= d1 && dl.deliveryDate <= d2
                         join r in EntityBroker.getMyEntities().Requests on dl.id equals r.deliveryID
                         join rd in EntityBroker.getMyEntities().RequestDetails on r.deliveryID equals rd.requestID
                         join s in EntityBroker.getMyEntities().Stationeries on rd.stationeryCode equals s.code
                         join d in EntityBroker.getMyEntities().Departments on dl.deptCode equals d.code
                         group new { dl, r, d, rd, s } by new { d.name, s.category, rd.neededQuantity, dl.deliveryDate.Month, dl.deliveryDate.Year } into g
                         select new RequisitionObj { Name = g.Key.name, Category = g.Key.category, Month = g.Key.Month, Year = g.Key.Year, NeededQuantity = g.Where(y => y.d.name == g.Key.name).Sum(y => y.rd.neededQuantity) }).Distinct();
            var q = (from k in query
                     select new RequisitionObj { Name = k.Name, Category = k.Category, Month = k.Month, Year = k.Year, NeededQuantity = query.Where(y => y.Category == k.Category).Sum(y => y.NeededQuantity) }).Distinct();
            return q.ToList();
        }
                   
    }
}