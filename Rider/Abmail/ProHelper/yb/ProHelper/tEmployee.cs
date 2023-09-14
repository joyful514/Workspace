namespace yb.ProHelper
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using yb.SqlHelper;

    public class tEmployee
    {
        public int ChangePwd(string OldPwd, string NewPwd, int ID)
        {
            int num = -1;
            SqlParameter parameter2 = new SqlParameter("ReturnValue", SqlDbType.Int) {
                Direction = ParameterDirection.ReturnValue
            };
            ArrayList parameters = new ArrayList {
                parameter2,
                new SqlParameter("@pEmpID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ID),
                new SqlParameter("@pOldPwd", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, OldPwd),
                new SqlParameter("@pNewPwd", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NewPwd)
            };
            try
            {
                DBClass.ProcedureNOQuery("sp_ChangePassword", ref parameters);
                num = int.Parse(((SqlParameter) parameters[0]).Value.ToString());
            }
            catch (Exception)
            {
            }
            return num;
        }

        public bool DuplicateUser(string Account)
        {
            DataTable table = DBClass.dataSetQuery($"select * from tEmployee where account='{Account}'").Tables[0];
            return ((table != null) && (table.Rows.Count > 0));
        }

        public enum DeptID
        {
            管理员 = 1,
            普通用户 = 2
        }
    }
}

