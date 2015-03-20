<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="~/Store/CRUD/SupplierPages/ManageSupplierUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.SupplierPages.manageSupplierUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">
        .auto-style11 {
            width: 85%;
        height: 389px;
    }
        .auto-style2 {
            width: 361px;
        }
        .auto-style3 {
            width: 157px;
        }
        .auto-style4 {
            width: 157px;
            height: 62px;
            text-align: left;
        }
        .auto-style6 {
            height: 62px;
        }
        .auto-style12 {
            width: 157px;
            height: 100%;
            text-align: left;
        }
        .auto-style13 {
            height: 62px;
            text-align: left;
        }
        .auto-style14 {
            width: 204px;
            text-align: left;
        }
        .auto-style15 {
            width: 204px;
            height: 62px;
            text-align: left;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
        <h2> Manage Supplier Info</h2>

    <table class="auto-style11">
        <tr>
            <td class="auto-style12">
                <asp:Label ID="lblSupCode" runat="server" Text="Supplier Code"></asp:Label>
                :</td>
            <td class="auto-style14">
                <asp:DropDownList ID="ddSupCode" runat="server" OnSelectedIndexChanged="ddSupCode_SelectedIndexChanged" >
                </asp:DropDownList>
                <asp:Button ID="btnRetrieve" runat="server" OnClick="btnRetrieve_Click" Text="Retrieve" CssClass="btn btn-primary"/>
            </td>
            <td class="text-left">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="lbSupName" runat="server" Text="Supplier Name"></asp:Label>
                :</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtSupName" runat="server"></asp:TextBox>
            </td>
            <td class="text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSupName" ErrorMessage="Supplier name cannot be blank" Enabled="False"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblGST" runat="server" Text="GST Registration No"></asp:Label>
                :</td>
            <td class="auto-style15">
                <asp:TextBox ID="txtGST" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style13">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGST" ErrorMessage="GST registration number cannot be blank" Enabled="False"></asp:RequiredFieldValidator>
                &nbsp;
        <asp:RegularExpressionValidator ID="GSTRegExp" runat="server" ControlToValidate="txtGST" ErrorMessage="GST Registration number should be of(MR-1234567-1) formate" ValidationExpression="^[M][R][-][\d]{7}[-][\d]$" Enabled="False"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="lblConName" runat="server" Text="Contact Name"></asp:Label>
                :</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtConName" runat="server"></asp:TextBox>
            </td>
            <td class="text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtConName" ErrorMessage="Contact name cannot be blank" Enabled="False"></asp:RequiredFieldValidator>
                &nbsp;
                    <asp:RegularExpressionValidator ID="ConNameRegExp" runat="server" ControlToValidate="txtConName" ErrorMessage="Name field should have only alpahabets" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="lblPhone" runat="server" Text="Phone No"></asp:Label>
                :</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </td>
            <td class="text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone no cannot be blank" Enabled="False"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="phoneRegExp" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number should start from (8 or 9xxxxxxx) and followed by only 7 numbers" ValidationExpression="^[8|9][\d]{7}$" Enabled="False"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="lblFax" runat="server" Text="Fax No"></asp:Label>
                :</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtFaxNo" runat="server"></asp:TextBox>
            </td>
            <td class="text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFaxNo" ErrorMessage="Fax no cannot be blank" Enabled="False"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="FaxRegExp" runat="server" ControlToValidate="txtFaxNo" ErrorMessage="Fax  Number should start from (8 or 9xxxxxxx) and followed by only 7 numbers" ValidationExpression="^[8|9][\d]{7}$" Enabled="False"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                :</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="text-left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address cannot be blank" Enabled="False"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                :</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td class="text-left">
                <asp:RegularExpressionValidator ID="EmailRegExp" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Email in Correct Format(axz@abc.com)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Enabled="False"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style14">
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="btn btn-primary"/>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" CssClass="btn btn-success" />
        
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="text-left">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        <br />
        <br />
 

</asp:Content>
