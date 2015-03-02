using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Controller
{
    public class NewRequestController
    {
        public string getAvailabeQuantity(string id)
        {

            var getMax = (from x in EntityBroker.getMyEntities().Inventories
                          where x.stationeryCode == id
                          select x.availableQty ).Single();
            return getMax.ToString();
        }

    }
}