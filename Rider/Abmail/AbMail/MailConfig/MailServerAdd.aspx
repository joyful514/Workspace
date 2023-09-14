    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailServerAdd.aspx.cs"
    Inherits="AbMail.MailConfig.MailServerAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" style="background: #fafafa; padding: 10px;" id="add">
                <tr>
                    <td>
                        <label for="name">
                            HostID:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHostId" runat="server" class="easyui-validatebox" ReadOnly="true" BackColor="#CCFF99"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Smtp:*
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSmtp" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Smtp Port:*
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPort" runat="server"  Text="25" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Pop3:*
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPop3" runat="server"  class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Pop3 Port:*
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPop3Port" runat="server" Text="110" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Priority:
                        </label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPriority" runat="server">
                            <asp:ListItem Value="Normal">Normal</asp:ListItem>
                            <asp:ListItem Value="High">High</asp:ListItem>
                            <asp:ListItem Value="Low">Low</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            EnableSsl:
                        </label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEnableSsl" runat="server">
                            <asp:ListItem Value="False">False</asp:ListItem>
                            <asp:ListItem Value="True">True</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            From:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtForm" runat="server" class="easyui-validatebox" Width="450" TextMode="MultiLine" Rows="10"></asp:TextBox>
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