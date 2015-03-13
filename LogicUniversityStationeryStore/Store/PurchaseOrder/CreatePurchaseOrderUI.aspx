﻿<%@ Page Language="C#"  MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true"  CodeBehind="CreatePurchaseOrderUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.PurchaseOrder.CreatePurchaseOrderUI" %>
<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryBody" runat ="server">

    <table class="auto-style11">
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:Label ID="lblPageTitle" runat="server" Font-Bold="True" Text="Request Stationery Purchase Order"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                <asp:Label ID="lblSupplierTitle" runat="server" Text="Supplier:"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:DropDownList ID="ddlSupplier" runat="server" DataTextField="supplierName" DataValueField="supplierCode" AppendDataBoundItems="True">
                <asp:ListItem Text="--Select Supplier--" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                <asp:Label ID="lblDeliveryDateTitle" runat="server" Text="Delivery Date:"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="myodatepicker"></asp:TextBox>
                <br />
                <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                <asp:Label ID="lblItemDescriptionTitle" runat="server" Text="Item Description:"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:DropDownList ID="ddlItemDescription" runat="server" DataTextField="description" DataValueField="code" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged">
                    <asp:ListItem Text="--Select Item Description--" Value ="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                <asp:Label ID="lblQuantity" runat="server" Text="Item Quantity:"></asp:Label>
            </td>
            <td class="auto-style12">
                <uc1:spinner ID="spinner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>
               <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />              
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>
              
                <asp:GridView ID="GrdPurchaseOrder" runat="server" AutoGenerateColumns="False" Height="72px" OnRowCancelingEdit="GrdPurchaseOrder_RowCancelingEdit" OnRowDataBound="GrdPurchaseOrder_RowDataBound" OnRowDeleting="GrdPurchaseOrder_RowDeleting" OnRowEditing="GrdPurchaseOrder_RowEditing" OnRowUpdating="GrdPurchaseOrder_RowUpdating">
                    <Columns>
                        <asp:BoundField HeaderText="Item No" DataField="ItemNo" ReadOnly ="true"/>
                        <asp:BoundField HeaderText="Item Description" DataField ="Description" ReadOnly="true"/>
                       
                        <asp:TemplateField HeaderText="Quantity">
                            <EditItemTemplate>
                                <uc1:spinner ID="spinner2" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text ='<%#Bind("Quantity")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>    
                        <asp:BoundField HeaderText="UnitOfMeasure" DataField="UOM" ReadOnly ="true" />                   
                        <asp:BoundField HeaderText="Price" DataField="Price" ReadOnly ="true" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" ReadOnly="true" />
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True"/>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
              
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
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
 
   
</asp:Content>
