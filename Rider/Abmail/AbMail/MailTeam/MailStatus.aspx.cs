namespace AbMail.MailTeam
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MailStatus : BasePage
    {
        protected Button _btnSearch;
        protected TextBox _tbEmail;
        protected TextBox _tbfullName;
        protected TextBox _tbtel;
        protected HtmlForm form1;
        protected ListView ListView1;
        protected ObjectDataSource Ods;
        protected string strsql = "";

        protected void _btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void BindData()
        {
            this.Ods.SelectParameters["SelectList"].DefaultValue = " top 10 * ";
            this.Ods.SelectParameters["where"].DefaultValue = this.Get_sqlSearch();
            this.ListView1.DataBind();
        }

        protected string Get_sqlSearch()
        {
            return string.Format(" {0} and {1} and {2} ", string.IsNullOrEmpty(this._tbtel.Text) ? "1=1" : (" phone like '%" + this._tbtel.Text.Trim() + "%'"), string.IsNullOrEmpty(this._tbEmail.Text) ? "1=1" : (" Email = '" + this._tbEmail.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbfullName.Text) ? "1=1" : (" fullName like '%" + this._tbfullName.Text.Trim() + "%'"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Ods.SelectParameters["SelectList"].DefaultValue = " top 1 * ";
                this.Ods.SelectParameters["where"].DefaultValue = this.Get_sqlSearch();
                this.ListView1.DataBind();
            }
        }
    }
}