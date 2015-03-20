<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="ReorderAnaylsisUIN.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Report.ReorderAnaylsisUIN" %>
<%@ Register src="../../customControl/MonthYearControl.ascx" tagname="MonthYearControl" tagprefix="uc2" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">
  
        .auto-style7 {
            width: 186%;
            height: 920px;
        }
        .auto-style8 {
            height: 316px;
            width: 270px;
        }
        .auto-style9 {
            width: 211px;
        height: 374px;
    }
        .auto-style10 {
            height: 316px;
            width: 211px;
        }
        .auto-style13 {
            width: 270px;
        height: 374px;
    }
        .auto-style14 {
            width: 211px;
            height: 26px;
        }
        .auto-style15 {
            width: 270px;
            height: 26px;
        }
  
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">



    <table class="auto-style7">
        <tr>
            <td class="auto-style14"><h3> Please Choose Category:</h3>

       
            <asp:LinkButton ID="lkAll" runat="server" OnClick="lkAll_Click">Select All</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lkNone" runat="server" OnClick="lkNone_Click">Select None</asp:LinkButton>
                    <asp:CheckBoxList ID="ChxCate" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="category" DataValueField="category">
            <asp:ListItem Value="itemAll">All</asp:ListItem>
            <asp:ListItem Value="itemNone">None</asp:ListItem>
                         </asp:CheckBoxList>
            </td>
            <td class="auto-style15"></td>
        </tr>
        <tr>
            <td class="auto-style9">      <h3><label for="myDate">Please Choose Month and Year :</label>&nbsp;</h3>
      
                <uc2:MonthYearControl ID="MonthYearControl1" runat="server" />
        <asp:Button ID="btnRodAly" runat="server" Text="Submit" OnClick="btnRodAly_Click" CssClass="btn btn-primary" Width="79px"/><asp:Label ID="lbMessage" runat="server"></asp:Label>
            </td>
            <td class="auto-style13">
                <CR:CrystalReportViewer ID="CrystalReporttest1" runat="server"  />
            </td>
        </tr>
        <tr>
            <td class="auto-style10">

       
                &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT DISTINCT [category] FROM [Stationery]"></asp:SqlDataSource>
        <br/>
           <br/>
        </td>
            <td class="auto-style8">
                &nbsp;</td>
        </tr>
    </table>



</asp:Content>
