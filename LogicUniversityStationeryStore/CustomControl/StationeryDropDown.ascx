<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StationeryDropDown.ascx.cs" Inherits="LogicUniversityStationeryStore.CustomControl.StationeryDropDown" %>
<%--need to add jquerydd js file in page wich it is used--%><%--<link rel="stylesheet" href="Scripts/JqueryUI/dd.css" />
            <script src="Scripts/jquery-2.1.3.min.js"></script>
    <script src="Scripts/JqueryUI/jquery.dd.min.js"></script>--%>

<script>
    $(document).ready(function (e) {
        try {
            $("#webmenu").msDropDown();
        } catch (e) {
            alert(e.message);
        }
        var x=$("#webmenu option:selected").text();
        console.log(x);

    });

    function setValue(x)
    {
        console.log(x);
        console.log('<%=txtGetValue.ClientID%>');
        document.getElementById('<%=txtGetValue.ClientID%>').value = x;
        $("#<%=txtGetValue.ClientID%>").text(x);
    }
</script>
 <select name="webmenu" id="webmenu" style="width: 266px"  onchange="setValue($('#webmenu option:selected').text())">
    <option value="clip" data-image="icons/IC_clip.jpg">Clip</option>
    <option value="envelope" data-image="icons/IC_envelope.jpg">Envelope</option>
    <option value="eraser" data-image="icons/IC_eraser.jpg">Eraser</option>
    <option value="exercise"  selected="selected" title="icons/IC_exercise.jpg">Exercise Book</option>
    <option value="file" data-image="icons/IC_file.jpg">File</option>
    <option value="highlighter" data-image="icons/IC_highlighter.jpg">Highlighter</option>
    <option value="pad" data-image="icons/IC_pad.jpg">Pad</option>
    <option value="paper" data-image="icons/IC_paper.jpg">Paper</option>
    <option value="pen" data-image="icons/IC_pen.jpg">Pen</option>
    <option value="puncher" data-image="icons/IC_puncher.jpg">Puncher</option>
    <option value="ruler" data-image="icons/IC_ruler.jpg">Ruler</option>
    <option value="scissors" data-image="icons/IC_scissors.jpg">Scissors</option>
    <option value="sharpener" data-image="icons/IC_sharpener.jpg">Sharpener</option>
    <option value="shorthand" data-image="icons/IC_shorthand.jpg">Shorthand</option>
    <option value="stapler" data-image="icons/IC_stapler.jpg">Stapler</option>
    <option value="tacks" data-image="icons/IC_tacks.jpg">Tacks</option>
    <option value="tape" data-image="icons/IC_tape.jpg">Tape</option>
    <option value="Tparency" data-image="icons/IC_Tparency.jpg">Tparency</option>
    <option value="tray" data-image="icons/IC_tray.jpg">Tray</option>
  </select><asp:TextBox ID="txtGetValue" style="display:none" runat="server"></asp:TextBox>

