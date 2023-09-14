<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailRunManage.aspx.cs"
    Inherits="AbMail.MailTeam.MailRun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="PageTool" Namespace="PageTool" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../Scripts/easyui/themes/default/easyui.css" />
    <link href="../Scripts/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/easyui/jquery.easyui.min.js"></script>
    <script src="../Scripts/thickbox-compressed.js" type="text/javascript"></script>
    <link href="../Scripts/css/thickbox.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <fieldset style="width: 100%;">
                <legend>发送组管理</legend><a class='thickbox' title="Edit" href="MailRunAdd.aspx?keepThis=true&TB_iframe=true&height=400&width=450">
                    添加</a>
                <input id="btnFan" type="button" value="删除" />
                <input id="binStop" type="button" value="停止" />
                <input id="btnSend" type="button" value="发送" />手动发送必须一个组一个组的激活，且间隔3分钟，服务器处理能力有限。
                <input id="btnRef" type="button" value="刷新" />
                初始化整个用户的数据: <asp:Button ID="_btnNew" runat="server" Text="初始化" OnClick="_btnNew_Click"  />
                <div id="progress">
                    <span style="line-height: 150%;"></span>
                </div>
            </fieldset>
        </div>
        <div>
            <asp:ListView ID="ListView2" runat="server" DataSourceID="Ods1" EnableViewState="false"
                DataKeyNames="ID">
                <LayoutTemplate>
                    <table id="tlv" class="grid" cellspacing="0" border="0">
                        <tr>
                            <th>
                                Edit
                            </th>
                            <th>
                                <input type="checkbox" id="checkAll" />
                            </th>
                            <th>
                                邮件组
                            </th>
                            <th>
                                SMTP_ID
                            </th>
                            <th>
                                SMTP
                            </th>
                            <th>
                                策略
                            </th>
                            <th>
                                策略名
                            </th>
                            <th>
                                内容
                            </th>
                             <th>
                                主题
                            </th>
                            <th>
                                每次
                            </th>
                            <th>
                                隔(秒)
                            </th>
                            <th>
                                定时
                            </th>
                            <th>
                                运行
                            </th>
                            <th>
                                用户
                            </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server" />
                        <tr class="pager">
                            <td colspan="100">
                                <div class="container">
                                    <asp:DataPager ID="pager" runat="server" PagedControlID="ListView2" PageSize="30"
                                        ViewStateMode="Enabled">
                                        <Fields>
                                            <SqlNetFrameworkWebControls:GooglePagerField NextPageImageUrl="~/Images/button_arrow_right.gif"
                                                PreviousPageImageUrl="~/Images/button_arrow_left.gif" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    没有任何数据</EmptyDataTemplate>
                <ItemTemplate>
                    <tr id="row" runat="server" class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                        <td>
                            <a class='thickbox' title="修改" href="MailRunAdd.aspx?id=<%# Eval("ID")%>&keepThis=true&TB_iframe=true&height=400&width=450">
                                Edit</a>
                        </td>
                        <td>
                            <input type="checkbox" name="selId" class="selId" value='<%#Eval("ID")%>' />
                        </td>
                        <td>
                            <span>
                                <%#Eval("rId")%></span>
                        </td>
                        <td>
                            <span><a class='thickbox' title="修改" href="../MailConfig/MailServerAdd.aspx?id=<%# Eval("id1")%>&keepThis=true&TB_iframe=true&height=380&width=600">
                                <%#Eval("hostid")%></a></span>
                        </td>
                        <td>
                            <span>
                                <%#Eval("smtp")%></span>
                        </td>
                        <td>
                            <span><a class='thickbox' title="修改" href="MailStrategyAdd.aspx?id=<%# Eval("id2")%>&keepThis=true&TB_iframe=true&height=300&width=680">
                                <%#Eval("groupId")%></a> </span>
                        </td>
                        <td>
                            <span>
                                <%#Eval("mailStrategyName")%></span>
                        </td>
                        <td>
                            <span><a class="goEdit" ref="<%#Eval("id3") %>" title="<%#Eval("subject")%>">
                                <%#Eval("mailId")%></a></span>
                        </td>
                        <td> <%#Eval("subject")%></td>
                        <td>
                            <span>
                                <%#Eval("num")%></span>
                        </td>
                        <td>
                            <span>
                                <%#Eval("timenum")%></span>
                        </td>
                        <td>
                            <span><%#string.Format("{0:d}", Eval("Date0"))%> <%#Eval("time1")%>:<%#Eval("time2")%></span>
                        </td>
                        <td>
                            <span style="color: Red;">
                                <%#Eval("Run")%></span>
                        </td>
                        <td>
                            <span>
                                <%#Eval("EmpNO")%></span>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="Ods1" runat="server" SelectMethod="GetDataByPager2005"
                EnablePaging="True" MaximumRowsParameterName="maxNumberRows" TypeName="yb.ybSqlHelper"
                StartRowIndexParameterName="startRowIndexId" SelectCountMethod="GetRecordCount">
                <SelectParameters>
                    <asp:Parameter Name="SelectList" DefaultValue="*" Type="String" />
                    <asp:Parameter Name="tablename" DefaultValue="vwMailRun" Type="String" />
                    <asp:Parameter Name="where" DefaultValue=" 1=1 " Type="String" />
                    <asp:Parameter Name="OrderExpression" DefaultValue="rid desc" Type="String" />
                    <asp:Parameter DefaultValue="0" Name="startRowIndexId" Type="Int32" />
                    <asp:Parameter DefaultValue="20" Name="maxNumberRows" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <div>
            <asp:ListView ID="ListView1" runat="server" DataSourceID="Ods">
                <LayoutTemplate>
                    <table id="tlv" class="grid" cellspacing="0" border="0">
                        <tr>
                            <th>
                                组编号
                            </th>
                            <th>
                                提示
                            </th>
                            <th>
                                序号
                            </th>
                            <th>
                                时间
                            </th>
                            <th>
                                用户
                            </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server" />
                        <tr class="pager">
                            <td colspan="100">
                                <div class="container">
                                    <asp:DataPager ID="pager" runat="server" PagedControlID="ListView1" PageSize="20">
                                        <Fields>
                                            <SqlNetFrameworkWebControls:GooglePagerField NextPageImageUrl="~/Images/button_arrow_right.gif"
                                                PreviousPageImageUrl="~/Images/button_arrow_left.gif" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    没有任何数据</EmptyDataTemplate>
                <ItemTemplate>
                    <tr id="row" runat="server" class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                        <td>
                            <span>
                                <%#Eval("rId")%></span>
                        </td>
                        <td>
                            <span>
                                <%#Eval("m")%></span>
                        </td>
                        <td>
                            <span>
                                <%#Eval("y")%></span>
                        </td>
                        <td>
                            <span>
                                <%#Eval("d")%></span>
                        </td>
                        <td>
                            <span>
                                <%#Eval("EmpNO")%></span>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="Ods" runat="server" SelectMethod="GetDataByPager2005" EnablePaging="True"
                MaximumRowsParameterName="maxNumberRows" TypeName="yb.ybSqlHelper" StartRowIndexParameterName="startRowIndexId"
                SelectCountMethod="GetRecordCount">
                <SelectParameters>
                    <asp:Parameter Name="SelectList" DefaultValue="*" Type="String" />
                    <asp:Parameter Name="tablename" DefaultValue="tbl_Error" Type="String" />
                    <asp:Parameter Name="where" DefaultValue=" M like '成功%' and DATEDIFF(d,d,getdate())<=30"
                        Type="String" />
                    <asp:Parameter Name="OrderExpression" DefaultValue="d desc" Type="String" />
                    <asp:Parameter DefaultValue="0" Name="startRowIndexId" Type="Int32" />
                    <asp:Parameter DefaultValue="20" Name="maxNumberRows" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <div>
            <script type="text/javascript">
                var empName = "<%= this.uname%>";
                $(function () {
                    $("#checkAll").click(function () {
                        $(".selId").trigger("click");
                    });
                });
                $(function () {
                    $("#btnRef").click(function () {
                        window.location.href = window.location.href;
                    });
                });
                $(function () {
                    //发送邮件
                    $("#btnSend").click(function () {
                        if (!confirm("确定发送这个编组")) {
                            return;
                        }
                        if ($(".selId:checkbox:checked").size() == 0) {
                            alert("请选择！");
                            return;
                        }
                        var ids = "";
                        $(".selId:checkbox:checked").each(function () {
                            ids = ids + $(this).val() + ",";
                        });
                        ids = ids.slice(0, -1);
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "d.asmx/RunMail",
                            data: "{'strIds':'" + ids + "','uname':'" + empName + "'}",
                            dataType: 'json',
                            success: function (result) {
                                alert("执行完成")
                                $('#progress').find('span').html(result.d);
                            },
                            error: function () {
                                alert("系统出错");
                            }
                        });
                    });
                });
                $(function () {
                    //删除
                    $("#btnFan").click(function () {
                        if (!confirm("确定删除")) {
                            return;
                        }
                        if ($(".selId:checkbox:checked").size() == 0) {
                            alert("请选择！");
                            return;
                        }
                        var ids = "";
                        $(".selId:checkbox:checked").each(function () {
                            ids = ids + $(this).val() + ",";
                        });
                        ids = ids.slice(0, -1);
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "d.asmx/DelObj",
                            data: "{'strIds':'" + ids + "','tbName':'tbl_MailRun'}",
                            dataType: 'json',
                            success: function () {
                                alert("成功删除")
                                window.location.href = window.location.href;
                            }
                        });
                    });
                });
                $(function () {
                    //停止
                    $("#binStop").click(function () {
                        if (!confirm("确定停止这个编组")) {
                            return;
                        }
                        if ($(".selId:checkbox:checked").size() == 0) {
                            alert("请选择！");
                            return;
                        }
                        var ids = "";
                        $(".selId:checkbox:checked").each(function () {
                            ids = ids + $(this).val() + ",";
                        });
                        ids = ids.slice(0, -1);
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "d.asmx/StopMail",
                            data: "{'strIds':'" + ids + "','uname':'" + empName + "'}",
                            dataType: 'json',
                            success: function (result) {
                                alert("执行完成")
                                window.location.href = window.location.href;
                            },
                            error: function () {
                                alert("系统出错");
                            }
                        });
                    });
                });
            </script>
            <script type="text/javascript">

                $(function () {
                    $(".goEdit").click(function () {
                        var obj = $(this);
                        var Id = obj.attr("ref");
                        window.parent.createTab("MailConfig/MailContentAdd.aspx?id=" + Id, "模板编辑");
                    });
                });
       
            </script>
        </div>
    </div>
    </form>
</body>
</html>
