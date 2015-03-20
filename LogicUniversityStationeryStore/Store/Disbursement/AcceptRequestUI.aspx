<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="AcceptRequestUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Disbursement.AcceptRequestUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 

<asp:Content ID="content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.3/themes/smoothness/jquery-ui.css"/>
   <script src="//code.jquery.com/jquery-1.10.2.js"></script>
   <script src="//code.jquery.com/ui/1.11.3/jquery-ui.js"></script>

    <style type="text/css">
        .auto-style6 {
            text-align: left;
            font-size: x-small;
        }
        .auto-style7 {
            width: 200%;
            text-align: left;
        }
        .auto-style8 {
            text-align: left;
            font-size: small;
            width: 430px;
        }
        .auto-style9 {
            font-size: small;
            text-align: left;
        }
        .auto-style10 {
            text-align: left;
            font-size: medium;
            width: 430px;
        }
    </style>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="StationeryBody" runat="server">
    <br /><br />
    <div style="width: 1219px; height: 324px; margin-top: 0px;">
     <table>
        <tr>
            <td class="auto-style7">
    <asp:Label ID="Label2" runat="server" Text="Department Name: " style="width:300px; font-size: small;" CssClass="auto-style9"></asp:Label>   </td>
            <td class="auto-style10">  
    <asp:Label ID="lblDeptName" runat="server" OnDataBinding="Page_Load" style="background-color: #99CCFF; font-size: small;"></asp:Label></td> 
            <td class="auto-style9">Delivery Date:</td>
                <td class="auto-style6"><asp:TextBox ID="boxDeliverDate" runat="server" CssClass="datepicker" Width="178px" style="font-size: medium"></asp:TextBox><asp:Label ID="Label3" runat="server" CssClass="auto-style9"></asp:Label></td>
        </tr>
         <tr>
             <td class="auto-style7">
                 <asp:Label ID="Label4" runat="server" Text="Collection Point: " style="font-size: small"></asp:Label></td>
             <td class="auto-style8">
                  <asp:Label ID="lblCollPoint" runat="server" Text="" style="background-color: #99CCFF"></asp:Label>
             </td>
         </tr>
        </table>
    <br/>
    <div style="text-align:center">
    <asp:GridView ID="RequestByDeptView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="544px">
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
    </div>
        <br/>
    <p style="text-align:center">
    <asp:Button ID="BtnAccept" runat="server" Text="Accept" OnClick="BtnAccept_Click" CssClass="btn btn-success" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" CssClass="btn btn-primary"/>
    </p></div>
</asp:Content>
