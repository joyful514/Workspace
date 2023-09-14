namespace AbMail.Mail01
{
    using ProHelper;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb.SqlHelper;
    using yb.WebHelper;

    public class MailListManage : BasePage
    {
        protected Button _btnSearch;
        protected DropDownList _rbst;
        protected TextBox _tbArea;
        protected TextBox _tbCity;
        protected TextBox _tbCollector;
        protected TextBox _tbCollege;
        protected TextBox _tbCountry;
        protected TextBox _tbCustomerID;
        protected TextBox _tbEmail;
        protected TextBox _tbfullName;
        protected TextBox _tbGMT;
        protected TextBox _tblastName;
        protected DropDownList _tbod;
        protected TextBox _tbState;
        protected TextBox _tbTitle;
        protected TextBox _tbUniversity;
        protected TextBox _tbCount;
        protected Button btnSaveStrategy;
        protected HtmlForm form1;
        protected Label lblsql;
        protected Label lbltitle;
        protected ListView ListView1;
        protected ObjectDataSource Ods;
        protected ScriptManager ScriptManager1;
        protected string strsql = "";
        protected TextBox tbTitle;
        protected HiddenField HiddenField1;
        private string tmp = "";

        protected void _btnSearch_Click(object sender, EventArgs e)
        {
            
            this.BindData();
        }

        private void BindData()
        {
            
            this.Ods.SelectParameters["where"].DefaultValue = this.Get_sqlSearch();
            this.ListView1.DataBind();
          
        }

        protected void btnSaveStrategy_Click(object sender, EventArgs e)
        {
            if (HiddenField1!=null&&HiddenField1.Value.Trim()!="")
            {

                this.strsql = this.strsql + " and id in  (" + HiddenField1.Value.Trim() + ")";
            }
            else
            {
                this.strsql = tmp;
            }
           
            if (this.tbTitle.Text.Trim() != "")
            {
                CreateSysno sysno = new CreateSysno();
                ArrayList parameters = new ArrayList();
                parameters.Add(new SqlParameter("@id", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Guid.Empty));
                parameters.Add(new SqlParameter("@groupId", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, sysno.create("tbl_MailStrategyName", "groupId", 6, "G", base.CurrentUser.EmpNO.Trim())));
                parameters.Add(new SqlParameter("@mailStrategyName", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, this.tbTitle.Text));
                parameters.Add(new SqlParameter("@mailSql", SqlDbType.Text, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, this.strsql));
                parameters.Add(new SqlParameter("@createBy", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, base.CurrentUser.EmpName));
                parameters.Add(new SqlParameter("@createDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now.ToString()));
                parameters.Add(new SqlParameter("@ip", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, base.Request.UserHostAddress));
                parameters.Add(new SqlParameter("@EmpNO", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, base.CurrentUser.EmpNO.Trim()));
                try
                {
                    DBClass.ProcedureQuery("spAddMailStrategy", ref parameters);
                }
                catch (Exception exception)
                {
                    this.lblsql.Text = exception.ToString();
                }
                ShowMessage.AjaxShow("添加成功！");
            }
            else
            {
                ShowMessage.AjaxShow("邮件发送策略名不能为空！");
            }
            HiddenField1.Value = "";
        }

        protected string Get_sqlSearch()
        {
            return string.Format(" unsubscribe=0 and {0} and {1} and {2} and {3} and {4} and {5} and {6} and {7} and {8} and {9} and {10} and {11} and {12} and {13} and {14} and {15} and {16}", new object[] { string.IsNullOrEmpty(this._tbCustomerID.Text) ? "1=1" : (" CustomerID = '" + this._tbCustomerID.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbCollector.Text) ? "1=1" : (" Collector = '" + this._tbCollector.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbCountry.Text) ? "1=1" : (" Country = '" + this._tbCountry.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbState.Text) ? "1=1" : (" State = '" + this._tbState.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbCity.Text) ? "1=1" : (" City = '" + this._tbCity.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbArea.Text) ? "1=1" : (" Area like '%" + this._tbArea.Text.Trim() + "%'"), string.IsNullOrEmpty(this._tbGMT.Text) ? "1=1" : (" GMT = '" + this._tbGMT.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbTitle.Text) ? "1=1" : (" title = '" + this._tbTitle.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbUniversity.Text) ? "1=1" : (" University = '" + this._tbUniversity.Text.Trim() + "'"), string.IsNullOrEmpty(this._tbCollege.Text) ? "1=1" : (" College like '%" + this._tbCollege.Text.Trim() + "%'"), string.IsNullOrEmpty(this._tbEmail.Text) ? "1=1" : (" Email like '%" + this._tbEmail.Text.Trim() + "%'"), string.IsNullOrEmpty(this._tbfullName.Text) ? "1=1" : (" fullName like '%" + this._tbfullName.Text.Trim() + "%'"), string.IsNullOrEmpty(this._tblastName.Text) ? "1=1" : (" lastName like '%" + this._tblastName.Text.Trim() + "%'"), " 1=1 ", " 1=1 ", " EmpNO='" + base.CurrentUser.EmpNO.Trim() + "'", string.IsNullOrEmpty(this._tbCount.Text) ? "1=1" : (" sendCount = " + this._tbCount.Text.Trim()) });
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!base.IsPostBack)
            {
                this.Ods.SelectParameters["SelectList"].DefaultValue = " top 100 * ";
                this.Ods.SelectParameters["where"].DefaultValue = this.Get_sqlSearch();
                this.ListView1.DataBind();
            }
            this.strsql = "select id,customerId,email from tbl_Customers where d=0 and unsubscribe=0 and " + this.Get_sqlSearch();
            tmp = this.strsql;
            this.lblsql.Text = this.strsql;
        }

       

    

     

    }
}