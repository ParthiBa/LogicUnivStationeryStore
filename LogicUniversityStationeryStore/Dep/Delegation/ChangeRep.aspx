<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="ChangeRep.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Delegation.ChangeRep" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">

    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">

    <table class="auto-style2">
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblChaDepRep" runat="server" Text="Change Department Representative"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCurrRep" runat="server" Text="Current Representative"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCurrentRep" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAuthTo" runat="server" Text="Authorize To"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddAuthTo" runat="server" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnChangeRep" runat="server" Text="Change Rep" OnClick="btnChangeRep_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
