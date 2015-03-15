<%@ Page Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="ListOfPurchaseOrderUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.PurchaseOrder.PurchaseOrderList" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryBody" runat ="server">

    <table class="auto-style2">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblListOfPurchaseOrderTitle" runat="server" Font-Bold="True" Text="List Of Purchase Order"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:GridView ID="grdListPurchaseOrder" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="No">
              <ItemTemplate>
               <%# Container.DataItemIndex + 1 %>
              </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="OrderNo" Visible="false">
                <ItemTemplate>                    
                    <asp:Label ID="lblOrderNo" runat="server" Text='<%#Bind("OrderID")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>  
             <asp:TemplateField HeaderText="Request Order Date">
                <ItemTemplate>                    
                    <asp:Label ID="lblOrderDate" runat="server" Text='<%#Bind("OrderDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>         
            <asp:BoundField HeaderText="Order Due Date" DataField="DueDate" DataFormatString="{0:dd/MM/yyyy}"/>
             <asp:TemplateField HeaderText="Delivery Date">
                <ItemTemplate>                    
                    <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Bind("DeliveryDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order By">
                <ItemTemplate>                    
                    <asp:Label ID="lblOrderBy" runat="server" Text='<%#Bind("EmpName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier Company">
                <ItemTemplate>                    
                    <asp:Label ID="lblSupplier" runat="server" Text='<%#Bind("SupName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>              
              <asp:TemplateField HeaderText="SupplierCode" Visible="false">
                <ItemTemplate>                                        
                    <asp:Label ID="lblSupCode" runat="server" Text='<%#Bind("SupCode")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="Total Amount">
                <ItemTemplate>                    
                    <asp:Label ID="lblTotalAmt" runat="server" Text='<%#Bind("Total")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>       
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>                    
                    <asp:LinkButton ID="LnkBtnStatus" runat="server" Text='<%#Bind("status")%>' OnClick="LnkBtnStatus_Click" ForeColor=""></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView></td>
        </tr>
    </table>

    

    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="StationeryHead">
    
   
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {}
    </style>
    
   
</asp:Content>