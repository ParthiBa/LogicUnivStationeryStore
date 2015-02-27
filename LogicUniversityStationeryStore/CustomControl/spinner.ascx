<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="spinner.ascx.cs" Inherits="LogicUniversityStationeryStore.CustomControl.WebUserControl1" %>
<%--need to add the jquery ui in page it is used--%>
<script type="text/javascript">
    function setLimit<%=uniqueKey%>(min, max) {

        var id = $("#<%=txtNumber.ClientID %>");
        id.attr("min", min);
        id.attr("max", max);

    }

</script>



<asp:TextBox ID="txtNumber" runat="server" type="number" Width="57px"></asp:TextBox>
<asp:RangeValidator ID="setRange" runat="server" ControlToValidate="txtNumber" ErrorMessage="RangeValidator" Type="Integer"></asp:RangeValidator>

