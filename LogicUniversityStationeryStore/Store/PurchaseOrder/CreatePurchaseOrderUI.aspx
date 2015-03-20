<%@ Page Language="C#"  MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true"  CodeBehind="CreatePurchaseOrderUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.PurchaseOrder.CreatePurchaseOrderUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 

<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryBody" runat ="server">

    <table class="auto-style11">
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:Label ID="lblPageTitle" runat="server" Font-Bold="True" Text="Request Stationery Purchase Order"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Label ID="lblSupplierTitle" runat="server" Text="Supplier:"></asp:Label>
            </td>
            <td class="text-left">
                <asp:DropDownList ID="ddlSupplier" runat="server" DataTextField="supplierName" DataValueField="supplierCode" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                <asp:ListItem Text="--Select Supplier--" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="text-right">
                &nbsp;</td>
            <td class="text-left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Label ID="lblDeliveryDateTitle" runat="server" Text="Delivery Date:"></asp:Label>
            </td>
            <td class="text-left">               
                <input type="date" runat ="server" id="deliveryDate" class="mydatepicker"/>
                <br />
                <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-right">
                &nbsp;</td>
            <td class="text-left">               
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Label ID="lblItemDescriptionTitle" runat="server" Text="Item Description:" Visible="False"></asp:Label>
            </td>
            <td class="text-left">
                <asp:DropDownList ID="ddlItemDescription" runat="server" DataTextField="description" DataValueField="code" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged" AutoPostBack="True" Visible="False">                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="text-right">
                &nbsp;</td>
            <td class="text-left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Label ID="lblQuantityTitle" runat="server" Text="Item Quantity:" Visible="False"></asp:Label>
            </td>
            <td class="text-left">
                <uc1:spinner ID="spinner1" runat="server" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="text-right">
                &nbsp;</td>
            <td class="text-left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-left">&nbsp;</td>
            <td class="text-left">
               <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" Visible="False" CssClass="btn btn-success"/>              
            </td>
        </tr>
        <tr>
            <td class="text-left">&nbsp;</td>
            <td class="text-left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>
              
               <asp:GridView ID="GrdPurchaseOrder" runat="server" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Height="72px" OnRowCancelingEdit="GrdPurchaseOrder_RowCancelingEdit" OnRowDataBound="GrdPurchaseOrder_RowDataBound" OnRowDeleting="GrdPurchaseOrder_RowDeleting" OnRowEditing="GrdPurchaseOrder_RowEditing" OnRowUpdating="GrdPurchaseOrder_RowUpdating">
                     <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Item No" DataField="ItemNo" ReadOnly ="true"/>
                        <asp:BoundField HeaderText="Item Description" DataField ="Description" ReadOnly="true"/>
                       
                        <asp:TemplateField HeaderText="Quantity">
                            <EditItemTemplate>
                                <uc1:spinner ID="spinner2" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text ='<%#Bind("Quantity")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>    
                        <asp:BoundField HeaderText="UnitOfMeasure" DataField="UOM" ReadOnly ="true" />                   
                        <asp:BoundField HeaderText="Price" DataField="Price" ReadOnly ="true" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" ReadOnly="true" />
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                        <ControlStyle ForeColor="#0066FF" />
                        </asp:CommandField>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" >
                        <ControlStyle ForeColor="#0066FF" />
                        </asp:CommandField>
                    </Columns>
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                     <RowStyle BackColor="#EFF3FB" /> 
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />                    
                     <SortedAscendingCellStyle BackColor="#F5F7FB" />
                     <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                     <SortedDescendingCellStyle BackColor="#E9EBEF" />
                     <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
              
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>
              
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td class="text-left">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Visible="False" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="StationeryHead">
    <style type="text/css">
        .auto-style11 {
            width: 100%;
        }
        .auto-style12 {
            height: 23px;
        }
        .auto-style13 {
            width: 186px;
        }
        .auto-style14 {
            height: 23px;
            width: 186px;
        }
    </style>
    <script>
        document.addEventListener("DOMContentLoaded", function (event) {           
            var d = new Date();
            var n = d.toString();
            var m = d.getMonth();
            if (m != 10 || m != 11)
            {
                var date = d.getFullYear() + '-' + '0'+(d.getMonth() + 1) + '-' + d.getDate();
            }
            console.log(n);
            var myelemet = document.getElementsByClassName("mydatepicker")[0];
            myelemet.setAttribute("min", date);
        });



    </script>
   
</asp:Content>
