<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeBehind="UserAdd.aspx.cs" Inherits="AbMail.Admin.UserAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background: #fafafa; padding: 10px;" id="add">
        <div>
            <div>
                <label for="name">
                    用户账户 :
                </label>
                <asp:TextBox ID="txtUserName" runat="server" class="easyui-validatebox"></asp:TextBox>用于登入系统，请牢记！
            </div>
        </div>
        <div>
            <label for="name">
                用户密码 :
            </label>
            <asp:TextBox ID="txtPwd" runat="server" class="easyui-validatebox" Text="" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <div style="display: inline">
                <label for="name">
                    真实姓名 :
                </label>
            </div>
            <asp:TextBox ID="txtName" runat="server" class="easyui-validatebox"></asp:TextBox>
        </div>
        <div>
            <div>
                <label for="name">
                    用户部门 :
                </label>
                <asp:DropDownList ID="ddlDeptID" runat="server">
                    <asp:ListItem Value="2">普通用户</asp:ListItem>
                    <asp:ListItem Value="1">管理员</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <div>
                <label for="name">
                    联系电话 :
                </label>
                <asp:TextBox ID="txtTel" runat="server" class="easyui-validatebox" Width="180px"></asp:TextBox>
            </div>
        </div>
        <div>
            <div>
                <label for="name">
                    联系地址 :
                </label>
                <asp:TextBox ID="txtAddress" runat="server" class="easyui-validatebox" Width="180px"></asp:TextBox>
            </div>
        </div>
        <div>
            <div>
                <label for="name">
                    邮件地址 :
                </label>
                <asp:TextBox ID="txtMail" runat="server" class="easyui-validatebox" Width="180px"></asp:TextBox>
            </div>
        </div>
        <div>
            <asp:Button ID="btnsave" runat="server" Text="保存" OnClick="btnsave_Click" />
        </div>
    </div>
</asp:Content>
