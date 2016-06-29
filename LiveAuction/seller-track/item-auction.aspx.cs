using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Text;

namespace LiveAuction.seller_track
{
    public partial class item_auction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                //DataTable dt = this.GetData();

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.
                //html.Append("<table class='table table-condensed'>");
                
                ////Building the Header row.
                //html.Append("<tr>");
                //foreach (DataColumn column in dt.Columns)
                //{
                //    html.Append("<script type=\"text/javascript\">alert(" + dt.Rows.ToString() + ");</script>");
                //    html.Append("<th>");
                //    html.Append(column.ColumnName);
                //    html.Append("</th>");
                //}
                //html.Append("</tr>");
                //html.Append("<tr class=\"active\"><td colspan=\"5\">Live Auction</td></tr>");


                //Building the Data rows.
                //foreach (DataRow row in dt.Rows)
                //{
                    
                //    html.Append("<tr>");
                //    Response.Write( dt.Columns);
                //    foreach (DataColumn column in dt.Columns)
                //    {
                //        html.Append("<td>");
                        
                //        html.Append(row[column.ColumnName]);
                //        html.Append("</td>");
                //    }
                //    html.Append("<td>");
                //    html.Append("<i class=\"fa fa-calendar-o\"></i>&nbsp<a href=\"#\" class=\"btn-link\">Requested to schedule</a>");
                //    html.Append("</td>");
                //    html.Append("</tr>");
                //}
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select * from Auction";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();

                string lit = @"<table class='table table-condensed'>
                        <thead>
                            <tr class='headings'>
                                <th>Date </th>
                                <th>Auction Name </th>
                                <th>Scheduling Fee </th>
                                <th>Commission(%) </th>                                
                                <th class='no-link last'>
                                    <span class='nobr'>Action</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody><tr class='active'><td colspan='5'>Live Auction</td></tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                        lit = lit + @"<tr>
                                <td class=''>" + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "</td>" +
                                    "<td class=''>" + dt.Rows[i]["AuctionName"] + "</td>" +
                                    "<td class=''></td>" +
                                    "<td class=''>" + dt.Rows[i]["Commission"] + " %" + "</td>" +
                                    "<td class='last'><i class=\"fa fa-calendar-o\"></i>&nbsp" +
                                        "<a href='" + dt.Rows[i]["AuctionId"] + "'>Requested to schedule</a>" +
                                    "</td>" +
                                "</tr>";
                        
                }
                html.Append(lit);
                //Table end.
                html.Append("</table>");

                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

//                
            }
        }
        private DataTable GetData()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
               // using (SqlCommand cmd = new SqlCommand("select AuctionDate as Date,AuctionName as [Auction Name],Commission as [Commission(%)]from [AuctionBidPlatform].[dbo].[Auction]"))
                using (SqlCommand cmd = new SqlCommand("select * from Auction"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}