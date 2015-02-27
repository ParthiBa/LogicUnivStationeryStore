<%@ Page Language="C#" MasterPageFile="~/Site1.Master"  AutoEventWireup="true" CodeBehind="RetrievalListUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Disbursement.RetrievalListUI" %>
<%@ Register src="../../CustomerControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="lblPageTitle" runat="server" Font-Bold="True" Text="Stationery Retrieval List"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="binNo" HeaderText="Bin No" SortExpression="binNo" />
                        <asp:BoundField DataField="stationeryCode" HeaderText="Item Number" SortExpression="stationeryCode" />
                        <asp:BoundField DataField="description" HeaderText="Stationery Description" SortExpression="description" />
                        <asp:BoundField DataField="Quantity Needed" HeaderText="Quantity Needed" ReadOnly="True" SortExpression="Quantity Needed" />
                        <asp:TemplateField HeaderText="Quantity Retrieved">
                            <ItemTemplate>
                                <uc1:spinner ID="spinner1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnBreakDownByDept" runat="server" Text="BreakDownByDepartment" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LogicStationeryConnectionString %>" SelectCommand="select distinct i.binNo,rd.stationeryCode,s.description,sum(rd.neededQuantity) over(partition by rd.stationeryCode) as [Quantity Needed]
from  Inventory i,RequestDetail rd,Stationery s,Request r
where r.status='Accepted' and rd.requestID=r.id and i.stationeryCode=rd.stationeryCode and s.code=rd.stationeryCode
order by rd.stationeryCode
"></asp:SqlDataSource>
            </td>
        </tr>
    </table>

</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>



