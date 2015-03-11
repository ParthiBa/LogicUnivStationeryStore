using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.ENTITY
{
    public class DeptInfor
    {
        string code;
        string rempName;
        string name;
        string contactName;
        string hempName;
        string telNo;
        string faxNo;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
       
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string HempName
        {
            get { return hempName; }
            set { hempName = value; }
        }

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }
        

        public string TelNo
        {
            get { return telNo; }
            set { telNo = value; }
        }
        

        public string FaxNo
        {
            get { return faxNo; }
            set { faxNo = value; }
        }
        

        public string RempName
        {
            get { return rempName; }
            set { rempName = value; }
        }
                 
    }
}