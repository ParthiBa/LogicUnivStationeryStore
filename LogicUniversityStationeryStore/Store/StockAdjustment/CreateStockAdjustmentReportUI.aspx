<%@ Page Title="" Language="C#" MasterPageFile="~/Home/StationeryMaster.master" AutoEventWireup="true" CodeBehind="CreateStockAdjustmentReportUI.aspx.cs" Inherits="LogicUniversityStationeryStore.Store.StockAdjustment.CreateStockAdjustmentReportUI" %>
<%@ MasterType VirtualPath="~/Home/StationeryMaster.master"%>
<%@ Register src="../../CustomControl/StationeryDropDown1.ascx" tagname="StationeryDropDown" tagprefix="uc1" %>

<%@ Register src="../../CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc2" %>

<%@ Register src="../../CustomControl/Spinner2.ascx" tagname="Spinner2" tagprefix="uc3" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="StationeryHead" runat="server">
    <script>

</script>
      
        <style type="text/css">
        .auto-style11 {
            width: 100%;
        }
        .auto-style18 {
            height: 22px;
        }
        .auto-style19 {
            height: 22px;
            width: 154px;
            font-weight: 700;
        }
        .auto-style20 {
            width: 154px;
        }
        .auto-style21 {
            width: 154px;
            height: 47px;
        }
        .auto-style22 {
            height: 47px;
        }
        .auto-style23 {
            width: 154px;
            height: 21px;
        }
        .auto-style24 {
            height: 21px;
        }
        .left{
            float:left;
            font-weight: 700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="StationeryBody" runat="server">


   <div>
    
        <br />
        <table style="width:100%;">
            <tr>
                <td colspan="2" class="auto-style19">
                  <span class="left"><asp:Literal ID="ltSelectCate" runat="server" Text="Select Category:" ></asp:Literal></span>  
                </td>
                <td class="auto-style18">
    
        <asp:Label ID="lblDate" runat="server" Text="Date:" style="font-weight: 700"></asp:Label>
   
                    <asp:Label ID="lblShowDate" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
                </td>
             
            </tr>
            <tr>
                <td colspan="2" class="auto-style20">
                    <asp:DropDownList ID="stationaryDropDownList" runat="server" AutoPostBack="True" DataTextField="category" DataValueField="category" OnSelectedIndexChanged="stationaryDropDownList_SelectedIndexChanged" CssClass="form-control" Width="498px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
               
            </tr>
            <tr>
                <td colspan="2" class="auto-style19">
             <span class="left"><asp:Literal ID="ltCateItem" runat="server" Text="Select Item based Category" ></asp:Literal></span>       
                </td>
                <td class="auto-style18">
                </td>
               
            </tr>
              <tr>
                <td colspan="2" class="auto-style21">
                    <asp:DropDownList ID="ddlStationarItemsbyCat" runat="server" OnSelectedIndexChanged="ddlStationarItemsbyCat_SelectedIndexChanged" AutoPostBack="True" DataTextField="description" DataValueField="code" CssClass="form-control" style="float:left;" Width="493px">
                    </asp:DropDownList>
                  </td>
                <td class="auto-style22">
                    &nbsp;</td>
                
            </tr>

                          <tr>
                <td colspan="2" class="auto-style19">
                  <span class="left"><asp:Literal ID="ltqua" runat="server" Text="Quantity"  ></asp:Literal></span>  
                              </td>
                <td class="auto-style18"></td>
                
            </tr>

                          <tr>
                <td colspan="2" class="auto-style20">
        
                 <span class="left">   <uc3:Spinner2 ID="Spinner21" runat="server" />   Measured In:  <asp:Literal ID="lblUnitOfMeasure" runat="server" Text="dozen"></asp:Literal>   </span>
                 
                   
                    <br />
                   
                   
                              </td>
                <td>&nbsp;</td>
                
            </tr>

                          <tr>
                <td colspan="2" class="auto-style23">
               <span class="left">  <asp:Literal ID="ltAmit" runat="server" Text="Amount" ></asp:Literal></span>   
                              </td>
                <td class="auto-style24 left"></td>
                
            </tr>

                       <tr>
                <td colspan="2" class="auto-style20">
            <span class="left"> <asp:Label ID="lblAmountDisp" runat="server"></asp:Label></span>       
                           </td>
                <td>&nbsp;</td>
                
            </tr>
                       <tr>
                <td colspan="2" class="auto-style20">
                    <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" placeholder="Please type the reason here " Height="59px" Width="501px"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReason" ErrorMessage="Please add Reason " BackColor="White" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                           </td>
                <td>&nbsp;</td>
                
            </tr>
        </table>
        <br />
    
           <asp:Button ID="btnAddItem" runat="server" Text="Add" OnClick="btnSubmitItem_Click"  CssClass="btn btn-primary" Height="48px" Width="146px"/>
        
        <br />
        <br />
        <br />
        
        <asp:GridView ID="GrdDiscrepDetails" runat="server" AutoGenerateColumns="False" style="margin-right: 1px" CssClass="table" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GrdDiscrepDetails_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="No" DataField="No" />
                <asp:TemplateField HeaderText="ItemCode">
                    <ItemTemplate>
                        <asp:Label ID="lblItemCode" runat="server"  Text='<%#Bind("ItemNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ItemName" HeaderText="StationaryItem" />
                <asp:BoundField DataField="quantity" HeaderText="quantity" />
                <asp:BoundField DataField="Reason" HeaderText="Reason" />
                <asp:BoundField DataField="amount" HeaderText="Amount" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    
    
        <br />
        <asp:Button ID="btnSubmitAdjustment" cssClass="btn btn-success" runat="server" Height="33px" Text="Submit " Width="242px" OnClick="btnSubmitAdjustment_Click" />
        <br />
        <br />
        <br />
        <br />
        
    
        <br />
    
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    
        <br />
        Total Amount : <asp:Label ID="lblAmount" runat="server"></asp:Label>
    
    
    </div>
</asp:Content>

  
