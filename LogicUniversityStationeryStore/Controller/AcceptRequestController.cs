using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;
using LogicUniversityStationeryStore.Store.Disbursement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using LogicUniversityStationeryStore.ENTITY;

namespace LogicUniversityStationeryStore.Controller
{
    public class AcceptRequestController
    {
        List<ApprovedRequest> list = new List<ApprovedRequest>();
        List<Request> lireq = new List<Request>();
        List<ReqByDept> lrbd = new List<ReqByDept>();
        DisbursementList createDisb = new DisbursementList();
        NotificationHelper note = new NotificationHelper();
    
        //for binding into Representative Name and Collection Point according to Department 
        public Department getDepartmentData(string deptName)
        {

            EntityBroker broker = new EntityBroker();
            var q = from dp in broker.getEntities().Departments
                    where dp.name == deptName
                    select dp;
            Department m = q.First<Department>();
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

        public string getDeptBySession(string dept)
        {
            EntityBroker broker = new EntityBroker();


            var deptName = from x in broker.getEntities().Departments
                           where x.code == dept
                           select x;
            Department deptname = deptName.FirstOrDefault();
            broker.dispose();
            if (deptname != null)
            {
                string deptm = deptname.name;
                return deptm;
            }
                string message = "Error!";
                return message;
            
        }

        public string getCollPBySession(string dept)
        {
            EntityBroker broker = new EntityBroker();

            var collPoint = from x in broker.getEntities().Departments
                            join c in broker.getEntities().CollectionPoints on x.collectionPt  equals c.id
                            where x.code == dept
                            select c;
            CollectionPoint deptCp = collPoint.FirstOrDefault();
            broker.dispose();

            if (deptCp != null)
            {
                string deptc = deptCp.place;
                return deptc;
            }
                string message = "Collection Point Error!";
                return message;
        
        }

        public List<ApprovedRequest> getApprovedReq(string dept)
        {
            EntityBroker broker = new EntityBroker();

            var data = (from x in broker.getEntities().Requests
                        where x.deptCode == dept && x.status == "Approved" && x.dateOfApp <= DateTime.Today.Date
                        join rd in broker.getEntities().RequestDetails on x.id equals rd.requestID
                        join d in broker.getEntities().Departments on x.deptCode equals d.code
                        join s in broker.getEntities().Stationeries on rd.stationeryCode equals s.code
                        group new { x, d, rd, s } by new { rd.stationeryCode, d.name, x.dateOfApp, s.description, rd.neededQuantity } into g
                        select new ApprovedRequest() { Name = g.Key.name, StationeryCode = g.Key.stationeryCode, Description = g.Key.description, DateOfApp = g.Key.dateOfApp.Value, NeededQuantity = g.Sum(y => y.rd.neededQuantity) }).Distinct();
            var result = (from row in data
                          select new ApprovedRequest() { Name = row.Name, StationeryCode = row.StationeryCode, Description = row.Description, DateOfApp = row.DateOfApp, NeededQuantity = data.Where(y => y.StationeryCode == row.StationeryCode).Sum(y => y.NeededQuantity) }).Distinct();
            var list = result.ToList();
            broker.dispose();
            return list;
        }


        public bool createAndUpdate(string dept, string clerk, string XOL, string delivDate)
        {
            EntityBroker broker = new EntityBroker();


            var item = from dep in broker.getEntities().Departments
                       where dep.code == dept
                       join coll in broker.getEntities().CollectionPoints on XOL equals coll.place
                       select coll;
            CollectionPoint i = item.FirstOrDefault();
           
            
            // create new row in disbursementlist
                createDisb.clerkEmpNo = clerk;
                createDisb.deptCode = dept;
                createDisb.status = "Accepted";
                if (!string.IsNullOrEmpty(delivDate))
                {
                    createDisb.deliveryDate = Convert.ToDateTime(delivDate);
                }
                else
                {
                    return false;
                }
                createDisb.collectionPt = i.id;
                broker.getEntities().DisbursementLists.Add(createDisb);
                broker.getEntities().SaveChanges();

            //update in request table
                var update = (from x in broker.getEntities().Requests
                              where x.deptCode == dept && x.status == "Approved"
                              select x).Distinct();
                lireq = update.ToList();
                if (lireq != null)
                {
                    foreach (var l in lireq)
                    {
                        l.status = "Accepted";
                        l.deliveryID = createDisb.id;
                        l.lastUpdate = DateTime.Now;
                    }
                    broker.getEntities().SaveChanges();
                }

           //create RequesrByDept
                CreateRBD(createDisb.id);
           //notifying the DeptRep
                NotifyDeptRep(dept, i.place, createDisb.deliveryDate);

                broker.dispose();
                return true;
        }

        public void CreateRBD(int ID)
        {
            EntityBroker broker = new EntityBroker();

            var sum = (from x in broker.getEntities().Requests
                          where x.status == "Accepted" && x.deliveryID == ID
                       join xd in broker.getEntities().RequestDetails on x.id equals xd.requestID
                          group new { x, xd } by new { xd.stationeryCode, x.deliveryID, xd.neededQuantity } into ng
                          select new ReqByDept() { StationeryCode = ng.Key.stationeryCode, DeliveryID = ng.Key.deliveryID.Value, NeededQuantity = ng.Sum(y => y.xd.neededQuantity) }).Distinct();
            var create = (from row in sum
                          select new ReqByDept() { StationeryCode = row.StationeryCode, DeliveryID = row.DeliveryID, NeededQuantity = sum.Where(y => y.StationeryCode == row.StationeryCode).Sum(y => y.NeededQuantity) }).Distinct();
            List<ReqByDept> lrbd = create.ToList();
            if (lrbd != null)
            {
                foreach (ReqByDept c in lrbd)
                {
                    RequestByDept createReqByDept = new RequestByDept();
                    createReqByDept.stationeryCode = c.StationeryCode;
                    createReqByDept.deliveryID = c.DeliveryID;
                    createReqByDept.neededQuantity = c.NeededQuantity;
                    createReqByDept.disbursedQuantity = 0;
                    createReqByDept.retrievedQuantity = 0;
                    broker.getEntities().RequestByDepts.Add(createReqByDept);
                   
                }
                broker.getEntities().SaveChanges();
            }
            broker.dispose();
        }

        public void NotifyDeptRep(string dept, string place,DateTime deliverD) 
        {
            EntityBroker broker = new EntityBroker();
             Employee Rep;
            var emailAddress = from n in broker.getEntities().Employees
                               where n.deptCode == dept && n.empRole == "deptRep"
                               select n;
     
             Rep = emailAddress.FirstOrDefault();
            if(Rep==null)
            {
                // getting value from Department table
                // employee1 dept rep
                var email = from x in broker.getEntities().Departments
                            where (x.code.Equals(dept))
                            select x.Employee1;
                Rep = email.FirstOrDefault<Employee>();
            }
            string To = Rep.email;
            // no email server ,so gmail server 
            string Email = "Dear " + Rep.designation + "." + Rep.empName + ", " + "The request from your department has been accepted. Please be present during delivery at " + place + " on " + deliverD.ToString("dd/MM/yyyy") +
          "." + "Please check here: ";
            string Message = "<p>" + Email + "</p> <a href=" + "http://10.10.1.192/LUStationeryStore/Dep/updateCollectionPoint/CollectionPointbyOrder.aspx?erid=" + createDisb.id + ">Click for Changing the order</a>";
   
            string Subject = "Your requisition has been accepted!";
            note.sendEmailtoDepRep("LogicZoolrep@GMAIL.COM", Message, Subject);
            broker.dispose();
        
        }
    
        }
  
}