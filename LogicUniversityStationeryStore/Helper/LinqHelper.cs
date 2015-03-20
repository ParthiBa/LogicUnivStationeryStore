using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Helper
{
    public class LinqHelper
    {

        public static string GetRole(string id)
        {
            EntityBroker broker = new EntityBroker();
            String geRole = (from x in broker.getEntities().Employees
                            where x.empNo == id
                            select x.empRole).ToString();
            broker.dispose();
            return geRole;

        }

        public static dynamic  getAllCategories()
        {
            EntityBroker broker = new EntityBroker();
            var qq = ((from x in broker.getEntities().Stationeries
                      select new { x.category }).Distinct()).ToList();
            broker.dispose();
            return qq;
        }

        public static dynamic getItemByCategory(string category)
        {
            EntityBroker broker = new EntityBroker();
            var quwe = from x in broker.getEntities().Stationeries
                       where x.category == category
                       select new { x.code, x.description };
            var er = quwe.ToList();
            broker.dispose();
            return er;
        }


        public static string getUnitOfMeasure(string ItemCode)
        {
            EntityBroker broker = new EntityBroker();
            string quwe = ((from x in broker.getEntities().Stationeries
                           where x.code == ItemCode
                           select x.unitOfMeasure).Single()).ToString();
            broker.dispose();
            return quwe;
        }

        public static dynamic findEmpName(String empId)
        {
            EntityBroker broker = new EntityBroker();
            var q = (from x in broker.getEntities().Employees
                     where x.empNo.Equals(empId)
                     select  x ).First();
            broker.dispose();
            return q.empName;

        }

        public static Employee findEmpbyId(String empId)
        {
            EntityBroker broker = new EntityBroker();
            var q = (from x in broker.getEntities().Employees
                     where x.empNo.Equals(empId)
                     select  x).First();
            broker.dispose();
            return q ;

        }


        public static Employee findEmpbyName(string Name)
        {
            EntityBroker broker = new EntityBroker();
            var q = from x in broker.getEntities().Employees
                    where x.empName.Equals(Name)
                    select x;

            var result = q.FirstOrDefault<Employee>();
            broker.dispose();
            return result;


        }
    

        public dynamic findPricebtItemCode(string ItemCode)
        {
            EntityBroker broker = new EntityBroker();
            var qa = from x in broker.getEntities().Stationeries
                     where x.code.Equals(ItemCode)
                     select x.price3;
            var result = qa.FirstOrDefault();
            broker.dispose();
            
            return Convert.ToDecimal(result);
        }
     
    }
}