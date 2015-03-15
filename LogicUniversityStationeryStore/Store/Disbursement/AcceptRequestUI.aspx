<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="AcceptRequestUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Disbursement.AcceptRequestUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 


<asp:Content ID="Content3" ContentPlaceHolderID="StationeryBody" runat="server">
    <br /><br />
     <table>
        <tr>
            <td class="auto-style3">
    <asp:Label ID="Label2" runat="server" Text="Department Name: "></asp:Label>     
    <asp:Label ID="lblDeptName" runat="server" OnDataBinding="Page_Load" style="background-color: #99CCFF"></asp:Label></td> 
            <td style="text-align:center" class="auto-style2">Delivery Date:<asp:TextBox ID="boxDeliverDate" runat="server" CssClass="datepicker"></asp:TextBox><asp:Label ID="Label3" runat="server"></asp:Label></td>
        </tr>
         <tr><//tr>
         <tr>
             <td>
                 <asp:Label ID="Label4" runat="server" Text="Collection Point: "></asp:Label>
                  <asp:Label ID="lblCollPoint" runat="server" Text="" style="background-color: #99CCFF"></asp:Label>
             </td>
         </tr>
        </table>
    <br/><br/>
    <div style="text-align:center">
    <asp:GridView ID="RequestByDeptView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="StationeryCode" HeaderText="Stationery Code" />
            <asp:BoundField DataField="Description" HeaderText="Name" />
            <asp:BoundField DataField="NeededQuantity" HeaderText="Quantity" />
            <asp:BoundField DataField="DateOfApp" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date of Applycation" SortExpression="date" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
    </div><br/>
    <p style="text-align:center">
    <asp:Button ID="BtnAccept" runat="server" Text="Accept" OnClick="BtnAccept_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
    </p>
</asp:Content>
