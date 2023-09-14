namespace AbMail.MailTeam
{
    using ProHelper;
    using System;
    using System.ComponentModel;
    using System.Web.Script.Services;
    using System.Web.Services;
    using yb;

    [WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1), ScriptService, WebService(Namespace="http://tempuri.org/"), ToolboxItem(false)]
    public class d : WebService
    {
        [WebMethod]
        public void DelObj(string strIds, string tbName)
        {
            string[] strArray = strIds.ToString().Split(new char[] { ',' });
            if (strArray != null)
            {
                foreach (string str in strArray)
                {
                    ybSqlHelper.ExecuteNonQuery("delete from " + tbName + " where id='" + str + "'");
                }
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string RunMail(string strIds, string uname)
        {
            string mailmsg = "";
            string[] strArray = strIds.ToString().Split(new char[] { ',' });
            if (strArray != null)
            {
                foreach (string str2 in strArray)
                {
                    ybSqlHelper.ExecuteNonQuery("update tbl_MailRun set Run=1 where id='" + str2 + "'");
                }
            }
            new Send().runMail(strIds, uname, out mailmsg);
            return mailmsg;
        }

        [WebMethod]
        public void StopMail(string strIds, string uname)
        {
            string[] strArray = strIds.ToString().Split(new char[] { ',' });
            if (strArray != null)
            {
                foreach (string str in strArray)
                {
                    ybSqlHelper.ExecuteNonQuery("update tbl_MailRun set Run=0 where id='" + str + "'");
                }
            }
        }
    }
}

