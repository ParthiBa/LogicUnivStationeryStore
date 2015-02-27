<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrderList.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.PurchaseOrder.PurchaseOrderList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../Content/bootstrap.css" />
    
</head>
<body>
    <h1>Purchase Order List</h1>
    <form id="form1" runat="server">
      
    <div>
    
        <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EDSlistOfPurchaseOrder">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="dateOfOrder" HeaderText="dateOfOrder" SortExpression="dateOfOrder" />
                <asp:BoundField DataField="dateOfReq" HeaderText="dateOfReq" SortExpression="dateOfReq" />
                <asp:BoundField DataField="dateOfDelivery" HeaderText="dateOfDelivery" SortExpression="dateOfDelivery" />
                <asp:BoundField DataField="empNo" HeaderText="empNo" SortExpression="empNo" />
                <asp:BoundField DataField="supplierCode" HeaderText="supplierCode" SortExpression="supplierCode" />
                <asp:BoundField DataField="totalAmount" HeaderText="totalAmount" SortExpression="totalAmount" />
                <asp:TemplateField HeaderText="Supplier">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
        <asp:EntityDataSource ID="EDSlistOfPurchaseOrder" runat="server" ConnectionString="name=LogicStatinoryStoreEntitiesConnection" DefaultContainerName="LogicStatinoryStoreEntitiesConnection" EnableFlattening="False" EntitySetName="PurchaseOrders">
        </asp:EntityDataSource>
    
    </div>
    </form>
</body>
</html>
