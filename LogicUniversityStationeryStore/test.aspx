<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="LogicUniversityStationeryStore.test" %>

<%@ Register src="CustomControl/spinner.ascx" tagname="spinner" tagprefix="uc1" %>

<%@ Register src="CustomControl/StationeryDropDown.ascx" tagname="StationeryDropDown" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
 
    </script>
    <link rel="stylesheet" href="Scripts/JqueryUI/dd.css" />
            <script src="Scripts/jquery-2.1.3.min.js"></script>
    <script src="Scripts/JqueryUI/jquery.dd.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    
        <asp:Label ID="lblT" runat="server" Text="Label"></asp:Label>
    

    
    </div>

        <p>
           
        <uc2:StationeryDropDown ID="StationeryDropDown1" runat="server" />
           
    </form>
</body>
</html>
