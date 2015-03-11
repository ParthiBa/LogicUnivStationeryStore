using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Helper;
using LogicUniversityStationeryStore.Store.Disbursement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var q = from dp in EntityBroker.getMyEntities().Departments
                    where dp.name == deptName
                    select dp;
            Department m = q.First<Department>();
            return m;
        }

        //for binding Delivery Date according to Department
        public DateTime getDeliveryDate(String deptName)
        {
            var date = from d in EntityBroker.getMyEntities().DisbursementLists
                       join dp in EntityBroker.getMyEntities().Departments on d.deptCode equals dp.code
                       where dp.code == deptName
                       select d.deliveryDate;
            DateTime dt = date.First<DateTime>();
            return dt;
        }

        public string getDeptBySession(string dept)
        {
            var deptName = from x in EntityBroker.getMyEntities().Departments
                           where x.code == dept
                           select x;
            Department deptname = deptName.FirstOrDefault();
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
            var collPoint = from x in EntityBroker.getMyEntities().Departments
                            join c in EntityBroker.getMyEntities().CollectionPoints on x.collectionPt equals c.id
                            where x.code == dept
                            select c;
            CollectionPoint deptCp = collPoint.FirstOrDefault();
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
            var data = (from x in EntityBroker.getMyEntities().Requests
                        where x.deptCode == dept && x.status == "Approved"
                        join rd in EntityBroker.getMyEntities().RequestDetails on x.id equals rd.requestID
                        join d in EntityBroker.getMyEntities().Departments on x.deptCode equals d.code
                        join s in EntityBroker.getMyEntities().Stationeries on rd.stationeryCode equals s.code
                        group new { x, d, rd, s } by new { rd.stationeryCode, d.name, x.dateOfApp, s.description, rd.neededQuantity } into g
                        select new ApprovedRequest() { Name = g.Key.name, StationeryCode = g.Key.stationeryCode, Description = g.Key.description, DateOfApp = g.Key.dateOfApp.Value, NeededQuantity = g.Sum(y => y.rd.neededQuantity) }).Distinct();
            var result = (from row in data
                          select new ApprovedRequest() { Name = row.Name, StationeryCode = row.StationeryCode, Description = row.Description, DateOfApp = row.DateOfApp, NeededQuantity = data.Where(y => y.StationeryCode == row.StationeryCode).Sum(y => y.NeededQuantity) }).Distinct();
            return list = result.ToList();
        }


        public bool createAndUpdate(string dept, string clerk, string XOL, string delivDate)
        {
            var item = from dep in EntityBroker.getMyEntities().Departments
                       where dep.code == dept
                       join coll in EntityBroker.getMyEntities().CollectionPoints on XOL equals coll.place
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
                EntityBroker.getMyEntities().DisbursementLists.Add(createDisb);
                EntityBroker.getMyEntities().SaveChanges();

            //update in request table
                var update = (from x in EntityBroker.getMyEntities().Requests
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
                    EntityBroker.getMyEntities().SaveChanges();
                }

           //create RequesrByDept
                CreateRBD(createDisb.id);
           //notifying the DeptRep
                NotifyDeptRep(dept, i.place, createDisb.deliveryDate);
                return true;
        }

        public void CreateRBD(int ID)
        {
            var sum = (from x in EntityBroker.getMyEntities().Requests
                          where x.status == "Accepted" && x.deliveryID == ID
                          join xd in EntityBroker.getMyEntities().RequestDetails on x.id equals xd.requestID
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
                    EntityBroker.getMyEntities().RequestByDepts.Add(createReqByDept);
                   
                }
                EntityBroker.getMyEntities().SaveChanges();
            } 

        }

        public void NotifyDeptRep(string dept, string place,DateTime deliverD) 
        {
            var emailAddress = from n in EntityBroker.getMyEntities().Employees
                               where n.deptCode == dept && n.empRole == "deptRep"
                               select n;
            Employee Rep = emailAddress.FirstOrDefault();
            string hyperlink = "http://localhost:3285/Dep/updateCollectionPoint/CollectionPointbyOrder.aspx?erid=" + createDisb.id;
            //string To = Rep.email;
            string to = "LogicZoolrep@gmail.com";        
            string Email = "Dear " + Rep.designation + "." + Rep.empName + ", " + "The request from your department has been accepted. Please be present during delivery at " + place + " on " + deliverD.ToString("dd/MM/yyyy")  + 
                " \n If you want to change the collection point , you can do so by following hyperlink" +  hyperlink ;
            string Subject = "Your requisition has been accepted!";
            note.sendEmailbyClerk(to, Email, Subject); 
        
        
        }
    
        }
  
}