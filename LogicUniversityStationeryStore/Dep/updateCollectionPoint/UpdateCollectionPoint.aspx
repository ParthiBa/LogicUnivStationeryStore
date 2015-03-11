<%@ Page Title="" Language="C#" MasterPageFile="~/Home/DepartMentMaster.master" AutoEventWireup="true" CodeBehind="UpdateCollectionPoint.aspx.cs" Inherits="LogicUniversityStationeryStore.UpdateCollectionPoint" %>
<%@ MasterType VirtualPath="~/Home/DepartMentMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DepartmentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DepartmentContent" runat="server">
     <table class="auto-style11">
            <tr>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="height: 200px">
                    </td>
                <td class="auto-style4" style="height: 200px">
                    <br />
                    <asp:GridView ID="CPGridView" runat="server"   Width="209px" AllowCustomPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="CPGridView_SelectedIndexChanged" >
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false"/>
                            <asp:BoundField DataField="place" HeaderText="place" SortExpression="place" />
                            <asp:BoundField DataField="timeSlot" HeaderText="timeSlot" SortExpression="timeSlot" />
                            <asp:TemplateField HeaderText="Select">
                               <ItemTemplate>
                                    <input type="radio" name="radio" value="<%#Eval("id") %>">"
                                   <asp:RadioButton ID="selectedItem" runat="server" OnCheckedChanged="selectedItem_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT [place], [timeSlot], [id] FROM [CollectionPoint]"></asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click"  />
                </td>
            </tr>
        </table>
</asp:Content>

