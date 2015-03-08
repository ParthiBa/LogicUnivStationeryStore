<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="LogicUniversityStationeryStore.test1" %>
<%@ Register src="CustomControl/StationeryDropDown1.ascx" tagname="StationeryDropDown1" tagprefix="uc1" %>
<%@ Register Src="~/CustomControl/spinner.ascx" TagPrefix="uc1" TagName="spinner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     function setupDropDown()
     {
         try{
             $(".webmenu").msDropdown();
         }
         catch(e)
         {
             console.log("Exception StationaryDropDown " + e);
         }
     }

     function alertaa()
     {
         alert("hello");
     }
 </script>
<script src="Scripts/ProJs/DelgationDatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:StationeryDropDown1 ID="StationeryDropDown11" runat="server" />

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:TextBox ID="calendar" runat="server" CssClass="calendarClass"></asp:TextBox>
    <br />
    <uc1:spinner ID="spinner1" runat="server" />

    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

    <asp:Label ID="Label1" runat="server" Text="lbldisp"></asp:Label>

</asp:Content>
