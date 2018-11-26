$(function () {
    showNum();

    var h = ($(window).height() - 200) + "px";
    alert(h);
    $("#selectExam").css("height",h); 
    
});


function showNum() {
    var html = "";
    for (var i = 0; i < 100; i++) {
        html += "<li><a href=\"javascript:;\" class='numberstyle'></a>" + i.toString() + "</li>";
    }

    $("#ExamNum").append(html);
}