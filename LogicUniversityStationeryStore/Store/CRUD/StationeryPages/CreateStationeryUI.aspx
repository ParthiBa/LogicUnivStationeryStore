<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="~/Store/CRUD/Stationery/CreateStationeryUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.StationeryPages.createStationeryUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
        <style type="text/css">
            .auto-style11 {
            width: 135%;
                height: 477px;
            }
        .auto-style2 {
            height: 23px;
        }
            .auto-style12 {
                height: 44px;
            }
            .auto-style13 {
                height: 23px;
                width: 179%;
                text-align: left;
            }
            .auto-style14 {
                height: 44px;
                text-align: left;
                width: 179%;
            }
            .auto-style18 {
                text-align: left;
                width: 38%;
            }
            .auto-style19 {
                height: 44px;
                text-align: left;
                width: 38%;
            }
            .auto-style20 {
                height: 23px;
                width: 38%;
                text-align: left;
            }
            .auto-style21 {
                text-align: left;
                width: 20%;
            }
            .auto-style22 {
                height: 44px;
                text-align: left;
                width: 20%;
            }
            .auto-style23 {
                height: 23px;
                width: 20%;
                text-align: left;
            }
            .auto-style24 {
                text-align: left;
                width: 179%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
    <div>
            <h2> Create Stationery</h2>

        &nbsp;&nbsp;<br />
        <table class="auto-style11">
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblCode" runat="server" Text="Code"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode" ErrorMessage="Stationary code cannot be null"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">
    
        <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="txtCategory" runat="server" ></asp:TextBox>
                </td>
                <td class="auto-style24">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCategory" ErrorMessage="Stationary category cannot be null"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblDescreption" runat="server" Text="Descreption"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescription" ErrorMessage="Stationary descreption cannot be null"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblReorderLevel" runat="server" Text="ReorderLevel"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="txtReorderLevel" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReorderLevel" ErrorMessage="Stationary reorder level cannot be null"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="ReorderRangeVal" runat="server" ControlToValidate="txtReorderLevel" ErrorMessage="ReOreder Value should be an Whole Number" MaximumValue="9999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblReorderQty" runat="server" Text="Reorder Qty"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="txtReorderQty" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReorderQty" ErrorMessage="Stationary reorder qty cannot be null"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="ReorderQtyRangeVal" runat="server" ControlToValidate="txtReorderQty" ErrorMessage="ReOreder Value should be an Whole Number" MaximumValue="9999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblUnitOfMeasure" runat="server" Text="Unit Of Measure"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="txtUnitOfMeasure" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUnitOfMeasure" ErrorMessage="Stationary unit of measure cannot be null"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblPrice1" runat="server" Text="Price1"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="txtPrice1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
                    <asp:RequiredFieldValidator ID="price1ReqFieldVal" runat="server" ControlToValidate="txtPrice1" ErrorMessage="Price1  cannot be empty"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price1RangeVal" runat="server" ControlToValidate="txtPrice1" ErrorMessage="Price1 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style22">
        <asp:Label ID="lblPrice2" runat="server" Text="Price2"></asp:Label>
                </td>
                <td class="auto-style19">
        <asp:TextBox ID="txtPrice2" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style14">
                    <asp:RequiredFieldValidator ID="price2ReqFieldVal" runat="server" ControlToValidate="txtPrice2" ErrorMessage="Price2  cannot be empty"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price2RangeVal" runat="server" ControlToValidate="txtPrice2" ErrorMessage="Price2 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency"></asp:RangeValidator>
                </td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblprice3" runat="server" Text="price3"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="txtPrice3" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
                    <asp:RequiredFieldValidator ID="price3ReqFieldVal" runat="server" ControlToValidate="txtPrice3" ErrorMessage="Price3  cannot be empty"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="Price3RangeVal" runat="server" ControlToValidate="txtPrice3" ErrorMessage="Price3 Value should be a Number" MaximumValue="99999" MinimumValue="0" Type="Currency"></asp:RangeValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23">
        <asp:Label ID="lblSupplier1" runat="server" Text="Supplier1"></asp:Label>
                </td>
                <td class="auto-style20">
        <asp:DropDownList ID="DDSupplier1" runat="server">
        </asp:DropDownList>
                </td>
                <td class="auto-style13"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblSupplier2" runat="server" Text="Supplier2"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:DropDownList ID="DDSupplier2" runat="server">
        </asp:DropDownList>
                </td>
                <td class="auto-style24">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">
        <asp:Label ID="lblSupplier3" runat="server" Text="Supplier3"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:DropDownList ID="DDSupplier3" runat="server">
        </asp:DropDownList>
                </td>
                <td class="auto-style24">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style24">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style18">
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" Height="36px" CssClass="btn btn-success" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" OnClick="Button2_Click" Text="Clear"  CssClass="btn btn-warning"/>
                </td>
                <td class="auto-style24">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21"></td>
                <td class="auto-style18"></td>
                <td class="auto-style24"></td>
                <td></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    
</asp:Content>
