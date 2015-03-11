using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using LogicUniversityStationeryStore.DAO;


namespace LogicUniversityStationeryStore.Controller
{
    public class UpdateCollectionPointController
    {

        public DisbursementList getDisbursementInfo(int orderId )
        {
            var disbursement = from dl in EntityBroker.getMyEntities().DisbursementLists
                    where dl.id == orderId
                    select dl;
            DisbursementList d = disbursement.FirstOrDefault();
            return d;
        }
        //public CollectionPoint getCollectionPointInfo(int ID)
        //{
        //    var collectionpoint = from cp in EntityBroker.getMyEntities().CollectionPoints
        //                          where cp.id == ID
        //                          select new {cp.place,cp.timeSlot};
        //    CollectionPoint c=
        //    return cp;
        //}
        public Department UpdateDeptCollectionPt()
        {
            var department = from dp in EntityBroker.getMyEntities().Departments
                             select dp;
            Department de = department.FirstOrDefault();
            return de;
        }

        public string findCollectionPointName(int id)
        {
            var q = from x in EntityBroker.getMyEntities().CollectionPoints
                    where x.id == id
                    select x.place;
            return q.FirstOrDefault();


        }
    }
}