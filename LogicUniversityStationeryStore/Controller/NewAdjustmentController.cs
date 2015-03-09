using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.Helper;
using LogicUniversityStationeryStore.DAO;
namespace LogicUniversityStationeryStore.Controller
{
    public class NewAdjustmentController
    {
        StockAdjustment newAdjustment;
        LinqHelper linqhelper = new LinqHelper();


        public void  createStockAdjustment(string Clerkid)
        {

            newAdjustment.status = "Pending";
            newAdjustment.Employee1 = LinqHelper.findEmpbyId(Clerkid);
            EntityBroker.getMyEntities().StockAdjustments.Add(newAdjustment);
            EntityBroker.getMyEntities().SaveChanges();


        }


    }
}