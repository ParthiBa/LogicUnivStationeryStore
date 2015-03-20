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
            EntityBroker broker = new EntityBroker();

           Employee e = ((from x in broker.getEntities().Employees
                                where x.empNo.Equals(id)
                                select x).First());
           if (e.empRole.Equals("deptHead") || (e.empRole.Equals("depTempHead")))
            {
                broker.dispose();

                return true;
            }
            else
            {
                broker.dispose();

                return false;
            }


        }
        public dynamic ListofRequests(String Headid)
        {

            EntityBroker broker = new EntityBroker();

            var dept =( (from x in broker.getEntities().Employees
                       where x.empNo.Equals(Headid)
                       select x.deptCode).First()).ToString();
         


            var q = (from x in broker.getEntities().Requests
                     where x.status.Equals("Pending") && x.deptCode.Equals(dept)
                     select new { x.id, dateOfApp = x.dateOfApp, x.Employee.empName, }).ToList(); ;

            broker.dispose();
            return q;

        } 

            public dynamic   findEmpName(int RequestId)
{


    EntityBroker broker = new EntityBroker();

    Request r = (from x in broker.getEntities().Requests
                 where x.id == RequestId
                 select x ).First<Request>();
    Request ra = broker.getEntities().Requests
        .Where(x => x.id == RequestId)
        .Include(x => x.RequestDetails)
        .Include(x => x.Department)
        .Include(x => x.Employee)
        .FirstOrDefault();
    CurrentRequest = ra;
    string empName = r.Employee.empName;
   // broker.getEntities().Entry(CurrentRequest).State = EntityState.Detached;
    broker.dispose();
    return  empName;

}

        public dynamic getValueForGrid(int requestId)
            {

                EntityBroker broker = new EntityBroker();

                var getVal = (from x in broker.getEntities().RequestDetails
                             where x.requestID == requestId
                             select new {x.stationeryCode, x.Stationery.description, x.neededQuantity,x.Stationery.unitOfMeasure , x.Stationery.Inventory.availableQty }).ToList();

                broker.dispose();
                return getVal;

            }


        public void approveCurrentRequest()
        {
            EntityBroker broker = new EntityBroker();
       
         


            CurrentRequest.status = "Approved";
            CurrentRequest.lastUpdate = DateTime.Now;
            bool isNostock=false;

            foreach(RequestDetail rd  in CurrentRequest.RequestDetails)
            {
                string stcode = rd.stationeryCode;
               //find invetntoy and set the inventory
 

               if(findAvailableQuantity(stcode,broker)==0)
               {
                   isNostock = true;
                   break;
               }

               Inventory invent = findIventoryObj(stcode,broker);
               invent.availableQty = invent.availableQty - rd.neededQuantity;

            }
            //if (isNostock)
            //{
            //    CurrentRequest.status = "Cancelled";
            //}



            broker.getEntities().Entry(CurrentRequest).State = EntityState.Modified;
         
          //  broker.getEntities().Requests.Add(CurrentRequest);
            broker.getEntities().SaveChanges();


            broker.dispose();
            //set to email address
            NotifyHelper.sendEmailbyClerk("MickeyZoolEmp@gmail.com", NotificationHelper.RequestApproved(CurrentRequest.id), "Your request is approved");

        }



        public void CreateAdvanceRequest(List<KeyValuePair<string,int>> lessQuantity)
        {
            EntityBroker broker = new EntityBroker();

            Request AdvanceRequest = new Request();
            AdvanceRequest.dateOfApp = CurrentRequest.dateOfApp.Value.AddDays(7);
            AdvanceRequest.status = "Approved";
            AdvanceRequest.deptCode = CurrentRequest.deptCode;
            AdvanceRequest.empNo = CurrentRequest.empNo;
            AdvanceRequest.lastUpdate = DateTime.Now;
            broker.getEntities().Requests.Add(AdvanceRequest);
            broker.getEntities().SaveChanges();

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

            broker.dispose();
            approveCurrentRequest();
            
            NotifyAdvanceRequest(stationaryCodes);

        }


        public Inventory findIventoryObj(string stationerycode)
        {
            EntityBroker broker = new EntityBroker();

            var q = from x in broker.getEntities().Inventories
                    where x.stationeryCode.Equals(stationerycode)
                    select x;

            var q1= q.FirstOrDefault<Inventory>();
            broker.dispose();
            return q1;

        }
        public Inventory findIventoryObj(string stationerycode,EntityBroker broker)
        {


            var q = from x in broker.getEntities().Inventories
                    where x.stationeryCode.Equals(stationerycode)
                    select x;

            var q1 = q.FirstOrDefault<Inventory>();
       
            return q1;

        }



        private void NotifyAdvanceRequest(List<string> stationeryCode)
        {
            EntityBroker broker = new EntityBroker();
            List<string> stationaryName = new List<string>();
            string MessagetoClerk="Advance requestMade please buy the following  items \n";
            foreach(string code in stationeryCode)
            {
                var q = (from x in broker.getEntities().Stationeries
                        where x.code.Equals(stationeryCode)
                        select x.description).FirstOrDefault();
                string itemName=q.ToString();
                MessagetoClerk= MessagetoClerk + itemName + "\n";

                stationaryName.Add(itemName);
            }

            broker.dispose();
            NotifyHelper.EmailtoClerk("Please buy these items , Stock is low", MessagetoClerk);
            NotifyHelper.sendEmailbyClerk("MickeyZoolEmp@gmail.com ", NotificationHelper.InfromAdvanceRequest(stationaryName), "Advance request by the system");

        }
       


        // this method to update the current needed quantity during create Advance Request
        private void updateCurrentRequest(string Stationeryid,int AvailableQuantity)
        {
            EntityBroker broker = new EntityBroker();

            RequestDetail rd = (from x in broker.getEntities().RequestDetails
                                where x.Request.id == CurrentRequest.id && x.stationeryCode.Equals(Stationeryid)
                               select x).FirstOrDefault<RequestDetail>();
            rd.neededQuantity = AvailableQuantity;
            broker.dispose();
        }

        private int  findAvailableQuantity(string id )
        {
            EntityBroker broker = new EntityBroker();


            var q = from x in broker.getEntities().Inventories
                    where x.stationeryCode.Equals(id)
                    select x;

            int ax =(int) q.FirstOrDefault<Inventory>().availableQty;
            broker.dispose();
            return ax;
        }

        private int findAvailableQuantity(string id,EntityBroker broker)
        {
            

            var q = from x in broker.getEntities().Inventories
                    where x.stationeryCode.Equals(id)
                    select x;

            int ax = (int)q.FirstOrDefault<Inventory>().availableQty;
            
            return ax;
        }


        public void rejectCurrentRequest(String reason)
        {
            EntityBroker broker = new EntityBroker();

            CurrentRequest.lastUpdate = DateTime.Now;
            CurrentRequest.rejectedReason = reason;
            CurrentRequest.status = "Rejected";

            broker.getEntities().Entry(CurrentRequest).State = EntityState.Modified;


            // call notoification controller
            //EntityBroker.getMyEntities().Requests.Add(CurrentRequest);
            broker.getEntities().SaveChanges();


            broker.dispose();
            NotifyHelper.sendEmailbyClerk("MickeyZoolEmp@gmail.com", NotificationHelper.RequestRjected(CurrentRequest.id, reason), "your request has been rejected");

        }

        private Stationery findStationerybyKey(string id)
        {
            EntityBroker broker = new EntityBroker();


            var q = from x in broker.getEntities().Stationeries
                    where x.code.Equals(id)
                    select x;

            var q1 = q.FirstOrDefault<Stationery>();
                broker.dispose();
                return q1;
        }


    }




}