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
//int selectedRadio=1;
            string selectedstring="";
        UpdateCollectionPointController ucpc = new UpdateCollectionPointController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setDepartmentMaster(this.Master, role);

          //   DisbursementList itm=ucpc.getDisbursementInfo(1);
         //  ClerkIdLbl.Text=itm.clerkEmpNo;
        //   OrderIdLbl.Text=itm.id.ToString();
         //   DeliveryDateLbl.Text=itm.deliveryDate.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Request.Form["radio"]!=null)
            {
       int  selectedRadio=Convert.ToInt32(Request.Form["radio"]);

             Department dep=ucpc.UpdateDeptCollectionPt(selectedRadio);
            dep.collectionPt=selectedRadio;

              selectedstring= ucpc.findCollectionPointName(selectedRadio);

           

            ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert1312a", "alert('" + selectedstring + " has been chosen as the collection point!'); window.location = '" + Page.ResolveUrl("~/Home/DeptRepHome.aspx") + "';", true);
            }
        }

        protected void CPGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void selectedItem_CheckedChanged(object sender, EventArgs e)
        {
        //    GridViewRow row = ((RadioButton)sender).Parent.Parent as GridViewRow;
        //    row.Cells[0].ToString();
        //    selectedRadio=
        }

     }
  }
    
