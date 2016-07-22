using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using UtilityLayer;
using System.Data;
using System.Text;

namespace LiveAuction.UserControl
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        BidderBL objBidderBL = new BidderBL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCookie();
            }

        }

        #region Load Cookie
        public void LoadCookie()
        {
            if (Request.Cookies["LoginCookie"] != null)
            {
                txtLoginEmail.Text = Request.Cookies["LoginCookie"].Values["UserName"].Trim().ToString();
                txtLoginEmail.Text = Request.Cookies["LoginCookie"].Values["Password"].Trim().ToString();
                //txtLoginPassword.Attributes.Add("Value", Request.Cookies["LoginCookie"].Values["Password"].Trim().ToString());
                //txtLoginPassword.Attributes.Add("MaxLength", "20");
                //txtLoginPassword.Attributes.Add("Size", "20");
                chkPwdSave.Checked = true;
            }
        }
        #endregion

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Email = txtLoginEmail.Text.Trim();
            string Password = txtLoginPassword.Text.Trim();
            //string UserType = rdbtnlistUserType.SelectedValue;
            string UserType = "1";
            DataTable dtLogin = objBidderBL.GetLoginUser(Email, Password, UserType);
            if (dtLogin != null && dtLogin.Rows.Count > 0)
            {
                if (UserType == "1")
                {
                    Session["UserType"] = "Bidder";
                    Session["UserName"] = Convert.ToString(dtLogin.Rows[0]["PreferredName"]);
                    Session["UserId"] = Convert.ToString(dtLogin.Rows[0]["BidderId"]);
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Session["UserType"] = "Seller";
                    Session["UserName"] = Convert.ToString(dtLogin.Rows[0]["PreferredName"]);
                    Session["UserId"] = Convert.ToString(dtLogin.Rows[0]["SellerId"]);
                    Response.Redirect("seller-track/dashboard.aspx");
                }

                if (chkPwdSave.Checked == true)
                {
                    HttpCookie cookie = new HttpCookie("LoginCookie");
                    cookie.Values.Add("UserName", txtLoginPassword.Text);
                    cookie.Values.Add("Password", txtLoginPassword.Text);
                    cookie.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(cookie);


                }
                else
                {
                    Response.Cookies["LoginCookie"].Values.Clear();
                }

                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trLoginG('Successfully Login');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trLoginR('Login Failed');", true);
            }

        }



        protected void btnForgot_Click(object sender, EventArgs e)
        {
            string Email = txtForgotEmail.Text.Trim();

            string UserType = rdbtnlistFGUserType.SelectedValue;
            DataTable dtFGPwd = objBidderBL.EmailCheck(Email, UserType);
            if (dtFGPwd != null && dtFGPwd.Rows.Count > 0)
            {
                string PreferredName = Convert.ToString(dtFGPwd.Rows[0]["PreferredName"]);
                //string Email = Convert.ToString(dtFGPwd.Rows[0]["Email"]);
                string Password = Convert.ToString(dtFGPwd.Rows[0]["Password"]);
                string strEmailFrom = System.Configuration.ConfigurationSettings.AppSettings["AdminEmailID"].ToString();
                string strEmailTo = Email;
                StringBuilder strEmailBody = new StringBuilder();
                strEmailBody.Append("<html><body><div>");
                strEmailBody.Append("Dear <b>" + PreferredName + "</b>,");
                strEmailBody.Append("<br/><br/>Your sign in password is  : " + "<b>" + Password + "</b>");
                strEmailBody.Append("<br/><br/>Thanks,");
                strEmailBody.Append("<br/>ABP Admin");
                strEmailBody.Append("</div></body></html>");
                string strMailBody = strEmailBody.ToString();
                string strEmailSub = "ABP - Forgot Password";
                int i = Mail.ShootMail(strEmailTo, strEmailFrom, strEmailSub, strMailBody);
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trLoginG('Your password has been emailed to you.');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trLoginR('Please try again after sometime.');", true);
                    
                }
            }
        }
    }
}