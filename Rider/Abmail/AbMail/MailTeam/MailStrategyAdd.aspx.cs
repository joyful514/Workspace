using ProHelper;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using yb;
using yb.WebHelper;
namespace AbMail.Mail01
{
 

    public class MailStrategyAdd : BasePage
    {
        protected string _ID = "";
        protected Button btnsave;
        protected string conn = "";
        protected HtmlForm form1;
        protected Label Label1;
        protected TextBox txtGroupId;
        protected TextBox txtMailSql;
        protected TextBox txtMailStrategyName;

        protected void btnsave_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if ((this.txtMailStrategyName.Text.ToString().Trim() == "") && (this.txtMailSql.Text.ToString().Trim() == ""))
            {
                flag = false;
                ShowMessage.AjaxShow("策略名和SQL不能为空!");
            }
            if (flag)
            {
                CreateSysno sysno = new CreateSysno();
                ArrayList parameters = new ArrayList();
                if (this._ID != "")
                {
                    parameters.Add(new SqlParameter("@id", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Guid.Parse(this._ID)));
                    parameters.Add(new SqlParameter("@groupId", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, this.txtGroupId.Text));
                }
                else
                {
                    parameters.Add(new SqlParameter("@id", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Guid.Empty));
                    parameters.Add(new SqlParameter("@groupId", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, sysno.create("tbl_MailStrategyName", "groupId", 6, "G", base.CurrentUser.EmpNO.Trim())));
                }
                parameters.Add(new SqlParameter("@mailStrategyName", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, this.txtMailStrategyName.Text));
                parameters.Add(new SqlParameter("@mailSql", SqlDbType.Text, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, this.txtMailSql.Text));
                parameters.Add(new SqlParameter("@createBy", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, base.CurrentUser.EmpName));
                parameters.Add(new SqlParameter("@createDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now.ToString()));
                parameters.Add(new SqlParameter("@ip", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, base.Request.UserHostAddress));
                parameters.Add(new SqlParameter("@EmpNO", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, base.CurrentUser.EmpNO.Trim()));
                try
                {
                    int num = new ybNewSqlHelper("ConnectionString").ProcedureNOQuery("spAddMailStrategy", ref parameters);
                }
                catch (Exception exception)
                {
                    ShowMessage.AjaxShow(exception.ToString());
                }
                ShowMessage.AjaxShow("添加成功！");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this._ID = Fetch.Get("ID").Trim();
            if (!base.IsPostBack && (this._ID != ""))
            {
                string cmdtext = string.Format("select * from tbl_MailStrategyName where id='{0}'", this._ID);
                DataTable table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet(cmdtext).Tables[0];
                if ((table != null) && (table.Rows.Count > 0))
                {
                    this.txtGroupId.Text = table.Rows[0]["groupId"].ToString();
                    this.txtMailStrategyName.Text = table.Rows[0]["mailStrategyName"].ToString();
                    this.txtMailSql.Text = table.Rows[0]["mailSql"].ToString();
                }
            }
        }
    }
}