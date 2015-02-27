<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePurOrdUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.CreatePurOrdUI" %>

<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 70px;
        }
        .auto-style2 {
            height: 70px;
            width: 146px;
        }
        .auto-style3 {
            width: 146px;
        }
    </style>
    <link rel="stylesheet" href="../../Content/bootstrap.css" />
    <link rel="stylesheet" href="../../Scripts/JqueryUI/dotluv.css" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../../Scripts/JqueryUI/jquery-ui.js"></script>
    <script src="../../Scripts/ProJs/loadDatePick.js">s
        //***********************************Datepicker**********


    </script>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 500px">
    
    &nbsp;<br />
        <table style="width: 100%; height: 214px;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblSupplier" runat="server" Text="Supplier: " ></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlChooseSupplier" runat="server" DataSourceID="EntityDataSource1" DataTextField="supplierName" DataValueField="supplierCode" CssClass="dropdown">
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=LogicUnivesrityEntities" DefaultContainerName="LogicUnivesrityEntities" EnableFlattening="False" EntitySetName="PurchaseOrderDetails">
                    </asp:EntityDataSource>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblDeilveryDate" runat="server" Text="Delivery Date : " ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDeliveryDate" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSource2" Width="791px" AllowPaging="True" AllowSorting="True" CssClass="table table-responsive" Height="293px">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="orderID" HeaderText="orderID" SortExpression="orderID" />
                <asp:BoundField DataField="stationeryCode" HeaderText="stationeryCode" SortExpression="stationeryCode" />
                <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=LogicUnivesrityEntities" DefaultContainerName="LogicUnivesrityEntities" EnableFlattening="False" EntitySetName="PurchaseOrderDetails">
        </asp:EntityDataSource>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="76px" />
    
    </div>
    </form>
</body>
</html>
