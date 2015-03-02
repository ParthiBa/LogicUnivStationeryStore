using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.DAO
{
    public class EntityBroker 
    {

        private static  LogicUniversityEntities1mine ctx = new  LogicUniversityEntities1mine();
        public static  LogicUniversityEntities1mine getMyEntities()
        {
            return ctx;
        }
    }
}