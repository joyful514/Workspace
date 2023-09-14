namespace AbMail.MailConfig
{
    using LinqHelper;
    using ProHelper;
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb;
    using yb.WebHelper;

    public class MailContentAdd : BasePage
    {
        protected string _ID = "";
        protected Button btnsave;
        protected Button btnup;
        protected DropDownList ddlIsBodyHtml;
        protected DropDownList ddlIsReply;
        protected FileUpload fileFu;
        protected HtmlForm form1;
        protected Label lblcol;
        protected TextBox txtBody;
        protected TextBox txtMailID;
        protected TextBox txtReplyTo;
        protected TextBox txtSubject;
        protected TextBox txtTitle;
        protected TextBox txtUpFile;
        protected TextBox txtUrl;

        protected void btnsave_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (this.txtSubject.Text.ToString().Trim() == "")
            {
                flag = false;
                ShowMessage.AjaxShow("邮件主题不能为空!");
            }
            if (!(!(this.txtReplyTo.Text.ToString().Trim() != "") || tImport.isEmail(this.txtReplyTo.Text.ToString().Trim().ToLower())))
            {
                flag = false;
                ShowMessage.AjaxShow("回复邮件地址不符合规范!");
            }
            if (flag)
            {
                using (Mail01DataContext context = dbLinq.GetErpData())
                {
                    tbl_MailContent content;
                    if (this._ID != "")
                    {
                        content = context.tbl_MailContent.Single<tbl_MailContent>(z => z.id == Guid.Parse(this._ID));
                        content.subject = this.txtSubject.Text.ToString();
                        content.title = this.txtTitle.Text;
                        content.isBodyHtml = Convert.ToBoolean(this.ddlIsBodyHtml.SelectedValue);
                        content.isReply = Convert.ToBoolean(this.ddlIsReply.SelectedValue);
                        content.replyTo = this.txtReplyTo.Text;
                        content.body = this.txtBody.Text;
                        content.url = this.txtUrl.Text;
                        content.upfile = this.txtUpFile.Text;
                    }
                    else
                    {
                        content = new tbl_MailContent
                        {
                            id = Guid.NewGuid()
                        };
                        content.mailId = new CreateSysno().create("tbl_MailContent", "mailId", 6, "M", base.CurrentUser.EmpNO.Trim());
                        content.subject = this.txtSubject.Text.ToString();
                        content.title = this.txtTitle.Text;
                        content.isBodyHtml = Convert.ToBoolean(this.ddlIsBodyHtml.SelectedValue);
                        content.isReply = Convert.ToBoolean(this.ddlIsReply.SelectedValue);
                        content.replyTo = this.txtReplyTo.Text;
                        content.body = this.txtBody.Text;
                        content.url = this.txtUrl.Text;
                        content.upfile = this.txtUpFile.Text;
                        content.EmpNO = base.CurrentUser.EmpNO.Trim();
                        context.tbl_MailContent.InsertOnSubmit(content);
                    }
                    context.SubmitChanges();
                    ShowMessage.AjaxShow("添加成功！");
                }
            }
        }

        protected void btnup_Click(object sender, EventArgs e)
        {
            string filename = "";
            Random random = new Random();
            string str2 = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Convert.ToString(random.Next(0x186a0, 0x30d40)) + Path.GetExtension(this.fileFu.FileName);
            filename = base.Server.MapPath(@"AttachmentsFile\" + str2);
            if (this.fileFu.PostedFile.ContentLength <= 0xfa000)
            {
                this.fileFu.SaveAs(filename);
                this.txtUpFile.Text = filename;
            }
            else
            {
                JS.Alert("邮件附件大小不能超过1MB!");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet("Select name from syscolumns Where ID=OBJECT_ID('dbo.tbl_Customers')").Tables[0];
            string str = "";
            for (int i = 6; i < table.Rows.Count; i++)
            {
                str = str + "{" + table.Rows[i][0].ToString() + "} | ";
            }
            this.lblcol.Text = "内容变量:" + str;
            this._ID = Fetch.Get("ID").Trim();
            if (!Directory.Exists(base.Server.MapPath("AttachmentsFile")))
            {
                Directory.CreateDirectory(base.Server.MapPath("AttachmentsFile"));
            }
            if (!base.IsPostBack && (this._ID != ""))
            {
                using (Mail01DataContext context = dbLinq.GetErpData())
                {
                    tbl_MailContent content = context.tbl_MailContent.SingleOrDefault<tbl_MailContent>(z => z.id == Guid.Parse(this._ID));
                    this.txtMailID.Text = content.mailId;
                    this.txtSubject.Text = content.subject;
                    this.txtTitle.Text = content.title;
                    this.ddlIsBodyHtml.SelectedValue = content.isBodyHtml.ToString();
                    this.ddlIsReply.SelectedValue = content.isReply.ToString();
                    this.txtReplyTo.Text = content.replyTo;
                    this.txtBody.Text = content.body;
                    this.txtUrl.Text = content.url;
                    this.txtUpFile.Text = content.upfile;
                }
            }
        }
    }
}