<%@ Page Language="C#" MasterPageFile="~/Home/StationeryMaster.master"  AutoEventWireup="true" CodeBehind="RetrievalListUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Disbursement.RetrievalListUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryBody" runat="server">

    <table class="auto-style3">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblPageTitle" runat="server" Font-Bold="True" Text="Stationery Retrieval List" style="text-align: left"></asp:Label>
                <div style="width:100%">
                <asp:GridView ID="GrdRetrievalList" ForeColor="#333333" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowDataBound="hightLightRow" AllowPaging="True" OnPageIndexChanging="GrdRetrievalList_PageIndexChanging" Width="774px" >
                     <AlternatingRowStyle BackColor="White" />
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
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                &nbsp;</td>            
        </tr>
        <tr>
            <td class="auto-style4">
                 &nbsp;</td>
        </tr>
     
    </table>

</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="StationeryHead">
    <style type="text/css">
        .auto-style3 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            height: 23px;
            width: 144%;
            text-align: left;
        }
    </style>
</asp:Content>



