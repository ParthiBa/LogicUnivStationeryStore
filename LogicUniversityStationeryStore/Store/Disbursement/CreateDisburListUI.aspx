<%@ Page Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="CreateDisburListUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.CreateDisburListUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StationeryBody" runat="server">


    <table class="auto-style1">
    <tr>
        <td colspan="2" class="auto-style11">
            <asp:Label ID="lblPageTitle" runat="server" Font-Bold="True" Text="Generate Stationery Disbursement List"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style9">
            <asp:Label ID="lblDepNameTitle" runat="server" Text="Department Name:"></asp:Label>
        </td>
        <td class="auto-style13">
           <%-- <asp:DropDownList ID="ddlDepName" runat="server" AutoPostBack="True" DataSourceID="DepartmentNameDS" DataTextField="name" DataValueField="code" OnSelectedIndexChanged="ddlDepName_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem Text="--Select a department--" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DepartmentNameDS" runat="server" ConnectionString="<%$ ConnectionStrings:LogicStationeryConnectionString %>" SelectCommand="select name,code from Department"></asp:SqlDataSource>--%>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:DropDownList ID="ddlDepName" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="Code"  OnSelectedIndexChanged="ddlDepName_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem Text="--Select a department--" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>      
    </tr>
    <tr>
        <td class="auto-style9">
            <asp:Label ID="lblRepNameTitle" runat="server" Text="Representative Name:" style="text-align: right"></asp:Label>
        </td>
        <td class="auto-style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblRepName" runat="server" style="text-align: left"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style9">
            <asp:Label ID="lblCollectionPointTitle" runat="server" Text="Collection Point:" style="text-align: right"></asp:Label>
        </td>
        <td class="auto-style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCollectionPoint" runat="server" style="text-align: left"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style10">
            <asp:Label ID="lblDate" runat="server" Text="Delivery Date for the week:" style="text-align: right"></asp:Label>
        </td>
        <td class="auto-style12">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblDeliveryDate" runat="server" style="text-align: left"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style5"></td>
        <td class="auto-style6"> </td>
    </tr>
    <tr>
        <td class="auto-style7"></td>
        <td class="auto-style8">
            <asp:GridView ID="GrdDisbursementList" runat="server" ForeColor="#333333" GridLines="None" EmptyDataText="No Records" AutoGenerateColumns="False" Height="82px" Width="371px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Stationery Description">
                        <ItemTemplate>
                            <asp:Label ID="lblStationeryDes" runat="server" Text='<%#Bind("SDescription")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Retrieved Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblRetrievedQty" runat="server" Text ='<%#Bind("OldRetrievedQty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Disbursed Quantity" Visible ="false">
                        <ItemTemplate>
                            <asp:Label ID="lblDisbursedQty" runat="server" Text ='<%#Bind("DisbursedQty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Disbursed Quantity">
                        <ItemTemplate>
                            <uc1:spinner ID="spinner1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RequestByDeptID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblRBDId" runat="server" Text ='<%#Bind("RBDId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="DeliveryID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbldeliverID" runat="server" Text ='<%#Bind("deliverID") %>'></asp:Label>
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
        <td class="auto-style10"></td>
        <td class="text-left">
            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" OnClick="btnCancel_Click" CssClass="btn btn-danger" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" Visible="False" OnClick="btnSave_Click" CssClass="btn btn-success" />
        </td>
    </tr>
    <tr>
        <td colspan="2" class="auto-style11">
            &nbsp;</td>
    </tr>
</table>


    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="StationeryHead">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 333px;
    }
        .auto-style3 {
            width: 333px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 611px;
            height: 14px;
            text-align: right;
        }
        .auto-style6 {
            height: 14px;
        }
        .auto-style7 {
            width: 611px;
            height: 137px;
            text-align: right;
        }
        .auto-style8 {
            height: 137px;
        }
    .auto-style9 {
            width: 611px;
            text-align: right;
        }
    .auto-style10 {
            width: 611px;
            height: 100%;
            text-align: right;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style12 {
            height: 23px;
            text-align: left;
        }
        .auto-style13 {
            text-align: left;
        }
    </style>
</asp:Content>
