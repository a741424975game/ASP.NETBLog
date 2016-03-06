<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" MasterPageFile="MasterPage.master"  %>

<asp:Content ContentPlaceHolderID="title" runat="server">
        用户登陆
</asp:Content>



<asp:Content ContentPlaceHolderID="content" runat="server">
    <h1>用户登录</h1>
          <div class="login-form">
	<div> <a href="homePage.aspx" class="close"></a></div>
		<div class="head-info">
			<label class="lbl-1"> </label>
			<label class="lbl-2"> </label>
			<label class="lbl-3"> </label>
		</div>
			<div class="clear"> </div>
			<form runat="server" >
					<div class="login-input">
                           <input  id="userNameTb"  name="userNameTb" class="input-username"  placeholder="用户名"  autocomplete="off" />
						<div class="key">
					    <input  id="userPwdTb" name="userPwdTb" class="input-password" type="password" placeholder="密码"   autocomplete="off"/>
						</div>
					</div>
                 <div style="display: inline">

                            <button id="signinBt" runat="server" onserverclick="signinBt_Click" class="signinBt"  type="submit">登陆</button>
                            <button id="goToSignupBt" runat="server" onserverclick="goToSignupBt_Click" class="registerBt">注册</button>

            </div>
			</form>
	           
        </div>
</asp:Content>


