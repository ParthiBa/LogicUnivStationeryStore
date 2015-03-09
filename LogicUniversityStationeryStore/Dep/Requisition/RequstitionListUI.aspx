<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="RequstitionListUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Requisition.RequstitionListUI" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">
    <asp:GridView ID="grdPendingRequest" runat="server" Height="116px" Width="423px" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="dateOfApp" HeaderText="Requsted Date" ReadOnly="True" SortExpression="Date"  DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="empName" HeaderText="Requsted by" ReadOnly="True" SortExpression="empName" />
            <asp:TemplateField HeaderText="Approve/Reject">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server"  
                        NavigateUrl='<%# "~/Dep/Requisition/ApproveRequisistionUI.aspx?rid=" + Eval("id") %>'
                       
                        Text="Click here for More details"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
         

            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="False" />
        </Columns>
    </asp:GridView>



</asp:Content>
