namespace AbMail.Admin
{
    using System;
    using System.ComponentModel;
    using System.Web.Script.Services;
    using System.Web.Services;
    using yb;

    [ToolboxItem(false), WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1), ScriptService, WebService(Namespace="http://tempuri.org/")]
    public class Admin : WebService
    {
        [WebMethod]
        public void DelObj(string strIds, string tbName)
        {
            string[] strArray = strIds.ToString().Split(new char[] { ',' });
            if (strArray != null)
            {
                foreach (string str in strArray)
                {
                    string cmdText = "delete from " + tbName + " where id='" + str + "'";
                    int num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(cmdText);
                }
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}

