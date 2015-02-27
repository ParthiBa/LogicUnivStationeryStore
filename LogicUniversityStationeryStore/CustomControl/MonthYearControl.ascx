<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MonthYearControl.ascx.cs" Inherits="LogicUniversityStationeryStore.customControl.MonthYearControl" %>
<asp:DropDownList ID="month" runat="server">
    <asp:ListItem value="Jan">January</asp:ListItem>
    <asp:ListItem value="Feb">February</asp:ListItem>
    <asp:ListItem value="Mar">March</asp:ListItem>
    <asp:ListItem value="Apr">April</asp:ListItem>
    <asp:ListItem value="May">May</asp:ListItem>
    <asp:ListItem value="Jun">June</asp:ListItem>
    <asp:ListItem value="Jul">July</asp:ListItem>
    <asp:ListItem value="Aug">August</asp:ListItem>
    <asp:ListItem value="Sep">September</asp:ListItem>
    <asp:ListItem value="Oct">October</asp:ListItem>
    <asp:ListItem value="Nov">Novermber</asp:ListItem>
    <asp:ListItem value="Dec">December</asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID ="year" runat="server">
</asp:DropDownList>
<br/>
    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Height="83px" Width="199px">
    <asp:ListItem></asp:ListItem>
    </asp:ListBox>
<br/>
    <asp:Button ID="btnRemoveMY" runat="server" Text="Remove" OnClick="btnRemoveMY_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAddMY" runat="server" Text="Add" OnClick="btnAddMY_Click" />

<script src="../Scripts/ProJs/loadMonthYears.js"></script>