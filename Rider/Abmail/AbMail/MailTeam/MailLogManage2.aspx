﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailLogManage.aspx.cs"
    Inherits="AbMail.MailTeam.MailLogManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <link href="../Scripts/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Scripts/thickbox-compressed.js" type="text/javascript"></script>
    <link href="../Scripts/css/thickbox.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset style="width: 100%;">
                <legend>查询</legend>
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="_rbTime" runat="server">
                                <asp:ListItem Value="">所有时间</asp:ListItem>
                                <asp:ListItem Value="createDate">发送日期</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>Start：
                        <asp:TextBox ID="datepicker1" runat="server" EnableViewState="false" Width="80" class="easyui-datebox"></asp:TextBox>
                            End：
                        <asp:TextBox ID="datepicker2" runat="server" EnableViewState="false" Width="80" class="easyui-datebox"></asp:TextBox>
                        </td>
                        <td>发送组编号：<asp:TextBox ID="_tbrId" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>策略编号：<asp:TextBox ID="_tbgroupId" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>接收人：<asp:TextBox ID="_tbto" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>用户编号：<asp:TextBox ID="_empno" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="_btnSearch" runat="server" Text="查询" OnClick="_btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 100%;">
                <input id="btnFan" type="button" value="删除" />
            </fieldset>
            <div>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="Ods" EnableViewState="false"
                    DataKeyNames="ID">
                    <LayoutTemplate>
                        <table id="tlv" class="grid" cellspacing="0" border="0">
                            <tr>
                                <th>
                                    <input type="checkbox" id="checkAll" />
                                </th>
                                <th>发送组编号
                                </th>
                                <th>客户编号
                                </th>
                                <th>策略编号
                                </th>
                                <th>内容编号
                                </th>
                                <th>邮件主题
                                </th>
                                <th>发送地址
                                </th>
                                <th>发出人
                                </th>
                                <th>发送时间
                                </th>
                                <th>接收人
                                </th>
                                <th>邮件状态
                                </th>
                                <th>用户
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server" />
                            <tr class="pager">
                                <td colspan="100">
                                    <div class="container">
                                        <asp:DataPager ID="pager" runat="server" PagedControlID="ListView1" PageSize="10">
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
                        没有任何数据
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr id="row" runat="server" class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                            <td>
                                <input type="checkbox" name="selId" class="selId" value='<%#Eval("ID")%>' />
                            </td>
                            <td>
                                <span>
                                    <%#Eval("rId")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("customerId")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("groupId")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("mailId")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("subject")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("address")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("createBy")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("createDate")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("to")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("MailStatus")%></span>
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
                        <asp:Parameter Name="tablename" DefaultValue="tbl_MailLog" Type="String" />
                        <asp:Parameter Name="where" DefaultValue=" 1=1 " Type="String" />
                        <asp:Parameter Name="OrderExpression" DefaultValue="createDate desc" Type="String" />
                        <asp:Parameter DefaultValue="0" Name="startRowIndexId" Type="Int32" />
                        <asp:Parameter DefaultValue="20" Name="maxNumberRows" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <asp:Button ID="delAllBtn" runat="server" Text="清空" OnClick="delAllBtn_Click" />
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        $("#checkAll").click(function () {
            $(".selId").trigger("click");
        });
    });
    $(function () {
        //删除
        $("#btnFan").click(function () {
            if (!confirm("确定删除此用户")) {
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
                data: "{'strIds':'" + ids + "','tbName':'tbl_MailLog'}",
                dataType: 'json',
                success: function () {
                    alert("成功删除")
                    window.location.href = window.location.href;
                }
            });
        });
    });
</script>