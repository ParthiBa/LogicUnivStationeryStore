<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="ApproveStockAdjustment.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.StockAdjustment.ApproveStockAdjustment" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 417px;
        }
        .auto-style4 {
            width: 417px;
            height: 55px;
        }
        .auto-style5 {
            height: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
    <asp:GridView ID="grdStockAdjustmentDetailsView" runat="server" AutoGenerateColumns="False" Height="205px" Width="455px" CssClass="table table-striped">
        <Columns>
            <asp:BoundField HeaderText="Item" DataField="description" />
            <asp:BoundField HeaderText="Quantity" DataField="quantity" />
            <asp:BoundField HeaderText="Reason" DataField="reason" />
            <asp:BoundField HeaderText="Amount" DataField="amount" />
        </Columns>
    </asp:GridView>
    <table class="auto-style2">
          <tr>
            <td class="auto-style4">
               <asp:Label ID="lblApprovedPerson" runat="server" Enabled="False" Visible="False"></asp:Label>
                <asp:Label ID="lblShowPersonName" runat="server" Enabled="False" Visible="False"></asp:Label>
              </td>
            <td class="auto-style5">
           
                <asp:Label ID="lblRejectedReason" runat="server" Enabled="False" Text="This Request Was Rejected due to" Visible="False"></asp:Label>
                <asp:Label ID="lblDispReson" runat="server" Enabled="False" Visible="False"></asp:Label>
           
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
               
                <asp:Button ID="btnReject" runat="server" Text="Reject" Width="169px" CssClass="btn btn-danger" OnClick="btnReject_Click" Enabled="False" Visible="False" />
            </td>
            <td class="auto-style5">
                <asp:Button ID="btnApprove" runat="server" Height="37px" Text="Approve" Width="119px"  CssClass="btn btn-success" OnClick="btnApprove_Click" Enabled="False" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
               
                <asp:TextBox ID="txtReviewReason" CssClass="form-control" runat="server" placeholder="Please enter the reason for rejection the request" Visible="false" Height="105px" Width="427px"></asp:TextBox>
              </td> 
            <td>&nbsp;</td>
        </tr>
             <tr>
            <td class="auto-style3">
                <asp:Button ID="btnRjectSubmit" runat="server" Text="Submit Reject" Width="240px" CssClass="btn btn-primary" Enabled="False" Visible="False" OnClick="btnRjectSubmit_Click"  />
                </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
