using System.Runtime.CompilerServices;

namespace AbMail
{
    using LinqHelper;
    using ProHelper;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb.WebHelper;

    public class login : Page
    {
        protected CheckBox chbSavePassword;
        protected Button cmdLogin;
        protected HtmlForm form1;
        protected Label lblMessage;
        protected RequiredFieldValidator RequiredFieldValidator1;
        protected RequiredFieldValidator RequiredFieldValidator2;
        protected TextBox txtLoginName;
        protected TextBox txtLoginPassword;

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            if (CP.Copyright())
            {


                Cookie.Remove("cookieUserInfo");
                tEmployee employee = dbLinq.GetErpData().tEmployee.FirstOrDefault<tEmployee>(z => (z.Account == this.txtLoginName.Text.Trim()) && (z.Password == FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtLoginPassword.Text.Trim(), "md5")));
                if (employee == null)
                {
                    this.lblMessage.Text = "用户名或密码错误！";
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("cookieUserInfo");
                    if (base.Request.Browser.Cookies)
                    {
                        cookie["UserLogin"] = Server.UrlEncode(this.txtLoginName.Text);
                        cookie["EmpID"] = employee.ID.ToString();
                        if (this.chbSavePassword.Checked)
                        {
                            cookie.Expires = DateTime.Now.AddDays(30.0);
                        }
                        else
                        {
                            cookie.Expires = DateTime.Now.AddDays(1.0);
                        }
                        base.Response.Cookies.Add(cookie);
                    }
                    this.Page.Response.Redirect("Default1.aspx");
                }
            }
            else
            {
                ShowMessage.AjaxShow("试用期结束请联系开发商QQ:30619024.");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            if (!this.Page.IsPostBack)
            {
                if (base.Request.QueryString["user"] != null)
                {
                    this.txtLoginName.Text = base.Request.QueryString["user"];
                    this.txtLoginPassword.Attributes.Add("value", "");
                }
                else if (base.Request.Browser.Cookies)
                {
                    if (base.Request.Cookies["cookieUserInfo"] != null)
                    {
                        this.txtLoginName.Text = Server.UrlDecode(base.Request.Cookies["cookieUserInfo"]["UserLogin"]);
                        this.txtLoginPassword.Attributes.Add("value", base.Request.Cookies["cookieUserInfo"]["UserPwd"]);
                        this.chbSavePassword.Checked = true;
                    }
                    this.chbSavePassword.Visible = true;
                }
                else
                {
                    this.chbSavePassword.Visible = false;
                }
                this.Session.Clear();
            }
            if (this.txtLoginName.Text == "")
            {
                this.Page.SetFocus(this.txtLoginName);
            }
            else
            {
                this.Page.SetFocus(this.txtLoginPassword);
            }

            this.txtLoginPassword.Text = "10000";
            this.txtLoginName.Text = "10000";
        }
        
    }
}

