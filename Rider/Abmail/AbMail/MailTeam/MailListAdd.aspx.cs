namespace AbMail.Mail01
{
    using LinqHelper;
    using ProHelper;
    using System;
    using System.Linq;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using yb.WebHelper;

    public class MailListAdd : BasePage
    {
        protected string _ID = "";
        protected Button btnsave;
        protected DropDownList ddlOurCustomer;
        protected DropDownList ddlUnsubscribe;
        protected HtmlForm form1;
        protected TextBox txtArea;
        protected TextBox txtCity;
        protected TextBox txtCollector;
        protected TextBox txtCollege;
        protected TextBox txtCountry;
        protected TextBox txtCustomerID;
        protected TextBox txtDepartment;
        protected TextBox txtEmail;
        protected TextBox txtFirstName;
        protected TextBox txtFullName;
        protected TextBox txtGMT;
        protected TextBox txtlabAddress;
        protected TextBox txtLabWebsite;
        protected TextBox txtLastName;
        protected TextBox txtphone;
        protected TextBox txtPi;
        protected TextBox txtPublicationList;
        protected TextBox txtResearchInterest;
        protected TextBox txtState;
        protected TextBox txtUniversity;

        protected void btnsave_Click(object sender, EventArgs e)
        {
            tImport import = new tImport();
            bool flag = true;
            if ((this.txtCountry.Text.ToString().Trim() == "") || (this.txtEmail.Text.ToString().Trim() == ""))
            {
                flag = false;
                ShowMessage.AjaxShow("国家,邮件地址等不能为空!");
            }
            if (!tImport.isEmail(this.txtEmail.Text.ToString().Trim().ToLower()))
            {
                flag = false;
                ShowMessage.AjaxShow("邮件地址不符合规范!");
            }
            if ((this._ID == "") && import.checkMail(this.txtEmail.Text.ToString().Trim().ToLower(), base.CurrentUser.EmpNO))
            {
                flag = false;
                ShowMessage.AjaxShow("邮件地址重复!");
            }
            if (flag)
            {
                using (Mail01DataContext context = dbLinq.GetErpData())
                {
                    tbl_Customers customers;
                    if (this._ID != "")
                    {
                        customers = context.tbl_Customers.Single<tbl_Customers>(z => z.ID == Guid.Parse(this._ID));
                        customers.country = this.txtCountry.Text.ToString();
                        customers.state = this.txtState.Text.ToString();
                        customers.city = this.txtCity.Text.ToString();
                        customers.area = this.txtArea.Text.ToString();
                        customers.university = this.txtUniversity.Text.ToString();
                        customers.college = this.txtCollege.Text.ToString();
                        customers.department = this.txtDepartment.Text.ToString();
                        customers.pi = this.txtPi.Text.ToString();
                        customers.fullName = this.txtFullName.Text.ToString();
                        customers.firstName = this.txtFirstName.Text.ToString();
                        customers.lastName = this.txtLastName.Text.ToString();
                        customers.labAddress = this.txtlabAddress.Text.ToString();
                        customers.phone = this.txtphone.Text.ToString();
                        customers.email = this.txtEmail.Text.ToString();
                        customers.labWebsite = this.txtLabWebsite.Text.ToString();
                        customers.researchInterest = this.txtResearchInterest.Text.ToString();
                        customers.publicationList = this.txtPublicationList.Text.ToString();
                        customers.collector = this.txtCollector.Text.ToString();
                        customers.GMT = this.txtGMT.Text.ToString();
                        customers.unsubscribe = Convert.ToBoolean(this.ddlUnsubscribe.SelectedValue);
                        customers.ourCustomer = Convert.ToBoolean(this.ddlOurCustomer.SelectedValue);
                    }
                    else
                    {
                        customers = new tbl_Customers
                        {
                            ID = Guid.NewGuid(),
                            country = this.txtCountry.Text.ToString(),
                            state = this.txtState.Text.ToString(),
                            city = this.txtCity.Text.ToString(),
                            area = this.txtArea.Text.ToString(),
                            university = this.txtUniversity.Text.ToString(),
                            college = this.txtCollege.Text.ToString(),
                            department = this.txtDepartment.Text.ToString(),
                            pi = this.txtPi.Text.ToString(),
                            fullName = this.txtFullName.Text.ToString(),
                            firstName = this.txtFirstName.Text.ToString(),
                            lastName = this.txtLastName.Text.ToString(),
                            labAddress = this.txtlabAddress.Text.ToString(),
                            phone = this.txtphone.Text.ToString(),
                            email = this.txtEmail.Text.ToString(),
                            labWebsite = this.txtLabWebsite.Text.ToString(),
                            researchInterest = this.txtResearchInterest.Text.ToString(),
                            publicationList = this.txtPublicationList.Text.ToString(),
                            collector = this.txtCollector.Text.ToString(),
                            GMT = this.txtGMT.Text.ToString(),
                            unsubscribe = Convert.ToBoolean(this.ddlUnsubscribe.SelectedValue),
                            ourCustomer = Convert.ToBoolean(this.ddlOurCustomer.SelectedValue)
                        };
                        customers.customerId = new CreateSysno().create("tbl_Customers", "customerId", 10, "1", base.CurrentUser.EmpNO.Trim());
                        customers.createBy = base.CurrentUser.EmpName;
                        customers.createDate = new DateTime?(DateTime.Now);
                        customers.ip = base.Request.UserHostAddress;
                        customers.EmpNO = base.CurrentUser.EmpNO.Trim();
                        context.tbl_Customers.InsertOnSubmit(customers);
                    }
                    context.SubmitChanges();
                    ShowMessage.AjaxShow("添加成功！");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this._ID = Fetch.Get("ID").Trim();
            if (!base.IsPostBack && (this._ID != ""))
            {
                using (Mail01DataContext context = dbLinq.GetErpData())
                {
                    tbl_Customers customers = context.tbl_Customers.SingleOrDefault<tbl_Customers>(z => z.ID == Guid.Parse(this._ID));
                    this.txtCustomerID.Text = customers.customerId;
                    this.txtCountry.Text = customers.country;
                    this.txtState.Text = customers.state;
                    this.txtCity.Text = customers.city;
                    this.txtArea.Text = customers.area;
                    this.txtUniversity.Text = customers.university;
                    this.txtCollege.Text = customers.college;
                    this.txtDepartment.Text = customers.department;
                    this.txtPi.Text = customers.pi;
                    this.txtFullName.Text = customers.fullName;
                    this.txtFirstName.Text = customers.firstName;
                    this.txtLastName.Text = customers.lastName;
                    this.txtlabAddress.Text = customers.labAddress;
                    this.txtphone.Text = customers.phone;
                    this.txtEmail.Text = customers.email;
                    this.txtLabWebsite.Text = customers.labWebsite;
                    this.txtResearchInterest.Text = customers.researchInterest;
                    this.txtPublicationList.Text = customers.publicationList;
                    this.txtCollector.Text = customers.collector;
                    this.txtGMT.Text = customers.GMT;
                    this.ddlUnsubscribe.SelectedValue = customers.unsubscribe.ToString();
                    this.ddlOurCustomer.SelectedValue = customers.ourCustomer.ToString();
                }
            }
        }
    }
}