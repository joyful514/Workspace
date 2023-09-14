namespace AbMail.Admin
{
    using LinqHelper;
    using System;
    using System.Linq;
    using System.Web.Security;
    using System.Web.UI.WebControls;
    using yb.WebHelper;

    public class UserEdit : BasePage
    {
        protected Button btnsave;
        protected DropDownList ddlDeptID;
        protected decimal id;
        protected TextBox txtAddress;
        protected TextBox txtMail;
        protected TextBox txtName;
        protected TextBox txtPwd;
        protected TextBox txtTel;
        protected TextBox txtUserName;

        protected void btnsave_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if ((this.txtUserName.Text.ToString().Trim() == "") && (this.txtPwd.Text.ToString().Trim() == ""))
            {
                flag = false;
                ShowMessage.AjaxShow("用户名和密码不能为空!");
            }
            if (flag)
            {
                using (Mail01DataContext context = dbLinq.GetErpData())
                {
                    tEmployee employee = context.tEmployee.Single<tEmployee>(z => z.ID == this.id);
                    employee.Account = this.txtUserName.Text.ToString().Trim();
                    employee.EmpName = this.txtName.Text.ToString().Trim();
                    if (this.txtPwd.Text.ToString().Trim() != "")
                    {
                        employee.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtPwd.Text.ToString().Trim(), "MD5");
                    }
                    employee.DeptID = Convert.ToDecimal(this.ddlDeptID.SelectedValue);
                    employee.Mobile = this.txtTel.Text.ToString().Trim();
                    employee.Address = this.txtAddress.Text.ToString().Trim();
                    employee.Email = this.txtMail.Text.ToString().Trim();
                    employee.Type = 0;
                    employee.EnabledFlag = 1;
                    context.SubmitChanges();
                    ShowMessage.AjaxShow("修改成功！");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = Convert.ToDecimal(Fetch.Get("id"));
            if (!base.IsPostBack)
            {
                using (Mail01DataContext context = dbLinq.GetErpData())
                {
                    tEmployee employee = context.tEmployee.SingleOrDefault<tEmployee>(z => z.ID == this.id);
                    this.txtUserName.Text = employee.Account;
                    this.txtName.Text = employee.EmpName;
                    this.ddlDeptID.SelectedValue = employee.DeptID.ToString();
                    this.txtTel.Text = employee.Mobile.ToString();
                    this.txtAddress.Text = employee.Address;
                    this.txtMail.Text = employee.Email;
                }
            }
        }
    }
}

