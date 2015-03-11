using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;

namespace LogicUniversityStationeryStore.Controller
{
    public class ApproveRequestController
    {

        NotificationHelper NotifyHelper = new NotificationHelper();   

        int RequesTID;
        Request CurrentRequest;
        public bool checkhead(string id)
        {
           Employee e = ((from x in EntityBroker.getMyEntities().Employees
                                where x.empNo.Equals(id)
                                select x).First());
           if (e.empRole.Equals("deptHead") || (e.empRole.Equals("depTempHead")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public dynamic ListofRequests(String Headid)
        {
            var dept =( (from x in EntityBroker.getMyEntities().Employees
                       where x.empNo.Equals(Headid)
                       select x.deptCode).First()).ToString();
         


            var q = (from x in EntityBroker.getMyEntities().Requests
                     where x.status.Equals("Pending") && x.deptCode.Equals(dept)
                     select new { x.id, dateOfApp = x.dateOfApp, x.Employee.empName, }).ToList(); ;
            return q;

        } 

            public dynamic   findEmpName(int RequestId)
{
    Request r = (from x in EntityBroker.getMyEntities().Requests
                 where x.id == RequestId
                 select x ).First<Request>();

    CurrentRequest = r;
    return r.Employee.empName ;

}

        public dynamic getValueForGrid(int requestId)
            {
                var getVal = (from x in EntityBroker.getMyEntities().RequestDetails
                             where x.requestID == requestId
                             select new {x.stationeryCode, x.Stationery.description, x.neededQuantity,x.Stationery.unitOfMeasure , x.Stationery.Inventory.availableQty }).ToList();

                return getVal;
            }


        public void approveCurrentRequest()
        {

            CurrentRequest.status = "Approved";
            CurrentRequest.lastUpdate = DateTime.Now;
            bool isNostock=false;

            foreach(RequestDetail rd  in CurrentRequest.RequestDetails)
            {
                string stcode = rd.Stationery.code;
               //find invetntoy and set the inventory
 

               if(findAvailableQuantity(stcode)==0)
               {
                   isNostock = true;
                   break;
               }

               Inventory invent = findIventoryObj(stcode);
               invent.availableQty = invent.availableQty - rd.neededQuantity;

            }
            //if (isNostock)
            //{
            //    CurrentRequest.status = "Cancelled";
            //}
            EntityBroker.getMyEntities().SaveChanges();

            //set to email address
            NotifyHelper.sendEmailbyClerk("MickeyZoolEmp@gmail.com", NotificationHelper.RequestApproved(CurrentRequest.id), "Your request is approved");

        }



        public void CreateAdvanceRequest(List<KeyValuePair<string,int>> lessQuantity)
        {
            Request AdvanceRequest = new Request();
            AdvanceRequest.dateOfApp = CurrentRequest.dateOfApp.Value.AddDays(7);
            AdvanceRequest.status = "Approved";
            AdvanceRequest.deptCode = CurrentRequest.deptCode;
            AdvanceRequest.empNo = CurrentRequest.empNo;
            AdvanceRequest.lastUpdate = DateTime.Now;
            EntityBroker.getMyEntities().Requests.Add(AdvanceRequest);
            EntityBroker.getMyEntities().SaveChanges();

            List<string> stationaryCodes = new List<string>();
            foreach(KeyValuePair<string,int> lessq in lessQuantity)
            {
                // lessq.value denotes the old needed quantity for that item
                RequestDetail rd = new RequestDetail();
                rd.requestID = AdvanceRequest.id;
                rd.Stationery=findStationerybyKey( lessq.Key);

                int availableQuantityItem= findAvailableQuantity(lessq.Key);
                rd.neededQuantity = lessq.Value - availableQuantityItem;
                updateCurrentRequest(lessq.Key, availableQuantityItem);


                stationaryCodes.Add(lessq.Key);
                AdvanceRequest.RequestDetails.Add(rd);
            }

            approveCurrentRequest();
            NotifyAdvanceRequest(stationaryCodes);

        }


        public Inventory findIventoryObj(string stationerycode)
        {
            var q = from x in EntityBroker.getMyEntities().Inventories
                    where x.stationeryCode.Equals(stationerycode)
                    select x;

            return q.FirstOrDefault<Inventory>();

        }



        private void NotifyAdvanceRequest(List<string> stationeryCode)
        {
            List<string> stationaryName = new List<string>();
            string MessagetoClerk="Advance requestMade please buy the following  items \n";
            foreach(string code in stationeryCode)
            {
                var q = (from x in EntityBroker.getMyEntities().Stationeries
                        where x.code.Equals(stationeryCode)
                        select x.description).FirstOrDefault();
                string itemName=q.ToString();
                MessagetoClerk= MessagetoClerk + itemName + "\n";

                stationaryName.Add(itemName);
            }

            NotifyHelper.EmailtoClerk("Please buy these items , Stock is low", MessagetoClerk);
            NotifyHelper.sendEmailbyClerk("MickeyZoolEmp@gmail.com ", NotificationHelper.InfromAdvanceRequest(stationaryName), "Advance request by the system");

        }
       


        // this method to update the current needed quantity during create Advance Request
        private void updateCurrentRequest(string Stationeryid,int AvailableQuantity)
        {
            RequestDetail rd = (from x in EntityBroker.getMyEntities().RequestDetails
                                where x.Request.id == CurrentRequest.id && x.stationeryCode.Equals(Stationeryid)
                               select x).FirstOrDefault<RequestDetail>();
            rd.neededQuantity = AvailableQuantity;

        }

        private int  findAvailableQuantity(string id )
        {
            var q = from x in EntityBroker.getMyEntities().Inventories
                    where x.stationeryCode.Equals(id)
                    select x;

            int ax =(int) q.FirstOrDefault<Inventory>().availableQty;
            return ax;
        }


        public void rejectCurrentRequest(String reason)
        {

            CurrentRequest.rejectedReason = reason;
            CurrentRequest.status = "Rejected";



            // call notoification controller
            //EntityBroker.getMyEntities().Requests.Add(CurrentRequest);
            EntityBroker.getMyEntities().SaveChanges();

            NotifyHelper.sendEmailbyClerk("MickeyZoolEmp@gmail.com", NotificationHelper.RequestRjected(CurrentRequest.id, reason), "your request has been rejected");

        }

        private Stationery findStationerybyKey(string id)
        {

            var q = from x in EntityBroker.getMyEntities().Stationeries
                    where x.code.Equals(id)
                    select x;

            return q.FirstOrDefault<Stationery>();

        }


    }




}