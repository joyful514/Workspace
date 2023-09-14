namespace AbMail.MailTeam
{
    using ProHelper;
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb;
    using yb.WebHelper;

    public class ListImport : BasePage
    {
        protected Button _btnUnsub;
        protected DropDownList _DpTyep;
        protected TextBox _tbCountry;
        protected TextBox _tbName;
        protected Button btnUpload;
        protected HtmlForm form1;
        protected FileUpload fuExcel;
        protected HyperLink hlmb;
        protected Label lblmsg;
        protected Label lblup;

        protected void _btnUnsub_Click(object sender, EventArgs e)
        {
            string selectedValue = this._DpTyep.SelectedValue;
            if (selectedValue != null)
            {
                string[] strArray;
                string str2;
                int num;
                if (!(selectedValue == "1"))
                {
                    if (selectedValue == "2")
                    {
                        if (this._tbCountry.Text.Trim() != "")
                        {
                            if (this._tbName.Text.Trim() != "")
                            {
                                strArray = this._tbName.Text.ToString().Trim().Split(new char[] { '\r' });
                                foreach (string str in strArray)
                                {
                                    str2 = string.Format("update dbo.tbl_Customers set ourCustomer=1 where (fullName='{0}' or email='{0}' or customerId='{0}') and country='{1}' and empno={2}", str.Replace("\r", "").Replace("\n", "").Replace("'", "''"), this._tbCountry.Text.Trim(), base.CurrentUser.EmpName);
                                    num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(str2);
                                }
                            }
                            ShowMessage.AjaxShow("完成！");
                        }
                        else
                        {
                            if (this._tbName.Text.Trim() != "")
                            {
                                strArray = this._tbName.Text.ToString().Trim().Split(new char[] { '\r' });
                                foreach (string str in strArray)
                                {
                                    str2 = string.Format("update dbo.tbl_Customers set ourCustomer=1 where (fullName='{0}' or email='{0}' or customerId='{0}') and empno={1}", str.Replace("\r", "").Replace("\n", "").Replace("'", "''"), base.CurrentUser.EmpName);
                                    num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(str2);
                                }
                            }
                            ShowMessage.AjaxShow("完成！");
                        }
                    }
                    else if (selectedValue == "3")
                    {
                        if (this._tbCountry.Text.Trim() != "")
                        {
                            if (this._tbName.Text.Trim() != "")
                            {
                                strArray = this._tbName.Text.ToString().Trim().Split(new char[] { '\r' });
                                foreach (string str in strArray)
                                {
                                    str2 = string.Format("delete from dbo.tbl_Customers where (fullName='{0}' or email='{0}' or customerId='{0}') and country='{1}' and empno={2}", str.Replace("\r", "").Replace("\n", "").Replace("'", "''"), this._tbCountry.Text.Trim(), base.CurrentUser.EmpName);
                                    num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(str2);
                                }
                            }
                            ShowMessage.AjaxShow("删除完成！");
                        }
                        else
                        {
                            if (this._tbName.Text.Trim() != "")
                            {
                                strArray = this._tbName.Text.ToString().Trim().Split(new char[] { '\r' });
                                foreach (string str in strArray)
                                {
                                    str2 = string.Format("delete from dbo.tbl_Customers where (fullName='{0}' or email='{0}' or customerId='{0}') and empno={1}", str.Replace("\r", "").Replace("\n", "").Replace("'", "''"), base.CurrentUser.EmpName);
                                    num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(str2);
                                }
                            }
                            ShowMessage.AjaxShow("删除完成！");
                        }
                    }
                }
                else if (this._tbCountry.Text.Trim() != "")
                {
                    if (this._tbName.Text.Trim() != "")
                    {
                        strArray = this._tbName.Text.ToString().Trim().Split(new char[] { '\r' });
                        foreach (string str in strArray)
                        {
                            str2 = string.Format("update dbo.tbl_Customers set unsubscribe=1 where (fullName='{0}' or email='{0}' or customerId='{0}') and country='{1}' and empno='{2}'", str.Replace("\r", "").Replace("\n", "").Replace("'", "''"), this._tbCountry.Text.Trim(), base.CurrentUser.EmpName);
                            num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(str2);
                        }
                    }
                    ShowMessage.AjaxShow("退订完成！");
                }
                else
                {
                    if (this._tbName.Text.Trim() != "")
                    {
                        strArray = this._tbName.Text.ToString().Trim().Split(new char[] { '\r' });
                        foreach (string str in strArray)
                        {
                            str2 = string.Format("update dbo.tbl_Customers set unsubscribe=1 where (fullName='{0}' or email='{0}' or customerId='{0}') and empno={1}", str.Replace("\r", "").Replace("\n", "").Replace("'", "''"), base.CurrentUser.EmpNO);
                            num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(str2);
                        }
                    }
                    ShowMessage.AjaxShow("退订完成！");
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.fuExcel.HasFile)
            {
                string extension = Path.GetExtension(this.fuExcel.FileName);
                string filename = "";
                try
                {
                    Random random = new Random();
                    string str3 = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Convert.ToString(random.Next(0x2710, 0x4e20)) + extension.ToLower();
                    filename = base.Server.MapPath(@"TempFile\" + str3);
                    this.fuExcel.SaveAs(filename);
                    this.lblup.Text = "上传路径：" + filename;
                    string connectionString = "";
                    if (extension.ToLower() == ".xlsx")
                    {
                        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                    }
                    else
                    {
                        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
                    }
                    OleDbCommand selectCommand = new OleDbCommand("select * from [Sheet1$]", new OleDbConnection(connectionString));
                    OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    DataTable dt = dataSet.Tables[0];
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        tImport import = new tImport();
                        string str5 = "";
                        str5 = import.Import(dt, base.CurrentUser.EmpNO);
                        if (str5 != "")
                        {
                            this.lblmsg.Text = "导入完成:" + str5;
                        }
                        else
                        {
                            this.lblmsg.Text = "</br>数据导入完成.";
                        }
                    }
                    else
                    {
                        this.lblmsg.Text = "没有取得数据，文档格式不符合模板.";
                    }
                }
                catch (Exception exception)
                {
                    this.lblmsg.Text = "错误： " + exception.Message.ToString();
                }
            }
            else
            {
                this.lblmsg.Text = "不是Excel标准格式,请另存为Excel工作簿.";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(base.Server.MapPath("TempFile")))
            {
                Directory.CreateDirectory(base.Server.MapPath("TempFile"));
            }
        }
    }
}