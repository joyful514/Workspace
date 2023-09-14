namespace AbMail
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb.WebHelper;

    public class Default : BasePage
    {
        protected HtmlGenericControl aLoginOut;
        protected Button btnLogout;
        protected HtmlForm form1;
        protected LinkButton LinkButton1;

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this.Session.Abandon();
            this.Session.Clear();
           // Cookie.Remove("cookieUserInfo");
            base.Response.Write("<script>window.close();</script>");
            this.Page.Response.End();
        }

        public string GetMenuString()
        {
            return MenuDAL.Current.CreateHTML();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
            }
        }
    }
}