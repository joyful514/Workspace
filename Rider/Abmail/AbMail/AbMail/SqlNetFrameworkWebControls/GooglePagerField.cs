namespace SqlNetFrameworkWebControls
{
    using System;
    using System.Globalization;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class GooglePagerField : DataPagerField
    {
        private int _maximumRows;
        private bool _showNextPage = true;
        private bool _showPreviousPage = true;
        private int _startRowIndex;
        private int _totalRowCount;

        private void AddNonBreakingSpace(DataPagerFieldItem container)
        {
            if (this.RenderNonBreakingSpacesBetweenControls)
            {
                container.Controls.Add(new LiteralControl("&nbsp;"));
            }
        }

        private Control CreateControl(string commandName, string buttonText, int fieldIndex, string imageUrl, bool enabled)
        {
            IButtonControl control = new ImageButton();
            ((ImageButton) control).ImageUrl = imageUrl;
            ((ImageButton) control).Enabled = enabled;
            ((ImageButton) control).AlternateText = HttpUtility.HtmlDecode(buttonText);
            control.Text = buttonText;
            control.CommandName = commandName;
            control.CommandArgument = fieldIndex.ToString(CultureInfo.InvariantCulture);
            WebControl control2 = control as WebControl;
            if (!((control2 == null) || string.IsNullOrEmpty(this.ButtonCssClass)))
            {
                control2.CssClass = this.ButtonCssClass;
            }
            return (control as Control);
        }

        public override void CreateDataPagers(DataPagerFieldItem container, int startRowIndex, int maximumRows, int totalRowCount, int fieldIndex)
        {
            this._startRowIndex = startRowIndex;
            this._maximumRows = maximumRows;
            this._totalRowCount = totalRowCount;
            if (string.IsNullOrEmpty(base.DataPager.QueryStringField))
            {
                this.CreateDataPagersForCommand(container, fieldIndex);
            }
            else
            {
                this.CreateDataPagersForQueryString(container, fieldIndex);
            }
        }

        private void CreateDataPagersForCommand(DataPagerFieldItem container, int fieldIndex)
        {
            this.CreateGoToTexBox(container);
            this.CreatePageSizeControl(container);
            this.CreateLabelRecordControl(container);
            if (this._showPreviousPage)
            {
                container.Controls.Add(this.CreateControl("Prev", this.PreviousPageText, fieldIndex, this.PreviousPageImageUrl, this._showPreviousPage));
                this.AddNonBreakingSpace(container);
            }
            if (this._showNextPage)
            {
                container.Controls.Add(this.CreateControl("Next", this.NextPageText, fieldIndex, this.NextPageImageUrl, this._showNextPage));
                this.AddNonBreakingSpace(container);
            }
        }

        private void CreateDataPagersForQueryString(DataPagerFieldItem container, int fieldIndex)
        {
            bool flag = false;
            if (!base.QueryStringHandled)
            {
                int num;
                base.QueryStringHandled = true;
                if (int.TryParse(base.QueryStringValue, out num))
                {
                    num--;
                    int num2 = this._startRowIndex / this._maximumRows;
                    int num3 = (this._totalRowCount - 1) / this._maximumRows;
                    if ((num >= 0) && (num <= num3))
                    {
                        this._startRowIndex = num * this._maximumRows;
                        flag = true;
                    }
                }
            }
            this.CreateGoToTexBox(container);
            this.CreatePageSizeControl(container);
            this.CreateLabelRecordControl(container);
            if (this._showPreviousPage)
            {
                int pageIndex = (this._startRowIndex / this._maximumRows) - 1;
                container.Controls.Add(this.CreateLink(this.PreviousPageText, pageIndex, this.PreviousPageImageUrl, this.EnablePreviousPage));
                this.AddNonBreakingSpace(container);
            }
            if (this._showNextPage)
            {
                int num5 = (this._startRowIndex + this._maximumRows) / this._maximumRows;
                container.Controls.Add(this.CreateLink(this.NextPageText, num5, this.NextPageImageUrl, this.EnableNextPage));
                this.AddNonBreakingSpace(container);
            }
            if (flag)
            {
                base.DataPager.SetPageProperties(this._startRowIndex, this._maximumRows, true);
            }
        }

        protected override DataPagerField CreateField()
        {
            return new GooglePagerField();
        }

        private void CreateGoToTexBox(DataPagerFieldItem container)
        {
            Label child = new Label {
                Text = "Go to: "
            };
            container.Controls.Add(child);
            ButtonTextBox box = new ButtonTextBox {
                CommandName = "GoToItem",
                Width = new Unit("20px")
            };
            container.Controls.Add(box);
            this.AddNonBreakingSpace(container);
            this.AddNonBreakingSpace(container);
        }

        private void CreateLabelRecordControl(DataPagerFieldItem container)
        {
            int num = this._startRowIndex + base.DataPager.PageSize;
            if (num > this._totalRowCount)
            {
                num = this._totalRowCount;
            }
            container.Controls.Add(new LiteralControl(string.Format("{0} - {1} of {2}", this._startRowIndex + 1, num, this._totalRowCount)));
            this.AddNonBreakingSpace(container);
            this.AddNonBreakingSpace(container);
            this.AddNonBreakingSpace(container);
        }

        private HyperLink CreateLink(string buttonText, int pageIndex, string imageUrl, bool enabled)
        {
            int pageNumber = pageIndex + 1;
            HyperLink link = new HyperLink {
                Text = buttonText,
                NavigateUrl = base.GetQueryStringNavigateUrl(pageNumber),
                ImageUrl = imageUrl,
                Enabled = enabled
            };
            if (!string.IsNullOrEmpty(this.ButtonCssClass))
            {
                link.CssClass = this.ButtonCssClass;
            }
            return link;
        }

        private void CreatePageSizeControl(DataPagerFieldItem container)
        {
            container.Controls.Add(new LiteralControl("Show rows: "));
            ButtonDropDownList child = new ButtonDropDownList {
                CommandName = "UpdatePageSize"
            };
            child.Items.Add(new ListItem("10", "10"));
            child.Items.Add(new ListItem("25", "25"));
            child.Items.Add(new ListItem("50", "50"));
            child.Items.Add(new ListItem("60", "60"));
            child.Items.Add(new ListItem("100", "100"));
            ListItem item = child.Items.FindByValue(base.DataPager.PageSize.ToString());
            if (item == null)
            {
                item = new ListItem(base.DataPager.PageSize.ToString(), base.DataPager.PageSize.ToString());
                child.Items.Insert(0, item);
            }
            item.Selected = true;
            container.Controls.Add(child);
            this.AddNonBreakingSpace(container);
            this.AddNonBreakingSpace(container);
        }

        public override void HandleEvent(CommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "UpdatePageSize"))
            {
                base.DataPager.PageSize = int.Parse(e.CommandArgument.ToString());
                base.DataPager.SetPageProperties(this._startRowIndex, base.DataPager.PageSize, true);
            }
            else if (string.Equals(e.CommandName, "GoToItem"))
            {
                int startRowIndex = int.Parse(e.CommandArgument.ToString()) - 1;
                base.DataPager.SetPageProperties(startRowIndex, base.DataPager.PageSize, true);
            }
            else if (string.IsNullOrEmpty(base.DataPager.QueryStringField))
            {
                if (string.Equals(e.CommandName, "Prev"))
                {
                    int num2 = this._startRowIndex - base.DataPager.PageSize;
                    if (num2 < 0)
                    {
                        num2 = 0;
                    }
                    base.DataPager.SetPageProperties(num2, base.DataPager.PageSize, true);
                }
                else if (string.Equals(e.CommandName, "Next"))
                {
                    int num3 = this._startRowIndex + base.DataPager.PageSize;
                    if (num3 > this._totalRowCount)
                    {
                        num3 = this._totalRowCount - base.DataPager.PageSize;
                    }
                    if (num3 < 0)
                    {
                        num3 = 0;
                    }
                    base.DataPager.SetPageProperties(num3, base.DataPager.PageSize, true);
                }
            }
        }

        [CssClassProperty]
        public string ButtonCssClass
        {
            get
            {
                object obj2 = base.ViewState["ButtonCssClass"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return string.Empty;
            }
            set
            {
                if (value != this.ButtonCssClass)
                {
                    base.ViewState["ButtonCssClass"] = value;
                    this.OnFieldChanged();
                }
            }
        }

        private bool EnableNextPage
        {
            get
            {
                return ((this._startRowIndex + this._maximumRows) < this._totalRowCount);
            }
        }

        private bool EnablePreviousPage
        {
            get
            {
                return (this._startRowIndex > 0);
            }
        }

        public string NextPageImageUrl
        {
            get
            {
                object obj2 = base.ViewState["NextPageImageUrl"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return string.Empty;
            }
            set
            {
                if (value != this.NextPageImageUrl)
                {
                    base.ViewState["NextPageImageUrl"] = value;
                    this.OnFieldChanged();
                }
            }
        }

        public string NextPageText
        {
            get
            {
                object obj2 = base.ViewState["NextPageText"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "Next";
            }
            set
            {
                if (value != this.NextPageText)
                {
                    base.ViewState["NextPageText"] = value;
                    this.OnFieldChanged();
                }
            }
        }

        public string PreviousPageImageUrl
        {
            get
            {
                object obj2 = base.ViewState["PreviousPageImageUrl"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return string.Empty;
            }
            set
            {
                if (value != this.PreviousPageImageUrl)
                {
                    base.ViewState["PreviousPageImageUrl"] = value;
                    this.OnFieldChanged();
                }
            }
        }

        public string PreviousPageText
        {
            get
            {
                object obj2 = base.ViewState["PreviousPageText"];
                if (obj2 != null)
                {
                    return (string) obj2;
                }
                return "Previous";
            }
            set
            {
                if (value != this.PreviousPageText)
                {
                    base.ViewState["PreviousPageText"] = value;
                    this.OnFieldChanged();
                }
            }
        }

        public bool RenderNonBreakingSpacesBetweenControls
        {
            get
            {
                object obj2 = base.ViewState["RenderNonBreakingSpacesBetweenControls"];
                if (obj2 != null)
                {
                    return (bool) obj2;
                }
                return true;
            }
            set
            {
                if (value != this.RenderNonBreakingSpacesBetweenControls)
                {
                    base.ViewState["RenderNonBreakingSpacesBetweenControls"] = value;
                    this.OnFieldChanged();
                }
            }
        }
    }
}

