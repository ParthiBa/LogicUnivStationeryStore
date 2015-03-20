<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="ChangeRep.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Delegation.ChangeRep" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">

    <style type="text/css">
        .auto-style2 {
            width: 70%;
        height: 170px;
    }
    .auto-style4 {
        height: 22px;
            text-align: left;
            width: 162px;
        }
    .auto-style5 {
        height: 22px;
        width: 693px;
            text-align: left;
        }
    .auto-style6 {
            width: 693px;
            text-align: left;
        }
        .auto-style7 {
            text-align: left;
            width: 162px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">

    <table class="auto-style2">
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5">
                <h2>Change Department Representative</h2>
              
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="lblCurrRep" runat="server" Text="Current Representative"></asp:Label>
                :</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtCurrentRep" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="lblAuthTo" runat="server" Text="Authorize To"></asp:Label>
                :</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddAuthTo" runat="server" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style6">
                <asp:Button ID="btnChangeRep" runat="server" Text="Change Rep" OnClick="btnChangeRep_Click" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>

</asp:Content>
