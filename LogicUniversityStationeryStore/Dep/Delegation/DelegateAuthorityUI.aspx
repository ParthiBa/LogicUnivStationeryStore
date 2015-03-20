<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="DelegateAuthorityUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Delegation.delegateAuthorityUI" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %> 

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
          $("#<%=txtToDate.ClientID%>").change(function () {

              var fromdate = $("#<%=txtFromDate.ClientID%>").val();
              var todate = $("#<%=txtToDate.ClientID%>").val();
              console.log(fromdate);
              console.log(todate);

              if (Date.parse(fromdate) > Date.parse(todate)) {


                  todate = "";
                  alert("Invaild Date Range");
              }

          });
      });
   
  </script>
    <style type="text/css">
        .auto-style11 {
            width: 192%;
            margin-bottom: 0px;
        height: 204px;
    }
        .auto-style2 {
            width: 359px;
        }
        .auto-style3 {
            width: 276px;
        }
        .auto-style13 {
            width: 10%;
            text-align: left;
        }
        .auto-style14 {
        width: 10%;
        text-align: left;
        height: 41px;
    }
        .auto-style15 {
            text-align: left;
            height: 36px;
        }
        .auto-style16 {
            width: 10%;
            text-align: left;
            height: 102px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">
    <table class="auto-style11">
            <tr>
                <td class="auto-style16">
                    <h2>DELEGATE AUTHORITY</h2>

                    <br />
        <asp:Label ID="lblAuthorizeTO" runat="server" Text="Authorize To:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddAuthorizeTo" runat="server" Height="21px" OnSelectedIndexChanged="ddAuthorizeTo_SelectedIndexChanged" Width="178px" >
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
                </td>
           <%-- </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="lblAuthorizeRank" runat="server" Text="Authorize Rank"></asp:Label>
                </td>
                <td class="auto-style3">
        <%--<asp:DropDownList ID="ddAuthorizeRank" runat="server">
            <asp:ListItem>depTempHead</asp:ListItem>
            <asp:ListItem>Department Representative</asp:ListItem>
            <asp:ListItem Selected="True"></asp:ListItem>
        </asp:DropDownList>--%>
                <%--</td>--%>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;<asp:Label ID="Label5" runat="server" Text="Authorize Date Range:" style="text-align: left" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
        From Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<asp:TextBox ID="txtFromDate" class="calender" runat="server" Width="148px" OnTextChanged="txtFromDate_TextChanged" />
                   
                </td>
               <%-- <td class="auto-style12">--%>
                 <%--<td>  <asp:CompareValidator ID="cmpVal1" ControlToCompare="txtFromDate" 
                    ControlToValidate="txtToDate" class="calender" Operator="GreaterThanEqual"   
                   ErrorMessage="*Invalid Data" runat="server"></asp:CompareValidator>
                </td>--%>
            </tr>
            <tr>
                <td class="auto-style13">
        To Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<asp:TextBox ID="txtToDate" class="calender" runat="server" Width="147px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-success" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
        </table>
</asp:Content>
