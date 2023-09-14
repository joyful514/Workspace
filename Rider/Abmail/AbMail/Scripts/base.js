// 弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]
//jQuery.ajaxSettings.traditional = true;
$(document).ajaxError(function (event, request, settings) {
    $("#dd").html(request.responseText).dialog('open');
});
/*--------------------对话框---------------------------*/

function msgShow(title, msgString, msgType) {
    $.messager.alert(title, msgString, msgType);
}
function msgShowTip(msg) {
    msgShow("注意", msg, "warning");
}
function msgShowOk(msg) {
    msgShow('成功完成', msg == undefined ? "成功完成" : msg, 'info');
}
function msgSlide(msg) {
    $.messager.show({
        title: '信息提示',
        msg: msg,
        timeout: 3000,
        showType: 'slide'
    });
}
function msgShowEnd() {
    msgShow('成功完成', '成功完成', 'info');
}
function ajaxWinOpen(inf) {
    $('#ww').empty()
    .append(inf)
    .window({
        title: '返回信息',
        iconCls: 'icon-edit',
        modal: true,
        shadow: true,
        closed: false
    });
}

function winOpenErp(url) {
    winOpenIframe('aa',url, 1280, 800);
}
function winOpenIframe(title, url, w, h) {
    $('#ww').empty()
    .append("<iframe  frameborder=\"0\" style=\"width:100%;height:100%;\" src=\"" + url + "\"></iframe>")
    .window({
        title: title,
        iconCls: 'icon-edit',
        modal: true,
        shadow: true,
        closed: false,
        width: w,
        height: h
    });
}
function winOpenModalDialog(url, w, h) {
    var width = w == undefined ? 900 : w;
    var height = h == undefined ? 600 : h;
    window.showModalDialog(url, window, 'dialogWidth=' + w + 'px;dialogHeight=' + h + 'px;dialogLeft=50;dialogTop=50;help:no;status:no;scroll:yes');
}
function loadUrl(url, toContent) {
    toContent.html('<div style="padding:5px"><img align="absMiddle" src="/content/images/spinner.gif"></div>');
    toContent.load(url, { date: new Date() }, function () {
        // window.parent.SetWinHeight(window.parent.document.getElementById("frame"));
    });
}
/*----------------------页面选择----------------------------*/
function setClipTxt(t) {
    window.clipboardData.setData('text', document.getElementById(t).value);
}
function selItem(itemName) {
    itemname = itemName == undefined ? 'item' : itemName;
    $("input[name='" + itemname + "']").trigger('click');
}
function selItemUrl(itemName) {
    itemname = itemName == undefined ? 'item' : itemName;
    return $("input[name='" + itemname + "']:checked").serialize();
}
function selItemVal(itemName) {
    itemname = itemName == undefined ? 'item' : itemName;
    var ids = [];
    $("input[name='" + itemname + "']:checked").each(function () {
        ids.push($(this).val());
    });
    if (ids.length == 0) {
        msgShowTip("请选择数据");
        return false;
    }
    return ids.join(',');
}
function selItemValOne(itemName) {
    itemname = itemName == undefined ? 'item' : itemName;
    var ids = [];
    $("input[name='" + itemname + "']:checked").each(function () {
        ids.push($(this).val());
    });
    if (ids.length == 0) {
        msgShowTip("请选择数据");
        return false;
    }
    if (ids.length > 1) {
        msgShowTip("请选择一个数据");
        return false;
    }
    return ids.join(',');
}
/*-------------------grid功能-------------------------*/
function setContextMenu(e, field) {
    e.preventDefault();
    if (!$('#tmenu').length) {
        createColumnMenu();
    }
    $('#tmenu').menu('show', {
        left: e.pageX,
        top: e.pageY
    });
}

function createColumnMenu() {
    var tmenu = $('<div id="tmenu" style="width:160px;"></div>').appendTo('body');
    var fields = $('#tt').datagrid('getColumnFields');
    for (var i = 0; i < fields.length; i++) {
        $('<div iconCls="icon-ok"/>').html(fields[i]).appendTo(tmenu);
    }
    tmenu.menu({
        onClick: function (item) {
            if (item.iconCls == 'icon-ok') {
                $('#tt').datagrid('hideColumn', item.text);
                tmenu.menu('setIcon', {
                    target: item.target,
                    iconCls: 'icon-empty'
                });
            } else {
                $('#tt').datagrid('showColumn', item.text);
                tmenu.menu('setIcon', {
                    target: item.target,
                    iconCls: 'icon-ok'
                });
            }
        }
    });
}

function getGridSels() {
    var ids = [];
    var rows = $('#tt').datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        ids.push(rows[i].Id);
    }
    if (ids.length == 0) {
        msgShowTip("请选择要操作的数据");
        return;
    }
    return ids.join(',');
}
function getGridSel() {
    var ids = [];
    var rows = $('#tt').datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        ids.push(rows[i].Id);
    }
    if (ids.length == 0) {
        msgSlide("请选择要操作的数据");
        return;
    }
    if (ids.length > 1) {
        msgSlide("只能选一个要操作的数据");
        return;
    }
    return ids.join(','); 
}
function gridReload() {
    msgShowEnd();
    $('#tt').datagrid('reload');
}
/*------------页面Init------------------*/
function initInput() {
    $("input[type=text],TextArea,input[type=password]")
            .addClass("input-default")
            .focus(function () {
                $(this).addClass("input-hover-on");
            })
            .blur(function () {
                $(this).removeClass("input-hover-on");
            });
    $("#searchButton").focus();
}
function initLoad() {
    $("#loading")
	.ajaxStart(function () {
	    $(this).show();
	})
	.ajaxComplete(function () {
	    $(this).hide();
	});
}
function initSearch() {
    $("form:first").submit();
}
function loadList(url) {
    $("#main").empty().load(url + "?" + $("form:first").serialize());
}
//$.parser.plugins = ["linkbutton", "menu", "menubutton", "splitbutton", "tree", "combobox", "combotree", "numberbox", "numberspinner", "timespinner", "calendar", "datebox", "layout", "panel", "datagrid", "tabs", "accordion", "window", "dialog"];
function initMain() {
    $.parser.parse($("#main")[0]);
    $.validator.unobtrusive.parse($("#main")[0]);
    $(".xheditor").xheditor();
}

$(function () {
    initInput();
    initLoad();
    $.parser.parse();
});
