<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateDisburListUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Dep.CreateDisburListUI" %>

<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table class="auto-style1">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblPageTitle" runat="server" Font-Bold="True" Text="Generate Stationery Disbursement List"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblDepNameTitle" runat="server" Text="Department Name:"></asp:Label>
        </td>
        <td>
           <%-- <asp:DropDownList ID="ddlDepName" runat="server" AutoPostBack="True" DataSourceID="DepartmentNameDS" DataTextField="name" DataValueField="code" OnSelectedIndexChanged="ddlDepName_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem Text="--Select a department--" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DepartmentNameDS" runat="server" ConnectionString="<%$ ConnectionStrings:LogicStationeryConnectionString %>" SelectCommand="select name,code from Department"></asp:SqlDataSource>--%>
             <asp:DropDownList ID="ddlDepName" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="Code"  OnSelectedIndexChanged="ddlDepName_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem Text="--Select a department--" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>      
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblRepNameTitle" runat="server" Text="Representative Name:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblRepName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblCollectionPointTitle" runat="server" Text="Collection Point:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblCollectionPoint" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="lblDate" runat="server" Text="Delivery Date for the week:"></asp:Label>
        </td>
        <td class="auto-style4">
            <asp:Label ID="lblDeliveryDate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style5"></td>
        <td class="auto-style6"> </td>
    </tr>
    <tr>
        <td class="auto-style7"></td>
        <td class="auto-style8">
            <asp:GridView ID="GrdDisbursementList" runat="server" EmptyDataText="No Records" AutoGenerateColumns="False" Height="82px">
                <Columns>
                    <asp:TemplateField HeaderText="Stationery Description">
                        <ItemTemplate>
                            <asp:Label ID="lblStationeryDes" runat="server" Text='<%#Bind("SDescription")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Retrieved Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblRetrievedQty" runat="server" Text ='<%#Bind("OldRetrievedQty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Disbursed Quantity" Visible ="false">
                        <ItemTemplate>
                            <asp:Label ID="lblDisbursedQty" runat="server" Text ='<%#Bind("DisbursedQty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Disbursed Quantity">
                        <ItemTemplate>
                            <uc1:spinner ID="spinner1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RequestByDeptID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblRBDId" runat="server" Text ='<%#Bind("RBDId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="DeliveryID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbldeliverID" runat="server" Text ='<%#Bind("deliverID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="auto-style3"></td>
        <td class="auto-style4">
            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" OnClick="btnCancel_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" Visible="False" OnClick="btnSave_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
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
        width: 333px;
    }
        .auto-style3 {
            width: 333px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 333px;
            height: 14px;
        }
        .auto-style6 {
            height: 14px;
        }
        .auto-style7 {
            width: 333px;
            height: 137px;
        }
        .auto-style8 {
            height: 137px;
        }
    </style>
</asp:Content>
