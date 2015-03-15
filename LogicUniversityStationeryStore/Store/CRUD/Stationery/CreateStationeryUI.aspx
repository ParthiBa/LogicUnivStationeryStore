<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="~/Store/CRUD/Stationery/CreateStationeryUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.StationeryPages.createStationeryUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
        <style type="text/css">
        .auto-style11 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
    <div>
    
        &nbsp;&nbsp;<br />
        <table class="auto-style11">
            <tr>
                <td>
        <asp:Label ID="lblCode" runat="server" Text="Code"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode" ErrorMessage="Stationary code cannot be null"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
    
        <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtCategory" runat="server" ></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCategory" ErrorMessage="Stationary category cannot be null"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblDescreption" runat="server" Text="Descreption"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescription" ErrorMessage="Stationary descreption cannot be null"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblReorderLevel" runat="server" Text="ReorderLevel"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtReorderLevel" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReorderLevel" ErrorMessage="Stationary reorder level cannot be null"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="ReorderRangeVal" runat="server" ControlToValidate="txtReorderLevel" ErrorMessage="ReOreder Value should be aWhole Number" MaximumValue="9999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblReorderQty" runat="server" Text="Reorder Qty"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtReorderQty" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReorderQty" ErrorMessage="Stationary reorder qty cannot be null"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="ReorderQtyRangeVal" runat="server" ControlToValidate="txtReorderQty" ErrorMessage="ReOreder Value should be aWhole Number" MaximumValue="9999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblUnitOfMeasure" runat="server" Text="Unit Of Measure"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtUnitOfMeasure" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUnitOfMeasure" ErrorMessage="Stationary unit of measure cannot be null"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblPrice1" runat="server" Text="Price1"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtPrice1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="price1ReqFieldVal" runat="server" ControlToValidate="txtPrice1" ErrorMessage="Price1  cannot be empty"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price1RangeVal" runat="server" ControlToValidate="txtPrice1" ErrorMessage="Price1 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblPrice2" runat="server" Text="Price2"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtPrice2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="price2ReqFieldVal" runat="server" ControlToValidate="txtPrice2" ErrorMessage="Price2  cannot be empty"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price2RangeVal" runat="server" ControlToValidate="txtPrice2" ErrorMessage="Price2 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblprice3" runat="server" Text="price3"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtPrice3" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="price3ReqFieldVal" runat="server" ControlToValidate="txtPrice3" ErrorMessage="Price3  cannot be empty"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price3RangeVal" runat="server" ControlToValidate="txtPrice3" ErrorMessage="Price3 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="lblSupplier1" runat="server" Text="Supplier1"></asp:Label>
                </td>
                <td class="auto-style2">
        <asp:DropDownList ID="DDSupplier1" runat="server">
        </asp:DropDownList>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblSupplier2" runat="server" Text="Supplier2"></asp:Label>
                </td>
                <td>
        <asp:DropDownList ID="DDSupplier2" runat="server">
        </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblSupplier3" runat="server" Text="Supplier3"></asp:Label>
                </td>
                <td>
        <asp:DropDownList ID="DDSupplier3" runat="server">
        </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" OnClick="Button2_Click" Text="Clear" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    
</asp:Content>
