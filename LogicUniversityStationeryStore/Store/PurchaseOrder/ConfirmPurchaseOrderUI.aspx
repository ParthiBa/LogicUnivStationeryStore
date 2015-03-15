<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home/StationeryMaster.master" CodeBehind="ConfirmPurchaseOrderUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.PurchaseOrder.ConfirmPurchase" %>

<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %>
<%@ Register Src="~/CustomControl/spinner.ascx" TagPrefix="uc1" TagName="spinner" %>


<asp:Content ID="Content1" ContentPlaceHolderID="StationeryBody" runat ="server">

    <table class="auto-style2">
        <tr>
            <td class="auto-style3" colspan="2">
                <asp:Label ID="lblConfirmPurchaseOrderTitle" runat="server" Font-Bold="True" Text="Confirm Purchase Order"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblOrderNoTitle" runat="server" Text="Order No:"></asp:Label>
            </td>
            <td class="auto-style3"><asp:Label ID="lblOrderNo" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblOrderByTitle" runat="server" Text="Order By:"></asp:Label></td>
            <td><asp:Label ID="lblOrderBy" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDateOfOrderTitle" runat="server" Text="Order Date:"></asp:Label></td>
            <td><asp:Label ID="lblOrderDate" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblSupplierTitle" runat="server" Text="Supplier:"></asp:Label></td>
            <td><asp:Label ID="lblSupplier" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDeliveryDateTitle" runat="server" Text="DeliveryDate"></asp:Label></td>
            <td><input type="date" runat ="server" id="deliveryDate" class="mydatepicker"/></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:GridView ID="grdConfirmPurchaseOrder" runat="server" AutoGenerateColumns="False" OnRowEditing="grdConfirmPurchaseOrder_RowEditing" OnRowUpdating="grdConfirmPurchaseOrder_RowUpdating" OnRowCancelingEdit="grdConfirmPurchaseOrder_RowCancelingEdit" OnRowDataBound="grdConfirmPurchaseOrder_RowDataBound" DataKeyNames="Key">
                     <Columns>                          
                         <asp:TemplateField HeaderText="Item No">
                             <ItemTemplate>
                             <asp:Label ID="lblItemID" runat="server" Text ='<%#Bind("itemid")%>'></asp:Label>
                         </ItemTemplate>   
                             </asp:TemplateField>                                
                        <asp:TemplateField HeaderText="Item Description">
                             <ItemTemplate>
                             <asp:Label ID="lblItemDesp" runat="server" Text ='<%#Bind("itemDesp")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <EditItemTemplate>
                                <uc1:spinner runat="server" ID="spinner2" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text ='<%#Bind("Quantity")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>    
                        <asp:BoundField HeaderText="UnitOfMeasure" DataField="UOM" ReadOnly ="true" />                
                         <asp:TemplateField HeaderText="Price">
                             <ItemTemplate>
                             <asp:Label ID="lblPrice" runat="server" Text ='<%#Bind("Price")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Amount">
                             <ItemTemplate>
                             <asp:Label ID="lblAmount" runat="server" Text ='<%#Bind("Amount") %>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>                       
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True"/>                       
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel Order" OnClick="btnCancel_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm Order" OnClick="btnConfirm_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back To List" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="StationeryHead">
    
   
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 22px;
        }
    </style>
    <script>
        document.addEventListener("DOMContentLoaded", function (event) {
            var d = new Date();
            var n = d.toString();
            var m = d.getMonth();
            if (m != 10 || m != 11) {
                var date = d.getFullYear() + '-' + '0' + (d.getMonth() + 1) + '-' + d.getDate();
            }
            console.log(n);
            var myelemet = document.getElementsByClassName("mydatepicker")[0];
            myelemet.setAttribute("min", date);
        });
    </script>
    
   
</asp:Content>

