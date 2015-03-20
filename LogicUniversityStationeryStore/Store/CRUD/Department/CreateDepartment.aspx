<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="CreateDepartment.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.CRUD.Department.CreateDepartment" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryHead" runat="server">

    <style type="text/css">
        .auto-style4 {
            width: 220px;
            text-align: left;
        }
        .auto-style5 {
            width: 108px;
        }
        .auto-style6 {
            text-align: left;
            width: 323px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StationeryBody" runat="server">
    <br /> <br />
    <br />

<div style="width:832px">
        <div >
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" 
                       Font-Size="XX-Large" ForeColor="black" Text="Create Department Details"></asp:Label>
        </div>
    <br />
    <br />
     <br />
 <table>
    
            <tr >
                <td class="auto-style4" >
                    <asp:Label ID="Label1" runat="server" Text="Department Code :"></asp:Label>
                </td>
                <td class="auto-style6" >
                    <asp:TextBox ID="codeBox" runat="server" Width="120px"></asp:TextBox>
      
                </td>
                <td class="auto-style5">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Department code cannot be empty" ControlToValidate="codeBox" 
                        ForeColor="Red" Display="Dynamic" ToolTip="Department code cannot be empty">*Department code cannot be empty</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style4" >
                    <asp:Label ID="Label2" runat="server" Text="Department Name :"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                    
                  
                </td>
                <td class="auto-style5">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="nameBox" Display="Dynamic" 
                        ErrorMessage="Department NAME cannot be empty" ForeColor="Red" ToolTip="Password Required">*Department NAME cannot be empty</asp:RequiredFieldValidator></td>
            </tr>
     <tr>
            <td class="auto-style4"> &nbsp;   </td>
            </tr>
    
    
            <tr>
                <td class="auto-style4" >
                    <asp:Label ID="Label3" runat="server" Text="Contact Name:"></asp:Label>
                &nbsp;</td>
                <td class="auto-style6" >
                    <asp:TextBox ID="contactNameBox" runat="server"></asp:TextBox>
                   
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="contactNameBox" Display="Dynamic" 
                        ErrorMessage="Contact Name Required" ForeColor="Red" 
                        ToolTip="Contact Name Required">*Contact Name Required</asp:RequiredFieldValidator></td>
            </tr>
          <tr>
                <td class="auto-style4" >
                    <asp:Label ID="Label4" runat="server" Text="Telephone No:"></asp:Label>
                &nbsp;</td>
                <td class="auto-style6">
                    <asp:TextBox ID="telNoBox" runat="server"></asp:TextBox>
                
                </td>
                <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="telNoBox" Display="Dynamic" 
                        ErrorMessage="Telephone No Required" ForeColor="Red" 
                        ToolTip="Telephone No Required">*Telephone No Required</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="telNoBox" ErrorMessage="Please Enter a ValidNumber" 
                        ForeColor="Red" 
                        ValidationExpression="^\d{7,8}$" 
                        ToolTip="Please Enter a Valid Number.">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label5" runat="server" Text="Fax No :"></asp:Label>
                </td>
                <td class="auto-style6" >
                    <asp:TextBox ID="faxNoBox" runat="server"></asp:TextBox>
                   
                </td>
                <td class="auto-style5">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="faxNoBox" Display="Dynamic" 
                        ErrorMessage="Fax NUMBER Required" ForeColor="Red" 
                        ToolTip="Fax No Required">*Fax NUMBER Required</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="faxNoBox" ErrorMessage="Please Enter a ValidNumber" 
                        ForeColor="Red" 
                        ValidationExpression="^\d{7,8}$" 
                        ToolTip="Please Enter a Valid Number.">*Please Enter a Valid Number.</asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style4" >
                    <asp:Label ID="Label6" runat="server" Text="Head's Name :"></asp:Label>
                </td>
                <td class="auto-style6" >
                    <asp:DropDownList ID="Drop1" runat="server" DataSourceID="SqlDataSource1" DataTextField="empName" DataValueField="empName" style="margin-left: 0px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT [empName] FROM [Employee]"></asp:SqlDataSource>
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
     
     
     
      
            <tr>
            <td class="auto-style4"> &nbsp;   </td>
            </tr>
     <tr>
                <td class="auto-style4" >
                    <asp:Label ID="Label7" runat="server" Text="Representative Name :"></asp:Label>
                </td>
                <td class="auto-style6" >
                    <asp:DropDownList ID="Drop2" runat="server" DataSourceID="SqlDataSource1" DataTextField="empName" DataValueField="empName">
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">&nbsp;</td>
       </tr>
        
           
        </table>
  
        <div>
            <br />
            <br />
             <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-success"/> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnCreate" Text="Create" runat="server" OnClick="BtnCreate_Click" CssClass="btn btn-primary" />
        </div>
        </div>








</asp:Content>
