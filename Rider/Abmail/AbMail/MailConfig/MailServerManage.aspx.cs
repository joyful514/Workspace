namespace AbMail.Mail
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MailServerManage : BasePage
    {
        protected HtmlForm form1;
        protected ListView ListView1;
        protected ObjectDataSource Ods;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.CurrentUser.DeptID == 2M)
            {
                this.Ods.SelectParameters["where"].DefaultValue = " EmpNO='" + base.CurrentUser.EmpNO.Trim() + "'";
            }
        }
    }
}