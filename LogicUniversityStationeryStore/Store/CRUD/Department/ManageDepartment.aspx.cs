using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversityStationeryStore.ENTITY;
using LogicUniversityStationeryStore.DAO;
using LogicUniversityStationeryStore;
using LogicUniversityStationeryStore.Controller;

namespace LogicUniversityStationeryStore.Store.CRUD.Department
{
    public partial class ManageDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string role = Request.Cookies["UserRole"].Value.ToString();
            CheckRoleController.setStationaryMaster(this.Master, role);
        }

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    using (LogicUniversityEntities ctx = new LogicUniversityEntities())
        //    {
        //        var dpt = ctx.Departments.FirstOrDefault(m => m.code == codebox.Text);
        //        if (dpt != null)
        //        {
        //            dpt.code = codebox.Text;
        //            dpt.name = namebox.Text;
        //            dpt.contactName = contactNamebox.Text;
        //            dpt.telNo = telNobox.Text;
        //            dpt.faxNo = faxNobox.Text;
        //            dpt.deptHead = deptHeadbox.Text;
        //            dpt.deptRep = deptRepbox.Text;

        //            ctx.SaveChanges();

        //        }

        //    }
        //}
         protected void btnUpdate_Click(object sender, EventArgs e)
        {
                 string codeB=codebox.Text;
                 string nameB=namebox.Text;
                 string contactB=contactNamebox.Text;

                string telB=telNobox.Text;

                string drop1=Drop1.Text;

                string drop2=Drop2.Text;
                string faxB = faxNobox.Text;
                string drop1name=  Drop1.SelectedValue;
                string drop2name=  Drop2.SelectedValue;

                 CreateAndUpdateDeptController create = new CreateAndUpdateDeptController();

                 create.updateDept(codeB,nameB,contactB,telB,drop1,drop2,faxB,drop1name,drop2name);



                 ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Department info has been updated!'); window.location = '" + Page.ResolveUrl("~/Home/StationeryClerkHome.aspx") + "';", true);



             }
        
        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            string dcode= codebox.Text;
            CreateAndUpdateDeptController create = new CreateAndUpdateDeptController();
            DeptInfor d=create.retre(dcode);
         
                    codebox.Text = d.Code;
                    namebox.Text = d.Name;
                    Drop2.Text = d.HempName;
                    contactNamebox.Text = d.ContactName;
                    telNobox.Text = d.TelNo;
                    faxNobox.Text = d.FaxNo;
                    Drop1.Text =d.RempName;
          
           
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    using (LogicUniversityEntities ctx = new LogicUniversityEntities())
        //    {
        //        var dpt = ctx.Departments.FirstOrDefault(m => m.code == codebox.Text);
        //        if (dpt != null)
        //        {
        //            ctx.Departments.Remove(dpt);
        //            ctx.SaveChanges();
        //            ClearFields();
        //        }
        //    }
        //}
            protected void ClearFields()
        {
            codebox.Text = null;
            namebox.Text = null;
            namebox.Text = null;
            telNobox.Text = null;
            faxNobox.Text = null;
            contactNamebox.Text = null;
        }
    }
}