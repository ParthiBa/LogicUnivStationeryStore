<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="ListOfStockAdjustmentUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.StockAdjustment.ListOfStockAdjustmentUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master"%>

<asp:content id="Content1" ContentPlaceHolderID="StationeryBody" runat="server">
  
    <div style="height: 268px" >
    
        <table class="nav-justified">
            <tr>
                <td >
                    &nbsp;</td>
                <td ></td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="GrdStockAdjustmentShow" runat="server"  CssClass="table table-hover table-striped"  AutoGenerateColumns="False" Height="137px" Width="671px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                
          <%--      <asp:ButtonField CommandName="Cancel" HeaderText="ClickForDetails" ShowHeader="True" Text="Button"   />--%>
                <%--<asp:ButtonField ButtonType="Button" ImageUrl="~/Store/StockAdjustment/CreateDiscrepUI.aspx?id={id}" Text="Button" />--%>
                <asp:BoundField DataField="empName" HeaderText="Requested by" />
                
                <asp:BoundField DataField="status" HeaderText="CurrentStatus" />
                <asp:TemplateField HeaderText="Click on link for More Details" > <ItemTemplate> <asp:HyperLink ID="Component1" runat="server" 
                    NavigateUrl='<%# "~/Store/StockAdjustment/ApproveStockAdjustment.aspx?id="+Eval("id") %>' Text='<%# "Click for Order "+Eval("id") %>' > </asp:HyperLink></ItemTemplate></asp:TemplateField>
            </Columns>
        </asp:GridView>
    
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
</asp:content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="StationeryHead">
    <style type="text/css">
        .table-striped {}
    </style>
</asp:Content>
