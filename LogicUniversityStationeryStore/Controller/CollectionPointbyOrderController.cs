using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Controller
{
    public class CollectionPointbyOrderController
    {

        DisbursementList d;
        Department dept;
        Employee clerk;
        DateTime deliveryDate;
        public DisbursementList getDisbursementInfo(int orderId)
        {

            orderId = 1;
            var disbursement = from dl in EntityBroker.getMyEntities().DisbursementLists
                               where dl.id == orderId
                               select dl;
             d = disbursement.FirstOrDefault();
             clerk = d.Employee;
             deliveryDate = d.deliveryDate;
           


            return d;
           
        }
        public dynamic getCollectionPointInfo()
        {
            var collectionpoint = from cp in EntityBroker.getMyEntities().CollectionPoints
                                 select cp;
            var qc = collectionpoint.ToList();
            return qc;
        }
        public void SaveChange() {
            EntityBroker.getMyEntities().SaveChanges();
        }

        public Department getDeptInfo(int orderId) {

             orderId = 1;
            var disbursement = from dl in EntityBroker.getMyEntities().DisbursementLists
                               where dl.id == orderId
                               select dl;
            d = disbursement.FirstOrDefault();
            
            var department = from dpt in EntityBroker.getMyEntities().Departments
                             where dpt.code==d.deptCode 
                             select dpt;
                     dept=department.FirstOrDefault();
            return dept;
        }
    }
}