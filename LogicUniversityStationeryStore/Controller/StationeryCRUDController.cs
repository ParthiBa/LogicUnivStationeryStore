using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.DAO;



namespace LogicUniversityStationeryStore.Controller
{
    public class StationeryCRUDController
    {
    
        string staCode;
        string staCategory;
        string staDescription;
        string staReorderLevel;
        string staReorderQty;
        string UnitOfMeasure;
        decimal Price1;
        decimal Price2;
        decimal Price3;
        string Supplier1;
        string Supplier2;
        string Supplier3;

        public StationeryCRUDController()
        {
           
        }


        public StationeryCRUDController(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j, string l, string m)
        {
            this.staCode = a;
            this.staCategory = b;
            this.staDescription = c;
            this.staReorderLevel = d;
            this.staReorderQty = e;
            this.UnitOfMeasure = f;
            this.Price1 = Convert.ToDecimal( g);
            this.Price2 = Convert.ToDecimal(h);
            this.Price3 = Convert.ToDecimal(i);
            this.Supplier1 = j;
            this.Supplier2 = l;
            this.Supplier3 = m;
           
        }
        public void callCreate()
        {
            create();
        }

        public List<string> ddPageLoad()
        {
            List<string> staSuppList = new List<string>();

            var supplierName = from o in EntityBroker.getMyEntities().Suppliers
                               select o.supplierName;

            foreach (string name in supplierName)
            {
                staSuppList.Add(name);
                
            }
            return staSuppList;
        }


        public List<string> rudPageLoad()
        {
            List<string> categoryList = new List<string>();
            var stationeryCatogary = (from o in EntityBroker.getMyEntities().Stationeries
                                      select o.category).Distinct();

            foreach (string s in stationeryCatogary)
            {
                categoryList.Add(s);
            }
            return categoryList;
        }

        public void create()
        {
            Stationery sta = new Stationery();
            //string supp1  = "";
            sta.code = staCode;
            sta.category = staCategory;
            sta.description = staDescription;
            sta.reorderLevel = staReorderLevel;
            sta.reorderQuantity = staReorderQty;
            sta.unitOfMeasure = UnitOfMeasure;
            sta.price1 = Price1;
            sta.price2 = Price2;
            sta.price3 = Price3;

            //supplier1
            var sup1 = from o in EntityBroker.getMyEntities().Suppliers
                       where Supplier1 == o.supplierName
                       select o;
            Supplier supp1 = sup1.FirstOrDefault<Supplier>();
            sta.supplier1 = supp1.supplierCode; 

            //supplier2
            var sup2 = from o in EntityBroker.getMyEntities().Suppliers
                       where Supplier2 == o.supplierName
                       select o;
            Supplier supp2 = sup2.FirstOrDefault<Supplier>();
            sta.supplier2 = supp2.supplierCode;

            //supplier3
            var sup3 = from o in EntityBroker.getMyEntities().Suppliers
                       where Supplier3 == o.supplierName
                       select o;
            Supplier supp3 = sup3.FirstOrDefault<Supplier>();
            sta.supplier3 = supp3.supplierCode;
            EntityBroker.getMyEntities().Stationeries.Add(sta);
            EntityBroker.getMyEntities().SaveChanges();
 
        }
        public string clear()
        {
            string a = "";
            return a;
        }

        public Stationery rudPageLoad(string categoryName, string itemName)
        { 
            var stationeryDt1= from o in EntityBroker.getMyEntities().Stationeries
                               where o.category == categoryName && o.description==itemName
                              select o;

            Stationery stationeryDetails = stationeryDt1.FirstOrDefault<Stationery>();

            return stationeryDetails;
        }

        public string getSupplierName(string supCode)
        {
            var sup = from o in EntityBroker.getMyEntities().Suppliers
                       where supCode == o.supplierCode
                       select o.supplierName;
            string supp = sup.FirstOrDefault<string>();
            return supp;
        }

        public List<string> getAllSupplierName(string supCode)
        {
            List<string> supAllNames = new List<string>();
             var supplierDtl = (from o in EntityBroker.getMyEntities().Suppliers
                                where supCode != o.supplierCode
                               select o.supplierName).Distinct();

             foreach (string s in supplierDtl)
             {
                 supAllNames.Add(s);
             }
             return supAllNames;
        }

        public List<string> ddCategoryChanged(string categoryName)
        {
            List<string> stationeryNames = new List<string>();
            var stationeryDescription = from o in EntityBroker.getMyEntities().Stationeries
                                        where o.category == categoryName
                                        select o.description;

            foreach (string s in stationeryDescription)
            {
                stationeryNames.Add(s);
            }
            return stationeryNames;
        }

        public void update(Stationery s)
        {
            var stationeryDtl = from o in EntityBroker.getMyEntities().Stationeries
                                where o.category == s.category && o.description == s.description
                                select o;

            Stationery sta = stationeryDtl.FirstOrDefault<Stationery>();
            sta.unitOfMeasure = s.unitOfMeasure;
            sta.reorderLevel = s.reorderLevel;
            sta.reorderQuantity = s.reorderQuantity;
            sta.price1 = s.price1;
            sta.price2 = s.price2;
            sta.price3 = s.price3;
            sta.supplier1 = getSuplierCode(s.supplier1);
            sta.supplier2 = getSuplierCode(s.supplier2);
            sta.supplier3 = getSuplierCode(s.supplier3);
            EntityBroker.getMyEntities().SaveChanges();
          
        }

        public string getSuplierCode(string name)
        {
            var sup1 = from o in EntityBroker.getMyEntities().Suppliers
                       where name == o.supplierName
                       select o;
            Supplier supp1 = sup1.FirstOrDefault<Supplier>();
            return supp1.supplierName;
        }

        //public void deleteStationery()
        //{
        //    var stationeryDtl = from o in context.Stationeries
        //                        where o.category == ddCategory.Text & o.description == ddDescription.Text
        //                        select o;

        //    Stationery sta = stationeryDtl.FirstOrDefault<Stationery>();

        //    if (sta != null)
        //    {
        //        context.Stationeries.Remove(sta);
        //        context.SaveChanges();
        //    }
        //}
    }
}