<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListImport.aspx.cs" Inherits="AbMail.MailTeam.ListImport" %>

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
            <fieldset style="width: 600px;">
                第一步：下载模板，安装模板填入数据,国家和邮件地址,全名,收集人等为必填项.
            <asp:HyperLink ID="hlmb" runat="server" NavigateUrl="~/Template.xls">下载</asp:HyperLink>
            </fieldset>
            <fieldset style="width: 600px;">
                第二步：选择excel文件<asp:FileUpload ID="fuExcel" runat="server" />&nbsp;&nbsp;
            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="导入" />
                <asp:Label ID="lblup" runat="server" ForeColor="Red"></asp:Label>
            </fieldset>
            <fieldset style="width: 600px;">
                结果：<asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            </fieldset>
            <fieldset style="width: 600px;">
                1.(未在本地计算机上注册“Microsoft.ACE.OLEDB.12.0”提供程序)在对应的 IIS 应用程序池中，设置应用程序池默认属性,右击"高级设置",启用32位应用程序,设置为
            true。</br> 2.如果2007版本的Excel不能导入，请导入2003版本的Excel文件.
            </fieldset>
        </div>
        <div>
            <div>
                邮件批量人工退订：输入全名或者邮件地址，回车换行
            </div>
            <div>
                <fieldset style="width: 600px;">
                    <div>
                        类型：<asp:DropDownList ID="_DpTyep" runat="server">
                            <asp:ListItem Value="1">退订</asp:ListItem>
                            <asp:ListItem Value="2">客户</asp:ListItem>
                            <asp:ListItem Value="3">删除</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div>
                        国家：<asp:TextBox ID="_tbCountry" runat="server"></asp:TextBox>可以为空，退订所有符合条件的地址。
                    </div>
                    <div>
                        地址：<asp:TextBox ID="_tbName" runat="server" TextMode="MultiLine" Rows="10" Columns="40"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="_btnUnsub" runat="server" Text="退订" OnClick="_btnUnsub_Click" />
                    </div>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>