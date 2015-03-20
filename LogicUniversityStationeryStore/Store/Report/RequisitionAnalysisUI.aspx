<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionAnalysisUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Report.RequisitionAnalysisUI" %>
<%@ Register src="../../customControl/MonthYearControl.ascx" tagname="MonthYearControl" tagprefix="uc2" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Requisition Trend</title>
</head>
<body>
    <h1>Requisition Trend Analysis</h1>
    <form id="form1" runat="server">
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
            <uc2:MonthYearControl ID="MonthYearControl1" runat="server" />
        </p>
        <asp:Button ID="btnReqAly" runat="server" Text="Submit" OnClick="btnReqAly_Click" CssClass="btn btn-primary"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="back" OnClientClick= "window.history.go(-1);return false;" />
    </td>

        <td>
        
        <asp:Label ID="lblMessage1" runat="server"></asp:Label>
        
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" GroupTreeStyle-BackColor="White" HasCrystalLogo="False" Height="50px" ViewStateMode="Enabled" Width="350px" />
        </td>
                </tr>
            </table>
    </form>
</body>
</html>
