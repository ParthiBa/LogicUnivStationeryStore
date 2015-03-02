<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateDiscrepUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.CreateDiscrepUI" %>

<%@ Register src="../../CustomControl/StationeryDropDown.ascx" tagname="StationeryDropDown" tagprefix="uc1" %>

<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 280px;
            height: 29px;
        }
        .auto-style3 {
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
            width: 116px;
        }
        .auto-style5 {
            height: 29px;
            width: 225px;
        }
        .auto-style6 {
            height: 29px;
            width: 54px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
        <br />
        <table class="auto-style1">
                <tr>
                <td class="auto-style2">
                    Select Sationay Category</td>
                <td class="auto-style4">Select Item:</td>
                <td class="auto-style5">Reason</td>
                <td class="auto-style6">Quantity</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style2">
        <uc1:StationeryDropDown ID="StationeryDropDown1" runat="server" />
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlStationarItemsbyCat" runat="server" OnSelectedIndexChanged="ddlStationarItemsbyCat_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtReason" runat="server"></asp:TextBox>
&nbsp;<br />
                    <asp:RegularExpressionValidator ID="RegexReason" runat="server" ErrorMessage="Please Enter Characters and Numbers" ValidationExpression="^[a-zA-Z0-9]*$" ControlToValidate="txtReason"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style6">
                    <uc2:spinner ID="spin" runat="server" />
                </td>
                <td class="auto-style3">
                    <asp:Label ID="lblUom" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnSubmitItem" runat="server" Text="Button" />
        <asp:GridView ID="GrdDiscrepDetails" runat="server" AutoGenerateColumns="True" style="margin-right: 1px">
        </asp:GridView>
    
    
        <br />
        Total Amount : <asp:Label ID="lblAmount" runat="server"></asp:Label>
    
    
    </div>
    </form>
</body>
</html>
