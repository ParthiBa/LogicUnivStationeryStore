<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="ApproveRequisistionUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Requisition.ApproveRequisistionUI" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 22px;
            width: 81px;
        }
        .auto-style5 {
            width: 122px;
        }
        .auto-style7 {
            width: 548px;
        }
        .auto-style8 {
            height: 22px;
            width: 122px;
        }
        .auto-style9 {
            width: 548px;
            height: 38px;
        }
        .auto-style10 {
            height: 38px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">



    s<table class="auto-style2">
        <tr>
            <td class="auto-style8"> <asp:Label ID="lblEmployeeName" runat="server" Text="RequestBy:"></asp:Label></td>
            <td class="auto-style4"><asp:Label ID="lblShowEmpName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style5">  
                <asp:Label ID="lbltest1" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lbltest2" runat="server" Text="Label"></asp:Label>
            </td>
            <td></td>
        </tr>
    </table>

 
    <asp:GridView ID="GrdViewItems" runat="server" CssClass="table-hover" AutoGenerateColumns="False" Width="1029px">
        <Columns>
            <asp:TemplateField HeaderText="ItemId" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("stationeryCode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("stationeryCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Items Requested" ReadOnly="True" DataField="description" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblQuantity" runat="server" Text=' <%#Bind("neededQuantity")%>'></asp:Label>
                    <asp:Label ID="lblUOm" runat="server" Text=' <%#Bind("unitOfMeasure")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AvailableQuantity" SortExpression="availableQty" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("availableQty") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAvailableQuantity" runat="server" Text='<%# Bind("availableQty") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

        <table class="auto-style2">
        <tr>
            <td class="auto-style9">
                <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" OnClick="btnReject_Click" />
            </td>
            <td class="auto-style10">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnApprove_Click" />
            </td>
               
        </tr>
        <tr>
            <td class="auto-style7"> <asp:TextBox ID="TxtReason" runat="server" CssClass="form-control" placeholder="Please type the reason for Rejection" Width="493px" Height="69px" OnTextChanged="TxtReason_TextChanged"></asp:TextBox></td>
            <td> &nbsp;</td>
             
        </tr>
              <tr>
            <td class="auto-style7"> <asp:Button ID="btnOkReject" runat="server" Text="Ok" CssClass="btn btn-primary" Height="26px" OnClick="btnOkReject_Click" /></td>
            <td>
                             </td>
             
        </tr>
    </table>
   
</asp:Content>
