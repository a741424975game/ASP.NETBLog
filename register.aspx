<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
注册新用户
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <script type="text/javascript" src="js/verify.js"></script>
    <h1>用户注册</h1>
    <div class="register-form">
        <div><a href="homePage.aspx" class="close"></a></div>
        <div class="head-info">
            <label class="lbl-1"></label>
            <label class="lbl-2"> </label>
            <label class="lbl-3"> </label>
        </div>
        <div class="clear"> </div>
    <form id="signinForm" runat="server"  >
        <div class="register-input">
                <div id="input_userNameTb">
                    <input  id="userNameTb" name="userNameTb"   type="text" class="input-username" placeholder="用户名"  autocomplete="off" onblur="v_name();" onkeyup="v_name();"/>
                    <div class="error">
                        <span class="username">不得为空</span>
                     </div>
                </div>
                <div id="input_userPwdTb">
                    <input id="userPwdTb" name="userPwdTb"  type="password" class="input-password" placeholder="密码"  autocomplete="off" onblur ="v_password();" onkeyup="v_password();"/><br />
                    <div class="error">
                        <span class="password">必须多于或等于6个字符</span>
                     </div>
                </div>
                <div id="input_userPwdSTb">
                    <input id="userPwdSTb"  name="userPwdSTb" type="password" class="input-password" placeholder="重复密码"  autocomplete="off" onblur="v_repeat();" onkeyup="v_repeat();"/><br />
                    <div class="none">
                        <span class="repeat"></span>
                     </div>
                </div>
                <div id="input_userEmailTb" >
                        <input id="userEmailTb" name="userEmailTb"  type="text" class="input-email" placeholder="邮箱"  autocomplete="off"  onblur="v_email();" onkeyup="v_email();"/><br />
                        <div class="none">
                            <span class="email"></span>
                         </div>
                </div>

        </div>
                   <div>
                        <asp:Button ID="signupBt" runat="server" OnClick="signupBt_Click" CssClass="none" Text="注册" />
                        <button id="signupRs"   class="resetBt_2"  type="reset">重置</button>

            </div>
    </form>
</div>
    </asp:Content>
