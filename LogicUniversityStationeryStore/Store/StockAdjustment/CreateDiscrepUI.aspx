<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateDiscrepUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.CreateDiscrepUI" %>

<%@ Register src="../../CustomControl/StationeryDropDown.ascx" tagname="StationeryDropDown" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
        <br />
        <br />
        <br />
        <uc1:StationeryDropDown ID="StationeryDropDown1" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnSubmitItem" runat="server" Text="Button" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSource1" style="margin-right: 1px">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="reportID" HeaderText="reportID" SortExpression="reportID" />
                <asp:BoundField DataField="stationeryCode" HeaderText="stationeryCode" SortExpression="stationeryCode" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                <asp:BoundField DataField="reason" HeaderText="reason" SortExpression="reason" />
                <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=LogicUniversityEntities" DefaultContainerName="LogicUniversityEntities" EnableFlattening="False" EntitySetName="StockAdjustmentDetails">
        </asp:EntityDataSource>
    
    </div>
    </form>
</body>
</html>
