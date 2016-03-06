<%@ Page Language="C#" AutoEventWireup="true" CodeFile="homePage.aspx.cs" Inherits="homePage" MasterPageFile="MasterPage.master" %>


<asp:Content ContentPlaceHolderID="title" runat="server">
    我的首页
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server" >
    <script type="text/javascript" src="js/loadDaily.js"></script>
    <link href="#" rel="stylesheet" onload="loadPageNum()" />
    <div style="text-align:center;">
        <h1>我的首页</h1>
    <ul id="list" class="bloglist">
        </ul>
        <div id="pageAndBottom" class="pageAndBottom">
            <div class="pageLabel"><label >第</label><label id="pageNum" ></label><label >页</label><label>共</label><label id="totalPage"></label><label>页</label></div>
       <div class="pageChangeBottoms"> <button class="pageChangeBottom" id="firstDailyPageBt" onclick="firstPage();">第一页</button><button class="pageChangeBottom"  id="previousDailyPageBt"  onclick="previousPage()">上一页</button><button class="pageChangeBottom"  id="nextDailyPageBt"onclick="nextPage();">下一页</button></div>
        </div>
        </div>
</asp:Content>
