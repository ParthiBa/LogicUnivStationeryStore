using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Controller
{
    public class SupplierCRUDController
    {
        
        string supplierCode;
        string supplierName;
        string registrationNo;
        string contactName;
        string telNo;
        string faxNo;
        string address;
        string email;
        public SupplierCRUDController()//Default Constructor//
        {
            ddPageLoad();
            clear();
        }
        public SupplierCRUDController(string a)//parameterised constructor//
        {
            this.supplierCode = a;
            retriveBtn();

        }
        public SupplierCRUDController(string a, string b, string c, string d, string e, string f, string g, string h)//parameterised constructor//
        {
            this.supplierCode = a;
            this.supplierName = b;
            this.registrationNo = c;
            this.contactName = d;
            this.telNo = e;
            this.faxNo = f;
            this.address = g;
            this.email = h;
        }
       
       
        public void callCreate()//Create Button//
        {
            createbutton();
        }
        public void createbutton()//Create Button//
        {
            Supplier sup = new Supplier();
            sup.supplierCode = supplierCode;
            sup.supplierName = supplierName;
            sup.registrationNo = registrationNo;
            sup.contactName = contactName;
            sup.telNo = telNo;
            sup.faxNo = faxNo;
            sup.address = address;
            sup.email = email;
            EntityBroker.getMyEntities().Suppliers.Add(sup);
            EntityBroker.getMyEntities().SaveChanges();
        }

        public List<string> ddPageLoad()//Create Page Load//
        {
            List<string> SupCodeList = new List<string>();

            var supplierName = from o in EntityBroker.getMyEntities().Suppliers
                               select o.supplierCode;

            foreach (string name in supplierName)
            {
                SupCodeList.Add(name);
            }
            return SupCodeList;

        }
        public string clear()//Clear Button//
        {
            string a = "";
            return a;
        }

        public List<Supplier> retriveBtn()//Retrive Button//
        {
            List<Supplier> suppDetail = (from o in EntityBroker.getMyEntities().Suppliers
                                         where o.supplierCode == supplierCode
                                         select o).ToList();

            return suppDetail;
        }
        public void callUpdate()//Update Button//
        {
            updateButton();
        }
        public void updateButton()//Update Button//
        {
            var supplierDtl = from o in EntityBroker.getMyEntities().Suppliers
                              where o.supplierCode == supplierCode
                              select o;

            Supplier sup = supplierDtl.FirstOrDefault<Supplier>();

            if (sup != null)
            {
                sup.supplierName = supplierName;
                sup.registrationNo = registrationNo;
                sup.contactName = contactName;
                sup.telNo = telNo;
                sup.faxNo = faxNo;
                sup.address = address;
                sup.email = email;

                EntityBroker.getMyEntities().SaveChanges();
            }
        }

    }
}