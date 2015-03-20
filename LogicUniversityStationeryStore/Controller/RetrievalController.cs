using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;

namespace LogicUniversityStationeryStore.Controller
{
    public class RetrievalController
    {
        public String getStationeryDescription(String stationeryCode)
        {
            EntityBroker broker = new EntityBroker();
            var sc = from s in broker.getEntities().Stationeries
                     where s.code == stationeryCode
                     select s.description;
            String stationeryDesp = sc.First<String>();
            broker.dispose();
            return stationeryDesp;
        }

        //for Retrieval Detail page
        public String getDepartmentOfLoginPerson(String empNo)
        {

            EntityBroker broker = new EntityBroker();

            var e = from emp in broker.getEntities().Employees
                    where emp.empNo == empNo
                    select emp.deptCode;
            String empDeptCode = e.First<String>();
            broker.dispose();
            return empDeptCode;
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

        //--Inserting New Request and New Request Detail and Updating--//
        public Request insertNewRequest(String empDeptCode, String empNo, int delId)
        {
            Request rq = new Request();
            rq.dateOfApp = DateTime.Today.AddDays(7);
            rq.deptCode = empDeptCode;
            rq.empNo = empNo;
            rq.status = "Approved";
            rq.lastUpdate = DateTime.Today;
            rq.deliveryID = delId;
            return rq;
        }

        public RequestDetail insertNewRequestDetail(int RequestedId,String SCode,int NeededQty,int actualQty)
        {
            RequestDetail rd = new RequestDetail();
            rd.requestID = RequestedId;
            rd.stationeryCode = SCode;
            rd.neededQuantity = NeededQty - actualQty;
            return rd;
        }

        //notifyMessage
        public void NotifyToStoreClerk(String StationeryDescription)
        {
            NotificationHelper n = new NotificationHelper();
            String message = NotificationHelper.CLerkLowItemsInStock(StationeryDescription);
            String subject = "Low Items in Stock";
            bool Status = n.EmailtoClerk(message, subject);
        }

    }
 }