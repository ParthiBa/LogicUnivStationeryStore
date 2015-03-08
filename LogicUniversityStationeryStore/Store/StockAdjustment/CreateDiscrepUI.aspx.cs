using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Dep
{
    public partial class CreateDiscrepUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string AdjustmentID = Request.Params["id"];
            if (AdjustmentID != null)
            {
                // update the Grid
                int AdjustmentId = Convert.ToInt32(AdjustmentID);
                // var q = from x in EntityBroker.getMyEntites().StockAdjustmentDetails
                var q = (from x in EntityBroker.getMyEntities().StockAdjustmentDetails
                         where x.reportID == AdjustmentId
                         select x).ToList();
                GrdDiscrepDetails.DataSource = q;
                lblTest.Text = AdjustmentId.ToString();
                GrdDiscrepDetails.DataBind();



            }
         //   StationeryDropDown1.ddlDropDownSelect += new EventHandler(NewItemSelected);
            spin.setLimit("-1000", "1000");
        }

        void NewItemSelected(object sender, EventArgs e){
        //{
        //    string Cateogory = StationeryDropDown1.getValues();
        //    var q = (from x in EntityBroker.getMyEntities().Stationeries
        //             where x.category == Cateogory
        //             select new { x.code, x.category }).ToList();
        //    //     ddlStationarItemsbyCat.DataTextField = "category";
        //    //   ddlStationarItemsbyCat.DataValueField = "code";
        //    ddlStationarItemsbyCat.DataSource = q;
        //    ddlStationarItemsbyCat.DataBind();
        }

        protected void ddlStationarItemsbyCat_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   lblTest.Text = ddlStationarItemsbyCat.SelectedValue;
        }


    }
}