<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailListAdd.aspx.cs" Inherits="AbMail.Mail01.MailListAdd" %>

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
                            CustomerID :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustomerID" runat="server" class="easyui-validatebox" ReadOnly="true"
                            BackColor="#CCFF99"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            Country :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            State :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtState" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            City :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Area :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtArea" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            University :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUniversity" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            College :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCollege" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            Department :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepartment" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Pi :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPi" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            FullName :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            FirstName :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            LastName :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            LabAddress :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtlabAddress" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            Phone :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtphone" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Email :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            LabWebsite :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLabWebsite" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Research Interest :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtResearchInterest" runat="server" class="easyui-validatebox" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            Publication List :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicationList" runat="server" class="easyui-validatebox" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Collector :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCollector" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                    <td>
                        <label for="name">
                            GMT :
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGMT" runat="server" class="easyui-validatebox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="name">
                            Unsubscribe :
                        </label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUnsubscribe" runat="server">
                            <asp:ListItem Value="False">False</asp:ListItem>
                            <asp:ListItem Value="True">True</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label for="name">
                            Our Customer :
                        </label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOurCustomer" runat="server">
                            <asp:ListItem Value="False">False</asp:ListItem>
                            <asp:ListItem Value="True">True</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="20px"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                    </td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>