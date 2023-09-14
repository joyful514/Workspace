namespace AbMail.MailTeam
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb;
    using yb.WebHelper;

    public class MailLogManage : BasePage
    {
        protected Button _btnSearch;
        protected TextBox _empno;
        protected DropDownList _rbTime;
        protected TextBox _tbgroupId;
        protected TextBox _tbrId;
        protected TextBox _tbto;
        protected TextBox datepicker1;
        protected TextBox datepicker2;
        protected Button delAllBtn;
        protected HtmlForm form1;
        protected ListView ListView1;
        protected ObjectDataSource Ods;

        protected void _btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void BindData()
        {
            this.Ods.SelectParameters["where"].DefaultValue = this.Get_sqlSearch();
            this.ListView1.DataBind();
        }

        protected void delAllBtn_Click(object sender, EventArgs e)
        {
            int num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery("delete from dbo.tbl_MailLog where EmpNO='" + base.CurrentUser.EmpNO.Trim() + "'");
            ShowMessage.Show(this.Page, "清除完成", "MailLogManage.aspx");
        }

        protected string Get_sqlSearch()
        {
            if (base.CurrentUser.DeptID == 2M)
            {
                return string.Format(" {0} and {1} and {2} and {3} and {4}", new object[] { ((!string.IsNullOrEmpty(this._rbTime.SelectedValue) && !string.IsNullOrEmpty(this.datepicker1.Text)) && !string.IsNullOrEmpty(this.datepicker2.Text)) ? (this._rbTime.SelectedValue + " between '" + this.datepicker1.Text.Trim() + "' and '" + Convert.ToDateTime(this.datepicker2.Text).AddHours(23.0).AddMinutes(59.0).ToString() + "'") : " 1=1 ", string.IsNullOrEmpty(this._tbrId.Text) ? "1=1" : (" rId = '" + this._tbrId.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbgroupId.Text) ? "1=1" : (" groupId = '" + this._tbgroupId.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbto.Text) ? "1=1" : (" [to] = '" + this._tbto.Text.Trim() + "'"), " EmpNO='" + base.CurrentUser.EmpNO.Trim() + "'" });
            }
            return string.Format(" {0} and {1} and {2} and {3} and {4}", new object[] { ((!string.IsNullOrEmpty(this._rbTime.SelectedValue) && !string.IsNullOrEmpty(this.datepicker1.Text)) && !string.IsNullOrEmpty(this.datepicker2.Text)) ? (this._rbTime.SelectedValue + " between '" + this.datepicker1.Text.Trim() + "' and '" + Convert.ToDateTime(this.datepicker2.Text).AddHours(23.0).AddMinutes(59.0).ToString() + "'") : " 1=1 ", string.IsNullOrEmpty(this._tbrId.Text) ? "1=1" : (" rId = '" + this._tbrId.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbgroupId.Text) ? "1=1" : (" groupId = '" + this._tbgroupId.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbto.Text) ? "1=1" : (" [to] = '" + this._tbto.Text.Trim() + "'"), string.IsNullOrEmpty(this._empno.Text) ? "1=1" : (" EmpNO = '" + this._empno.Text.Trim() + "'") });
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Ods.SelectParameters["where"].DefaultValue = this.Get_sqlSearch();
                this.ListView1.DataBind();
            }
        }
    }
}