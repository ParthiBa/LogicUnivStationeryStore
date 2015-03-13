using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LogicUniversityStationeryStore.DAO;


namespace LogicUniversityStationeryStore.Controller
{
    public class NewPurchaseController
    {
        string status;//for check which supplier 
        string s;//for catch which supplier 
        decimal price;//to get exactly price according to supplier

        PurchaseOrder p;//insert new purchase order 

        //for binding in ddlpurchaseOrder
        public dynamic getSupplier()
        {
            var q = (from s in EntityBroker.getMyEntities().Suppliers
                     select new
                     {
                          s.supplierName,
                          s.supplierCode
                     }).Distinct().ToList();
            return q;
        }
       
        //for binding dropdownlist inside gridview
        public dynamic getItemDescription()
        {
            var q = (from s in EntityBroker.getMyEntities().Stationeries
                     select new
                     {
                         s.description,
                         s.code
                     }).Distinct().ToList();
            return q;
        }

        //get Unit Of measure according to Item description 
        public string getUnitOfMeasure(string despCode)
        {
            var q = (from s in EntityBroker.getMyEntities().Stationeries
                     where s.code == despCode
                     select s.unitOfMeasure).Single();                   
            return q.ToString();
        }

        //check supplier1 or supplier2 or supplier3
        public string getSupplierStatus(string supplier,string despCode)
        {            
            var q = (from s in EntityBroker.getMyEntities().Stationeries
                     where s.supplier1 == supplier && s.code == despCode
                     select s.supplier1).Distinct().ToList();
            //if there is no match with supplier1
            if (q.Count == 0)
            {
                status = null;

                //check for supplier2
                if (status == null)
                {
                    var q1 = (from s1 in EntityBroker.getMyEntities().Stationeries
                              where s1.supplier2 == supplier && s1.code == despCode
                              select s1.supplier2).Distinct().ToList();
                    //if there is no match with supplier2
                    if (q1.Count == 0)
                    {
                        status = null;

                        //check for supplier3
                        if (status == null)
                        {
                            var q2 = (from s2 in EntityBroker.getMyEntities().Stationeries
                                      where s2.supplier3 == supplier && s2.code == despCode
                                      select s2.supplier3).Distinct().ToList();
                            //if there is no  match with supplier 3
                            if (q2.Count == 0)
                            {
                                status = null;
                            }
                            //if there is match with supplier3 
                            else
                            {
                                status = "s3";                              
                            }
                        }

                    }
                    //if there is match with supplier2 
                    else
                    {
                        status = "s2";                       
                    }

                }
            }
            //if there is match with supplier1
            else
            {
                status = "s1";
            }
                return status;
            
        }



        //get price according to ItemDescription and Supplier 
        public dynamic getPrice(string despCode, string supplier)
        {
            //check exactly supplier
            s = this.getSupplierStatus(supplier, despCode);
           
            if (s == "s1")
            {
                var q = (from st in EntityBroker.getMyEntities().Stationeries
                         where st.code == despCode && st.supplier1 == supplier
                         select st.price1);
               price = Convert.ToDecimal(q.FirstOrDefault());
            }
            if (s == "s2")
            {
                var q = (from st in EntityBroker.getMyEntities().Stationeries
                         where st.code == despCode && st.supplier2 == supplier
                         select st.price2);
                price = Convert.ToDecimal(q.FirstOrDefault());
            }
            if (s == "s3")
            {
                var q = (from st in EntityBroker.getMyEntities().Stationeries
                         where st.code == despCode && st.supplier3 == supplier
                         select st.price3);
                price = Convert.ToDecimal(q.FirstOrDefault()); 
            }
            return price;
        }

        //get maximum quantity to enter
        public String getMaxQty(string stationeryCode)
        {
            var q = (from i in EntityBroker.getMyEntities().Inventories
                     where i.stationeryCode == stationeryCode
                     select i.availableQty).Single();
            return q.ToString();            
                 
        }
        
        //insert new purchase order 
        internal void createPurchaseOrder(string empID,DateTime reqDate,string supplier)
        {
            p = new PurchaseOrder();
            p.dateOfOrder = DateTime.Now;
            p.dateReqDue = reqDate;
            p.empNo = empID;
            p.supplierCode = supplier;
            p.status = "Pending";
            EntityBroker.getMyEntities().PurchaseOrders.Add(p);
            EntityBroker.getMyEntities().SaveChanges();           
        }
        //insert new purchase order detail
        internal void createPurchaseOrderDetail(DataTable dt)
        {
            foreach(DataRow dr in dt.Rows)
            {
                PurchaseOrderDetail pd = new PurchaseOrderDetail();
                pd.PurchaseOrder = p;
                pd.stationeryCode = dr["ItemNo"].ToString();
                pd.requestedQuantity = Convert.ToInt32(dr["Quantity"].ToString());
                pd.amount = Convert.ToDecimal(dr["Amount"].ToString());
                EntityBroker.getMyEntities().PurchaseOrderDetails.Add(pd);
            }
            EntityBroker.getMyEntities().SaveChangesAsync();
        }
     
    }
    
}