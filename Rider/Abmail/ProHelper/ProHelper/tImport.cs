namespace ProHelper
{
    using System;
    using System.Data;
    using System.Text;
    using System.Text.RegularExpressions;
    using yb;

    public class tImport
    {
        public bool checkMail(string strMailAddress, string EmpNO)
        {
            string cmdtext = "select * from tbl_Customers where email='" + strMailAddress + "'";
            DataTable table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet(cmdtext).Tables[0];
            return ((table != null) && (table.Rows.Count > 0));
        }

        public bool checkMailByPerson(string strMailAddress, string EmpNO)
        {
            string[] strArray = new string[] { "select * from tbl_Customers where email='", strMailAddress, "' and EmpNO='", EmpNO, "'" };
            string cmdtext = string.Concat(strArray);
            DataTable table = new ybNewSqlHelper("ConnectionString").ExecuteDataSet(cmdtext).Tables[0];
            return ((table != null) && (table.Rows.Count > 0));
        }

        public string DataAdd(DataRow dr, string EmpNO)
        {
            string[] strArray;
            int num = -1;
            string str = ("" + "email") + ",EmpNO" + ",country";
            string str2 = (("" + "N'" + Sql.EscapeSQL(dr["邮件地址"].ToString().Trim().ToLower()) + "'") + ",N'" + EmpNO + "'") + ",N'" + Sql.EscapeSQL(dr["国家"].ToString().Trim().ToLower()) + "'";
            if (dr["州/省"].ToString().Trim() != "")
            {
                str = str + ",state";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["州/省"].ToString().Trim().ToLower()) + "'";
            }
            if (dr["城市"].ToString().Trim() != "")
            {
                str = str + ",city";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["城市"].ToString().Trim().ToLower()) + "'";
            }
            if (dr["学校/研究所"].ToString().Trim() != "")
            {
                str = str + ",university";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["学校/研究所"].ToString().Trim()) + "'";
            }
            if (dr["学院"].ToString().Trim() != "")
            {
                str = str + ",college";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["学院"].ToString().Trim()) + "'";
            }
            if (dr["系"].ToString().Trim() != "")
            {
                str = str + ",department";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["系"].ToString().Trim()) + "'";
            }
            if (dr["GMT"].ToString().Trim() != "")
            {
                str = str + ",gmt";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["GMT"].ToString().Trim()) + "'";
            }
            if (dr["导师"].ToString().Trim() != "")
            {
                str = str + ",pi";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["导师"].ToString().Trim()) + "'";
            }
            if (dr["全名"].ToString().Trim() != "")
            {
                str = str + ",fullName";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["全名"].ToString().Trim().Replace("\0\0", "\0")) + "'";
            }
            else
            {
                str = str + ",fullName";
                strArray = new string[] { str2, ",N'", Sql.EscapeSQL(dr["名"].ToString().Trim().Replace("\0\0", "\0")), " ", Sql.EscapeSQL(dr["姓"].ToString().Trim().Replace("\0\0", "\0")), "'" };
                str2 = string.Concat(strArray);
            }
            if (dr["名"].ToString().Trim() != "")
            {
                str = str + ",firstName";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["名"].ToString().Trim()) + "'";
            }
            if (dr["姓"].ToString().Trim() != "")
            {
                str = str + ",lastName";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["姓"].ToString().Trim()) + "'";
            }
            if (dr["职称"].ToString().Trim() != "")
            {
                str = str + ",title";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["职称"].ToString().Trim()) + "'";
            }
            if (dr["实验室地址"].ToString().Trim() != "")
            {
                str = str + ",labAddress";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["实验室地址"].ToString().Trim()) + "'";
            }
            if (dr["电话"].ToString().Trim() != "")
            {
                str = str + ",phone";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["电话"].ToString().Trim().Replace("NA", "")) + "'";
            }
            if (dr["实验室网址"].ToString().Trim() != "")
            {
                str = str + ",labWebsite";
                str2 = str2 + ",N'" + Sql.EscapeSQL(dr["实验室网址"].ToString().Trim()) + "'";
            }
            if (dr["研究领域"].ToString().Trim() != "")
            {
                str = str + ",researchInterest";
                str2 = (dr["研究领域"].ToString().Trim().Length != 2) ? (str2 + ",N'" + Sql.EscapeSQL(dr["研究领域"].ToString().Trim()) + "'") : (str2 + ",N'" + Sql.EscapeSQL(dr["研究领域"].ToString().Trim()).Replace("NA", "") + "'");
            }
            if (dr["发表文章"].ToString().Trim() != "")
            {
                str = str + ",publicationList";
                str2 = (dr["发表文章"].ToString().Trim().Length != 2) ? (str2 + ",N'" + Sql.EscapeSQL(dr["发表文章"].ToString().Trim()) + "'") : (str2 + ",N'" + Sql.EscapeSQL(dr["发表文章"].ToString().Trim()).Replace("NA", "") + "'");
            }
            if (dr["收集人"].ToString().Trim() != "")
            {
                str = str + ",collector" + ",createDate";
                str2 = (str2 + ",N'" + Sql.EscapeSQL(dr["收集人"].ToString().Trim()) + "'") + ",getdate()";
            }
            CreateSysno sysno = new CreateSysno();
            str = (str + ",customerId") + ",ourCustomer" + ",unsubscribe";
            str2 = ((str2 + ",'" + Sql.EscapeSQL(sysno.create("tbl_Customers", "customerId", 10, "1", EmpNO)) + "'") + ",'" + Sql.EscapeSQL("0") + "'") + ",'" + Sql.EscapeSQL("0") + "'";
            try
            {
                strArray = new string[] { "insert tbl_Customers(", str, ") values(", str2, ")" };
                num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(string.Concat(strArray));
            }
            catch (Exception exception1)
            {
                return exception1.Message.ToString();
            }
            return ((num <= -1) ? "False" : "True");
        }

        public string Import(DataTable dt, string EmpNO)
        {
            int num = 0;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            int num3 = 0;
            while (true)
            {
                if (num3 >= dt.Rows.Count)
                {
                    object[] objArray = new object[] { "</br>成功数量:", num.ToString(), ",失败数量:", num2.ToString(), "</br></br>", builder };
                    return string.Concat(objArray);
                }
                bool flag = false;
                bool flag2 = true;
                try
                {
                    int num4;
                    if (dt.Rows[num3]["国家"].ToString().Trim() == "")
                    {
                        num4 = num3 + 2;
                        builder.Append("第" + num4.ToString() + "行");
                        builder.Append("\"国家\" 不能为空。");
                        builder.Append("</br>");
                        flag = true;
                    }
                    else if (dt.Rows[num3]["国家"].ToString().Trim().ToLower().Equals("unsubscribe"))
                    {
                        num4 = num3 + 2;
                        builder.Append("第" + num4.ToString() + "行");
                        builder.Append("'" + dt.Rows[num3]["邮件地址"].ToString().Trim() + "'邮箱地址，已经设置为退订");
                        builder.Append("</br>");
                        flag2 = false;
                    }
                    if ((dt.Rows[num3]["邮件地址"].ToString().Trim() == "") && flag2)
                    {
                        num4 = num3 + 2;
                        builder.Append("第" + num4.ToString() + "行");
                        builder.Append("\"邮件地址\" 不能为空。");
                        builder.Append("</br>");
                        flag = true;
                    }
                    else
                    {
                        if (!(isEmail(dt.Rows[num3]["邮件地址"].ToString().Trim().ToLower()) || !flag2))
                        {
                            num4 = num3 + 2;
                            builder.Append("第" + num4.ToString() + "行");
                            builder.Append("\"邮件地址\"不符合规范。");
                            builder.Append("</br>");
                            flag = true;
                        }
                        if (this.checkMailByPerson(dt.Rows[num3]["邮件地址"].ToString().Trim().ToLower(), EmpNO) && flag2)
                        {
                            num4 = num3 + 2;
                            builder.Append("第" + num4.ToString() + "行");
                            builder.Append("\"邮件地址\"重复。");
                            builder.Append("</br>");
                            flag = true;
                        }
                        else if (this.checkMail(dt.Rows[num3]["邮件地址"].ToString().Trim().ToLower(), EmpNO) && flag2)
                        {
                            num4 = num3 + 2;
                            builder.Append("第" + num4.ToString() + "行");
                            builder.Append("\"邮件地址\"已经存在。");
                            builder.Append("</br>");
                        }
                        else if ((dt.Rows[num3]["邮件地址"].ToString().Trim() != "") && ((dt.Rows[num3]["邮件地址"].ToString().Trim().IndexOf("@yahoo.cn") > -1) || (dt.Rows[num3]["邮件地址"].ToString().Trim().IndexOf("@yahoo.com.cn") > -1)))
                        {
                            num4 = num3 + 2;
                            builder.Append("第" + num4.ToString() + "行");
                            builder.Append("禁止使用雅虎邮箱。");
                            builder.Append("</br>");
                            flag = true;
                        }
                    }
                    if ((dt.Rows[num3]["全名"].ToString().Trim() == "") && flag2)
                    {
                        num4 = num3 + 2;
                        builder.Append("第" + num4.ToString() + "行");
                        builder.Append("\"全名\" 不能为空。");
                        builder.Append("</br>");
                        flag = true;
                    }
                    if ((dt.Rows[num3]["收集人"].ToString().Trim() == "") && flag2)
                    {
                        builder.Append("第" + (num3 + 2).ToString() + "行");
                        builder.Append("\"收集人\" 不能为空。");
                        builder.Append("</br>");
                        flag = true;
                    }
                }
                catch
                {
                    flag = true;
                }
                if (flag || !flag2)
                {
                    num2++;
                }
                else if (this.DataAdd(dt.Rows[num3], EmpNO) == "True")
                {
                    num++;
                }
                else
                {
                    num2++;
                    builder.Append("第" + (num3 + 2).ToString() + "行");
                    builder.Append("</br>");
                }
                if (!(flag2 || (dt.Rows[num3]["邮件地址"].ToString().Trim() == "")))
                {
                    this.Unsubscribe(dt.Rows[num3]["邮件地址"].ToString().Trim(), EmpNO);
                    num++;
                    num2 = 0;
                }
                num3++;
            }
        }

        public static bool isEmail(string emailAddress) => 
            new Regex(@"^([a-za-z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-za-z0-9\-]+\.)+))([a-za-z]{2,4}|[0-9]{1,3})(\]?)$").IsMatch(emailAddress);

        private void Unsubscribe(string email, string empNo)
        {
            int num = 0;
            try
            {
                string[] strArray = new string[] { "email='", email, "' and empno='", empNo, "'" };
                string where = string.Concat(strArray);
                if (new ybNewSqlHelper("ConnectionString").GetRecordCount("Unsubscribe", where) == 0)
                {
                    strArray = new string[] { "insert Unsubscribe  values('", email, "','", empNo, "')" };
                    num = new ybNewSqlHelper("ConnectionString").ExecuteNonQuery(string.Concat(strArray));
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

