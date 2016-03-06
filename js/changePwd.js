var userName;

var flags = [false, false, false];

function enableSubmit(bool) {
    if (bool) {
        $("#content_changePwdBt").attr("class", "signupBt");
        $("#changePwdRs").attr("class", "resetBt");
    } else {
        $("#content_changePwdBt").attr("class", "none");
        $("#changePwdRs").attr("class", "resetBt_2");
    }

}

function v_submitbutton() {
    for (f in flags) if (!flags[f]) {
        enableSubmit(false);
        return;
    }
    enableSubmit(true);
}

function pWdChangeForm_lineState(name, state, msg) {
    if (state == "none") {
        $("#input_" + name + " div").attr("class", "none");
        return;
    }
    if (state == "corect") {
        $("#input_" + name + " div").attr("class", "corect");
        return;
    }
    $("#input_" + name + " div").attr("class", "error");
    $("#input_" + name + " span").text(msg);
}

function getUserName() {
    var action = "getUserName";
    $.ajax({
        type: "POST",
        async: false,
        url: "ChangePwd.ashx",
        data: { action:action },
        success: function (result) {
            userName = result;
        }
    });
}

function checkOldPwd() {
    getUserName();
    var pWd = $("#userOldPwdTb").val();
    if (pWd=="") {
        lineState("userOldPwd", "error", "请输入旧密码");
    } else {
        var action = "checkOldPwd";
        $.ajax({
            type: "POST",
            async: false,
            url: "ChangePwd.ashx",
            data: { action: action, name: userName, pWd: pWd },
            success: function (result) {
                if (result == "true") {
                    pWdChangeForm_lineState("userOldPwd", "corect", "");
                } else {
                    pWdChangeForm_lineState("userOldPwd", "error", "密码不正确");
                }
                flags[0] = result;
            }
        });
    }
    v_submitbutton();
}

function v_password() {
    var oldpWd = $("#userOldPwdTb").val();
    var password = $("#userPwdTb").val();
    if (password.length < 6) {
        pWdChangeForm_lineState("userPwdTb", "error", "必须多于或等于6个字符");
        flags[2] = false;
    } else {
        if (password.length > 16) {
            pWdChangeForm_lineState("userPwdTb", "error", "必须少于或等于16个字符");
            flags[1] = false;
        } else {
            if (oldpWd==password) {
                pWdChangeForm_lineState("userPwdTb", "error", "新密码不能与旧密码相同");
                flags[1] = false;
            } else {
                pWdChangeForm_lineState("userPwdTb", "corect", "");
                flags[1] = true;
            }
        }
    }
    v_repeat();
    v_submitbutton();
}

function v_repeat() {
    if (!flags[1]) {
        pWdChangeForm_lineState("userPwdSTb", "none", "");
        return;
    }
    if ($("#userPwdTb").val() != $("#userPwdSTb").val()) {
        pWdChangeForm_lineState("userPwdSTb", "error", "密码不一致");
        flags[2] = false;
    } else {
        pWdChangeForm_lineState("userPwdSTb", "corect", "");
        flags[2] = true;
    }
    v_submitbutton();
}