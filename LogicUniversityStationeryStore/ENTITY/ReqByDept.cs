using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.ENTITY
{
    public class ReqByDept
    {
        String stationeryCode;
        int neededQuantity;
        int deliveryID;
        public String StationeryCode
        {
            get { return stationeryCode; }
            set { stationeryCode = value; }
        }
    

        public int DeliveryID
        {
            get { return deliveryID; }
            set { deliveryID = value; }
        }
        

        public int NeededQuantity
        {
            get { return neededQuantity; }
            set { neededQuantity = value; }
        }
    }
}