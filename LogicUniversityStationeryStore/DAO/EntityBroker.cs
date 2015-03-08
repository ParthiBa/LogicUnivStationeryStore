using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.DAO
{
    public class EntityBroker 
    {
        private static LogicUniversityEntities3 ctx = new LogicUniversityEntities3();
        public static LogicUniversityEntities3 getMyEntities()
        {
            return ctx;
        }
    }
}