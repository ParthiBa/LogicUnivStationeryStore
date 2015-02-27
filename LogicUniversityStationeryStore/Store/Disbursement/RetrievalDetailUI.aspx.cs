using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.DAO;

namespace LogicUniversityStationeryStore.Store.Disbursement
{
    public partial class RetrievalDetailUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridBinding();

        }
        public void GridBinding()
        {
            var RetrieveList = (from i in EntityBroker.getMyEntities().Inventories
                                join rd in EntityBroker.getMyEntities().RequestDetails on i.stationeryCode equals rd.stationeryCode
                                join r in EntityBroker.getMyEntities().Requests on rd.requestID equals r.id
                                join s in EntityBroker.getMyEntities().Stationeries on rd.stationeryCode equals s.code
                                where r.status == "Accepted"
                                orderby i.binNo
                                group rd by new
                                {
                                    SCode = rd.stationeryCode,
                                    B = i.binNo,
                                    SDesp = s.description

                                } into RL
                                select new
                                {
                                    BinNo = RL.Key.B,
                                    ItemNo = RL.Key.SCode,
                                    StationeryDescription = RL.Key.SDesp,
                                    QuantityNeeded = RL.Sum(qty => qty.neededQuantity)

                                }).ToList();
            GrdRetrievalDetail.DataSource = RetrieveList;
            GrdRetrievalDetail.DataBind();  
        }
    }
}