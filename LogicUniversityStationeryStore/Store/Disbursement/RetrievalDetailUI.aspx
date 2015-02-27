<%@ Page Language="C#" MasterPageFile="~/Site1.Master"  AutoEventWireup="true" CodeBehind="RetrievalDetailUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Disbursement.RetrievalDetailUI" %>

<%@ Register src="../../CustomerControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="lblPageTitle" runat="server" EnableTheming="True" Font-Bold="True" Text="BreakDown By Department(Retrieval Detail)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStationeryCode" runat="server"></asp:Label>
&nbsp;
                <asp:Label ID="lblStationeryDesp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GrdRetrievalDetail" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="BinNo" HeaderText="BinNo" />
                        <asp:BoundField DataField="ItemNo" HeaderText="ItemNumber" />
                        <asp:BoundField DataField="StationeryDescription" HeaderText="Stationery Description" />
                        <asp:BoundField DataField="QuantityNeeded" HeaderText="Quantity Needed" />
                        <asp:TemplateField HeaderText="Quantity Retrieved"></asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnBrkDownByDept" runat="server" Text="BreakDownByDepartments" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
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
