<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.Department.DepartmentList" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">

    <br />
    <br />
    <div style="text-align:left">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" 
                       Font-Size="XX-Large" ForeColor="#FF3300" Text="&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp All Department Details"></asp:Label>
        
    <center>
    <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" >
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
        </center>
       </div> 
</asp:Content>
