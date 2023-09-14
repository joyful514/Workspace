using System.Text;

namespace ProHelper
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;
    using System.Net.Mail;
    using System.Runtime.InteropServices;
    using System.Threading;
    using yb;
    using yb.SqlHelper;

    public class Send
    {

        [DllImport("Go.dll", EntryPoint = "sendMailUsingGo", CallingConvention = CallingConvention.Cdecl)] 
        extern static IntPtr sendMailUsingGo(string from, string to, string reply, byte[] subject,
            byte[] body, string host, int port, string user, string pwd);

        [DllImport("Go.dll", EntryPoint = "test1", CallingConvention = CallingConvention.Cdecl)]
        extern static void test1();
        public DataTable getLastestMailAddress(string mailSql, string rid, string groupId, string mailId, string EmpNO, int num)
        {
            DataTable objA = null;
            if (ReferenceEquals(objA, null))
            {
                try
                {
                    ArrayList parameters = new ArrayList {
                        new SqlParameter("@Msql", SqlDbType.Text, 0x7d0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, mailSql),
                        new SqlParameter("@Rid", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, rid),
                        new SqlParameter("@Gid", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, groupId),
                        new SqlParameter("@Mid", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, mailId),
                        new SqlParameter("@EmpNO", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, EmpNO),
                        new SqlParameter("@Num", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, num)
                    };
                    objA = DBClass.ProcedureQueryDataSet("spLastestMailAddess", ref parameters).Tables[0];
                }
                catch (Exception exception)
                {
                    this.insertErrorLog("", "系统错误", "spLastestMailAddess," + exception.Message.ToString(), 1, EmpNO);
                }
            }
            return objA;
        }

        public void insertErrorLog(string rid, string customerId, string strMsg, int y, string EmpNO)
        {
            object[] objArray = new object[] { "insert into tbl_Error (rId,n,m,y,d,EmpNO) values ('", rid, "','", customerId, "','", strMsg, "','", y, "','", "", "", "", "" };
            objArray[9] = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            objArray[10] = "','";
            objArray[11] = EmpNO;
            objArray[12] = "')";
            string cmdText = string.Concat(objArray);
            int num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(cmdText);
        }

        public void insertMailLog(string rid, string customerId, string to, string groupId, string mailId, string subject, string mf, string strUser, string EmpNO)
        {
            string[] strArray = new string[] { "insert into tbl_MailLog (rId,customerId,[to],groupId,mailId,address,createBy,createDate,EmpNO,subject) values ('", rid, "','", customerId, "','", to, "','", groupId, "','", "", "", "", "", "", "", "", "", "", "", "", "" };
            strArray[9] = mailId;
            strArray[10] = "','";
            strArray[11] = mf;
            strArray[12] = "','";
            strArray[13] = strUser;
            strArray[14] = "','";
            strArray[15] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            strArray[0x10] = "','";
            strArray[0x11] = EmpNO;
            strArray[0x12] = "','";
            strArray[0x13] = subject;
            strArray[20] = "')";
            string cmdText = string.Concat(strArray);
            int num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(cmdText);
        }

        public bool isCheck(string rid, string customerId, string groupId, string mailId)
        {
            string[] strArray = new string[] { "select id from tbl_MailLog where rId='", rid, "' and customerId='", customerId, "' and groupId='", groupId, "' and mailId='", mailId, "'" };
            string cmdtext = string.Concat(strArray);
            DataTable table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet(cmdtext).Tables[0];
            return ((table == null) || (table.Rows.Count <= 0));
        }

        public bool isRun(string id)
        {
            string cmdtext = "select run from tbl_MailRun where id='" + id + "'";
            DataTable table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet(cmdtext).Tables[0];
            return (((table != null) && (table.Rows.Count > 0)) && Convert.ToBoolean(table.Rows[0]["run"]));
        }

        public void isSend(string gid, string to)
        {
            string cmdText = $"update dbo.tbl_Customers set d=1 where id='{gid}'";
            new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(cmdText);
            string cmdtext = $"select count([to]) from dbo.tbl_MailLog where [to]='{to}'";
            int num = Convert.ToInt32(new ybNewSqlHelper("ConnectionString").ExecuteDataSet(cmdtext).Tables[0].Rows[0][0]);
            cmdText = $"update dbo.tbl_Customers set sendCount={num} where email='{to}'";
            new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(cmdText);
        }

        public void runMail(string strIds, string strUser, out string Mailmsg)
        {
            string[] strArray5;
            int num11;
            Mailmsg = "";
            string empNO = "";
            int num = 0;
            int y = 0;
            char[] separator = new char[] { ',' };
            string[] strArray = strIds.ToString().Split(separator);
            DataTable table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet("Select name from syscolumns Where ID=OBJECT_ID('dbo.tbl_Customers')").Tables[0];
            if (strArray == null)
            {
                return;
            }
            else
            {
                strArray5 = strArray;
                num11 = 0;
            }
            while (true)
            {
                while (true)
                {
                    bool flag4 = num11 < strArray5.Length;
                    if (flag4)
                    {
                        string str2 = strArray5[num11];
                        try
                        {
                            DataTable table2 = null;
                            DataTable table3 = null;
                            string rid = "";
                            string from = "";
                            string reply = "";
                            string host = "";
                            int port = 0;
                            string user = "";
                            string pwd = "";
                            string str9 = "";
                            bool enableSsl = false;
                            bool isBodyHtml = false;
                            bool isReply = false;
                            string displayname = "";
                            string groupId = "";
                            string str12 = "";
                            string str13 = "";
                            string mailId = "";
                            string str15 = "";
                            string str16 = "";
                            string str17 = "";
                            string attachment = "";
                            int num4 = 0;
                            int num5 = 0;
                            int num6 = 0;
                            table2 = new ybNewSqlHelper("ConnectionString").ExecuteDataSet($"select * from vwMailRun where id='{str2}'").Tables[0];
                            flag4 = (table2 == null) || (table2.Rows.Count <= 0);
                            if (flag4)
                            {
                                Mailmsg = "不存在对应的邮件组！";
                            }
                            else
                            {
                                empNO = table2.Rows[0]["EmpNO"].ToString();
                                rid = table2.Rows[0]["rid"].ToString();
                                reply = table2.Rows[0]["replyTo"].ToString();
                                isReply = Convert.ToBoolean(table2.Rows[0]["isReply"]);
                                host = table2.Rows[0]["smtp"].ToString();
                                port = Convert.ToInt32(table2.Rows[0]["smtp_port"]);
                                str9 = table2.Rows[0]["priority"].ToString();
                                enableSsl = Convert.ToBoolean(table2.Rows[0]["enableSsl"]);
                                isBodyHtml = Convert.ToBoolean(table2.Rows[0]["isBodyHtml"]);
                                displayname = table2.Rows[0]["title"].ToString();
                                groupId = table2.Rows[0]["groupId"].ToString();
                                str12 = table2.Rows[0]["mailStrategyName"].ToString();
                                str13 = table2.Rows[0]["mailSql"].ToString();
                                mailId = table2.Rows[0]["mailId"].ToString();
                                str16 = table2.Rows[0]["body"].ToString();
                                str17 = table2.Rows[0]["url"].ToString();
                                attachment = table2.Rows[0]["upfile"].ToString();
                                num4 = Convert.ToInt32(table2.Rows[0]["num"]);
                                num5 = Convert.ToInt32(table2.Rows[0]["timenum"]);
                                flag4 = table2.Rows[0]["mailFrom"].ToString().Split(new char[] { '|' }).Length < 2;
                                if (flag4)
                                {
                                    Mailmsg = "邮件组配置错误！";
                                }
                                else
                                {
                                    string[] strArray2 = table2.Rows[0]["mailFrom"].ToString().Trim().Replace("\r\n", "#").Split(new char[] { '#' });
                                    table3 = this.getLastestMailAddress(str13.Replace("'", "9@9"), rid, groupId, mailId, empNO, num4);
                                    flag4 = (table3 == null) || (table3.Rows.Count <= 0);
                                    if (flag4)
                                    {
                                        Mailmsg = "本邮件组已经全部发送完成。";
                                    }
                                    else
                                    {
                                        int num7 = 0;
                                        while (true)
                                        {
                                            flag4 = num7 < table3.Rows.Count;
                                            if (!flag4 || !new Send().isRun(str2))
                                            {
                                                this.insertErrorLog(rid, "", "成功:" + num.ToString() + ",失败:" + y.ToString(), y, empNO);
                                                break;
                                            }
                                            DataTable table4 = new ybNewSqlHelper("ConnectionString").ExecuteDataSet($"select * from dbo.tbl_Customers where id='{table3.Rows[num7]["id"].ToString()}'").Tables[0];
                                            if ((table4 != null) && (table4.Rows.Count > 0))
                                            {
                                                string[] strArray3 = strArray2[num6 % strArray2.Length].Split(new char[] { '|' });
                                                from = strArray3[0].ToString().Trim();
                                                user = strArray3[0].ToString().Trim();
                                                pwd = strArray3[1].ToString().Trim();
                                                if (table2.Rows[0]["subject"].ToString().Trim().Split(new char[] { '|' }).Length < 2)
                                                {
                                                    str15 = table2.Rows[0]["subject"].ToString();
                                                }
                                                else
                                                {
                                                    string[] strArray4 = table2.Rows[0]["subject"].ToString().Trim().Split(new char[] { '|' });
                                                    str15 = strArray4[new Random().Next(0, strArray4.Length - 1)].ToString().Trim().Replace("\r\n", "");
                                                }
                                                string subject = str15;
                                                string body = "";
                                                body = isBodyHtml ? str16 : str17;
                                                subject = subject.Replace("{mailId}", mailId);
                                                body = body.Replace("{mailId}", mailId);
                                                int num9 = 6;
                                                while (true)
                                                {
                                                    flag4 = num9 < table.Rows.Count;
                                                    if (!flag4)
                                                    {
                                                        string strMsg = "";
                                                        try
                                                        {
                                                            flag4 = !this.sendMail(from, table3.Rows[num7]["email"].ToString().Trim(), reply, subject, body, host, port, isBodyHtml, enableSsl, isReply, user, pwd, displayname, attachment, empNO, y, rid, table3.Rows[num7]["customerId"].ToString().Trim());
                                                            if (flag4)
                                                            {
                                                                this.insertErrorLog(rid, table3.Rows[num7]["customerId"].ToString().Trim(), strMsg, y + 1, empNO);
                                                            }
                                                            else
                                                            {
                                                                this.insertMailLog(rid, table3.Rows[num7]["customerId"].ToString().Trim(), table3.Rows[num7]["email"].ToString().Trim(), groupId, mailId, subject.Replace("'", "''"), from, strUser, empNO);
                                                                this.isSend(table3.Rows[num7]["id"].ToString(), table3.Rows[num7]["email"].ToString().Trim());
                                                                num++;
                                                                Thread.Sleep((int)(Convert.ToInt32(table2.Rows[0]["timenum"]) * 0x3e8));
                                                            }
                                                        }
                                                        catch (ThreadAbortException exception)
                                                        {
                                                            this.insertErrorLog(rid, table3.Rows[num7]["customerId"].ToString().Trim(), exception.Message.ToString(), y, empNO);
                                                        }
                                                        catch (Exception exception2)
                                                        {
                                                            this.insertErrorLog(rid, table3.Rows[num7]["customerId"].ToString().Trim(), exception2.Message.ToString(), y, empNO);
                                                        }
                                                        num6++;
                                                        break;
                                                    }
                                                    subject = subject.Replace("{" + table.Rows[num9][0].ToString() + "}", table4.Rows[0][table.Rows[num9][0].ToString()].ToString());
                                                    body = body.Replace("{" + table.Rows[num9][0].ToString() + "}", table4.Rows[0][table.Rows[num9][0].ToString()].ToString());
                                                    num9++;
                                                }
                                            }
                                            num7++;
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        return;
                    }
                    break;
                }
                num11++;
            }
        }

        private static byte[] getUTF8Bytes(string s)
        {
            return Encoding.GetEncoding("utf-8").GetBytes(s);
        }

        private static string InsertChars(string input, int interval, string value)
        {
            for (int i = interval; i < input.Length; i += interval + 1)
            {
                input = input.Insert(i, value);
            }

            return input;
        }

        public bool sendMail(string from, string to, string reply, string subject, string body, string host, int port, bool IsBodyHtml, bool EnableSsl, bool isReply, string user, string pwd, string displayname, string attachment, string EmpNO, int row, string rid, string cusid)
        {   
            bool flag = true;
            string err = "";
            if (("smtp.qcloudmail.com").Equals(host))
            {
                try
                {
                    IntPtr pBuffer = sendMailUsingGo(from, to, reply, getUTF8Bytes(subject),
                        getUTF8Bytes(InsertChars(body,100,"\n")), host, port, user, pwd);
                    err = Marshal.PtrToStringAnsi(pBuffer);
                    if (!"".Equals(err))
                    {
                        this.insertErrorLog(rid, cusid, err, row, EmpNO);
                        flag = false;
                    }

                }
                catch(Exception e)
                {
                    this.insertErrorLog(rid, cusid, e.Message.ToString(), row, EmpNO);
                    flag = false;
                }
            }
            else
            {
                try
                {
                    MailMessage message = new MailMessage
                    {
                        From = new MailAddress(from, displayname)
                    };
                    message.To.Add(to);
                    message.Subject = subject;
                    message.IsBodyHtml = IsBodyHtml;
                    message.Body = body;
                    message.Priority = MailPriority.Normal;
                    if (reply.Trim() != "")
                    {
                        if (isReply)
                        {
                            message.Headers.Add("Disposition-Notification-To", reply);
                        }
                        message.ReplyToList.Add(reply);
                    }
                    if (attachment.Trim() != "")
                    {
                        message.Attachments.Add(new Attachment(attachment));
                    }
                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    SmtpClient client = new SmtpClient();
                    if ((user != "") && (pwd != ""))
                    {
                        client.Credentials = new NetworkCredential(user, pwd);
                    }
                    client.Port = port;
                    client.Host = host;
                    client.EnableSsl = EnableSsl;
                    try
                    {
                        client.Send(message);
                    }
                    catch (SmtpException exception)
                    {
                        flag = false;
                        this.insertErrorLog(rid, cusid, exception.Message.ToString(), row, EmpNO);
                    }
                }
                catch (Exception exception2)
                {
                    this.insertErrorLog(rid, cusid, exception2.Message.ToString(), row, EmpNO);
                    flag = false;
                }
            }
        
            return flag;
        }
    }
}

