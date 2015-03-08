<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryClerk.master" AutoEventWireup="true" CodeBehind="ListOfStockAdjustmentUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.StockAdjustment.ListOfStockAdjustmentUI" %>


<asp:content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div >
    
        <table class="nav-justified">
            <tr>
                <td >
                    <asp:Button ID="Button1" runat="server" Text="Create New Discrepencies" Width="265px" OnClick="Button1_Click" />
                </td>
                <td ></td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="GridView1" runat="server"  CssClass="table table-hover table-striped"  AutoGenerateColumns="False">
            <Columns>
                
                <asp:BoundField DataField="id" HeaderText="id" />
                <asp:BoundField DataField="status" HeaderText="status" />
                
          <%--      <asp:ButtonField CommandName="Cancel" HeaderText="ClickForDetails" ShowHeader="True" Text="Button"   />--%>
                <%--<asp:ButtonField ButtonType="Button" ImageUrl="~/Store/StockAdjustment/CreateDiscrepUI.aspx?id={id}" Text="Button" />--%>
                <asp:TemplateField > <ItemTemplate> <asp:HyperLink ID="Component1" runat="server" 
                    NavigateUrl='<%# "~/Store/StockAdjustment/CreateDiscrepUI.aspx?id="+Eval("id") %>' Text='<%# "Click for Order "+Eval("id") %>' > </asp:HyperLink></ItemTemplate></asp:TemplateField>
            </Columns>
        </asp:GridView>
    
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
</asp:content>