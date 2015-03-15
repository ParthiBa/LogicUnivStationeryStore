<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="CollectionPointbyOrder.aspx.cs" Inherits="LogicUniversity.CollectionPoint1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 88px;
        }
        .auto-style3 {
            width: 701px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Store Clerk:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="ClerkIdLbl" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Requisition Order ID:"></asp:Label>
                <asp:Label ID="OrderIDLbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="Delivery Date:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="DateLbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:GridView ID="CPGridView" runat="server"  Width="83px" AutoGenerateColumns="false" OnSelectedIndexChanged="CPGridView_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <input name="MyRadioBTN" type="radio" value="<%#Eval("id") %>" style ="width:20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Place" HeaderText="Collection Point" SortExpression="CollectionPoint" />
                        <asp:BoundField DataField="TimeSlot" HeaderText="Time" SortExpression="TimeSlot" />
                    </Columns>
                  
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click" Text="Update" />
            </td>
        </tr>
    </table>
    <asp:Label ID="Label4" runat="server"></asp:Label>
</asp:Content>
 