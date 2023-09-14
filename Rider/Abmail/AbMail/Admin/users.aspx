<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true"
    Inherits="admin_users" Title="无标题页" CodeBehind="users.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset style="width: 100%;">
        <input id="btnFan" type="button" value="删除" />
        <a class='thickbox' title="Edit" href="UserAdd.aspx?keepThis=true&TB_iframe=true&height=250&width=500">
            添加</a>
    </fieldset>
    <div>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="Ods" EnableViewState="false"
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
                            ID
                        </th>
                        <th>
                            帐号类型
                        </th>
                        <th>
                            员工编号
                        </th>
                        <th>
                            员工姓名
                        </th>
                        <th>
                            员工账号
                        </th>
                        <th>
                            员工密码
                        </th>
                        <th>
                            创建日期
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
                        <a class='thickbox' title="Edit" href="UserEdit.aspx?id=<%# Eval("ID")%>&keepThis=true&TB_iframe=true&height=250&width=500">
                            Edit</a>
                    </td>
                    <td>
                        <input type="checkbox" name="selId" class="selId" value='<%#Eval("ID")%>' />
                    </td>
                    <td>
                        <span>
                            <%#Eval("ID")%></span>
                    </td>
                    <td>
                        <span>
                            <%#  Enum.GetName(typeof(yb.ProHelper.tEmployee.DeptID), Convert.ToInt32(Eval("DeptID")))%></span>
                    </td>
                    <td>
                        <span>
                            <%#Eval("EmpNO")%></span>
                    </td>
                    <td>
                        <span>
                            <%#Eval("EmpName")%></span>
                    </td>
                    <td>
                        <span>
                            <%#Eval("Account")%></span>
                    </td>
                    <td>
                        <span>
                            <%#Eval("Password")%></span>
                    </td>
                    <td>
                        <span>
                            <%#Eval("JoinDate")%></span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="Ods" runat="server" SelectMethod="GetDataByPager2005" EnablePaging="True"
            MaximumRowsParameterName="maxNumberRows" TypeName="yb.ybSqlHelper" StartRowIndexParameterName="startRowIndexId"
            SelectCountMethod="GetRecordCount">
            <SelectParameters>
                <asp:Parameter Name="SelectList" DefaultValue="*" Type="String" />
                <asp:Parameter Name="tablename" DefaultValue="tEmployee" Type="String" />
                <asp:Parameter Name="where" DefaultValue=" 1=1 " Type="String" />
                <asp:Parameter Name="OrderExpression" DefaultValue="ID desc" Type="String" />
                <asp:Parameter DefaultValue="0" Name="startRowIndexId" Type="Int32" />
                <asp:Parameter DefaultValue="20" Name="maxNumberRows" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
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
                    url: "Admin.asmx/DelObj",
                    data: "{'strIds':'" + ids + "','tbName':'tEmployee'}",
                    dataType: 'json',
                    success: function () {
                        alert("成功删除")
                        window.location.href = window.location.href;
                    }
                });
            });
        });
    </script>
</asp:Content>
