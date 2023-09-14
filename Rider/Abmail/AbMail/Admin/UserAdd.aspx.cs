namespace AbMail.Admin
{
    using LinqHelper;
    using ProHelper;
    using System;
    using System.Web.Security;
    using System.Web.UI.WebControls;
    using yb.ProHelper;
    using yb.WebHelper;

    public class UserAdd : BasePage
    {
        protected Button btnsave;
        private Mail01DataContext db = dbLinq.GetErpData();
        protected DropDownList ddlDeptID;
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
            yb.ProHelper.tEmployee employee = new yb.ProHelper.tEmployee();
            if (employee.DuplicateUser(this.txtUserName.Text.ToString().Trim()))
            {
                flag = false;
                ShowMessage.AjaxShow("用户名已经存在,请换一个再注册!");
            }
            if (flag)
            {
                LinqHelper.tEmployee entity = new LinqHelper.tEmployee
                {
                    Account = this.txtUserName.Text.ToString().Trim(),
                    EmpName = this.txtName.Text.ToString().Trim(),
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtPwd.Text.ToString().Trim(), "MD5"),
                    DeptID = Convert.ToDecimal(this.ddlDeptID.SelectedValue)
                };
                entity.EmpNO = new CreateSysno().create("tEmployee", "EmpNO", 6, "", base.CurrentUser.EmpNO.Trim());
                entity.Mobile = this.txtTel.Text.ToString().Trim();
                entity.Address = this.txtAddress.Text.ToString().Trim();
                entity.Email = this.txtMail.Text.ToString().Trim();
                entity.Type = 0;
                entity.EnabledFlag = 1;
                entity.JoinDate = new DateTime?(DateTime.Now);
                this.db.tEmployee.InsertOnSubmit(entity);
                this.db.SubmitChanges();
                ShowMessage.AjaxShow("添加成功！");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

