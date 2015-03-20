using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LogicUniversityStationeryStore.Controller;
using LogicUniversityStationeryStore.Helper;
using LogicUniversityStationeryStore.CustomControl;

namespace LogicUniversityStationeryStore.Dep.Requisition
{
    public partial class CreateRequsistionUI : System.Web.UI.Page
    {
        NewRequestController NrController = new NewRequestController();

        string empId = "";
           


        string MaxQuantity = "2";
        string CurrentMaxQuantity;
        string currentValue;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["User"] != null)
            {
                empId = Request.Cookies["User"].Value.ToString();
                string role = Request.Cookies["UserRole"].Value.ToString();
                CheckRoleController.setDepartmentMaster(this.Master, role);

         //       string empid = (LinqHelper.findEmpbyName(empId)).empNo;


            }  
            // siteMater = Page.Master as Department;
                    spinner2.txtSpinChanged += new EventHandler(AmountChanged);
                    grdCreateItem.RowDataBound += new GridViewRowEventHandler(this.grdCreateItem_RowDataBound);
            //    Spinner21.setLimitQuantity("0", MaxQuantity, "");
            if (!IsPostBack)
            {
               
              // SetInitialRow();
                var allCat = LinqHelper.getAllCategories();
                ddlStationeryCategories.DataSource = allCat;
                ddlStationeryCategories.DataBind();
                var aa = LinqHelper.getItemByCategory("Clip");
                ddlItemsbyCategories.DataSource = aa;
                ddlItemsbyCategories.DataBind();
                    string MaxQuantity = NrController.getAvailabeQuantity(ddlItemsbyCategories.Items[0].Value);
             
                    spinner2.setLimit("1", MaxQuantity);
           
            }
            if (grdCreateItem.Rows.Count == 0)
            {

                Button1.Enabled = false;
            }
        }

        protected void grdCreateItem_RowEditing(object sender, GridViewEditEventArgs e)
        {

            grdCreateItem.EditIndex = e.NewEditIndex;
            //grdCreateItem.SelectedIndex = e.NewEditIndex;
            GridViewRow rd = grdCreateItem.Rows[e.NewEditIndex];

            string x = (string)(rd.Cells[2]).Text;
        //    BindData();
            GridViewRow r = grdCreateItem.Rows[e.NewEditIndex];

            Label cuurent =(Label) r.FindControl("Label2");
            currentValue = cuurent.Text;
            CurrentMaxQuantity = NrController.getAvailabeQuantity(x);
            Console.WriteLine("MaxQuantity");

          //  if(e.)
           
            WebUserControl1 value = rd.FindControl("spinner1") as WebUserControl1;

           //value.setLimit("0", "2");
            //// starts here 

            // DataRowView drview = grdCreateItem.Rows[e.NewEditIndex].DataItem as DataRowView;
            // if (e.Row.RowType == DataControlRowType.DataRow)
            // {
            //     HyperLink HLdetails = e.Row.FindControl("hyprlnkdetails") as HyperLink;
            //     Label lblText = e.Row.FindControl("lblText") as Label;
            // }

            //// ends here

            WebUserControl1 oo =(WebUserControl1) Page.FindControl("spinner1");
         //   oo.setLimit("0", Maxquantity);
         
            //  WebUserControl1 spinner = (WebUserControl1)r.FindControl("spinner1");
          //  WebUserControl1 spin =(WebUserControl1) r.Cells[1].FindControl("spinner1");
            TextBox t = (TextBox)r.FindControl("TextBox1");
          //  t.Text = "hello";
            for (int i = 0; i <= r.Controls.Count-1;i++ )
            {

                string ax = r.Controls[i].ToString();
                string y = r.Controls[i].UniqueID;
                Response.Write(y);

            }
          //  spin.setLimit("0", Maxquantity);
            //spinner.setLimit("0", Maxquantity);
            Console.WriteLine("jee");
           // spinner.setLimit("0", MaxQuantity);

            BindData();

            btnAddItem.Enabled = false;
            Button1.Enabled = false;
          
           
        }



        protected void ddlItemsbyCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sid = ddlItemsbyCategories.SelectedValue;
            txtStationaryId.Value = ddlItemsbyCategories.SelectedValue;
       
            var getUom = LinqHelper.getUnitOfMeasure(sid);
            string MaxQuantity = NrController.getAvailabeQuantity(sid);
            spinner2.setLimit("0", MaxQuantity);
            lblUom.Text = getUom;
         
            //  Spinner21.setLimitQuantity("0", MaxQuantity, getUom);
        }

        protected void ddlStationeryCategories_SelectedIndexChanged1(object sender, EventArgs e)
        {
            var s = LinqHelper.getItemByCategory(ddlStationeryCategories.SelectedValue);
            ddlItemsbyCategories.DataSource = s;
            ddlItemsbyCategories.DataBind();
            txtStationaryId.Value = ddlItemsbyCategories.Items[0].Value;
      
        }



        public void AmountChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtStationaryId.Value.Equals(""))
            {
                txtStationaryId.Value = ddlItemsbyCategories.Items[0].Value;
            }
            string item= ddlItemsbyCategories.SelectedItem.Text;
            string  quantity= spinner2.getValue();
            string sid = txtStationaryId.Value;
           
            addInitialRow(item, quantity,sid);
            Button1.Enabled = true;
        }

        protected void grdCreateItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Item",typeof(string)));
            dt.Columns.Add(new DataColumn("Quantity",typeof(string)));
            dr = dt.NewRow();
            dr["Item"] = "1";
            dr["Quantity"] = "hello";
            dt.Rows.Add(dr);
            ViewState["currentCreate"] = dt;
            grdCreateItem.DataSource = dt;
            grdCreateItem.DataBind();

        }

        private void addInitialRow(string Item,string Quantity)
        {

            if( ViewState["currentCreate"]==null)
            {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Item", typeof(string)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
            dr = dt.NewRow();
            dr["Item"] = Item;
            dr["Quantity"] = Quantity;
            dt.Rows.Add(dr);
            ViewState["currentCreate"] = dt;
            grdCreateItem.DataSource = dt;
            grdCreateItem.DataBind();
        }
            else
            {
                DataTable dt = (DataTable)ViewState["currentCreate"];
                DataRow dr = null;
                dr = dt.NewRow();
                dr["Item"] = Item;
                dr["Quantity"] = Quantity;
                dt.Rows.Add(dr);
                ViewState["currentCreate"] = dt;
                grdCreateItem.DataSource = dt;
                grdCreateItem.DataBind();
            }

        }



        private void addInitialRow(string Item, string Quantity,string Stationaryid)
        {

            if (ViewState["currentCreate"] == null)
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Item", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
                dt.Columns.Add(new DataColumn("StationaryId", typeof(string)));
                dr = dt.NewRow();
                dr["Item"] = Item;
                dr["Quantity"] = Quantity;
                dr["StationaryId"] = Stationaryid;
                dt.Rows.Add(dr);
                ViewState["currentCreate"] = dt;
                grdCreateItem.DataSource = dt;
                grdCreateItem.DataBind();
            }
            else
            {
                DataTable dt = (DataTable)ViewState["currentCreate"];
                DataRow dr = null;
                dr = dt.NewRow();
                dr["Item"] = Item;
                dr["Quantity"] = Quantity;
                  dr["StationaryId"] = Stationaryid;
                dt.Rows.Add(dr);
                ViewState["currentCreate"] = dt;
                grdCreateItem.DataSource = dt;
                grdCreateItem.DataBind();
            }

        }

        protected void grdCreateItem_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            btnAddItem.Enabled = true;
            Button1.Enabled = true;
        }

        protected void grdCreateItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DataTable dt= (DataTable)ViewState["currentCreate"];

            GridViewRow row= grdCreateItem.Rows[e.RowIndex];
            dt.Rows[row.DataItemIndex]["Quantity"] = ((WebUserControl1)row.Cells[1].FindControl("spinner1")).getValue();

            grdCreateItem.EditIndex = -1;
            BindData();

            Button1.Enabled = true;
            btnAddItem.Enabled = true;
          
        }

        protected void grdCreateItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["currentCreate"];
            dt.Rows.Remove(dt.Rows[e.RowIndex]);
            grdCreateItem.DataSource = dt;
            grdCreateItem.DataBind();
           
        }
        private void BindData()
        {
            DataTable dt = (DataTable)ViewState["currentCreate"];
        //    ViewState["currentCreate"] = dt;
            grdCreateItem.DataSource = dt;
            grdCreateItem.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["currentCreate"];
            if (dt.Rows[0] != null)
            {
                NrController.createRequest(empId);
                NrController.createRequestDetail(dt);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "myalert", "alert('Request Has been added Sucessfully '); window.location = '" + Page.ResolveUrl("~/Home/DeptEmpHome.aspx") + "';", true);
            }
           // Response.Write("<script language="'javascript'">window.alert('Your Message');window.location='yourpage.aspx';</script>");
        }

        protected void grdCreateItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           // string clientId_forRow = e.Row.ClientID;

             DataRowView drview = e.Row.DataItem as DataRowView;
          //   if (e.Row.RowType == DataControlRowType.DataRow)
           //  {
              //   WebUserControl1 HLdetails = e.Row.FindControl("spinner1") as WebUserControl1;
                 //Label lblText = e.Row.FindControl("lblText") as Label;
                // HLdetails.setLimit("0", "10");
            // }

            //FindControl
            if((e.Row.RowState & DataControlRowState.Edit)==DataControlRowState.Edit)
            {
                WebUserControl1 HLdetails = e.Row.FindControl("spinner1") as WebUserControl1;
                if(HLdetails!=null)
                {
                    HLdetails.setLimit("1", CurrentMaxQuantity);
                    HLdetails.setValue(currentValue);
                }

            }
        }

        protected void grdCreateItem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCreateItem.EditIndex = -1;
            BindData();
        }

    }
}