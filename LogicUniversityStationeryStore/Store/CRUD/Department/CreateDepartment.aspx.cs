using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.CRUD.Department
{
    public partial class CreateDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       
        protected void btnClear_Click(object sender, EventArgs e)
        {
            codeBox.Text = string.Empty;
            nameBox.Text = string.Empty;
            nameBox.Text =string.Empty;
            telNoBox.Text = string.Empty;
            faxNoBox.Text = string.Empty;
            contactNameBox.Text = string.Empty;

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            
            
            
            {
              
                 string codeB=codeBox.Text;
                 string nameB=nameBox.Text;
                 string contactB=contactNameBox.Text;

                string telB=telNoBox.Text;

                string drop1=Drop1.Text;

                string drop2=Drop2.Text;
                string faxB = faxNoBox.Text;
                string drop1name=  Drop1.SelectedValue;
                string drop2name=  Drop2.SelectedValue;

                 CreateAndUpdateDeptController create = new CreateAndUpdateDeptController();

                 create.createDept(codeB,nameB,contactB,telB,drop1,drop2,faxB,drop1name,drop2name);

            }
        }
    }
}