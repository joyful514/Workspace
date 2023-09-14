<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailStatus.aspx.cs" Inherits="AbMail.MailTeam.MailStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>查询</legend>
                <table>
                    <tr>
                        <td>Email：<asp:TextBox ID="_tbEmail" runat="server" Width="100"></asp:TextBox>
                        </td>
                        <td>FullName：<asp:TextBox ID="_tbfullName" runat="server" Width="100"></asp:TextBox>
                        </td>
                        <td>Tel：<asp:TextBox ID="_tbtel" runat="server" Width="100"></asp:TextBox>
                        </td>
                        <td style="width: 20px;"></td>
                        <td>
                            <asp:Button ID="_btnSearch" runat="server" Text="查询" OnClick="_btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <div>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="Ods" EnableViewState="false"
                    DataKeyNames="ID">
                    <LayoutTemplate>
                        <table id="tlv" class="grid" cellspacing="0" border="0">
                            <tr>
                                <th>Country
                                </th>
                                <th>Full Name
                                </th>
                                <th>First Name
                                </th>
                                <th>Last Name
                                </th>
                                <th>Phone
                                </th>
                                <th>Email
                                </th>
                                <th>Unsubscribe
                                </th>
                                <th>Customer
                                </th>
                                <th>Collector
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
                                <span>
                                    <%#Eval("country")%></span>
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
                                    <%#Eval("phone")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("email")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("unsubscribe")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("ourCustomer")%></span>
                            </td>
                            <td>
                                <span>
                                    <%#Eval("Collector")%></span>
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
    </form>
</body>
</html>