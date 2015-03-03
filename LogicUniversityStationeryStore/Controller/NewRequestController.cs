using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Controller
{
    public class NewRequestController
    {

        string EmpId;
        DateTime dateToday;
        int requestID;
        Request r;
        public string getAvailabeQuantity(string id)
        {

            var getMax = (from x in EntityBroker.getMyEntities().Inventories
                          where x.stationeryCode == id
                          select x.availableQty ).Single();
            return getMax.ToString();
        }
        public string getAvailabeQuantitybyStationary(string stationay)
        {

            var getMax = (from inven in EntityBroker.getMyEntities().Inventories
                          join stat in  EntityBroker.getMyEntities().Stationeries on inven.stationeryCode equals stat.code
                          where stat.description==stationay
                          select inven.availableQty).Single();
            return getMax.ToString();
        }


        internal void createRequest(string empId)
        {
           r = new Request();
            r.Employee = EntityBroker.getMyEntities().Employees.Find(empId);
            r.dateOfApp = DateTime.Now;
            r.Department = r.Employee.Department;
            r.lastUpdate = DateTime.Now;
            r.status = "Pending";
            EntityBroker.getMyEntities().Requests.Add(r);
            EntityBroker.getMyEntities().SaveChanges();
            requestID = r.id;

        

       

        }

        internal void createRequestDetail()
        {
           
        }

        internal void createRequestDetail(DataTable dt)
        {
             foreach(DataRow dr in dt.Rows)
             {
                 RequestDetail rd = new RequestDetail();
                 rd.Request = r;
               rd.neededQuantity=Convert.ToInt32(  dr["Quantity"].ToString()) ;
               rd.Stationery = getStat(dr["StationaryId"].ToString());
               EntityBroker.getMyEntities().RequestDetails.Add(rd);
             }

             EntityBroker.getMyEntities().SaveChangesAsync();
        }

        private Stationery getStat (string id)
        {
            var q = from x in EntityBroker.getMyEntities().Stationeries
                    where x.code.Equals(id)
                    select x ;
            return q.FirstOrDefault < Stationery > ();
        }
    }
}