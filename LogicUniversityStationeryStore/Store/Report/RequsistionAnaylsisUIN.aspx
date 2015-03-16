<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="RequsistionAnaylsisUIN.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Report.RequsistionAnaylsisUI" %>

<%@ Register src="../../customControl/MonthYearControl.ascx" tagname="MonthYearControl" tagprefix="uc2" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 352px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
          <table>
            <tr>
    <td>
           <h3> Please Choose Departments :</h3>
        <asp:CheckBoxList ID="chxDept" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="code">
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>
        <asp:LinkButton ID="lkAll" runat="server" OnClick="lkAll_Click">Select All</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lkNone" runat="server" OnClick="lkNone_Click">Select None</asp:LinkButton>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT [name], [code] FROM [Department] WHERE ([name] NOT LIKE '%' + @name + '%')">
            <SelectParameters>
                <asp:Parameter DefaultValue="Stationery Store" Name="name" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br/>
        <br/>
        <h3><label for="myDate">Please Choose Month and Year :</label>&nbsp;</h3>
        <p>
            <uc2:monthyearcontrol ID="MonthYearControl1" runat="server" />
        <asp:Button ID="btnReqAly" runat="server" Text="Submit" OnClick="btnReqAly_Click" CssClass="btn btn-primary"/>
        </p>
        <asp:Label ID="lblMessage1" runat="server"></asp:Label>
    </td>

        <td class="auto-style4">
        
        <cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" GroupTreeStyle-BackColor="White" HasCrystalLogo="False" Height="50px" ViewStateMode="Enabled" Width="350px" />
        </td>
                </tr>
            </table>
</asp:Content>
