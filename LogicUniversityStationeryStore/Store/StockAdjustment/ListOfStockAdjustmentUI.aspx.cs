﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Store.StockAdjustment
{
    public partial class ListOfStockAdjustmentUI : System.Web.UI.Page
    {

        UpdateAdjustmentController upAdController = new UpdateAdjustmentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);



            GrdStockAdjustmentShow.DataSource = upAdController.getDataforGrid(role);
            GrdStockAdjustmentShow.DataBind();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}