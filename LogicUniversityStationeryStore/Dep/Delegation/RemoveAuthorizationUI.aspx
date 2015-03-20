<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="RemoveAuthorizationUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Delegation.RemoveAuthorizationUI" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">


    <style type="text/css">
        .auto-style4 {
            text-align: left;
            width: 170px;
        }
    </style>


</asp:Content>   
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">


   
    


    
        <br />
        <table class="auto-style2">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblMessage2" runat="server" Font-Bold="True" Font-Names="Book Antiqua" ForeColor="#FF3300"></asp:Label>
                </td>
                <td class="text-left">
                    <h2>Remove Authorization</h2>
               
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblAuthorizedPerson" runat="server" Text="Authorized Person" Visible="False"></asp:Label>
                </td>
                <td class="text-left">
                    <asp:DropDownList ID="ddAuthorisedPerson" runat="server" AutoPostBack="True" OnTextChanged="ddAuthorisedPerson_TextChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblAuthorizationRank" runat="server" Text="Authorization Rank"></asp:Label>
                </td>
                <td class="text-left">
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                </td>
                <td class="text-left">
                    <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                </td>
                <td class="text-left">
                    <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                </td>
                <td class="text-left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="text-left">
                    <asp:Button ID="btnRemoveAuth" runat="server" Text="Remove Authorization" OnClick="btnRemoveAuth_Click"  CssClass="btn btn-danger"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
        </table>
   


   
    


</asp:Content>
