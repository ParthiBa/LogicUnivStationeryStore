using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStationeryStore.DAO
{
    public class EntityBroker 
    {
        private static LogicUniversityEntities4Perm ctx = new LogicUniversityEntities4Perm();

        private LogicUniversityEntities4Perm ctx2;
        public static LogicUniversityEntities4Perm getMyEntities()
        {
            return ctx;
        }
        //public LogicUniversityEntities3 getEnities()
        //{
        //    if(ctx2==null)
        //    {
        //        ctx2 = new LogicUniversityEntities3();

        //    }
        //    return ctx2;
        //}

        //public void dispose()
        //{

        //    ctx2.Dispose();

        //}

    }
}