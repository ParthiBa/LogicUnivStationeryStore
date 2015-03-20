<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="LogicUniversityStationeryStore.test2" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  

    <script src="Scripts/jquery-2.1.3.js"></script>
     <link rel="stylesheet" href="Scripts/JqueryUI/dotluv.css" />
     <script src="Scripts/JqueryUI/jquery-ui.js"></script>
     <script type="text/javascript">
         $(function () {

             $(".calendar").datapicker();

         });


     </script>



</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" CssClass="calendar"></asp:TextBox>
    
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RangeValidator" MaximumValue="10" MinimumValue="1" Type="Integer"></asp:RangeValidator>
    
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
