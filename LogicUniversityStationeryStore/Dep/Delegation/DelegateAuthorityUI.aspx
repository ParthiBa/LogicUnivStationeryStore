<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="DelegateAuthorityUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Delegation.delegateAuthorityUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">
        <link rel="stylesheet" href="../../Scripts/JqueryUI/dotluv.css">
 <script src="../../Scripts/jquery-2.1.3.min.js">
</script>
 <script src="../../Scripts/JqueryUI/jquery-ui.js"></script>
  <script>
      $(function () {
          //$(".calender").datepicker();
          $(".calender").datepicker({ minDate: 0 });
          //$("#datepicker").datepicker({ minDate: 0 });
          //past date 
         
      });
  </script>
    <style type="text/css">
        .auto-style11 {
            width: 100%;
            margin-bottom: 0px;
        }
        .auto-style2 {
            width: 359px;
        }
        .auto-style3 {
            width: 276px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">
    <table class="auto-style11">
            <tr>
                <td class="auto-style2">
        <asp:Label ID="lblAuthorizeTO" runat="server" Text="Authorize TO"></asp:Label>
                </td>
                <td class="auto-style3">
        <asp:DropDownList ID="ddAuthorizeTo" runat="server" Height="16px" OnSelectedIndexChanged="ddAuthorizeTo_SelectedIndexChanged" >
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="lblAuthorizeRank" runat="server" Text="Authorize Rank"></asp:Label>
                </td>
                <td class="auto-style3">
        <asp:DropDownList ID="ddAuthorizeRank" runat="server">
            <asp:ListItem>depTempHead</asp:ListItem>
            <asp:ListItem>Department Representative</asp:ListItem>
            <asp:ListItem Selected="True"></asp:ListItem>
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="Label5" runat="server" Text="Authorize Date Range"></asp:Label>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
        <p>From Date:</p>
                </td>
                <td class="auto-style3"><asp:TextBox ID="txtFromDate" class="calender" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style2">
        <p>From Date:</p>
                </td>
                <td class="auto-style3"><asp:TextBox ID="txtToDate" class="calender" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
        </table>
</asp:Content>
