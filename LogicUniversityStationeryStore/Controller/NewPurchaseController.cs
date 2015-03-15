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
        public dynamic getItemDescription(string supplierCode)
        {
            var q = (from s in EntityBroker.getMyEntities().Stationeries
                     where s.supplier1==supplierCode || s.supplier2==supplierCode || s.supplier3==supplierCode
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

       //--for ListOfPurchaseOrderUI page--//
            //for grid binding//     
        public dynamic bindGrdListPurchaseOrder()
        {
            var query = (from p in EntityBroker.getMyEntities().PurchaseOrders
                         join pd in EntityBroker.getMyEntities().PurchaseOrderDetails on p.id equals pd.orderID
                         join e in EntityBroker.getMyEntities().Employees on p.empNo equals e.empNo 
                         join s in EntityBroker.getMyEntities().Suppliers on p.supplierCode equals s.supplierCode
                         group pd by new
                                {
                                    oid     =p.id,
                                    DO      =p.dateOfOrder,
                                    DR      =p.dateReqDue,
                                    DD      =p.dateOfDelivery,
                                    empNo   =p.empNo,
                                    empName =e.empName,
                                    SC      =p.supplierCode,
                                    SName   =s.supplierName,
                                    ST      =p.status                                  
                                } into PO
                         orderby PO.Key.ST descending
                         select new
                         {
                             OrderID      =PO.Key.oid,
                             OrderDate    =PO.Key.DO,
                             DueDate      =PO.Key.DR,
                             DeliveryDate =PO.Key.DD,
                             EmpName      =PO.Key.empName,
                             SupCode      =PO.Key.SC,
                             SupName      =PO.Key.SName,
                             Total        =PO.Sum(pr => pr.amount),
                             status       =PO.Key.ST                          
                         }).ToList();
            return query;
        }
        //--for ConfirmPurchaseOrderUI.aspx--//
        //grid binding//
        public dynamic bindGrdConfirmPurchaseOrder(int orderID)
        {
            var query = (from p in EntityBroker.getMyEntities().PurchaseOrders
                         join pd in EntityBroker.getMyEntities().PurchaseOrderDetails on p.id equals pd.orderID
                         join s in EntityBroker.getMyEntities().Stationeries on pd.stationeryCode equals s.code
                         where pd.orderID == orderID
                         select new
                         {
                             itemid = pd.id,
                             itemDesp = s.description,                           
                             SupCode  = p.supplierCode,
                             Quantity = pd.requestedQuantity,
                             Amount = pd.amount,
                             UOM = s.unitOfMeasure
                         }).ToList();
            string desp;
            decimal price;

                DataTable dt = new DataTable();
            dt.Columns.Add("Key1", typeof(int));
            dt.Columns.Add("itemid", typeof(string));
            dt.Columns.Add("ItemDesp", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Amount", typeof(string));
            foreach(var item in query)
            {
                desp = getDespCode(item.itemDesp);
                price = getPrice(desp, item.SupCode);
                DataRow dr = dt.NewRow();
                dr["itemid"] = item.itemid;
                dr["ItemDesp"] = item.itemDesp;
                dr["Quantity"] = item.Quantity;
                dr["UOM"] = item.UOM;
                dr["Price"] = price;
                dr["Amount"] = item.Amount;
                dt.Rows.Add(dr);
            }          
           
            return dt;
        }
        //get description code to check condition
        public String getDespCode(string despName)
        {
            var q = (from s in EntityBroker.getMyEntities().Stationeries
                     where s.description == despName
                     select s.code).Single();
            return q.ToString();
        }

        //Cancel purchase order (update the purchase order status =Cancelled)
        public void CancelOrder(int orderId)
        {           
            PurchaseOrder p = EntityBroker.getMyEntities().PurchaseOrders.FirstOrDefault(po => po.id == orderId);
            p.status = "Cancelled";
            EntityBroker.getMyEntities().SaveChanges();
        }
        //confirm purchase order(update the purchase order status=Delivered)
        public void ConfirmOrder(int orderId,string sCode,DateTime d,int receivedQty,int id,decimal amt)
        {
            PurchaseOrder p =EntityBroker.getMyEntities().PurchaseOrders.FirstOrDefault(po=>po.id==orderId);
            p.status ="Delivered";
            p.dateOfDelivery =d;            

            PurchaseOrderDetail pd = EntityBroker.getMyEntities().PurchaseOrderDetails.FirstOrDefault(pod =>pod.id ==id);            
            pd.receivedQuantity = receivedQty;
            pd.amount = amt;
                
                Inventory i = EntityBroker.getMyEntities().Inventories.FirstOrDefault(iv => iv.stationeryCode == sCode);
                i.quantity += pd.receivedQuantity;
                i.availableQty += pd.receivedQuantity;
            
            EntityBroker.getMyEntities().SaveChanges();

        }
      
     
    }
    
}