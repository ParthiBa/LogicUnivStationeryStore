<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="RemoveAuthorizationUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Delegation.RemoveAuthorizationUI" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">




    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 22px;
        }
        .auto-style4 {
            height: 24px;
        }
    </style>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">


   
    


    
        <br />
        <table class="auto-style2">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblRemoveAuthorization" runat="server" Text="Remove Authorization"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblAuthorizedPerson" runat="server" Text="Authorized Person"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddAuthorisedPerson" runat="server" AutoPostBack="True" OnTextChanged="ddAuthorisedPerson_TextChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAuthorizationRank" runat="server" Text="Authorization Rank"></asp:Label>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                </td>
                <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="margin-left: 40px">
                    <asp:Button ID="btnRemoveAuth" runat="server" Text="Remove Authorization" OnClick="btnRemoveAuth_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
        </table>
   


   
    


</asp:Content>
