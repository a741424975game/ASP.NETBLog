

function load_ListofRecentDaily() {
    $.ajax({
        url: "LoadRecentDaily.ashx",
        type: 'POST',
        dataType: "JSON",
        timeout: 3000,
        async: true,
        cache: false,
        beforeSend: LoadFunction, //加载执行方法    
        error: erryFunction,  //错误执行方法    
        success: succFunction //成功执行方法    
    })
    function LoadFunction() {
        $("#list").html('加载中...');
    }
    function erryFunction() {
        alert("error");
    }
    function succFunction(data) {
        $("#list").html('');

        //eval将字符串转成对象数组  
        //var json = { "dailyTitle": "xxx", "date": "xxxx-xx-xx"};  
        //json = eval(json);  

        var json = eval(data); //数组         
        $.each(json, function (index, item) {
            //循环获取数据    
            var dailyId = json[index].dailyId;
            var dailyTitle = json[index].dailyTitle;
            var date = json[index].date;
            $("#list").html($("#list").html() + "<br/><a class='recentDailyTitlelink' href='daily.aspx?dailyId="+dailyId+"'>"
                + dailyTitle +
                "</a> - " + date + "<br/>");
        });
    }
}
function clearTextarea() {
    $("#dailyTitle").val("");
    $("#editor-content").html("");
}
