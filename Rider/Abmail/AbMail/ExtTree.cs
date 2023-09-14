using System;
using System.Data;
using System.Text;
using yb;

public class ExtTree
{
    private string _EmpId;
    private DataTable dt;
    private static ExtTree extTree = null;

    private void AddChildrenNode(DataTable _dt, StringBuilder sb)
    {
        if (_dt.Rows.Count > 0)
        {
            sb.Append(",leaf:false,children:[");
            foreach (DataRow row in _dt.Rows)
            {
                sb.Append("{");
                sb.Append("text:'" + row["title"].ToString() + "," + row["url"].ToString() + "',");
                sb.Append("id:'node" + row["id"].ToString() + "'");
                this.AddChildrenNode(this.GetAllNodes(row["id"].ToString()), sb);
                sb.Append("}");
            }
            sb.Append("]");
        }
        else
        {
            sb.Append(",leaf:true");
        }
    }

    public string CreateExtTreeJSON(string EmpId)
    {
        this._EmpId = EmpId;
        this.dt = this.GetAllNodes();
        StringBuilder sb = new StringBuilder();
        this.CreateExtTreeNode(sb);
        return sb.ToString().Replace("}{", "},{");
    }

    private void CreateExtTreeNode(StringBuilder sb)
    {
        DataTable allNodes = this.GetAllNodes("");
        if (allNodes.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow row in allNodes.Rows)
            {
                sb.Append("{");
                sb.Append("text:'" + row["title"].ToString() + "',");
                sb.Append("id:'node" + row["id"].ToString() + "'");
                this.AddChildrenNode(this.GetAllNodes(row["id"].ToString()), sb);
                sb.Append("}");
            }
        }
        sb.Append("]");
    }

    private DataTable GetAllNodes()
    {
        DataSet set = new DataSet();
         var result= ybSqlHelper.ExecuteDataSet(string.Format("SELECT tModel.ModelID AS id, tModel.PModelID AS parentid, tModel.ModelName AS title, tModel.URL, tModel.OrderNums \r\nFROM tModel\r\nWHERE (ModelID IN\r\n          (SELECT tModel.PModelID\r\n         FROM tModel INNER JOIN\r\n               tRightList tRightList ON \r\n               tRightList.ModelID = tModel.ModelID\r\n         WHERE (tRightList.ObjID = {0}  AND status = 0)))\r\nUNION\r\nSELECT tModel.ModelID AS id, tModel.PModelID AS parentid, tModel.ModelName AS title, tModel.URL, tModel.OrderNums \r\nFROM tModel\r\nWHERE (ModelID IN\r\n          (SELECT tModel.ModelID\r\n         FROM tModel INNER JOIN\r\n               tRightList tRightList ON \r\n               tRightList.ModelID = tModel.ModelID\r\n         WHERE (tRightList.ObjID = {0}  AND status = 0)))\r\n ORDER BY tModel.OrderNums", this._EmpId)).Tables[0];
        return result;
    }

    private DataTable GetAllNodes(string parentid)
    {
        DataTable table = this.dt.Clone();
        foreach (DataRow row in this.dt.Rows)
        {
            if (row["parentid"].ToString() == parentid.ToString())
            {
                table.Rows.Add(row.ItemArray);
            }
        }
        return table;
    }

    public static ExtTree Current
    {
        get
        {
            if (extTree == null)
            {
                extTree = new ExtTree();
            }
            return extTree;
        }
    }
}

