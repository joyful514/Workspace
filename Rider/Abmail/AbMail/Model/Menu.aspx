<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="AbMail.Model.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/thickbox.js" type="text/javascript"></script>
    <link href="../Scripts/css/thickbox.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="5" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LinqHelper.Mail01DataContext"
                        TableName="tModel" EnableDelete="True" EnableInsert="True" EnableUpdate="True"
                        Where="ID == @ID">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="stv1" DefaultValue="0" Name="ID" PropertyName="SelectedValue"
                                Type="Int32" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="LinqHelper.Mail01DataContext"
                        TableName="tModel" Where="PModelID== null">
                    </asp:LinqDataSource>
                    <table id="Table2" cellspacing="5" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td valign="top" width="250" height="350" rowspan="1">
                                <cc1:SmartTreeView ID="stv1" runat="server" AllowCascadeCheckbox="True" ImageSet="Arrows"
                                    OnSelectedNodeChanged="stv1_SelectedNodeChanged">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                        VerticalPadding="0px" />
                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                        NodeSpacing="0px" VerticalPadding="0px" />
                                </cc1:SmartTreeView>
                            </td>
                            <td valign="top" height="350">旧根菜单名
                            <asp:TextBox ID="TextBox2" runat="server" Height="17px" Width="117px"></asp:TextBox>
                                新根菜单名
                            <asp:TextBox ID="TextBox1" runat="server" Height="17px" Width="201px"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" Text="更新根菜单名" OnClick="Button1_Click" />
                                <asp:DetailsView ID="DetailsView1" runat="server" Height="250px" Width="531px" AutoGenerateRows="False"
                                    DataSourceID="LinqDataSource1" DataKeyNames="ID" OnItemDeleted="DetailsView1_ItemDeleted"
                                    OnItemDeleting="DetailsView1_ItemDeleting" OnItemUpdated="DetailsView1_ItemUpdated">
                                    <Fields>
                                        <asp:TemplateField HeaderText="菜单ID">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtModelID" runat="server" Text='<%# Bind("ModelID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="txtModelID" runat="server" Text='<%# Bind("ModelID") %>'></asp:TextBox>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <a title="权限" href="RightList.aspx?id=<%# Eval("ModelID")%>&keepThis=true&TB_iframe=true&height=250&width=550"
                                                    class="thickbox">
                                                    <%# Eval("ModelID")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="父菜单ID">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPModelID" runat="server" Text='<%# Bind("PModelID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="txtPModelID" runat="server" Text='<%# Bind("PModelID") %>'></asp:TextBox>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="labPModelID" runat="server" Text='<%# Bind("PModelID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ModelName" HeaderText="ModelName" SortExpression="ModelName" />
                                        <asp:TemplateField HeaderText="根菜单名">
                                            <InsertItemTemplate>
                                                <asp:DropDownList ID="_ddlPModelName" runat="server" DataSourceID="LinqDataSource2"
                                                    DataTextField="ModelName" DataValueField="ModelName" AppendDataBoundItems="True"
                                                    SelectedValue='<%#Bind("PModelName") %>'>
                                                    <asp:ListItem Selected="True" Value="" Text="选择"></asp:ListItem>
                                                </asp:DropDownList>
                                            </InsertItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="_ddlPModelName" runat="server" DataSourceID="LinqDataSource2"
                                                    DataTextField="ModelName" DataValueField="ModelName" AppendDataBoundItems="True"
                                                    SelectedValue='<%#Bind("PModelName") %>'>
                                                    <asp:ListItem Selected="True" Value="" Text="选择"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="_labPModelName" runat="server" Text='<%#Eval("PModelName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" ApplyFormatInEditMode="true"
                                            ControlStyle-Width="550px" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="OrderNums" HeaderText="OrderNums" SortExpression="OrderNums" />
                                        <asp:BoundField DataField="UrlDescribe" HeaderText="UrlDescribe" SortExpression="UrlDescribe" />
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                                    </Fields>
                                </asp:DetailsView>
                                <asp:Button ID="Button2" runat="server" Text="查看是否用过" OnClick="chcikModel" /><asp:TextBox
                                    ID="TextBox3" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="二级菜单排序" Style="margin-left: 0px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>