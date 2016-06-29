using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace LiveAuction.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];// ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select * from Admin where Email='" + txtUserName.Text + "'" + "and Password='" + txtPassword.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["AdminUserName"] = Convert.ToString(dt.Rows[0]["Email"]);
                    Session["AdminUserId"] = Convert.ToString(dt.Rows[0]["Id"]);
                    Response.Redirect("~/Admin/Dashboard.aspx");
                }
                else
                {
                    lblError.Text = "Username and password do not match";
                }
            }
        }
    }
}