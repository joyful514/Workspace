using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AbMail.Mail01
{
    public class MailStrategy : BasePage
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