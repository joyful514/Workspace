namespace AbMail.MailTeam
{
    using LinqHelper;
    using ProHelper;
    using System;
    using System.Linq;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb.WebHelper;

    public class MailRunAdd : BasePage
    {
        protected string _ID = "";
        protected Button btnsave;
        protected TextBox datepicker1;
        protected DropDownList ddlHostID;
        protected DropDownList ddlMailID;
        protected DropDownList ddlNum;
        protected DropDownList ddlSec;
        protected DropDownList ddlStrID;
        protected DropDownList ddlTime1;
        protected DropDownList ddlTime2;
        protected HtmlForm form1;
        protected Label Label1;
        protected SqlDataSource SqlDataSource1;
        protected SqlDataSource SqlDataSource2;
        protected SqlDataSource SqlDataSource3;
        protected TextBox txtGroupId;

        protected void btnsave_Click(object sender, EventArgs e)
        {
            using (Mail01DataContext context = dbLinq.GetErpData())
            {
                tbl_MailRun run;
                if (this._ID != "")
                {
                    run = context.tbl_MailRun.Single<tbl_MailRun>(z => z.id == Guid.Parse(this._ID));
                    run.hostid = this.ddlHostID.SelectedValue.ToString();
                    run.mailId = this.ddlMailID.SelectedValue.ToString();
                    run.groupId = this.ddlStrID.SelectedValue.ToString();
                    run.num = new decimal?(Convert.ToDecimal(this.ddlNum.SelectedValue));
                    run.timenum = new decimal?(Convert.ToDecimal(this.ddlSec.SelectedValue));
                    run.Time1 = this.ddlTime1.SelectedValue;
                    run.Time2 = this.ddlTime2.SelectedValue;
                    run.auto = this.ddlTime1.SelectedValue + ":" + this.ddlTime2.SelectedValue;
                    run.Date0 = new DateTime?(Convert.ToDateTime(this.datepicker1.Text));
                }
                else
                {
                    run = new tbl_MailRun
                    {
                        id = Guid.NewGuid()
                    };
                    run.rid = new CreateSysno().create("tbl_MailRun", "rid", 6, "R", base.CurrentUser.EmpNO.Trim());
                    run.hostid = this.ddlHostID.SelectedValue.ToString();
                    run.mailId = this.ddlMailID.SelectedValue.ToString();
                    run.groupId = this.ddlStrID.SelectedValue.ToString();
                    run.num = new decimal?(Convert.ToDecimal(this.ddlNum.SelectedValue));
                    run.timenum = new decimal?(Convert.ToDecimal(this.ddlSec.SelectedValue));
                    run.Time1 = this.ddlTime1.SelectedValue;
                    run.Time2 = this.ddlTime2.SelectedValue;
                    run.auto = this.ddlTime1.SelectedValue + ":" + this.ddlTime2.SelectedValue;
                    run.Date0 = new DateTime?(Convert.ToDateTime(this.datepicker1.Text));
                    run.EmpNO = base.CurrentUser.EmpNO.Trim();
                    context.tbl_MailRun.InsertOnSubmit(run);
                }
                context.SubmitChanges();
                ShowMessage.AjaxShow("添加成功！");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this._ID = Fetch.Get("ID").Trim();
            this.SqlDataSource1.SelectCommand = "SELECT * FROM [tbl_MailServerGroup] where EmpNO='" + base.CurrentUser.EmpNO + "' ORDER BY [hostid]";
            this.SqlDataSource2.SelectCommand = "SELECT [mailId] FROM [tbl_MailContent] where EmpNO='" + base.CurrentUser.EmpNO + "' ORDER BY [mailId]";
            this.SqlDataSource3.SelectCommand = "SELECT [groupId] FROM [tbl_MailStrategyName] where EmpNO='" + base.CurrentUser.EmpNO + "' ORDER BY [groupId]";
            if (!base.IsPostBack)
            {
                if (this._ID != "")
                {
                    using (Mail01DataContext context = dbLinq.GetErpData())
                    {
                        tbl_MailRun run = context.tbl_MailRun.SingleOrDefault<tbl_MailRun>(z => z.id == Guid.Parse(this._ID));
                        this.txtGroupId.Text = run.rid;
                        try
                        {
                            this.ddlHostID.SelectedValue = run.hostid;
                            this.ddlMailID.SelectedValue = run.mailId;
                            this.ddlStrID.SelectedValue = run.groupId;
                        }
                        catch (Exception)
                        {
                        }
                        this.ddlNum.SelectedValue = run.num.ToString();
                        this.ddlSec.SelectedValue = run.timenum.ToString();
                        this.ddlTime1.SelectedValue = run.Time1;
                        this.ddlTime2.SelectedValue = run.Time2;
                        this.datepicker1.Text = run.Date0.Value.ToShortDateString();
                    }
                }
                else
                {
                    this.datepicker1.Text = DateTime.Now.ToShortDateString();
                }
            }
        }
    }
}

