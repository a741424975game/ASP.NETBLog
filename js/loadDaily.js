var totalDailyPage;

var onPage = 1;

var userName;

function getTotalDailyPage() {
    var action = "getTotalDailyPage"
    $.ajax({
        type: "POST",
        async: false,
        url: "CountDailyPageNum.ashx",
        data: { action: action },
        success: function (result) {
            totalDailyPage = result;
            //alert(totalDailyPage);
        }
    })
}

function loadPageNum() {
    var action = "load";
    var pageNum;
    getTotalDailyPage()
    $.ajax({
        type: "POST",
        async: false,
        url: "CountDailyPageNum.ashx",
        data: { action: action },
        success: function (result) {
            pageNum = result;
        }
    })
    if (pageNum == totalDailyPage) {
        $("#nextDailyPageBt").attr("class", "none");
        //alert("true");
        //alert(pageNum);
        //alert(totalDailyPage);
    } 
    else {
        $("#nextDailyPageBt").attr("class", "pageChangeBottom");
        //alert("false");
        //alert(pageNum);
        //alert(totalDailyPage);
        }
    $("#pageNum").text(pageNum);
    $("#totalPage").text(totalDailyPage);
    loadDaily(pageNum);
}

function firstPage() {
    var action = "first"
    var pageNum
    $.ajax({
        type: "POST",
        async: false,
        url: "CountDailyPageNum.ashx",
        data: { action: action },
        success: function (result) {
            pageNum = result;
        }
    })
    $("#pageNum").text(pageNum);
    loadPageNum();
}

function nextPage() {
    var action = "plus"
    var pageNum
    $.ajax({
        type: "POST",
        async: false,
        url: "CountDailyPageNum.ashx",
        data: { action: action },
        success: function (result) {
            pageNum = result;
        }
    })
    $("#pageNum").text(pageNum);
    loadPageNum();
}
function previousPage() {
    var action = "minus"
    var pageNum
    $.ajax({
        type: "POST",
        async: false,
        url: "CountDailyPageNum.ashx",
        data: { action: action },
        success: function (result) {
            pageNum = result;
        }
    })
    $("#pageNum").text(pageNum);
    loadPageNum();
}

function loadDaily(pageNum) {
    $.ajax({
        type: "POST",
        async: false,
        url: "LoadDaily.ashx",
        timeout:3000,
        data: { pageNum: pageNum},
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
        var json = eval(data); //数组        
        if (json != "") {
            $("#pageAndBottom").attr("class", "pageAndBottom");
            $("#list").html('');

        //    //eval将字符串转成对象数组  
        //    //var json = { "dailyTitle": "xxx", "date": "xxxx-xx-xx"};  
        //    //json = eval(json);  

            var json = eval(data); //数组     
            
            $.each(json, function (index, item) {
                //循环获取数据    
                var dailyId = json[index].dailyId;
                var dailyContent = json[index].dailyContent;
                var dailyTitle = json[index].dailyTitle;
                var date = json[index].date;
                $("#list").html($("#list").html() +
                    "<li><div class='arrow_box'><div class='ti'></div><div class='ci'></div><h2 class='title dailyTitle'><a class='dailyTitlelink' href='daily.aspx?dailyId="+dailyId+"'>"
                    + dailyTitle +
                    "</a></h2><ul class='textinfo'>"
                    + dailyContent +
                    "</ul><ul class='details'><li class='likes'><a href='#'><i class='fa fa-heart-o'></i>10</a></li><li class='comments'><a href='#'><i class='fa fa-commenting-o'></i>34</a></li><li class='icon-time'><a href='#'>"
                    + date +
                    "</a></li></ul></div></li><li>");
            });

            if (pageNum != "1") {
                $("#previousDailyPageBt").attr("class", "pageChangeBottom");
                $("#firstDailyPageBt").attr("class", "pageChangeBottom");
            } else {
                $("#previousDailyPageBt").attr("class", "none");
                $("#firstDailyPageBt").attr("class", "none");
            }
            //nextPageIsNULL(pageNum);
        }
        else {
            $("#list").html('<h2>你还没有添加任何日常┑(￣Д ￣)┍~</h2>');
            $("#pageAndBottom").attr("class", "none");
        }
    }
}

    //function nextPageIsNULL(pageNum) {
    //    var action = "checkNextPage";
    //    var nextPage = "IsNotNULL";
    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "CountDailyPageNum.ashx",
    //        data: { action: action, pageNum: pageNum },
    //        success: function (result) {
    //            nextPage = result;
    //        }

    //    })
    //    if (nextPage == "NULL") {
    //        $("#nextDailyPageBt").attr("class", "none");
    //    } else {
    //        $("#nextDailyPageBt").attr("class", "pageChangeBottom");
    //    }
    //}





