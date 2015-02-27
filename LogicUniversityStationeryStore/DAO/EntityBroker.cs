using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.DAO
{
    public class EntityBroker 
    {


        private static LogicUniversityEntities ctx = new LogicUniversityEntities();
        public static LogicUniversityEntities getMyEntites()
        {
            return ctx;
        }
    }
}