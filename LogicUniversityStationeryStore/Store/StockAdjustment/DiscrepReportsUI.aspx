<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscrepReportsUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.DiscrepReportsUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link rel="stylesheet" href="../../Content/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="grdListOfOrderCLrk" runat="server"  CssClass="table table-hover table-striped"  AutoGenerateColumns="False">
            <Columns>
                
                <asp:BoundField DataField="id" HeaderText="id" />
                <asp:BoundField DataField="status" HeaderText="status" />
                
          <%--      <asp:ButtonField CommandName="Cancel" HeaderText="ClickForDetails" ShowHeader="True" Text="Button"   />--%>
                <%--<asp:ButtonField ButtonType="Button" ImageUrl="~/Store/StockAdjustment/CreateDiscrepUI.aspx?id={id}" Text="Button" />--%>
                <asp:TemplateField > <ItemTemplate> <asp:HyperLink ID="Component1" runat="server" NavigateUrl='<%# "~/Store/StockAdjustment/CreateDiscrepUI.aspx?id="+Eval("id") %>' Text='<%# "Click for Order "+Eval("id") %>' > </asp:HyperLink></ItemTemplate></asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
