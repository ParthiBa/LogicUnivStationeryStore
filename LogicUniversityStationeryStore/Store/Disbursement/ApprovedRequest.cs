using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.Store.Disbursement
{
    public class ApprovedRequest
    {
        private string name;
        private DateTime dateOfApp;
        private string stationeryCode;
        private string description;
        private int neededQuantity;
      

        public string StationeryCode
        {
            get { return stationeryCode; }
            set { stationeryCode = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NeededQuantity
        {
            get { return neededQuantity; }
            set { neededQuantity = value; }
        }
              

        public DateTime DateOfApp
        {
            get { return dateOfApp; }
            set { dateOfApp = value; }
        }          
      
    }
}