<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="ManageDepartment.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.Department.ManageDepartment" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">
        .auto-style11 {
        width: 73%;
        text-align: left;
    }
        .auto-style2 {
            width: 100%;
        }
    .auto-style12 {
        text-align: left;
        width: 586px;
    }
    .auto-style13 {
        width: 144%;
        text-align: left;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
     
        <div style="width:828px">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True"
                Font-Size="XX-Large" ForeColor="black" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manage Department Details"></asp:Label>

        </div>

        <br />
        <br />
        <br />
   
        <table style="margin-left:230px; height: 455px; width: 706px;">
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label1" runat="server" Text="Department Code :"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:DropDownList ID="codebox" runat="server" DataTextField="code" DataValueField="code" OnSelectedIndexChanged="codebox_SelectedIndexChanged">
                    </asp:DropDownList>

                    <asp:Button ID="BtnRetrieve" Text="Retrieve" runat="server" OnClick="BtnRetrieve_Click" Width="83px" CssClass="btn btn-primary"/>

                </td>
                <td class="text-left">
                    &nbsp;</td>
            </tr>

        <br />
        <br />
       
            <tr>
                <td class="auto-style12">
                    
                </td>
                <td class="auto-style11">
                    &nbsp;</td>

            </tr>


            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label2" runat="server" Text="Department Name :"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="namebox" runat="server"></asp:TextBox>

                </td>

            </tr>

            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label8" runat="server" Text="Head's Name :"></asp:Label>
                </td>
                <td class="auto-style11">

                    <asp:DropDownList ID="Drop2" runat="server" DataTextField="empName" DataValueField="empName" Width="136px">
                    </asp:DropDownList>

                </td>
            </tr>

            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label3" runat="server" Text="Contact Name:"></asp:Label>
                    &nbsp;</td>
                <td class="auto-style11">
                    <asp:TextBox ID="contactNamebox" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;   </td>
            </tr>

            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label4" runat="server" Text="Telephone No:"></asp:Label>
                    &nbsp;</td>
                <td class="auto-style11">
                    <asp:TextBox ID="telNobox" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label5" runat="server" Text="Fax No :"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="faxNobox" runat="server"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td class="auto-style12">&nbsp;   </td>
            </tr>



            <tr>

                <td class="auto-style12">
                    <asp:Label ID="Label7" runat="server" Text="Representative Name :"></asp:Label>
                </td>
                <td class="auto-style11">


                    <asp:DropDownList ID="Drop1" runat="server" Width="141px" DataSourceID="SqlDataSource2" DataTextField="empName" DataValueField="empName">
                    </asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT [empName] FROM [Employee]"></asp:SqlDataSource>

                </td>

            </tr>



            <tr>

                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style11">


            <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" CssClass="btn btn-primary" Height="32px"/>

                </td>

            </tr>
        </table>
  
        <div style="text-align: center">
            <br />
            <br />
  
        </div>
    

</asp:Content>
