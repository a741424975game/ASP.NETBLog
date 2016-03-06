function changeMainmune(userName, login_state) {
    if (login_state == true) {
        $("#welcome-info").attr("class","fa fa-user");
        $("#welcome-info").text("用户:" + userName);
        $("#add_daily_link").attr("class", "function");
        $("#login_link").attr("class", "none");
        $("#register_link").attr("class", "none");
        $("#loginout_link").attr("class", "function");
        $("#pWdChange_link").attr("class", "function");
        return;
    } else {
        $("#welcome-info").attr("class", "");
        $("#welcome_info").text("你还没有登陆┑(￣Д ￣)┍");
        $("#add_daily_link").attr("class", "none");
        $("#login_link").attr("class", "function");
        $("#register_link").attr("class", "function");
        $("#loginout_link").attr("class", "none");
        $("#pWdChange_link").attr("class", "none");
        return;
    }
}


function loadUserName() {
    var userName="";
    var login_state = false;
    $.ajax({
        type: "GET",
        async: true,
        url: "../Login.ashx",
        success: function (result) {
            if (result == "") {
                login_state = false;
                changeMainmune("", login_state);
            } else {
                login_state = true;
                userName = result;
                changeMainmune(userName, login_state);
            }
        }
    });
}
