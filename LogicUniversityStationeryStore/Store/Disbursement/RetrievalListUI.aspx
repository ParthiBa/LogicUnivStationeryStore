<%@ Page Language="C#" MasterPageFile="~/Site1.Master"  AutoEventWireup="true" CodeBehind="RetrievalListUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Disbursement.RetrievalListUI" %>
<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="lblPageTitle" runat="server" Font-Bold="True" Text="Stationery Retrieval List"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:GridView ID="GrdRetrievalList" runat="server" AutoGenerateColumns="False" OnRowDataBound="hightLightRow" >
                    <Columns>
                        <asp:BoundField DataField="binNo" HeaderText="Bin No" SortExpression="binNo" />                       
                        <asp:TemplateField HeaderText="Item Number">
                            <ItemTemplate>
                                <asp:Label ID="lblitemNo" runat="server" Text='<%#Bind("ItemNo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="StationeryDescription" HeaderText="Stationery Description" SortExpression="description" />
                        <asp:TemplateField HeaderText="Quantity Needed">
                            <ItemTemplate>
                                <asp:Label ID="lblQtyNeeded" runat="server" Text='<%#Bind("Qtyneeded")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity Retrieved">
                            <ItemTemplate>
                                <asp:Label ID="lblQtyRetrieved" runat="server" Text=""></asp:Label>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="QtyRetrieved(justbindLabel)" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblRetrievefromRBD" runat="server" Text='<%# Bind("Rqty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Of Measure">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitOfMeasure" runat="server" Text ='<%#Bind("UnitOM") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnBreakDownbyDept" runat="server" OnClick="lnkbtnBreakDownbyDept_Click">BreakDownByDepartments</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity(maximum)" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblmaxQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                     
                                              
                        <asp:TemplateField HeaderText="AvaQty" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblAvaQty" runat="server" Text='<%# Bind("AvaQty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>    
            </td>            
        </tr>
        <tr>
            <td>
                 &nbsp;</td>
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



