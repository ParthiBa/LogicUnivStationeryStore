using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.Store.Report
{
    public class ReorderObj
    {
        string category;
        int neededQuantity;
        int month;
        int year;       

        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        

        public int Year
        {
            get { return year; }
            set { year = value; }
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