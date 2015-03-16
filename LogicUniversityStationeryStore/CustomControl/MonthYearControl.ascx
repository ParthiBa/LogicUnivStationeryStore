<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MonthYearControl.ascx.cs" Inherits="LogicUniversityStationeryStore.customControl.MonthYearControl" %>
<asp:DropDownList ID="month" runat="server">
    <asp:ListItem text="Jan" value="01-01 01-31">January</asp:ListItem>
    <asp:ListItem text="Feb" value="02-01 02-28">February</asp:ListItem>
    <asp:ListItem text="Feb" value="03-01 03-31">March</asp:ListItem>
    <asp:ListItem text="Feb" value="04-01 04-30">April</asp:ListItem>
    <asp:ListItem text="Feb" value="05-01 05-31">May</asp:ListItem>
    <asp:ListItem text="Feb" value="06-01 06-30">June</asp:ListItem>
    <asp:ListItem text="Feb" value="07-01 07-31">July</asp:ListItem>
    <asp:ListItem text="Feb" value="08-01 08-31">August</asp:ListItem>
    <asp:ListItem text="Feb" value="09-01 09-30">September</asp:ListItem>
    <asp:ListItem text="Feb" value="10-01 10-31">October</asp:ListItem>
    <asp:ListItem text="Feb" value="11-01 11-30">Novermber</asp:ListItem>
    <asp:ListItem text="Feb" value="12-01 12-31">December</asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID ="year" runat="server">
</asp:DropDownList>
    <asp:Button ID="btnAddMY" runat="server" Text="Add" OnClick="btnAddMY_Click"  CssClass="btn btn-success"/>

<br/>
    <asp:ListBox ID="listDate" runat="server" SelectionMode="Multiple" Height="83px" Width="199px">
    </asp:ListBox>
<br/>
    <asp:Button ID="btnRemoveMY" runat="server" Text="Remove" OnClick="btnRemoveMY_Click"  CssClass="btn btn-danger"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    

