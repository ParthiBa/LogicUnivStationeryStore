﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryClerk.master" AutoEventWireup="true" CodeBehind="ListOfApprovedRequestUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.Disbursement.ListOfApprovedRequestUI" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br/>
        <p style="text-align:center">
          <asp:Label ID="Label2" runat="server" Text="You Have Request From Departments Below" Style="color: #666699; text-align: center; font-size: large; font-weight: 700;"></asp:Label>
        </p>

    <br/>
    <div style="margin-left:500px; margin-right:auto; height: 402px; width: 210px;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                 <emptydatatemplate>
                    No Requisition Found.  
                 </emptydatatemplate>
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="deptCode" HeaderText="Department Code" SortExpression="deptCode" />
            <asp:TemplateField HeaderText="Select">
           <ItemTemplate>
               <asp:LinkButton runat="server" ID="lnkView"  OnCommand="lnkView_Command" CommandArgument='<%#Eval("deptCode")%>'>Select</asp:LinkButton>
         </ItemTemplate>
                
       </asp:TemplateField>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT DISTINCT [deptCode] FROM [Request] WHERE ([status] = @status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="Approved" Name="status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
        </div>
    <br /> 
</asp:Content>
