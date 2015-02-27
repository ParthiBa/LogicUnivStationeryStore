<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateDisburListUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.CreateDisburListUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table class="auto-style1">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblPageTitle" runat="server" Font-Bold="True" Text="Generate Stationery Disbursement List"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblDepNameTitle" runat="server" Text="Department Name:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlDepName" runat="server" AutoPostBack="True" DataSourceID="DepartmentName" DataTextField="name" DataValueField="code" OnSelectedIndexChanged="ddlDepName_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="DepartmentName" runat="server" ConnectionString="<%$ ConnectionStrings:LogicStationeryConnectionString %>" SelectCommand="SELECT [name], [code] FROM [Department]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblRepNameTitle" runat="server" Text="Representative Name:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblRepName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblCollectionPointTitle" runat="server" Text="Collection Point:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblCollectionPoint" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblDate" runat="server" Text="Delivery Date for the week:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:GridView ID="GrdDisbursementList" runat="server" EmptyDataText="No Records Found">
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
</table>


    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 333px;
    }
</style>
</asp:Content>
