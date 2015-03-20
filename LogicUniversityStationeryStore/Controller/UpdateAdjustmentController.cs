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
            EntityBroker entitybroker = new EntityBroker();
            if (role.Equals("storeMan"))
            {
                var q1 = from x in entitybroker.getEntities().StockAdjustments
                         where x.showTo.Equals("Manager")
                         select new { x.Employee1.empName, x.status, x.id };
                var q = q1.ToList();
                entitybroker.dispose();
                return q;
            }
            else
            {
                var q1 = from x in entitybroker.getEntities().StockAdjustments
                         where x.showTo.Equals("Supervisor")
              select new { x.Employee1.empName, x.status, x.id };
                var q = q1.ToList();
                entitybroker.dispose();
                return q;
            }
          
           
        }


        public dynamic getStockAdjustmentDetails(int reportId)
        {
            EntityBroker entitybroker = new EntityBroker();
            var re = from x in entitybroker.getEntities().StockAdjustmentDetails
                     where x.StockAdjustment.id == reportId
                     select new { x.Stationery.description,x.reason,x.quantity,x.amount};
            var qq = re.ToList();
            entitybroker.dispose();
            return qq;
        }


        public string  getCuurentRequest(int ReportId,string empid)
        {
            Currentemp = LinqHelper.findEmpbyId(empid);
            EntityBroker entitybroker = new EntityBroker();
            var q1 = from x in entitybroker.getEntities().StockAdjustments
                     where x.id == ReportId
                     select x;
            currentStockAdjustment = q1.FirstOrDefault();
            entitybroker.dispose();
         
            return currentStockAdjustment.status;
        }
        private List<StockAdjustmentDetail> findStockAdjustmentDetails(int stockAdjustmentId)
        {

            EntityBroker broker = new EntityBroker();
            var qq = from x in broker.getEntities().StockAdjustmentDetails
                     where x.reportID.Equals(stockAdjustmentId)
                     select x;
            var q1 = qq.ToList();
            broker.dispose();
            return q1;
    

        }

        public void ApproveCurrentRequest()
        {
            currentStockAdjustment.status = "Approved";
            EntityBroker entitybroker = new EntityBroker();
            List<StockAdjustmentDetail> list = findStockAdjustmentDetails(currentStockAdjustment.id);
            foreach(StockAdjustmentDetail st in list)
            {
                Inventory In = findIventory(st.stationeryCode);
                In.quantity = In.quantity + st.quantity;
                In.availableQty = In.availableQty + st.quantity;


            }

            currentStockAdjustment.reviewDate = DateTime.Now;
            currentStockAdjustment.reviewedBy = Currentemp.empNo;
            currentStockAdjustment.Employee = Currentemp;
            entitybroker.getEntities().Entry(currentStockAdjustment).State = System.Data.Entity.EntityState.Modified;

            entitybroker.getEntities().SaveChanges(); 
            entitybroker.dispose();


             
        }

        private Inventory findIventory(string  code)
        {
            EntityBroker entitybroker = new EntityBroker();
            var q = from x in entitybroker.getEntities().Inventories
                    where x.stationeryCode.Equals(code)
                    select x;
         
            var q1 =q.FirstOrDefault();
            entitybroker.dispose();
            return q1;
        }

        private void setInfo()
        {

            EntityBroker entitybroker = new EntityBroker();
            //Employee Reviewed by
            currentStockAdjustment.reviewDate = DateTime.Now;
            currentStockAdjustment.reviewedBy = Currentemp.empNo;

            currentStockAdjustment.Employee = Currentemp;
            entitybroker.getEntities().Entry(currentStockAdjustment).State = System.Data.Entity.EntityState.Modified;
           entitybroker.getEntities().SaveChanges();
  
           entitybroker.dispose();
        }


        public void RejectCurrentRequest()
        {

            currentStockAdjustment.status = "Rejected";
            setInfo();

        }

        public string getStockAdjustmentReviwedByName()
        {


            return LinqHelper.findEmpName(currentStockAdjustment.reviewedBy);

        }


        public string getRjectedReason()
        {

            return currentStockAdjustment.reviewReason;
        }
       


    }
}