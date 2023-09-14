<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Admin.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../js/CheckDataFunction.js" type="text/javascript"></script>
    <script language="JavaScript" src="../js/CommFunc.js" type="text/javascript"></script>
    <base target="_self">
</head>
<body leftmargin="0" topmargin="0" onload="GetFocus('txOldPwd')">
    <form id="form1" method="post" runat="server">
    <table cellspacing="2" cellpadding="3" width="100%" align="center" border="0">
        <tr>
            <td background="..\images\in.gif" height="34">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="30">
                            <img height="34" src="..\images\left.gif" width="27">
                        </td>
                        <td>
                            &nbsp;修改密码
                        </td>
                        <td align="right">
                            <cc1:xMouseImage ID="btnSave" runat="server" ImageUrl="../Images/btnSave.GIF" ChangeImgUrl="../Images/btnSave_2.GIF">
                            </cc1:xMouseImage>
                            <cc1:xMouseImage ID="btnClose" runat="server" ImageUrl="../Images/btnClose.GIF" ChangeImgUrl="../Images/btnClose_2.GIF">
                            </cc1:xMouseImage>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table id="Table1" cellspacing="0" cellpadding="3" width="95%" border="1" class="TBCSS">
                    <tr>
                        <td class="tdTITLE" colspan="2">
                            <b>修改密码</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="40%" height="25">
                            旧密码：
                        </td>
                        <td>
                            <asp:TextBox ID="txOldPwd" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trCOLOR">
                        <td align="right" width="40%" height="25">
                            新密码：
                        </td>
                        <td>
                            <asp:TextBox ID="txNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="40%" height="25">
                            确认密码：
                        </td>
                        <td>
                            <asp:TextBox ID="txRepPwd" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div>
        </div>
    <script language="javascript" event="onclick" for="btnSave">												
        if(!CheckEque(txNewPwd,txRepPwd,'[错误提示]　确认密码有误。'))
            //if (!CheckEmpty2(txRepPwd,"[错误提示]　确认密码有误。",null))
            return false;
    </script>
    </form>
</body>
</html>
