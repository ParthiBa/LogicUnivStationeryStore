<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="ManageDepartment.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.Department.ManageDepartment" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">
        .auto-style11 {
            width: 189px;
        }
        .auto-style2 {
            width: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
     
        <div style="text-align: center">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True"
                Font-Size="XX-Large" ForeColor="#FF3300" Text="Manage Department Details"></asp:Label>

        </div>

        <br />
        <br />
        <br />
    <center>
        <table style="text-align: left">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Department Code :"></asp:Label>
                </td>
                <td><asp:TextBox ID="codebox" runat="server"></asp:TextBox>
                   
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="codebox" ErrorMessage="Enter the Department Code "
                         ForeColor="Red" Display="Dynamic" ToolTip="Department code cannot be empty">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="BtnRetrieve" Text="Retrieve" runat="server" OnClick="BtnRetrieve_Click" Width="83px" /></td>
            </tr>

        </table>
        <br />
        <br />
        <table  style="text-align: left">

            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Department Name :"></asp:Label>
                </td>
                <td class="auto-style11"><asp:TextBox ID="namebox" runat="server"></asp:TextBox>
                  
                </td>
               
                <td class="auto-style2">&nbsp;</td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Head's Name :"></asp:Label>
                </td>
                <td class="auto-style11">
                   
                    <asp:DropDownList ID="Drop2" runat="server" DataSourceID="SqlDataSource1" DataTextField="empName" DataValueField="empName" Width="136px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT [empName] FROM [Employee]"></asp:SqlDataSource>
                   
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Contact Name:"></asp:Label>
                    &nbsp;</td>
                <td class="auto-style11">
                    <asp:TextBox ID="contactNamebox" runat="server"></asp:TextBox>
                  
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;   </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Telephone No:"></asp:Label>
                    &nbsp;</td>
                <td class="auto-style11">
                    <asp:TextBox ID="telNobox" runat="server"></asp:TextBox>
                   
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Fax No :"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="faxNobox" runat="server"></asp:TextBox>
                    
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>

            <tr>
                <td>&nbsp;   </td>
            </tr>



            <tr>

                <td>
                    <asp:Label ID="Label7" runat="server" Text="Representative Name :"></asp:Label>
                </td>
                <td class="auto-style11">
                    
                    
                    <asp:DropDownList ID="Drop1" runat="server" Width="141px" DataSourceID="SqlDataSource2" DataTextField="empName" DataValueField="empName">
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT [empName] FROM [Employee]"></asp:SqlDataSource>
                    
                </td>
                <td class="auto-style2">&nbsp;</td>

            </tr>
        </table>
        </center>
        <div style="text-align: center">
            <br />
            <br />
  
            <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" style="height: 26px" />
        </div>
    

</asp:Content>
