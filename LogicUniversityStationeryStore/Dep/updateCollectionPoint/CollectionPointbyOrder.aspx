<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="CollectionPointbyOrder.aspx.cs" Inherits="LogicUniversity.CollectionPoint1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">

        .auto-style4 {
            width: 171px;
        }
        .auto-style5 {
            width: 240px;
        }
        .auto-style6 {
            width: 240px;
            text-align: left;
        }
        .auto-style7 {
            width: 171px;
            text-align: center;
        }
        .auto-style8 {
            text-align: left;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label1" runat="server" Text="Store Clerk:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:Label ID="ClerkIdLbl" runat="server"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:Label ID="Label2" runat="server" Text="Requisition Order ID:"></asp:Label>
                <asp:Label ID="OrderIDLbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label3" runat="server" Text="Delivery Date:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:Label ID="DateLbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">
                <asp:GridView ID="CPGridView" runat="server"  Width="83px" AutoGenerateColumns="False" OnSelectedIndexChanged="CPGridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <input name="MyRadioBTN" type="radio" value="<%#Eval("id") %>" style ="width:20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Place" HeaderText="Collection Point" SortExpression="CollectionPoint" />
                        <asp:BoundField DataField="TimeSlot" HeaderText="Time" SortExpression="TimeSlot" />
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
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click" Text="Update" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>
    <asp:Label ID="Label4" runat="server"></asp:Label>
</asp:Content>
 