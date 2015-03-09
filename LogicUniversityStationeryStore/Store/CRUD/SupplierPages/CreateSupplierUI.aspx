<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="~/Store/CRUD/SupplierPages/CreateSupplierUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.SupplierPages.createSupplierUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">

    <style type="text/css">
        .auto-style11 {
            width: 100%;
        }
    </style>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">

    <table class="auto-style11">
            <tr>
                <td>

        <asp:Label ID="lblSupCode" runat="server" Text="Supplier Code"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtSupCode" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSupCode" ErrorMessage="Supplier code cannot be blank"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSupCode" ErrorMessage="Supplier is not in correct formate" ValidationExpression="^[A-Z]{4}$"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lbSupName" runat="server" Text="Supplier Name"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtSupName" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSupName" ErrorMessage="Supplier name cannot be blank"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblGST" runat="server" Text="GST Registration No"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtGST" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGST" ErrorMessage="GST registration number cannot be blank"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="GSTRegExp" runat="server" ControlToValidate="txtGST" ErrorMessage="GST Registration number is not in correct formate" ValidationExpression="^[M][R][-][\d]{7}[-][\d]$"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblConName" runat="server" Text="Contact Name"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtConName" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConName" ErrorMessage="Contact name cannot be blank"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ConNameRegExp" runat="server" ControlToValidate="txtConName" ErrorMessage="Name Should be in correct Format" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblPhone" runat="server" Text="Phone No"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone no cannot be blank"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="phoneRegExp" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number Not in Correct Format" ValidationExpression="^[8|9][\d]{7}$"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblFax" runat="server" Text="Fax No"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtFaxNo" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFaxNo" ErrorMessage="Fax no cannot be blank"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="FaxRegExp" runat="server" ControlToValidate="txtFaxNo" ErrorMessage="Fax Number is not in correct format" ValidationExpression="^[8|9][\d]{7}$"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="135px"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address cannot be blank"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RegularExpressionValidator ID="EmailRegExp" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Email in Correct Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
</asp:Content>
