<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailRunAdd.aspx.cs" Inherits="AbMail.MailTeam.MailRunAdd" %>

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
    <div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <table width="100%" style="background: #fafafa; padding: 10px;" id="add">
            <tr>
                <td>
                    <label for="name">
                        发送组:
                    </label>
                </td>
                <td>
                    <asp:TextBox ID="txtGroupId" runat="server" class="easyui-validatebox" ReadOnly="true"
                        BackColor="#CCFF99" Width="65px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="name">
                        服务器:
                    </label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlHostID" runat="server" DataSourceID="SqlDataSource1" DataTextField="hostid"
                        DataValueField="hostid">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="name">
                        邮件内容:
                    </label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMailID" runat="server" DataSourceID="SqlDataSource2" DataTextField="mailId"
                        DataValueField="mailId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="name">
                        发送策略:
                    </label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStrID" runat="server" DataSourceID="SqlDataSource3" DataTextField="groupId"
                        DataValueField="groupId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="name">
                        发送数量(封):
                    </label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlNum" runat="server">
                      <asp:ListItem Value="1"><=1</asp:ListItem>
                        <asp:ListItem Value="50"><=50</asp:ListItem>
                        <asp:ListItem Value="100"><=100</asp:ListItem>
                        <asp:ListItem Value="200"><=200</asp:ListItem>
                        <asp:ListItem Value="300"><=300</asp:ListItem>
                        <asp:ListItem Value="400"><=400</asp:ListItem>
                        <asp:ListItem Value="500"><=500</asp:ListItem>
                        <asp:ListItem Value="600"><=600</asp:ListItem>
                        <asp:ListItem Value="1000"><=1000</asp:ListItem>
                        <asp:ListItem Value="2000"><=2000</asp:ListItem>
                        <asp:ListItem Value="2100"><=2100</asp:ListItem>
                        <asp:ListItem Value="2200"><=2200</asp:ListItem>
                        <asp:ListItem Value="2300"><=2300</asp:ListItem>
                        <asp:ListItem Value="2400"><=2400</asp:ListItem>
                        <asp:ListItem Value="2500"><=2500</asp:ListItem>
                        <asp:ListItem Value="3000"><=3000</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="name">
                        间隔时间(秒):
                    </label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSec" runat="server">
                        <asp:ListItem Value="120">120</asp:ListItem>
                        <asp:ListItem Value="180">180</asp:ListItem>
                        <asp:ListItem Value="240">240</asp:ListItem>
                        <asp:ListItem Value="300">300</asp:ListItem>
                        <asp:ListItem Value="360">360</asp:ListItem>
                        <asp:ListItem Value="400">400</asp:ListItem>
                        <asp:ListItem Value="500">500</asp:ListItem>
                        <asp:ListItem Value="600">600</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="name">
                        自动运行时间:
                    </label>
                </td>
                <td>
                    日期：<asp:TextBox ID="datepicker1" runat="server" EnableViewState="false" Width="80" class="easyui-datebox" ></asp:TextBox>
                    <br />
                    小时：
                    <asp:DropDownList ID="ddlTime1" runat="server">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                    </asp:DropDownList>
                    分钟：
                    <asp:DropDownList ID="ddlTime2" runat="server">
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="40">40</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
