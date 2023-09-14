using LinqHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using yb.CtrlHelper;
using yb.WebHelper;
namespace AbMail.Model
{
   

    public class Menu : BasePage
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button8;
        private Mail01DataContext db = dbLinq.GetErpData();
        protected DetailsView DetailsView1;
        protected HtmlForm Form1;
        protected LinqDataSource LinqDataSource1;
        protected LinqDataSource LinqDataSource2;
        protected SmartTreeView stv1;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected TextBox TextBox3;
        private List<tModel> tree;

        private void BindTree(TreeNodeCollection nds, int parentId)
        {
            Func<tModel, bool> predicate = null;
            TreeNode child = null;
            if (parentId == 0)
            {
                var list = (from m in this.tree
                            where !m.PModelID.HasValue
                            orderby m.OrderNums, m.ModelID
                            select new { ModelID = m.ModelID, ID = m.ID, ModelName = m.ModelID.ToString() + m.ModelName + m.OrderNums.ToString() }).ToList();
                foreach (var type in list)
                {
                    child = new TreeNode(type.ModelName, type.ID.ToString())
                    {
                        ShowCheckBox = false
                    };
                    nds.Add(child);
                    this.BindTree(child.ChildNodes, type.ModelID);
                }
            }
            else
            {
                if (predicate == null)
                {
                    predicate = delegate(tModel z)
                    {
                        int? pModelID = z.PModelID;
                        int num1 = parentId;
                        return (pModelID.GetValueOrDefault() == num1) && pModelID.HasValue;
                    };
                }
                var list2 = (from m in this.tree.Where<tModel>(predicate)
                             orderby m.OrderNums, m.ModelID
                             select new { ModelID = m.ModelID, ID = m.ID, PModelID = m.PModelID, ModelName = m.ModelID.ToString() + m.ModelName + m.OrderNums.ToString() }).ToList();
                foreach (var type2 in list2)
                {
                    child = new TreeNode(type2.ModelName, type2.ID.ToString())
                    {
                        ShowCheckBox = false
                    };
                    nds.Add(child);
                    this.BindTree(child.ChildNodes, type2.ModelID);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (Mail01DataContext context = dbLinq.GetErpData())
            {
                context.ExecuteCommand("update   tmodel set PModelName='" + this.TextBox1.Text.Trim() + "' where PModelName='" + this.TextBox2.Text.Trim() + "'", new object[0]);
            }
            ShowMessage.AjaxShow("OK");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            int num = 100;
            List<tModel> list = (from z in this.db.tModel
                                 where (z.PModelID != null) && z.ModelName.Contains("+")
                                 orderby z.OrderNums, z.ModelID
                                 select z).ToList<tModel>();
            foreach (tModel model in list)
            {
                model.OrderNums = new int?(num);
                num += 100;
            }
            this.db.SubmitChanges();
            using (List<tModel>.Enumerator enumerator = list.GetEnumerator())
            {
                tModel t;
                while (enumerator.MoveNext())
                {
                    int? nullable3;
                    t = enumerator.Current;
                    List<tModel> list2 = (from z in this.db.tModel
                                          where z.PModelID == t.ModelID
                                          orderby z.OrderNums, z.ModelID
                                          select z).ToList<tModel>();
                    int? orderNums = t.OrderNums;
                    int? nullable = orderNums.HasValue ? new int?(orderNums.GetValueOrDefault() + 5) : ((int?)(nullable3 = null));
                    foreach (tModel model2 in list2)
                    {
                        model2.OrderNums = nullable;
                        orderNums = nullable;
                        nullable = orderNums.HasValue ? new int?(orderNums.GetValueOrDefault() + 2) : ((int?)(nullable3 = null));
                    }
                    this.db.SubmitChanges();
                }
            }
            ShowMessage.AjaxShow("成功排序");
        }

        protected void chcikModel(object sender, EventArgs e)
        {
            using (Mail01DataContext context = dbLinq.GetErpData())
            {
                if (context.tModel.Count<tModel>(z => (z.ModelID == Convert.ToInt64(this.TextBox3.Text))) > 0)
                {
                    ShowMessage.AjaxShow("yes");
                }
                else
                {
                    ShowMessage.AjaxShow("no");
                }
            }
        }

        protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            using (Mail01DataContext context = dbLinq.GetErpData())
            {
                context.ExecuteCommand("delete from tRightList  where ModelID=" + this.ViewState["id"].ToString(), new object[0]);
            }
        }

        protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
        }

        private void InitializeComponent()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            this.DetailsView1.HeaderText = "菜单编辑";
            this.InitializeComponent();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.tree = this.db.tModel.ToList<tModel>();
                this.stv1.Nodes.Clear();
                this.BindTree(this.stv1.Nodes, 0);
                this.stv1.CollapseAll();
            }
        }

        protected void stv1_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.ViewState["id"] = this.stv1.SelectedValue;
        }
    }
}