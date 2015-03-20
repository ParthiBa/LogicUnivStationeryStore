using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using LogicUniversityStationeryStore.DAO;
using System.Data.Entity;

namespace LogicUniversityStationeryStore.Controller
{
    public class NewRequestController
    {
        EntityBroker broker1;
        string EmpId;
        DateTime dateToday;
        int requestID;
        Request r;
        public string getAvailabeQuantity(string id)
        {
            EntityBroker broker = new EntityBroker();

            var getMax = (from x in broker.getEntities().Inventories
                          where x.stationeryCode == id
                          select x.availableQty ).Single();
            broker.dispose();
            return getMax.ToString();
        }
        public string getAvailabeQuantitybyStationary(string stationay)
        {
            EntityBroker broker = new EntityBroker();


            var getMax = (from inven in broker.getEntities().Inventories
                          join stat in  broker.getEntities().Stationeries on inven.stationeryCode equals stat.code
                          where stat.description==stationay
                          select inven.availableQty).Single();
            broker.dispose();
            return getMax.ToString();
        }


        internal void createRequest(string empId)
        {
            broker1 = new EntityBroker();

           r = new Request();
            Employee ourEmp = broker1.getEntities().Employees.Find(empId);
            r.empNo = ourEmp.empNo;
            r.dateOfApp = DateTime.Now;
            r.deptCode = ourEmp.deptCode;
            //r.Department = r.Employee.Department;
            r.lastUpdate = DateTime.Now;
            r.status = "Pending";
            broker1.getEntities().Requests.Add(r);
            broker1.getEntities().SaveChanges();
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
               rd.Stationery = getStat(dr["StationaryId"].ToString(),broker1);
               broker1.getEntities().RequestDetails.Add(rd);
             }


           //  broker1.getEntities().Requests.Attach(r);

             broker1.getEntities().SaveChanges();
             broker1.dispose();

        }

        private Stationery getStat (string id)
        {
            EntityBroker broker = new EntityBroker();

            var q = from x in broker.getEntities().Stationeries
                    where x.code.Equals(id)
                    select x ;
            var q1= q.FirstOrDefault < Stationery > ();
            broker.dispose();
            return q1;
        }

        private Stationery getStat(string id,EntityBroker broker)
        {
         
            var q = from x in broker.getEntities().Stationeries
                    where x.code.Equals(id)
                    select x;
            var q1 = q.FirstOrDefault<Stationery>();
       
            return q1;
        }
    }
}