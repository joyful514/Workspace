namespace Admin
{
    using System;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb.CtrlHelper;
    using yb.ProHelper;
    using yb.WebHelper;

    public class ChangePassword : BasePage
    {
        protected xMouseImage btnClose;
        protected xMouseImage btnSave;
        protected HtmlForm form1;
        protected TextBox txNewPwd;
        protected TextBox txOldPwd;
        protected TextBox txRepPwd;

        private void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            tEmployee employee = new tEmployee();
            switch (employee.ChangePwd(FormsAuthentication.HashPasswordForStoringInConfigFile(this.txOldPwd.Text.Trim(), "MD5"), FormsAuthentication.HashPasswordForStoringInConfigFile(this.txNewPwd.Text.Trim(), "MD5"), Convert.ToInt32(base.CurrentUser.ID.ToString())))
            {
                case -2:
                    ShowMessage.AjaxShow("原密码不正确。");
                    break;

                case -1:
                    ShowMessage.AjaxShow("修改密码失败。");
                    break;

                case 0:
                    ShowMessage.AjaxShow("修改密码成功。", true);
                    break;
            }
        }

        private void InitializeComponent()
        {
            this.btnSave.Click += new ImageClickEventHandler(this.btnSave_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.btnClose.Attributes.Add("onclick", "window.close();");
        }
    }
}

