using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.Store.Report
{
    public class RequisitionObj
    {
        string name;
        string category;
        int neededQuantity;
        DateTime deliveryDate;
        int month;
        int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

     

        public int Month
        {
         get { return month; }
         set { month = value; }
        }


        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
      

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        

        public int NeededQuantity
        {
            get { return neededQuantity; }
            set { neededQuantity = value; }
        }

    }
}