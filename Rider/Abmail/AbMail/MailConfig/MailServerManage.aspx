<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailServerManage.aspx.cs"
    Inherits="AbMail.Mail.MailServerManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                <input id="btnFan" type="button" value="删除" />
                <a class='thickbox' title="Edit" href="MailServerAdd.aspx?keepThis=true&TB_iframe=true&height=380&width=600">添加</a>
            </fieldset>
            <div>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="Ods" EnableViewState="false"
                    DataKeyNames="ID">
                    <LayoutTemplate>
                        <table id="tlv" class="grid" cellspacing="0" border="0">
                            <tr>
                                <th>Edit
                                </th>
                                <th>
                                    <input type="checkbox" id="checkAll" />
                                </th>
                                <th>HostID
                                </th>
                                <th>Mail From
                                </th>
                                <th>Smtp
                                </th>
                                <th>Smtp_Port
                                </th>
                                <th>Priority
                                </th>
                                <th>enableSsl
                                </th>
                                <th>员工编号
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
                        没有任何数据
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr id="row" runat="server" class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                            <td>
                                <a class='thickbox' title="修改" href="MailServerAdd.aspx?id=<%# Eval("ID")%>&keepThis=true&TB_iframe=true&height=380&width=600">Edit</a>
                            </td>
                            <td>
                                <input type="checkbox" name="selId" class="selId" value='<%#Eval("ID")%>' />
                            </td>
                            <td>
                                <span>
                                    <%#Eval("hostid")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("mailFrom")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("smtp")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("smtp_port")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("Priority")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("enableSsl")%></span>
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
                        <asp:Parameter Name="tablename" DefaultValue="tbl_MailServerGroup" Type="String" />
                        <asp:Parameter Name="where" DefaultValue=" 1=1 " Type="String" />
                        <asp:Parameter Name="OrderExpression" DefaultValue="hostid desc" Type="String" />
                        <asp:Parameter DefaultValue="0" Name="startRowIndexId" Type="Int32" />
                        <asp:Parameter DefaultValue="20" Name="maxNumberRows" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
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
                data: "{'strIds':'" + ids + "','tbName':'tbl_MailServerGroup'}",
                dataType: 'json',
                success: function () {
                    alert("成功删除")
                    window.location.href = window.location.href;
                }
            });
        });
    });
</script>