<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="ApproveRequisistionUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Requisition.ApproveRequisistionUI" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">

    <style type="text/css">

        .auto-style5 {
            text-align: right;
        }
        .auto-style4 {
            text-align: left;
        }

        .auto-style6 {
            width: 512px;
        }

        .auto-style10 {
            text-align: left;
            height: 38px;
        }
        .auto-style11 {
            width: 512px;
            height: 38px;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">



    <table class="auto-style2">
        <tr>
            <td class="auto-style5"> <asp:Label ID="lblEmployeeName" runat="server" Text="RequestBy:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td class="auto-style4"><asp:Label ID="lblShowEmpName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style5">  
                &nbsp;</td>
            <td class="text-left"></td>
        </tr>
    </table>

 
    <asp:GridView ID="GrdViewItems" runat="server" CssClass="table-hover" AutoGenerateColumns="False" Width="1029px">
        <EmptyDataTemplate>

            NO more orders awaiting  for your approval

        </EmptyDataTemplate>
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
            <td class="auto-style11">
                <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" OnClick="btnReject_Click" />
            </td>
            <td class="auto-style10">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnApprove_Click" />
            </td>
               
        </tr>
        <tr>
            <td class="auto-style6"> <span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill the reason" ForeColor="#FF3300" ControlToValidate="TxtReason"></asp:RequiredFieldValidator><asp:TextBox ID="TxtReason" runat="server" CssClass="form-control" placeholder="Please type the reason for Rejection" Width="493px" Height="69px" OnTextChanged="TxtReason_TextChanged"></asp:TextBox></span> 
            </td>
            <td>                 
</td>
             
        </tr>
              <tr>
            <td class="auto-style6"> <asp:Button ID="btnOkReject" runat="server" Text="Ok" CssClass="btn btn-primary" Height="39px" OnClick="btnOkReject_Click" Width="82px" /></td>
            <td>
                             </td>
             
        </tr>
    </table>
   
</asp:Content>
