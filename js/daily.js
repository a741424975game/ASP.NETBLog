var editerName;
var dailyContent;
var dailyTitle;
var date;
var userName;
var state = 0;


function GetQueryString(name) {                                          //获取url参数 
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function getUserName() {
    var action = "getUserName";
    $.ajax({
        type: "POST",
        async: false,
        url: "GetDaily.ashx",
        data: { action:action},
        success: function (result) {
            userName=result
        }
    })
}

function getDailyById() {
    var action = "getDailyById";
    var dailyId=GetQueryString("dailyId");
    getUserName();
    $.ajax({
        type: "POST",
        async: false,
        url: "GetDaily.ashx",
        data: { action:action,dailyId: dailyId},
        success: function (result) {
            var json = eval(result);
            $.each(json, function (index, item) {
                //循环获取数据    
             editerName = json[index].userName;
            dailyContent = json[index].content;
            dailyTitle = json[index].title;
            date = json[index].date;
            editerName = $.trim(editerName); //去掉字符串中的空格
            
            $("#dailyTitle").val(dailyTitle);
            $("#editor-content").html(dailyContent);

            if (editerName == userName) {
                $("#content_deleteDaily").attr("class", "deleteBt");
                $("#content_editDaily").attr("class", "editBt");
            } else {
                $("#content_deleteDaily").attr("class", "none");
                $("#content_editDaily").attr("class", "none");
            }
            $("h2").text(dailyTitle);
            $("#text").html("<br/>" + dailyContent + "<br/>" );
            $("#dateAndName").html("<br/>" + date + "<br/>" + editerName + "<br/>");
            });
        }
    })
}



function editDaily() {
    if (state==0) {
        $("#dailyEditer").removeAttr("class");
        state = 1;
    } else {
        $("#dailyEditer").attr("class", "none");
        state = 0;
    }


}

function clearTextarea() {
    $("#dailyTitle").val("");
    $("#editor-content").html("");
}

function goBottom() {
    window.scrollTo(0, document.documentElement.scrollHeight - document.documentElement.clientHeight);
}