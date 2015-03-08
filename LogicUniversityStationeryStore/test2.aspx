<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="LogicUniversityStationeryStore.test2" %>

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
    
    </div>
    </form>
</body>
</html>
