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
            String geRole = (from x in EntityBroker.getMyEntities().Employees
                            where x.empNo == id
                            select x.empRole).ToString();
            return geRole;

        }

        public static dynamic  getAllCategories()
        {
            var qq = ((from x in EntityBroker.getMyEntities().Stationeries
                      select new { x.category }).Distinct()).ToList();
            return qq;
        }

        public static dynamic getItemByCategory(string category)
        {
            var quwe = from x in EntityBroker.getMyEntities().Stationeries
                       where x.category == category
                       select new { x.code, x.description };

            return quwe.ToList();
        }


        public static string getUnitOfMeasure(string ItemCode)
        {
            string quwe = ((from x in EntityBroker.getMyEntities().Stationeries
                           where x.code == ItemCode
                           select x.unitOfMeasure).Single()).ToString();

            return quwe;
        }

        public static dynamic findEmpName(String empId)
        {
            var q = (from x in EntityBroker.getMyEntities().Employees
                     where x.empNo.Equals(empId)
                     select new { x.empName }).First();
            return q.ToString(); ;

        }


        public static Employee findEmpbyName(string Name)
        {
            var q = from x in EntityBroker.getMyEntities().Employees
                    where x.empName.Equals(Name)
                    select x;


            return q.FirstOrDefault < Employee >();


        }


        public dynamic findPricebtItemCode(string ItemCode)
        {
            var qa = from x in EntityBroker.getMyEntities().Stationeries
                     where x.code.Equals(ItemCode)
                     select x.price3;

            return Convert.ToDecimal(qa.FirstOrDefault());
        }
     
    }
}