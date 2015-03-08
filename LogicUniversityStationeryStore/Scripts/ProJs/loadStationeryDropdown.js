$(function (e) {
    try {
        $(".webmenu").msDropDown();
    } catch (e) {
        alert(e.message);
        console.log(e);
        console.log($(".webmenu"));
    }
    var x = $(".webmenu option:selected").text();
    console.log(x);
});