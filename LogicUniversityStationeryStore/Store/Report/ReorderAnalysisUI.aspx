<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReorderAnalysisUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Report.ReorderAnalysisUI" %>
<%@ Register src="../../customControl/MonthYearControl.ascx" tagname="MonthYearControl" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Re-order Analysis</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Re-Order Trend Analysis</h1> 
        <div>
        Please Choose Category:
        <asp:CheckBoxList ID="ChxCate" runat="server">
        </asp:CheckBoxList>
        <br/><br/><label for="myDate">Please Choose Month and Year :</label>&nbsp;
        <p>   
            <uc2:MonthYearControl ID="MonthYearControl1" runat="server" />         
        </p>
    </div>
        <asp:Button ID="btnRodAly" runat="server" Text="Submit"/>
    </form>
</body>
</html>
