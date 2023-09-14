<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="AbMail.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台管理</title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ext/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="ext/ext-all.js"></script>
    <script type="text/javascript" src="js/TabCloseMenu.js"></script>
    <script src="js/CommFunc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <base target="_self" />
</head>
<script type="text/javascript">
    Ext.onReady(function () {
        tabs = new Ext.TabPanel({
            region: 'center',
            el: 'center',
            margins: '60 0 2 0',
            deferredRender: false,
            activeTab: 0,
            enableTabScroll: true,
            plugins: new Ext.ux.TabCloseMenu(),
            bodyStyle: 'width:100%;height:100%'
        });
        Ext.BLANK_IMAGE_URL = "ext/resources/images/default/s.gif";
        var Tree = Ext.tree;
        var tree = new Tree.TreePanel({
            el: 'west_content',
            useArrows: true,
            autoHeight: true,
            split: true,
            lines: true,
            autoScroll: true,
            animate: true,
            enableDD: true,
            border: false,
            containerScroll: true,
            expanded: true,
            rootVisable: false,
            loader: new Tree.TreeLoader({
                dataUrl: 'ext_tree_json.aspx' //生成 ext 2.0 所需要的树型格式
            })
        });

        // set the root node
        var root = new Tree.AsyncTreeNode({
            text: '客户开发管理系统',
            draggable: true,
            id: '0' // 0 为根目录
        });
        tree.setRootNode(root);
        createTab("Model/Help.aspx", "系统帮助");
        // render the tree
        tree.on('load', function (node) {
            for (var i = 0; i < node.childNodes.length; i++) {
                var arr = node.childNodes[i].text.split(",");
                //alert(arr.length);
                if (arr.length == 2) {
                    node.childNodes[i].text = arr[0];
                    node.childNodes[i].url = arr[1];
                }
            }
        }
			);

        tree.on('click', function (node) {
            if (!node.isLeaf()) {
                node.toggle();//单击展开树
                return;
            }
            var newurl = "";
            if (node.id == "0") {
                //createTab("","共享收藏");
            } else {
                //parent.nodeText = node.text;
                if (!node.url) {//不是HTTP网址
                   
                 
                    
                    newurl = "";
                    
                } else {//HTTP网址
                    newurl = node.url;
                }
            }
            parent.changeURL(newurl, node.text);
        });
        tree.render();
        root.expand();

        var viewport = new Ext.Viewport({
            layout: 'border',
            items: [{
                region: 'west',
                id: 'west',
                //el:'panelWest',
                title: '菜单导航',
                split: true,
                width: 200,
                minSize: 200,
                maxSize: 400,
                collapsible: true,
                margins: '60 0 2 2',
                cmargins: '60 5 2 2',
                layout: 'fit',
                layoutConfig: { activeontop: true },
                defaults: { bodyStyle: 'margin:0;padding:0;' },
                //iconCls:'nav',
                items:
                    new Ext.TabPanel({
                        border: false,
                        activeTab: 0,
                        tabPosition: 'bottom',
                        items: [{
                            contentEl: 'west_content',
                            title: '菜单导航',
                            autoScroll: true,
                            bodyStyle: 'padding:5px;'
                            //html:'<a href="welcome.aspx" target="main">欢迎！</a>',
                        },
                               {
                                   layout: 'accordion', layoutConfig: { animate: true },
                                   title: '内部信息',
                                   autoScroll: true,
                                   border: false,
                                   items: [<%=  GetMenuString() %>]
                               }]
                    })
            }, tabs,
            {
                region: 'south',
                margins: '0 0 0 2',
                border: false,
                html: '<div class="menu south">客户开发管理系统(V4.0)</div>'
            }
            ]
        });

        setTimeout(function () {
            Ext.get('loading').remove();
            Ext.get('loading-mask').fadeOut({ remove: true });
        }, 250)
    });
               function changeURL(url, text) {
                   //如果请求地址为空 则不打开新窗口 (空格已经在left_tree.js里去掉)
                   if (url ==undefined) {
                       return;
                   }

                   createTab(url, text);
               }
               var frameId = 0;//标签ID号
               //创建一个标签
               var _frameId = 0;
               function createTab(url, text) {
                   tabs.
                   _frameId = "s" + frameId;
                   tabs.add({
                       title: text,
                       //id: 'newtab' + _frameId,
                       iconCls: 'tabs',
                       html: '<iframe src="' + url + '" id="' + _frameId + '" style="width:100%;height:97%" frameBorder=0></iframe>',//tabFrame.outerHTML,
                       closable: true
                   }).show();
                   frameId++;
               }

               function openSrc() {
                   //alert(_frameId);
                   var $framediv = $("#center").find("li.x-tab-strip-active").attr("id").split("__")[1];
                   var $frameid = $("#" + $framediv).find("iframe");
                   var newwin = window.open($frameid[0].src);
                   newwin._print();
                   newwin.close();
               }
               function GenXinSelf() {
                   var $framediv = $("#center").find("li.x-tab-strip-active").attr("id").split("__")[1];
                   var $frameid = $("#" + $framediv).find("iframe");
                   $frameid[0].src = $frameid[0].src;
               }
</script>
<body>
    <form id="form1" runat="server">
        <div id="loading-mask" style="">
        </div>
        <div id="loading">
            <div class="loading-indicator">
                <img src="ext/resources/extanim32.gif" width="32" height="32" style="margin-right: 8px;"
                    align="absmiddle" />Loading...
            </div>
        </div>
        <div id="header">
            <h1>
                <%= ConfigurationManager.AppSettings["SubTitle"] %></h1>
        </div>
        <div class="menu">
            <span style="float: left">欢迎&nbsp;&nbsp;<b><% =CurrentUser.EmpName %></b>&nbsp;&nbsp;今天是<%= DateTime.Now.ToShortDateString() %>&nbsp;&nbsp;
            <a onclick="javascript:fnOpenModWinS('Admin/ChangePassword.aspx','')" href="#">修改密码</a>
                &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server">清空缓存</asp:LinkButton></span>
            <div id="aLoginOut" runat="server" style="float: right">
                <span>有问题请用 Ctrl+PrintScreen/SysRq 组合键拷全屏 RTX中 Ctrl+V 组合键-》管理员</span>
                <input type="button" name="Submit" value="刷新" onclick="GenXinSelf()" />
                <input type="button" name="Submit" value="打印" onclick="openSrc()" />
                <asp:Button ID="btnLogout" OnClientClick="" runat="server" Text="退出" OnClick="btnLogout_Click" />
                <input type="button" name="Submit" value="重新登录" onclick="location.href = 'Login.aspx';" />
            </div>
        </div>
        <div id="west">
        </div>
        <div id="center">
        </div>
        <div id="west_content" style="height: 300px;">
        </div>
    </form>
</body>
</html>