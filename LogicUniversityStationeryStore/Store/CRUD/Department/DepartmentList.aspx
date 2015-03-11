<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.Department.DepartmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div style="text-align:center ">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" 
                       Font-Size="XX-Large" ForeColor="#FF3300" Text="All Department Details"></asp:Label>
        </div>
   
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=LogicUniversityEntities" DefaultContainerName="LogicUniversityEntities" EnableFlattening="False" EntitySetName="Departments" EntityTypeFilter="Department" OnSelecting="EntityDataSource1_Selecting">
    </asp:EntityDataSource>
    <p>
    </p>
    <center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="code" DataSourceID="EntityDataSource1" >
        <Columns>
            <asp:BoundField DataField="name" HeaderText="DpetName" SortExpression="name" />
            <asp:BoundField DataField="code" HeaderText="DeptCode" ReadOnly="True" SortExpression="code" />
            <asp:BoundField DataField="deptHead" HeaderText="DeptHead" SortExpression="deptHead" />
            <asp:BoundField DataField="deptRep" HeaderText="DeptRep" SortExpression="deptRep" />
            <asp:BoundField DataField="contactName" HeaderText="ContactName" SortExpression="contactName" />
            <asp:BoundField DataField="telNo" HeaderText="TelNo" SortExpression="telNo" />
            <asp:BoundField DataField="faxNo" HeaderText="FaxNo" SortExpression="faxNo" />
            <asp:BoundField DataField="collectionPt" HeaderText="CollectionPt" SortExpression="collectionPt" />
        </Columns>
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
        
</asp:Content>
