<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="~/Store/CRUD/Stationery/ManageStationeryUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.StationeryPages.manageStationeryUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">



        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            text-align: left;
            width: 515px;
        }
        .auto-style6 {
            text-align: left;
            height: 10px;
        }
        .auto-style7 {
            height: 10px;
            text-align: left;
        }
        .auto-style8 {
            text-align: left;
            width: 515px;
            height: 10px;
        }



        .auto-style9 {
            text-align: left;
            height: 24px;
        }
        .auto-style10 {
            text-align: left;
            width: 515px;
            height: 24px;
        }



    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
            <h2> Manage Stationery</h2>

    <table class="auto-style11" style="width:100%">
            <tr>
                <td class="auto-style4">
    
        <asp:Label ID="lblCatagery" runat="server" Text="Catogery"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:DropDownList ID="ddCategory" runat="server" AutoPostBack="True" OnTextChanged="ddCategory_TextChanged">
        </asp:DropDownList>
        <asp:Button ID="btnRetrive" runat="server" OnClick="btnRetrive_Click" Text="Retrive" CssClass="btn btn-primary" />
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:DropDownList ID="ddDescription" runat="server">
        </asp:DropDownList>
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="lblCode" runat="server" Text="Code" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:TextBox ID="txtCode" runat="server" Visible="False" Width="119px"></asp:TextBox>
                </td>
                <td class="auto-style5">
        <asp:RequiredFieldValidator ID="ReqFieldValCode" runat="server" ControlToValidate="txtCode" ErrorMessage="Code cannot be null" Enabled="False" EnableViewState="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
        <asp:Label ID="lblReorderLevel" runat="server" Text="ReorderLevel" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style7">
        <asp:TextBox ID="txtReorderLevel" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style8">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReorderLevel" ErrorMessage="Stationary reorder level cannot be null" Enabled="False"></asp:RequiredFieldValidator>
                    &nbsp;<asp:RangeValidator ID="ReorderRangeVal" runat="server" ControlToValidate="txtReorderLevel" ErrorMessage="ReOreder Value should be an Whole Number" MaximumValue="9999" MinimumValue="0" Type="Integer" Enabled="False"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="lblReorderQty" runat="server" Text="Reorder Qty" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:TextBox ID="txtReorderQty" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style5">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReorderQty" ErrorMessage="Stationary reorder qty cannot be null" Enabled="False"></asp:RequiredFieldValidator>
                    &nbsp;<asp:RangeValidator ID="ReorderQtyRangeVal" runat="server" ControlToValidate="txtReorderQty" ErrorMessage="ReOreder Value should be an Whole Number" MaximumValue="9999" MinimumValue="0" Type="Integer" Enabled="False"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="lblUnitOfMeasure" runat="server" Text="Unit Of Measure" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:TextBox ID="TxtUnitOfMeasure" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style5">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUnitOfMeasure" ErrorMessage="Stationary unit of measure cannot be null" Enabled="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="lblPrice1" runat="server" Text="Price1" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:TextBox ID="txtPrice1" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="price1ReqFieldVal" runat="server" ControlToValidate="txtPrice1" ErrorMessage="Price1  cannot be empty" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price1RangeVal" runat="server" ControlToValidate="txtPrice1" ErrorMessage="Price1 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency" Enabled="False"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="lblPrice" runat="server" Text="Price2" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:TextBox ID="txtPrice2" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="price2ReqFieldVal" runat="server" ControlToValidate="txtPrice2" ErrorMessage="Price2  cannot be empty" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price2RangeVal" runat="server" ControlToValidate="txtPrice2" ErrorMessage="Price2 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency" Enabled="False"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
        <asp:Label ID="lblprice3" runat="server" Text="Price3" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style9">
        <asp:TextBox ID="txtPrice3" runat="server" Visible="False" ></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="price3ReqFieldVal" runat="server" ControlToValidate="txtPrice3" ErrorMessage="Price3  cannot be empty" Enabled="False" EnableTheming="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price3RangeVal" runat="server" ControlToValidate="txtPrice3" ErrorMessage="Price3 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency" Enabled="False"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="lblSupplier1" runat="server" Text="Supplier1" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:DropDownList ID="ddSupplier1" runat="server" Visible="False">
        </asp:DropDownList>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="lblSupplier2" runat="server" Text="Supplier2" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:DropDownList ID="ddsupplier2" runat="server" Visible="False">
        </asp:DropDownList>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
        <asp:Label ID="Suppler3" runat="server" Text="Supplier3" Visible="False"></asp:Label>
                    </td>
                <td class="auto-style4">
        <asp:DropDownList ID="ddSupplier3" runat="server" Visible="False">
        </asp:DropDownList>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">

&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Enabled="False" CssClass="btn btn-primary" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-success"/>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
        </table>
</asp:Content>
