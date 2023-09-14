namespace AbMail.MailConfig
{
    using LinqHelper;
    using ProHelper;
    using System;
    using System.Linq;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb.WebHelper;

    public class MailServerAdd : BasePage
    {
        protected string _ID = "";
        protected Button btnsave;
        protected DropDownList ddlEnableSsl;
        protected DropDownList ddlPriority;
        protected HtmlForm form1;
        protected TextBox txtForm;
        protected TextBox txtHostId;
        protected TextBox txtPop3;
        protected TextBox txtPop3Port;
        protected TextBox txtPort;
        protected TextBox txtSmtp;

        protected void btnsave_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if ((this.txtSmtp.Text.ToString().Trim() == "") && (this.txtPort.Text.ToString().Trim() == ""))
            {
                flag = false;
                ShowMessage.AjaxShow("Smtp地址和端口号不能为空!");
            }
            if (flag)
            {
                using (Mail01DataContext context = dbLinq.GetErpData())
                {
                    tbl_MailServerGroup group;
                    if (this._ID != "")
                    {
                        group = context.tbl_MailServerGroup.Single<tbl_MailServerGroup>(z => z.id == Guid.Parse(this._ID));
                        group.smtp = this.txtSmtp.Text.ToString();
                        group.smtp_port = this.txtPort.Text.ToString();
                        group.pop3 = this.txtPop3.Text.ToString();
                        group.pop3_port = this.txtPop3Port.Text.ToString();
                        group.priority = this.ddlPriority.SelectedValue;
                        group.enableSsl = new bool?(Convert.ToBoolean(this.ddlEnableSsl.SelectedValue));
                        group.mailFrom = this.txtForm.Text.ToString();
                    }
                    else
                    {
                        group = new tbl_MailServerGroup
                        {
                            id = Guid.NewGuid(),
                            smtp = this.txtSmtp.Text.ToString(),
                            smtp_port = this.txtPort.Text.ToString(),
                            pop3 = this.txtPop3.Text.ToString(),
                            pop3_port = this.txtPop3Port.Text.ToString(),
                            priority = this.ddlPriority.SelectedValue,
                            enableSsl = new bool?(Convert.ToBoolean(this.ddlEnableSsl.SelectedValue)),
                            mailFrom = this.txtForm.Text.ToString()
                        };
                        group.hostid = new CreateSysno().create("tbl_MailServerGroup", "hostid", 6, "S", base.CurrentUser.EmpNO.Trim());
                        group.Rd = false;
                        group.EmpNO = base.CurrentUser.EmpNO.Trim();
                        context.tbl_MailServerGroup.InsertOnSubmit(group);
                    }
                    context.SubmitChanges();
                    ShowMessage.AjaxShow("添加成功！");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this._ID = Fetch.Get("ID").Trim();
            if (!base.IsPostBack && (this._ID != ""))
            {
                using (Mail01DataContext context = dbLinq.GetErpData())
                {
                    tbl_MailServerGroup group = context.tbl_MailServerGroup.SingleOrDefault<tbl_MailServerGroup>(z => z.id == Guid.Parse(this._ID));
                    this.txtHostId.Text = group.hostid;
                    this.txtSmtp.Text = group.smtp;
                    this.txtPort.Text = group.smtp_port;
                    this.txtPop3.Text = group.pop3;
                    this.txtPop3Port.Text = group.pop3_port;
                    this.ddlPriority.SelectedValue = group.priority;
                    this.ddlEnableSsl.SelectedValue = group.enableSsl.ToString();
                    this.txtForm.Text = group.mailFrom;
                }
            }
        }
    }
}