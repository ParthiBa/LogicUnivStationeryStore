<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="CreateRequsistionUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.Requisition.CreateRequsistionUI" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %> 


                                              
<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>
<%@ Register Src="~/CustomControl/spinner.ascx" TagPrefix="uc2" TagName="spinner" %>

<%@ Register src="../../CustomControl/Spinner2.ascx" tagname="Spinner2" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">
    <style>
        .auto-style2 {
        width: 134%;
            height: 108px;
        }
    .auto-style3 {
        width: 420px;
            height: 90px;
        }
    .auto-style4 {
        width: 466px;
        height: 22px;
    }
    .auto-style6 {
        height: 22px;
        width: 60px;
    }
    .auto-style7 {
        width: 60px;
            height: 90px;
        }
        .auto-style8 {
            width: 14px;
            height: 90px;
        }
        .auto-style10 {
            height: 90px;
        }
        .auto-style11 {
            width: 466px;
            height: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">

    <br />
<table class="auto-style2">
    <tr>
        <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td class="auto-style6" colspan="3">&nbsp;</td>

    </tr>
    <tr>
        <td class="text-left">
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="lblCategory" runat="server" Text="Choose Category:" Font-Bold="True"></asp:Label>     
       
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;     
       
    <asp:DropDownList ID="ddlStationeryCategories" runat="server" AutoPostBack="True" DataTextField="category" DataValueField="category" OnSelectedIndexChanged="ddlStationeryCategories_SelectedIndexChanged1" Height="26px" Width="189px"></asp:DropDownList>
        </td>
        <td class="auto-style13" colspan="3">
            </td>
    </tr>
    <tr>
        <td class="auto-style11">

            &nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="lblCategory0" runat="server" Text="Choose Items:" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlItemsbyCategories" runat="server" DataTextField="description" DataValueField="code" OnSelectedIndexChanged="ddlItemsbyCategories_SelectedIndexChanged" AutoPostBack="True" Width="248px" Height="24px"></asp:DropDownList>
        </td>
        <td class="auto-style7">    
        </td>
        <td class="auto-style8">
            <asp:Button ID="btnAddItem" runat="server" Text="Add"  CssClass="btn btn-success"
                OnClick="btnAddItem_Click" Width="79px"  />
        </td>
        <td class="auto-style10">         
            <asp:HiddenField ID="txtStationaryId" runat="server" />
         
        </td>
    </tr>
    <tr>
        <td class="text-left">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             &nbsp;
             <asp:Label ID="lblQuantityTitle" runat="server" Text="Quantity:" Font-Bold="True">                 
             </asp:Label>
             &nbsp;&nbsp;&nbsp;
             &nbsp;
             <uc2:spinner ID="spinner2" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="text-left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblUnitOfMeasureTitle" runat="server" Text="Unit Of Measure:" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblUom" runat="server">Dozen</asp:Label>
        </td>
    </tr>
</table>
    <asp:GridView ID="grdCreateItem" runat="server" AutoGenerateColumns="False" Height="199px" Width="1071px" OnRowEditing="grdCreateItem_RowEditing" OnSelectedIndexChanged="grdCreateItem_SelectedIndexChanged" ViewStateMode="Enabled" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowUpdated="grdCreateItem_RowUpdated" OnRowUpdating="grdCreateItem_RowUpdating" OnRowDeleting="grdCreateItem_RowDeleting" OnRowDataBound="grdCreateItem_RowDataBound" OnRowCancelingEdit="grdCreateItem_RowCancelingEdit">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Item" DataField="Item" ReadOnly="true" />
            <asp:TemplateField HeaderText="Quantity" >
                <EditItemTemplate>
                    <uc1:spinner ID="spinner1" runat="server" />
                
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text=' <%#Bind("Quantity")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StationaryId" HeaderText="StationaryId"  ReadOnly="true"/>
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
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
<asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" Width="155px"  CssClass="btn btn-primary"/>
</asp:Content>
