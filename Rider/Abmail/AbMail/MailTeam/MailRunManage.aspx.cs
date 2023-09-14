namespace AbMail.MailTeam
{
    using System;
    using System.Text;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb;

    public class MailRun : BasePage
    {
        protected Button _btnNew;
        protected HtmlForm form1;
        protected ListView ListView1;
        protected ListView ListView2;
        protected ObjectDataSource Ods;
        protected ObjectDataSource Ods1;
        public string uname = "";

        protected void _btnNew_Click(object sender, EventArgs e) //d=0设置为可以发送状态
        {
            string cmdText = string.Format("update dbo.tbl_Customers set d=0 where EmpNO='{0}'", base.CurrentUser.EmpNO);
            int num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(cmdText);
        }

        public static string GetCheckBoxListSelVal(CheckBoxList ck)
        {
            string str = "";
            for (int i = 0; i < ck.Items.Count; i++)
            {
                if (ck.Items[i].Selected)
                {
                    str = str + ck.Items[i].Value + ",";
                }
            }
            return str.TrimEnd(new char[] { ',' });
        }

        public static string GetCheckedLvDataKey(ListView lv)
        {
            if (lv.DataKeyNames.Length == 0)
            {
                throw new ArgumentNullException("DataKeys", "未设置ListView的DataKeyNames");
            }
            StringBuilder builder = new StringBuilder("");
            int num = 0;
            foreach (ListViewItem item in lv.Items)
            {
                CheckBox box = (CheckBox)item.FindControl("chkItem");
                if (box.Checked)
                {
                    builder.Append(lv.DataKeys[num].Value.ToString());
                    builder.Append(",");
                }
                num++;
            }
            return builder.ToString().TrimEnd(new char[] { ',' });
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.uname = base.CurrentUser.EmpNO;
            if (base.CurrentUser.DeptID == 2M)
            {
              //  this.Ods.SelectParameters["where"].DefaultValue = " M like '成功%' and DATEDIFF(d,d,getdate())<=10 and EmpNO='" + base.CurrentUser.EmpNO + "'";
                this.Ods1.SelectParameters["where"].DefaultValue = " EmpNO='" + base.CurrentUser.EmpNO + "'";
            }
        }
    }
}

