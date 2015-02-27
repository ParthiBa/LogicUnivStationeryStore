<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionAnalysisUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Report.RequisitionAnalysisUI" %>
<%@ Register src="../../customControl/MonthYearControl.ascx" tagname="MonthYearControl" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Requisition Trend</title>
</head>
<body>
    <h1>Requisition Trend Analysis</h1>
    <form id="form1" runat="server">
    <div>
        Please Choose Departments :
        <asp:CheckBoxList ID="chxDept" runat="server">
        </asp:CheckBoxList>
        <br/><br/>
        <label for="myDate">Please Choose Month and Year :</label>&nbsp;
        <p>
            <uc2:MonthYearControl ID="MonthYearControl1" runat="server" />
        </p>
    </div>
        <asp:Button ID="btnReqAly" runat="server" Text="Submit"/>
    </form>
</body>
</html>
