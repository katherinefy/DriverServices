$(function () {

    //模拟考试、练习
    $(".dataOption").each(function () {
        var type = $(this).attr("datadata-field");
        if (type == "3") {
            showExam();
        }
        else {
            showPractice();
        }
    });
});

///显示模拟考试页面
function showExam() {
    var openid = '';
    var type = $("#selType").val();
    if (type == "") {
        alert("请选择需要模拟的类别");
        return;
    }
    else {
        window.location.href = "WeiExam.html?openid=" + openid + "&type=" + type;
    }
}

//显示练习页面
function showPractice(type) {
    var openid = '';
    var examType = $("#selType").val();
    if (examType == "") {
        alert("请选择需要练习的类别");
        return;
    }
    else {
        window.location.href = "WeiPractice.html?openid=" + openid + "&type=" + type + "&examType=" + examType;
    }
}