using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LogicUniversityStationeryStore.Helper;
using LogicUniversityStationeryStore.DAO;


namespace LogicUniversityStationeryStore.Controller
{
    public class NewAdjustmentController
    {
        StockAdjustment newAdjustment;
        LinqHelper linqhelper = new LinqHelper();
        NotificationHelper helper = new NotificationHelper();

        public void  createStockAdjustment(string Clerkid)
        {
            newAdjustment = new StockAdjustment();
            newAdjustment.status = "Pending";
            newAdjustment.Employee1 = LinqHelper.findEmpbyId(Clerkid);

            EntityBroker.getMyEntities().StockAdjustments.Add(newAdjustment);
                   
            EntityBroker.getMyEntities().SaveChanges();

        }


        public void addStockAdjusmentDetails(DataTable dt)
        {
            decimal sum=0;
            bool isMorethan250=false;
            foreach(DataRow r in dt.Rows)
            {
                StockAdjustmentDetail StockAdjusmentDetails = new StockAdjustmentDetail();
                StockAdjusmentDetails.StockAdjustment = newAdjustment;
                StockAdjusmentDetails.stationeryCode = r["ItemNo"].ToString();
                StockAdjusmentDetails.reason = r["Reason"].ToString();
                StockAdjusmentDetails.quantity = Convert.ToInt32(r["quantity"].ToString());
                StockAdjusmentDetails.amount = Convert.ToDecimal(r["amount"].ToString());
                sum = sum + StockAdjusmentDetails.amount;
                EntityBroker.getMyEntities().StockAdjustmentDetails.Add(StockAdjusmentDetails);
              
                if(  StockAdjusmentDetails.amount > 250 || sum >250)
                {
                 
                    isMorethan250 = true;
                }

            }

            if(isMorethan250)
            {

                newAdjustment.showTo = "Manager";
             helper.sendEmailbyClerk("sheldonLogiCManager@gmail.com",NotificationHelper.informStockAdjustment(newAdjustment.Employee1.empName),"New Stock adjustment Rrequest is waiting for your approval");
                // inform Manager
            
            }
            else
            {

                newAdjustment.showTo = "Supervisor";
                helper.sendEmailbyClerk("amyfarrahlogicsupervisor@gmail.com", NotificationHelper.informStockAdjustment(newAdjustment.Employee1.empName), "New Stock adjustment Rrequest is waiting for your approval");

            }
            //inform superivisor

           

            EntityBroker.getMyEntities().SaveChanges();


        }


    }
}