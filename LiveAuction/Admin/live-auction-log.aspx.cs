using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BusinessLogicLayer;
using EntityLayer;

namespace LiveAuction.Admin
{
    public partial class live_auction_log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGrid();
            }
        }
        private void FillGrid()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from [AuctionBidPlatform].[dbo].[LiveAuctionLogs]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            string moralHtml = "";
            string lit = @"<table id='example' class='table table-striped responsive-utilities jambo_table'>
                        <thead>
                            <tr class='headings'>
                                <th>
                                    <input type='checkbox' class='tableflat'>
                                </th>
                                <th>Log Id </th>
                                <th>File Name </th>
                                <th>Created on </th>                             
                                <th class='no-link last'>
                                    <span class='nobr'>Action</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lit = lit + @"<tr class='even pointer'>
                                <td class='a-center'>
                                    <input type='checkbox' class='tableflat'>
                                </td>
                                <td class=''>" + dt.Rows[i]["LiveAuctionLogId"] + "</td>" +
                                "<td class=''>" + dt.Rows[i]["FileName"] + "</td>" +
                                "<td class=''>" + Convert.ToDateTime(dt.Rows[i]["CreatedOn"]).Date.ToString("d") + "</td>" +
                                "<td class='last'>" +
                                    "<a href='/Admin/log_files/" + dt.Rows[i]["FileName"] + "'>View</a>" +
                                "</td>" +
                            "</tr>";
                }
                else
                {
                    lit = lit + @"<tr class='odd pointer'>
                                <td class='a-center'>
                                    <input type='checkbox' class='tableflat'>
                                </td>
                                <td class=''>" + dt.Rows[i]["LiveAuctionLogId"] + "</td>" +
                                "<td class=''>" + dt.Rows[i]["FileName"] + "</td>" +
                                "<td class=''>" + Convert.ToDateTime(dt.Rows[i]["CreatedOn"]).Date.ToString("d") + "</td>" +
                                "<td class='last'>" +
                                    "<a href='Admin/log_files/" + dt.Rows[i]["FileName"] + "'>View</a>" +
                                "</td>" +
                            "</tr>";
                }
                
            }
            //lit += @"</table>";
            literalText.Text = lit + moralHtml;

        }

        [System.Web.Services.WebMethod]
        public static string BlukCSVupload()
        {
            return "Hello " + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }

    }
}