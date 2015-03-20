using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using LogicUniversityStationeryStore.Helper;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Controller
{
    public class CollectionPointbyOrderController
    {

        DisbursementList d;
        Department dept;
     //   Employee clerk;
     //   DateTime deliveryDate;
        public DisbursementList getDisbursementInfo(int orderId)
        {

        
            EntityBroker broker = new EntityBroker();

            var disbursement = from dl in broker.getEntities().DisbursementLists
                               where dl.id == orderId
                               select dl;
             d = disbursement.FirstOrDefault();
            // clerk = d.Employee;
            // deliveryDate = d.deliveryDate;
             broker.dispose();

            return d;
           
        }
        public dynamic getCollectionPointInfo()
        {
            EntityBroker broker = new EntityBroker();

            var collectionpoint = from cp in broker.getEntities().CollectionPoints
                                 select cp;
            var qc = collectionpoint.ToList();
            broker.dispose();

            return qc;
        }

        public dynamic getCollectionPointInfo(int orderid)
        {

            EntityBroker broker = new EntityBroker();

            var collectionpoint = from cp in broker.getEntities().DisbursementLists
                                  where cp.id.Equals(orderid)
                                  select cp;
            var qc = collectionpoint.FirstOrDefault();
            broker.dispose();

       return     getCollectionPoints(qc.id,qc.clerkEmpNo);

        }
    

        public List<CollectionPoint> getCollectionPoints(int cp, String clerkEmpNo)
        {
            List<CollectionPoint> list = new List<CollectionPoint>();
            EntityBroker broker = new EntityBroker();

            var getCurrentDLBookedCp = from dl in broker.getEntities().DisbursementLists
                                       join c in broker.getEntities().CollectionPoints on dl.collectionPt equals c.id
                                       where dl.status == "Accepted" && dl.clerkEmpNo == clerkEmpNo
                                       select c;
            CollectionPoint otherBooked = getCurrentDLBookedCp.FirstOrDefault<CollectionPoint>();
            if (otherBooked.id == cp)
            {
                var pop = from c in broker.getEntities().CollectionPoints
                          select c;
                foreach (CollectionPoint col in pop)
                {
                    list.Add(col);
                }
            }
            else
            {
                list.Add(otherBooked);
                var pop = from c in broker.getEntities().CollectionPoints
                          where c.timeSlot != otherBooked.timeSlot
                          select c;
                foreach (CollectionPoint col in pop)
                {
                    list.Add(col);
                }
            }
          
            broker.dispose();
            return list;
        }


        public Department getDeptInfo(int orderId, int collectionpoint) {
            EntityBroker broker = new EntityBroker();


            var disbursement = from dl in broker.getEntities().DisbursementLists
                               where dl.id == orderId
                               select dl;
            d = disbursement.FirstOrDefault();
            d.collectionPt = collectionpoint;
            
            var department = from dpt in broker.getEntities().Departments
                             where dpt.code==d.deptCode 
                             select dpt;

            var q = from x in broker.getEntities().CollectionPoints
                    where x.id == collectionpoint
                    select x.place;

            string  CollectionPointNAme = q.FirstOrDefault();
            dept=department.FirstOrDefault();
                     dept.collectionPt = collectionpoint;
                     broker.getEntities().SaveChanges();

                     NotificationHelper helper = new NotificationHelper();
                     string message = "this order " + orderId + "has a new Collectopn point "+CollectionPointNAme+" for this " + dept.name;
            string subject="Collection Point Changed";
                     helper.EmailtoClerk(message,subject);


            return dept;
        }
        public string findCollectionPointName(int id)
        {
            EntityBroker broker = new EntityBroker();
            var q = from x in broker.getEntities().CollectionPoints
                    where x.id == id
                    select x.place;

            var q1 = q.FirstOrDefault();
            broker.dispose();
            return q1;

        }
    }
}