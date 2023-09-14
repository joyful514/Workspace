namespace AbMail
{
    using ProHelper;
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Web.Services;
    using yb;

    [WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1), WebService(Namespace="http://tempuri.org/"), ToolboxItem(false)]
    public class WMail : WebService
    {
        [WebMethod]
        public void RunMail1(string h, string s)
        {
            DataTable table = null;
            string cmdtext = string.Format("select id,date0,time1 from tbl_MailRun where auto='{0}'", h + ":" + s);
            table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet(cmdtext).Tables[0];
            if ((table != null) && (table.Rows.Count > 0))
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    new ybNewSqlHelper().ExecuteNonQuery("update tbl_MailRun set Run=1 where id='" + table.Rows[i]["id"].ToString() + "'");
                    if (Convert.ToDateTime(table.Rows[i]["date0"]) == DateTime.Now.Date)
                    {
                        try
                        {
                            string c = "";
                            if (DateTime.Now.Hour.ToString() == table.Rows[i]["time1"].ToString())
                            {
                                IAsyncResult result = new MyFunc(new Send().runMail).BeginInvoke(table.Rows[i]["id"].ToString(), "auto", out c, null, null);
                                Thread.Sleep(0x1388);
                            }
                        }
                        catch (ThreadAbortException)
                        {
                        }
                        catch (Exception exception)
                        {
                            new Send().insertErrorLog("", h + ":" + s, exception.Message.ToString(), 0, table.Rows[i]["EmpNO"].ToString());
                        }
                    }
                }
            }
        }

        [WebMethod]
        public void RunMail2(string h, string s)
        {
            DataTable table = null;
            string cmdtext = string.Format("select id,date0,time1 from tbl_MailRun where empno='" + ConfigurationManager.AppSettings["Db_id"] + "' and auto='{0}'", h + ":" + s);
            table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet(cmdtext).Tables[0];
            if ((table != null) && (table.Rows.Count > 0))
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    new ybNewSqlHelper().ExecuteNonQuery("update tbl_MailRun set Run=1 where id='" + table.Rows[i]["id"].ToString() + "'");
                    try
                    {
                        string c = "";
                        if (DateTime.Now.Hour.ToString() == table.Rows[i]["time1"].ToString())
                        {
                            IAsyncResult result = new MyFunc(new Send().runMail).BeginInvoke(table.Rows[i]["id"].ToString(), "auto", out c, null, null);
                            Thread.Sleep(0x4e20);
                        }
                    }
                    catch (ThreadAbortException)
                    {
                    }
                    catch (Exception exception)
                    {
                        new Send().insertErrorLog("", h + ":" + s, exception.Message.ToString(), 0, table.Rows[i]["EmpNO"].ToString());
                    }
                }
            }
        }

        public delegate void MyFunc(string a, string b, out string c);
    }
}

