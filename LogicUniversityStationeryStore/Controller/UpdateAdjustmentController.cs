using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.Helper;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Controller
{
    public class UpdateAdjustmentController
    {

        StockAdjustment currentStockAdjustment;
        Employee Currentemp;
        public dynamic getDataforGrid(string role)
        {


            if (role.Equals("storeMan"))
            {
                var q1 = from x in EntityBroker.getMyEntities().StockAdjustments
                         where x.Showto.Equals("Manager")
                         select new { x.Employee1.empName, x.status, x.id };
                return q1.ToList();
            }
            else
            {
                var q1 = from x in EntityBroker.getMyEntities().StockAdjustments
                         where x.Showto.Equals("Supervisor")
                         select new { x.Employee1.empName, x.status, x.id };
                return q1.ToList();
            }

           
        }


        public dynamic getStockAdjustmentDetails(int reportId)
        {
            var re = from x in EntityBroker.getMyEntities().StockAdjustmentDetails
                     where x.StockAdjustment.id == reportId
                     select new { x.Stationery.description,x.reason,x.quantity,x.amount};
            return re.ToList();
        }


        public string  getCuurentRequest(int ReportId,string empid)
        {
            Currentemp = LinqHelper.findEmpbyId(empid);
            var q1 = from x in EntityBroker.getMyEntities().StockAdjustments
                     where x.id == ReportId
                     select x;
            currentStockAdjustment = q1.FirstOrDefault();
         
            return currentStockAdjustment.status;
        }


        public void ApproveCurrentRequest()
        {
            currentStockAdjustment.status = "Approved";
            ICollection<StockAdjustmentDetail> list = currentStockAdjustment.StockAdjustmentDetails;
            foreach(StockAdjustmentDetail st in list)
            {
                Inventory In = findIventory(st.stationeryCode);
                In.quantity = In.quantity + st.quantity;
                In.availableQty = In.availableQty + st.quantity;


            }

            setInfo();


             
        }

        private Inventory findIventory(string  code)
        {
            var q = from x in EntityBroker.getMyEntities().Inventories
                    where x.stationeryCode.Equals(code)
                    select x;

            return q.FirstOrDefault();

        }

        private void setInfo()
        {

            //Employee Reviewed by
            currentStockAdjustment.reviewDate = DateTime.Now;
            currentStockAdjustment.Employee = Currentemp;
            EntityBroker.getMyEntities().SaveChanges();
        }


        public void RejectCurrentRequest()
        {

            currentStockAdjustment.status = "Rejected";
            setInfo();

        }

        public string getStockAdjustmentReviwedByName()
        {

           return currentStockAdjustment.Employee.empName;
        }


        public string getRjectedReason()
        {

            return currentStockAdjustment.reviewReason;
        }
       


    }
}