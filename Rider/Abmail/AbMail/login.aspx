<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AbMail.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #login-wrapper #login-content .notification
        {
            background-color: #336699;
            border: 0 none;
            color: #FFFFFF !important;
        }
        body#login
        {
            background: url("images/bg-login.gif") repeat scroll 0 0 #222222;
            color: #FFFFFF;
            margin: 0;
            padding: 0;
            text-align: center;
        }
        #login-wrapper
        {
            background: url("images/bg-login-top.png") repeat-x scroll left top transparent;
        }
        #login-wrapper #login-top
        {
            padding: 80px 0 50px;
            text-align: center;
            width: 100%;
        }
        #login-wrapper #login-content
        {
            margin: 0 auto;
            text-align: left;
            width: 320px;
            line-height: 1.6em;
        }
        #login-wrapper #login-content label
        {
            color: #FFFFFF;
            float: left;
            font-family: Helvetica,Arial,sans-serif;
            font-size: 14px;
            font-weight: normal;
            padding: 0;
            width: 70px;
        }
        #login-wrapper #login-content .text-input
        {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 0 none;
            float: right;
            width: 200px;
            -moz-border-radius: 2px 2px 2px 2px;
            color: #333333;
            font-size: 13px;
            height: 20px;
            padding: 2px;
            margin: 5px 10px 0 0;
        }
        #login-wrapper #login-content p
        {
            padding: 0;
        }
        #login-wrapper #login-content p#remember-password
        {
            float: right;
        }
        #login-wrapper #login-content p#remember-password input
        {
            background: none repeat scroll 0 0 transparent;
            border: 0 none;
            float: none;
            margin: 0 10px 0 0;
            width: auto;
        }
        #login-wrapper #login-content p .button
        {
            margin-top: 20px;
            width: auto;
            float: right;
           
        }

        .checkbox {
            margin-top: 20px;
            float: right;
        }
    </style>
</head>
<body id="login">
    <form id="form1" runat="server">
    <div id="login-wrapper" class="png_bg">
        <div id="login-top">
            <!-- Logo -->
            <img id="logo" src="images/logo.png" />
        </div>
        <!-- End #logn-top -->
        <table id="login-content">
            <tr>
                <td>
                    用户名</td>
                <td><asp:TextBox ID="txtLoginName" runat="server" class="text-input" Text="10000"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="padding-top: 20px">
                    密 码</td>
               <td style="padding-top: 20px"> <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" class="text-input" Text="10000"></asp:TextBox></td>
            </tr>
           
            <tr>
              <td colspan="2" style="padding-top: 10px">  <asp:CheckBox ID="chbSavePassword" runat="server" TextAlign="Left" CssClass="checkbox"
                    Text="保存"></asp:CheckBox>
                </td>
            </tr>
            
            <tr>
              <td colspan="2" style="text-align: right;padding-top: 10px" > <asp:Button ID="cmdLogin" runat="server" OnClick="cmdLogin_Click" Text="登录" class="button" /></td> 
            </tr>
            <div style="clear: both;">
            </div>
            <p style="height: 60px;">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginName"
                    ErrorMessage="1.登录名不能为空"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginPassword"
                    ErrorMessage="2.密码不能为空"></asp:RequiredFieldValidator>
            </p>
            <div style="clear: both;">
            </div>
        </table>
        <!-- End #login-content -->
        <div id="copyright" class="layout_center">
            <p>
                版权所有 2013-2015 保留所有权利（V4.0正式版）</p>
        </div>
    </div>
    <!-- End #login-wrapper -->
    </form>
</body>
</html>
