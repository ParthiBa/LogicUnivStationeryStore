using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;

namespace LogicUniversityStationeryStore.Controller
{
    public class DisbursementController
    {
      
    
        //for binding into Representative Name and Collection Point according to Department 
        public Department getDepartmentData(string deptCode)
        {
            EntityBroker broker = new EntityBroker();
             var q = from dp in broker.getEntities().Departments        
                    where dp.code.Equals(deptCode)
                    select dp;
            Department m = q.FirstOrDefault<Department>();
            broker.dispose();
            return m;
        }

        //for binding Delivery Date according to Department
        public DateTime getDeliveryDate(String deptName)
        {
            EntityBroker broker = new EntityBroker();
            var date = from d in broker.getEntities().DisbursementLists
                       join dp in broker.getEntities().Departments on d.deptCode equals dp.code
                       where dp.code == deptName
                       select d.deliveryDate;
            DateTime dt = date.First<DateTime>();
            broker.dispose();
            return dt;
        }
        //--Inserting and updating case in CreateDisburListUI.asp.cs--//
        public Request insertNewRequest(String empDeptCode, String empNo, int delId)
        {
            Request rq = new Request();
            rq.dateOfApp = DateTime.Today;
            rq.deptCode = empDeptCode;
            rq.empNo = empNo;
            rq.status = "Approved";
            rq.lastUpdate = DateTime.Today;
            rq.deliveryID = delId;
            return rq;
        }
      
        public RequestDetail insertNewRequestDetail(int RequestedId,String SCode,int RetrieveQ,int DisburseQ)
        {
            RequestDetail rd = new RequestDetail();
            rd.requestID = RequestedId;
            rd.stationeryCode = SCode;
            rd.neededQuantity = RetrieveQ - DisburseQ;           
            return rd;
        }


        //nofiy message
        public void NotifyToStoreClerk(List<String> StationeryDescription)
        {
            NotificationHelper n = new NotificationHelper();
            String message = NotificationHelper.CLerkLowItemsInStock(StationeryDescription);
            String subject = "Low Items in Stock";
            bool status = n.EmailtoClerk(message, subject);
        }
        //get collection point name
        public String getCollectionName(int collPt)
        {
            EntityBroker broker = new EntityBroker();
            var q = (from c in broker.getEntities().CollectionPoints
                     where c.id == collPt
                     select c.place).Single();
            broker.dispose();
            return q;

        }
        //for Retrieval Detail Page get original department code
        public String getOriginalDepartmentCode(int delid)
        {
            EntityBroker broker = new EntityBroker();
            var e = from dl in broker.getEntities().DisbursementLists
                    where dl.id == delid
                    select dl.deptCode;
            String deptCode = e.First<String>();
            broker.dispose();
            return deptCode;
        }
      }
}