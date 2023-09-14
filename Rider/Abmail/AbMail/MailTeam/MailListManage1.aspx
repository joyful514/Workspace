<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailListManage.aspx.cs"
    Inherits="AbMail.Mail01.MailListManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
        <div id="div01">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <fieldset style="width: 100%;">
                <legend>查询</legend>
                <table>
                    <tr>
                        <td>CustomerID：<asp:TextBox ID="_tbCustomerID" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>Collector：<asp:TextBox ID="_tbCollector" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>Country：<asp:TextBox ID="_tbCountry" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>State：<asp:TextBox ID="_tbState" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>City：<asp:TextBox ID="_tbCity" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>Area：<asp:TextBox ID="_tbArea" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>GMT：<asp:TextBox ID="_tbGMT" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>Title：<asp:TextBox ID="_tbTitle" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>University：<asp:TextBox ID="_tbUniversity" runat="server" Width="50"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>College：<asp:TextBox ID="_tbCollege" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>Email：<asp:TextBox ID="_tbEmail" runat="server" Width="100"></asp:TextBox>
                        </td>
                        <td>FullName：<asp:TextBox ID="_tbfullName" runat="server" Width="100"></asp:TextBox>
                        </td>
                        <td>LastName：<asp:TextBox ID="_tblastName" runat="server" Width="50"></asp:TextBox>
                        </td>
                        <td>Unsubscribe：
                        <asp:DropDownList ID="_rbst" runat="server">
                            <asp:ListItem Value="">所有</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td>Our Customer：<asp:DropDownList ID="_tbod" runat="server">
                            <asp:ListItem Value="">所有</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td style="width: 20px;"></td>
                        <td>
                            <asp:Button ID="_btnSearch" runat="server" Text="查询" OnClick="_btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 100%;">
                <legend>建立策略</legend><a class='thickbox' title="Edit" href="MailListAdd.aspx?keepThis=true&TB_iframe=true&height=380&width=660">添加</a>
                <asp:Label ID="lbltitle" runat="server" Text="邮件发送策略名："></asp:Label>
                <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
                <asp:Button ID="btnSaveStrategy" runat="server" Text="Save" OnClick="btnSaveStrategy_Click" /><br />
                <asp:Label ID="lblsql" runat="server" Text="" ForeColor="Red"></asp:Label>
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
                                <th>CustomerID
                                </th>
                                <th>GMT
                                </th>
                                <th>Country
                                </th>
                                <th>State
                                </th>
                                <th>City
                                </th>
                                <th>Area
                                </th>
                                <th>University
                                </th>
                                <th>College
                                </th>
                                <th>Department
                                </th>
                                <th>PI
                                </th>
                                <th>Title
                                </th>
                                <th>Full Name
                                </th>
                                <th>First Name
                                </th>
                                <th>Last Name
                                </th>
                                <th>Email
                                </th>
                                <th>Collector
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
                                <a class='thickbox' title="添加" href="MailListAdd.aspx?id=<%# Eval("ID")%>&keepThis=true&TB_iframe=true&height=380&width=660">Edit</a>
                            </td>
                            <td>
                                <input type="checkbox" name="selId" class="selId" value='<%#Eval("ID")%>' />
                            </td>
                            <td>
                                <span>
                                    <%#Eval("customerId")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("GMT")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("country")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("state")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("city")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("area")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("university")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("college")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("department")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("pi")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("title")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("fullName")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("firstName")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("lastName")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("email")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("collector")%></span>
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
                        <asp:Parameter Name="tablename" DefaultValue="tbl_Customers" Type="String" />
                        <asp:Parameter Name="where" DefaultValue=" 1=1 " Type="String" />
                        <asp:Parameter Name="OrderExpression" DefaultValue="customerId desc" Type="String" />
                        <asp:Parameter DefaultValue="0" Name="startRowIndexId" Type="Int32" />
                        <asp:Parameter DefaultValue="20" Name="maxNumberRows" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <script type="text/javascript">
            $(function () {
                $("#checkAll").click(function () {
                    $(".selId").trigger("click");
                });
            });
            $(function () {
                //删除
                $("#btnFan").click(function () {
                    if (!confirm("确定删除此条信息")) {
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
                        data: "{'strIds':'" + ids + "','tbName':'tbl_Customers'}",
                        dataType: 'json',
                        success: function () {
                            alert("成功删除")
                            window.location.href = window.location.href;
                        }
                    });
                });
            });
        </script>
    </form>
</body>
</html>