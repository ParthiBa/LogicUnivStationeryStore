<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Spinner2.ascx.cs" Inherits="LogicUniversityStationeryStore.CustomControl.Spinner2" %>
<script type="text/javascript">
    function setRangeLimit<%=uniqueKey%>(min, max) {

        var id = $("#<%=txtNumberOfItems.ClientID %>");
        id.attr("min", min);
        id.attr("max", max);

    }

</script>

<span>
<asp:TextBox ID="txtNumberOfItems"  type="number" runat="server" OnTextChanged="txtNumberOfItems_TextChanged" Width="84px" style="height: 22px" AutoPostBack="True"></asp:TextBox>
<asp:RangeValidator ID="RangeValidatortxt" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtNumberOfItems" Type="Integer"></asp:RangeValidator>

</span>
<br />


