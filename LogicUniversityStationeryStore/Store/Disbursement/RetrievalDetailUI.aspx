<%@ Page Language="C#" MasterPageFile="~/Home/StationeryMaster.master"  AutoEventWireup="true" CodeBehind="RetrievalDetailUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Disbursement.RetrievalDetailUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 

<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StationeryBody" runat="server">

    <table class="auto-style11">
        <tr>
            <td class="auto-style5" colspan="2">
                <asp:Label ID="lblPageTitle" runat="server" EnableTheming="True" Font-Bold="True" Text="BreakDown By Department(Retrieval Detail)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
&nbsp;<asp:Label ID="Label1" runat="server" Text="Stationery Code :"></asp:Label>
            </td>
            <td class="text-left">
                <asp:Label ID="lblStationeryCode" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="Stationery Description :"></asp:Label>
            </td>
            <td class="text-left">
                <asp:Label ID="lblStationeryDesp" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style16">
                &nbsp;
                <asp:Label ID="Label3" runat="server" Text="Unit Of Measure :"></asp:Label>
            </td>
            <td class="text-left">
                <asp:Label ID="lblUnitOfMeasure" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="auto-style7">
                <asp:GridView ID="GrdRetrievalDetail" ForeColor="#333333" GridLines="None" runat="server" AutoGenerateColumns="False" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="DeptName" HeaderText="Department Name" SortExpression="name" />
                        <asp:TemplateField HeaderText="Quantity Needed">
                            <ItemTemplate>
                                <asp:Label ID="lblNeededQty" runat="server" Text ='<%#Bind("QtyNeeded")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                        <asp:TemplateField HeaderText="Actual Quantity">
                            <ItemTemplate>
                                <uc2:spinner ID="spinner1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>                         
                        <asp:TemplateField HeaderText="DisburseQuantity" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblRetrievedQty" runat="server" Text =""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DeliverId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblDeliverId" runat="server" Text ='<%#Bind("DeliverId")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="RetrievedQuantity(just hold value from RequestByDepartment" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblRetrievedFromRBD" runat="server" Text ='<%# Bind("RetrievedQty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                                                                               
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
            <td></td>
            <td class="text-left">                
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
    </table>

    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="StationeryHead">
    <style type="text/css">
        .auto-style11 {
            width: 100%;
        }
        .auto-style5 {
            height: 40px;
            }
        .auto-style7 {
            height: 137px;
        }
        .auto-style8 {
            height: 23px;
            }
        .auto-style12 {
            height: 31px;
            width: 190px;
        }
        .auto-style13 {
            height: 31px;
        }
        .auto-style14 {
            height: 29px;
            width: 190px;
        }
        .auto-style15 {
            height: 29px;
        }
        .auto-style16 {
            height: 27px;
            width: 190px;
        }
        .auto-style17 {
            height: 27px;
        }
    </style>
</asp:Content>
