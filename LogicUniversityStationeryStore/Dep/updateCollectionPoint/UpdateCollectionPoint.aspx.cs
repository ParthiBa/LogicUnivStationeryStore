using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.Controller;


namespace LogicUniversityStationeryStore
{
    public partial class UpdateCollectionPoint : System.Web.UI.Page
    { 
         
        UpdateCollectionPointController ucpc = new UpdateCollectionPointController();
        protected void Page_Load(object sender, EventArgs e)
        {


            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);

             DisbursementList itm=ucpc.getDisbursementInfo(1);
         //  ClerkIdLbl.Text=itm.clerkEmpNo;
        //   OrderIdLbl.Text=itm.id.ToString();
         //   DeliveryDateLbl.Text=itm.deliveryDate.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        int selectedRadio=Convert.ToInt32(Request.Form["radio"]);
             Department dep=ucpc.UpdateDeptCollectionPt();
            dep.collectionPt=selectedRadio;
        }

     }
  }
    
