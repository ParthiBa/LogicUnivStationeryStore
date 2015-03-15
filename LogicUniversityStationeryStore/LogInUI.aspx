<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogInUI.aspx.cs" Inherits="LogicUniversityStationeryStore.LogInUI" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Mainhead" runat="server">
    <style type="text/css">
        .icon-bar {
            font-style: italic;
        }
        .field-validation-error {
            font-style: italic;
        }
        .centered {
  position: fixed;

  left: 50%;
  /* bring your own prefixes */
  transform: translate(-50%, -50%);
}
        .mylabel
        {


        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--    <div style="width:599px; margin:250px auto; padding:20px 0; text-align:left;background-color:#998fc4">--%>
    <div style="width:599px; margin:250px auto; padding:20px 0; text-align:left;background-color:#998fc4" class="centered">
    &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="User Email" style="font-weight: 700; color: #FFFFFF" ></asp:Label>
    <br/>&nbsp;&nbsp;<asp:TextBox ID="boxEmail"   runat="server" Width="278px" type="email" CssClass="form-control"></asp:TextBox>
        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="The user Email field is required." ControlToValidate="boxEmail" CssClass="icon-bar" Font-Bold="True"></asp:RequiredFieldValidator>
    <br/><br/><br/>
        &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Password" style="font-weight: 700; color: #FFFFFF; text-align: center" ></asp:Label>
    <br/>&nbsp;&nbsp;<asp:TextBox ID="boxPass" runat="server" TextMode="Password" EnableTheming="True" Width="266px" CssClass="form-control"></asp:TextBox>
        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="boxPass" CssClass="field-validation-error" ErrorMessage="The password field is required." Font-Bold="True"></asp:RequiredFieldValidator>
    <br/> <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="227px" CssClass="btn btn-primary loginbtn"/>
         &nbsp;&nbsp;</div>
</asp:Content>
