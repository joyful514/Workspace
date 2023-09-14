namespace ProHelper
{
    using System;
    using System.Data.SqlClient;
    using yb;

    public class CreateSysno
    {
        public string create(string strTbname, string strColname, int ilength, string strPrefix, string EmpNO)
        {
            string str;
            string str2;
            string[] strArray;
            if (strTbname == "tEmployee")
            {
                strArray = new string[] { "select top 1 ", strColname, " from ", strTbname, " where ", strColname, " like '", strPrefix, "%' order by ","","" };
                strArray[9] = strColname;
                strArray[10] = " desc";
                str2 = string.Concat(strArray);
            }
            else
            {
                strArray = new string[] { "select top 1 ", strColname, " from ", strTbname, " where ", strColname, " like '", strPrefix, "%' and EmpNO='","","","","" };
                strArray[9] = EmpNO;
                strArray[10] = "' order by ";
                strArray[11] = strColname;
                strArray[12] = " desc";
                str2 = string.Concat(strArray);
            }
            SqlDataReader reader = ybSqlHelper.ExecuteReader(str2);
            if (!reader.Read())
            {
                string str4 = "1";
                while (true)
                {
                    if (str4.Length >= (ilength - strPrefix.Trim().Length))
                    {
                        str = strPrefix.Trim().ToUpper() + str4;
                        break;
                    }
                    str4 = "0" + str4;
                }
            }
            else
            {
                string str3 = reader[strColname].ToString();
                int length = strPrefix.Trim().Length;
                str = (Convert.ToInt32(str3.Substring(length, str3.Length - length)) + 1).ToString();
                while (true)
                {
                    if (str.Length >= (ilength - length))
                    {
                        str = strPrefix.Trim().ToUpper() + str;
                        break;
                    }
                    str = "0" + str;
                }
            }
            reader.Dispose();
            return str;
        }
    }
}

