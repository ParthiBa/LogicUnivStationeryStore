using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.DAO
{
    public class EntityBroker 
    {
        private static  LogicUniversityEntities112323aa ctx = new  LogicUniversityEntities112323aa();
        public static  LogicUniversityEntities112323aa getMyEntities()
        {
            return ctx;
        }
    }
}