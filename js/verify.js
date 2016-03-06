function enableSubmit(bool) {
    if (bool) {
        $("#content_signupBt").attr("class", "signupBt");
        $("#signupRs").attr("class", "resetBt");
    } else {
        $("#content_signupBt").attr("class", "none");
        $("#signupRs").attr("class", "resetBt_2");
    }
        
}

function v_submitbutton() {
    for (f in flags) if (!flags[f]) {
        enableSubmit(false);
        return;
    }
    enableSubmit(true);
}

var flags = [false, false, false, false];
//邮箱验证，网上找到的正则
var RegEmail = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;

function registerForm_lineState(name, state, msg) {
    if (state == "none")
    {
        $("#input_" + name + " div").attr("class", "none");
        return;
    }
    if (state == "corect")
    {
        $("#input_" + name + " div").attr("class", "corect");
        return;
    }
    $("#input_" + name + " div").attr("class", "error");
    $("#input_" + name + " span").text(msg);
}



function v_name() {
    var name = $("#userNameTb").val();
    var isExist = false;
    $.ajax({
        type: "POST",
        async: false,
        url: "../IsExist.ashx",
        data:{name:name},
        success: function (msg) {
            if (msg == "true")
                isExist = true;
        }
    });
    if (name.length == 0) {
        registerForm_lineState("userNameTb", "error", "请输入用户名");
        flags[1] = false;
    } else {
           if (isExist) {
               registerForm_lineState("userNameTb", "error", "用户名已存在");
               flags[1] = false;
            }else {
               if (name.length < 6) {
                   registerForm_lineState("userNameTb", "error", "必须多于或等于6个字符");

               } else {
                   if (name.length > 32) {
                       registerForm_lineState("userNameTb", "error", "必须少于32个字符");
                       flags[1] = false;
                   } else {
                       registerForm_lineState("userNameTb", "corect", "");
                       flags[1] = true;
                   }
               }
        }
    }
    v_submitbutton();
}

function v_password() {
    var password = $("#userPwdTb").val();
    if (password.length < 6) {
        registerForm_lineState("userPwdTb", "error", "必须多于或等于6个字符");
        flags[2] = false;
    } else {
        if (password.length > 16) {
            registerForm_lineState("userPwdTb", "error", "必须少于或等于16个字符");
            flags[2] = false;
        } else {
            registerForm_lineState("userPwdTb", "corect", "");
            flags[2] = true;
        }
    }
    v_repeat();
    v_submitbutton();
}

function v_repeat() {
    if (!flags[2]) {
        registerForm_lineState("userPwdSTb", "none", "");
        return;
    }
    if ($("#userPwdTb").val() != $("#userPwdSTb").val()) {
        registerForm_lineState("userPwdSTb", "error", "密码不一致");
        flags[3] = false;
    } else {
        registerForm_lineState("userPwdSTb", "corect", "");
        flags[3] = true;
    }
    v_submitbutton();
}
function v_email() {
    var userEmailTb = $("#userEmailTb").val();
    if (!RegEmail.test(userEmailTb)) { registerForm_lineState("userEmailTb", "error", "邮箱格式不正确"); flags[0] = false; enableSubmit(false); }
    else { registerForm_lineState("userEmailTb", "corect", ""); flags[0] = true; }
    v_submitbutton();
}
