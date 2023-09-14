using System;
using System.Data;
using System.Security.Permissions;
using System.Text;
using System.Web.Hosting;
using System.Web.UI.WebControls;

public class MenuDAL
{
    private string _XMLpath;
    private static MenuDAL dal = null;

    private MenuDAL()
    {
        this.InitXMLpath();
    }

    public void BoundTree(TreeNodeCollection nodes)
    {
        DataTable allMenus = this.GetAllMenus(0);
        TreeNode child = null;
        DataTable table2 = null;
        TreeNode node2 = null;
        foreach (DataRow row in allMenus.Rows)
        {
            child = new TreeNode {
                Text = row["title"].ToString(),
                Value = row["id"].ToString(),
                SelectAction = TreeNodeSelectAction.SelectExpand
            };
            nodes.Add(child);
            table2 = this.GetAllMenus(int.Parse(row["id"].ToString()));
            if (table2.Rows.Count > 0)
            {
                foreach (DataRow row2 in table2.Rows)
                {
                    node2 = new TreeNode {
                        Text = row2["title"].ToString(),
                        NavigateUrl = row2["url"].ToString(),
                        Target = "main",
                        Value = row2["id"].ToString(),
                        SelectAction = TreeNodeSelectAction.SelectExpand
                    };
                    child.ChildNodes.Add(node2);
                }
            }
        }
    }

    public string CreateHTML()
    {
        StringBuilder builder = new StringBuilder();
        DataTable allMenus = this.GetAllMenus(0);
        DataTable table2 = null;
        foreach (DataRow row in allMenus.Rows)
        {
            builder.Append("{title:'" + row["title"].ToString() + "',autoScroll:true,border:false,iconCls:'nav',");
            table2 = this.GetAllMenus(int.Parse(row["id"].ToString()));
            if (table2.Rows.Count > 0)
            {
                string str = "<ul class=\"LeftNav\">";
                foreach (DataRow row2 in table2.Rows)
                {
                    string str3 = str;
                    str = str3 + "<li><a  href=javascript:createTab(\"" + row2["url"].ToString() + "\",\"" + row2["title"].ToString() + "\");> " + row2["title"].ToString() + "</a></li>";
                }
                if (str != "<ul>")
                {
                    builder.Append("html:'" + (str + "</ul>") + "'}");
                }
                else
                {
                    builder.Append("html:''}");
                }
            }
            else
            {
                builder.Append("html:''}");
            }
            builder.Append(",");
        }
        return builder.ToString().TrimEnd(new char[] { ',' });
    }

    private DataTable GetAllMenus()
    {
        DataSet set = new DataSet();
        set.ReadXml(this._XMLpath);
        return set.Tables[0];
    }

    private DataTable GetAllMenus(int parentid)
    {
        DataTable allMenus = this.GetAllMenus();
        DataTable table2 = allMenus.Clone();
        foreach (DataRow row in allMenus.Rows)
        {
            if (row["parentid"].ToString() == parentid.ToString())
            {
                table2.Rows.Add(row.ItemArray);
            }
        }
        return table2;
    }

    private void InitXMLpath()
    {
        string virtualPath = "~/app_data/xmlmenus.xml";
        this._XMLpath = HostingEnvironment.MapPath(virtualPath);
        new FileIOPermission(FileIOPermissionAccess.Write, this._XMLpath).Demand();
    }

    public static MenuDAL Current
    {
        get
        {
            if (dal == null)
            {
                dal = new MenuDAL();
            }
            return dal;
        }
    }
}

