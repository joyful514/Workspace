<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailContentAdd.aspx.cs" ValidateRequest="false"
    Inherits="AbMail.MailConfig.MailContentAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/xheditor/xheditor-1.1.14-zh-cn.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" style="background: #fafafa; padding: 10px;" id="add">
                <tr>
                    <td>
                        <label for="name">
                            MailID:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMailID" runat="server" class="easyui-validatebox" ReadOnly="true"
                            BackColor="#CCFF99"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Subject:*
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" runat="server" class="easyui-validatebox" TextMode="MultiLine" Rows="10" Columns="80"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            显示名:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            是否HTML格式:
                        </label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIsBodyHtml" runat="server">
                            <asp:ListItem Value="False">False</asp:ListItem>
                            <asp:ListItem Value="True">True</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            是否回复:
                        </label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIsReply" runat="server">
                            <asp:ListItem Value="True">True</asp:ListItem>
                            <asp:ListItem Value="False">False</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            回复邮箱:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtReplyTo" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            上传附件:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpFile" runat="server"></asp:TextBox>
                        <asp:FileUpload ID="fileFu" runat="server" /><asp:Button ID="btnup" runat="server"
                            Text="Up" OnClick="btnup_Click" />邮件附件大小不能超过1MB
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Html内容:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBody" runat="server" class="xheditor" Rows="20" Columns="80" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            文本内容:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUrl" runat="server" class="easyui-validatebox" TextMode="MultiLine" Rows="20" Columns="80"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblcol" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
 <script type="text/javascript">

                $(document).ready(function () {



                    var txt1 = "<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>-------------------------------------------" + "<a href='http://ab.cptbio.com:88/tuiding.aspx?email={email}&&eid={customerId}'>点此退订（Click here to Unsubscribe）</a>";                    // 以 HTML 创建元素
                    var txt2 = "-------------------------------------------" + " -------------------------------------------  " +
              "复制链接到浏览器进行退订（Copy link to browser for unsubscribe）：http://ab.cptbio.com:88/tuiding.aspx?email={email}&&eid={customerId}";

                    var value1 = $("#txtBody").val();
                    if (value1 == null || value1 == "") {
                        $("#txtBody").val(txt1);
                    }
                    var value2 = $("#txtUrl").val();
                    if (value2 == null || value2== "") {
                        $("#txtUrl").val(txt2);
                    }

                  

                });       
               
</script>
        </div>
    </form>
</body>
</html>