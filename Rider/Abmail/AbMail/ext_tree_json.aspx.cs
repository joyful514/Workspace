namespace AbMail
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class ext_tree_json : Page
    {
        protected HtmlForm form1;

        protected void Page_Load(object sender, EventArgs e)
        {
            string empId = "0";
            if (base.Request.Cookies["cookieUserInfo"] != null)
            {
                empId = base.Request.Cookies["cookieUserInfo"]["EmpID"].ToString();
            }
           
            HttpContext.Current.Response.Write(ExtTree.Current.CreateExtTreeJSON(empId));
            HttpContext.Current.Response.End();
        }
    }
}

