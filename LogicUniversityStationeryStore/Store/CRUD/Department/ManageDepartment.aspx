<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="ManageDepartment.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.Department.ManageDepartment" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">
    <style type="text/css">
        .auto-style11 {
            width: 100%;
        }
        .auto-style2 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
     
        <div style="position:fixed " >
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True"
                Font-Size="XX-Large" ForeColor="#FF3300" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manage Department Details"></asp:Label>

        </div>

        <br />
        <br />
        <br />
   
        <table style="margin-left:230px">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Department Code :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="codebox" runat="server" DataSourceID="SqlDataSource3" DataTextField="code" DataValueField="code" OnSelectedIndexChanged="codebox_SelectedIndexChanged">
                    </asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT [code] FROM [Department]"></asp:SqlDataSource>

                    <asp:Button ID="BtnRetrieve" Text="Retrieve" runat="server" OnClick="BtnRetrieve_Click" Width="83px" />

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="codebox" ErrorMessage="Enter the Department Code "
                        ForeColor="Red" Display="Dynamic" ToolTip="Department code cannot be empty">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>

        <br />
        <br />
       
            <tr>
                <td>
                    
                </td>
                <td class="auto-style11">
                    &nbsp;</td>

                <td class="auto-style2">&nbsp;</td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Department Name :"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="namebox" runat="server"></asp:TextBox>

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

            <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" style="height: 26px" />

                </td>
                <td class="auto-style2">&nbsp;</td>

            </tr>
        </table>
  
        <div style="text-align: center">
            <br />
            <br />
  
        </div>
    

</asp:Content>
