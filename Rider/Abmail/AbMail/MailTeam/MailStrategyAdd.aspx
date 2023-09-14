<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailStrategyAdd.aspx.cs" Inherits="AbMail.Mail01.MailStrategyAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <table width="100%" style="background: #fafafa; padding: 10px;" id="add">
                <tr>
                    <td>
                        <label for="name">
                            策略编号:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGroupId" runat="server" class="easyui-validatebox" ReadOnly="true" BackColor="#CCFF99"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            策略名:*
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMailStrategyName" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            提取客户信息SQL:*
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMailSql" runat="server" class="easyui-validatebox" Width="400" TextMode="MultiLine" Rows="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>