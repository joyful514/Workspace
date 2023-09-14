using LinqHelper;
using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using yb.WebHelper;

public class BasePage : Page
{
    public tEmployee CurrentUser;

    protected void dvDel(DetailsView _DetailsView)
    {
        _DetailsView.ItemDeleting += delegate(object sender, DetailsViewDeleteEventArgs e)
        {
        };
    }

    protected void dvgvPopup(GridView _gv_Data, DetailsView detailsView)
    {
        if (detailsView != null)
        {
            detailsView.ItemInserted += delegate(object sender, DetailsViewInsertedEventArgs e)
            {
                ShowMessage.AjaxShow("成功增加记录!", false);
                _gv_Data.DataBind();
            };
            detailsView.ItemUpdated += delegate(object sender, DetailsViewUpdatedEventArgs e)
            {
                ShowMessage.AjaxShow("成功升级记录!", false);
                _gv_Data.DataBind();
            };
            detailsView.ItemDeleted += delegate(object sender, DetailsViewDeletedEventArgs e)
            {
                ShowMessage.AjaxShow("成功删除记录", false);
                _gv_Data.DataBind();
            };
        }
    }

    protected void dvPopup(DetailsView detailsView)
    {
        if (detailsView != null)
        {
            detailsView.ItemInserted += (sender, e) => ShowMessage.AjaxShow("成功增加记录!", false);
            detailsView.ItemUpdated += (sender, e) => ShowMessage.AjaxShow("成功升级记录!", false);
            detailsView.ItemDeleted += (sender, e) => ShowMessage.AjaxShow("成功删除记录", false);
        }
    }

    protected void gvPopup(GridView _gv_Data)
    {
        if (_gv_Data != null)
        {
            _gv_Data.RowUpdated += (sender, e) => ShowMessage.AjaxShow("成功升级记录!", false);
            _gv_Data.RowDeleted += (sender, e) => ShowMessage.AjaxShow("成功删除记录", false);
        }
    }

    protected void gvRow(GridView gridView)
    {
        if (gridView != null)
        {
            gridView.RowDataBound += delegate(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#eeeeee';";
                    e.Row.Attributes["onmouseout"] = "this.style.backgroundColor=currentcolor;";
                }
                if (gridView.SortExpression.Length > 0)
                {
                    int index = -1;
                    foreach (DataControlField field in gridView.Columns)
                    {
                        if (field.SortExpression == gridView.SortExpression)
                        {
                            index = gridView.Columns.IndexOf(field);
                            break;
                        }
                    }
                    if ((index > -1) && (e.Row.RowType == DataControlRowType.Header))
                    {
                        TableCell cell1 = e.Row.Cells[index];
                        cell1.CssClass = cell1.CssClass + ((gridView.SortDirection == SortDirection.Ascending) ? " sortascheader  " : " sortdescheader ");
                    }
                }
            };
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        string userid = null;
        string links = ConfigurationManager.AppSettings["LogUrl"];
        if (base.Request.Cookies["cookieUserInfo"] != null)
        {
            userid = Server.UrlDecode(base.Request.Cookies["cookieUserInfo"]["EmpID"].ToString());
          
        }
        else
        {
            JS.Throw("操作提示", "帐户过期", links, links, false);
        }
        using (Mail01DataContext context = dbLinq.GetErpData())
        {
            if ((userid != null) && (userid.Trim() != ""))
            {
                this.CurrentUser = context.tEmployee.Single<tEmployee>(z => z.ID == Convert.ToDecimal(userid));
            }
            else
            {
                JS.Throw("操作提示", "帐户过期", links, links, false);
            }
        }
    }
}

