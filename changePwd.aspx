<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changePwd.aspx.cs" Inherits="changePwd" MasterPageFile="MasterPage.master" %>

<asp:Content ContentPlaceHolderID="title" runat="server">
   更改密码
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <script type="text/javascript" src="js/changePwd.js"></script>
            <h1>更改密码</h1>
                <div class="pWdChange-form">
        <div><a href="homePage.aspx" class="close"></a></div>
        <div class="head-info">
            <label class="lbl-1"></label>
            <label class="lbl-2"> </label>
            <label class="lbl-3"> </label>
        </div>
        <div class="clear"> </div>
    <form id="pWdChangeForm" runat="server" >
        <div class="pWdChange-input">
                <div id="input_userOldPwd">
                    <input  id="userOldPwdTb" name="userOldPwdTb"   type="password" class="input-oldPwd" placeholder="旧密码"  autocomplete="off" onblur=" checkOldPwd()" onkeyup=" checkOldPwd()"/>
                    <div class="error">
                        <span class="oldPwd">请输入旧密码</span>
                     </div>
                </div>
                <div id="input_userPwdTb">
                    <input id="userPwdTb" name="userPwdTb"  type="password" class="input-password" placeholder="新密码"  autocomplete="off" onblur ="v_password()" onkeyup="v_password()"/><br />
                    <div class="error">
                        <span class="password">必须多于或等于6个字符</span>
                     </div>
                </div>
                <div id="input_userPwdSTb">
                    <input id="userPwdSTb"  name="userPwdSTb" type="password" class="input-password" placeholder="重复密码"  autocomplete="off" onblur="v_repeat()" onkeyup="v_repeat()"/><br />
                    <div class="none">
                        <span class="repeat"></span>
                     </div>
                </div>

        </div>
                  <div>
                        <asp:Button ID="changePwdBt" runat="server" OnClick="changePwdBt_Click" CssClass="none" Text="提交"/>
                        <button id="changePwdRs"   class="resetBt_2"  type="reset">重置</button>

            </div>
    </form>
</div>
</asp:Content>
