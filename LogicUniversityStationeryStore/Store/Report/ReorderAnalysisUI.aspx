
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReorderAnalysisUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Report.ReorderAnalysisUI" %>
<%@ Register src="../../customControl/MonthYearControl.ascx" tagname="MonthYearControl" tagprefix="uc2" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Re-order Analysis</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Re-Order Trend Analysis</h1> 
       <table>
           <tr>
               <td>
         
       <h3> Please Choose Category:</h3>
        <asp:CheckBoxList ID="ChxCate" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="category" DataValueField="category">
            <asp:ListItem Value="itemAll">All</asp:ListItem>
            <asp:ListItem Value="itemNone">None</asp:ListItem>
        </asp:CheckBoxList>
            <asp:LinkButton ID="lkAll" runat="server" OnClick="lkAll_Click">Select All</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lkNone" runat="server" OnClick="lkNone_Click">Select None</asp:LinkButton>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT DISTINCT [category] FROM [Stationery]"></asp:SqlDataSource>
        <br/>
           <br/>
              <h3><label for="myDate">Please Choose Month and Year :</label>&nbsp;</h3>
            <p style="text-align: justify">   
                <uc2:MonthYearControl ID="MonthYearControl1" runat="server" />
            </p></td>
               <td>
                   <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" HasCrystalLogo="False" />
               </td>
    </tr></table>
        <asp:Button ID="btnRodAly" runat="server" Text="Submit" OnClick="btnRodAly_Click"/>
        <asp:Label ID="lbMessage" runat="server"></asp:Label>
        
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
