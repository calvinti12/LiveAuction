using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LiveAuction
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from Auction where IsSchedule='1'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            DateTime today = new DateTime();

            string lit = "";
            //            string lit = @"<div class='col-md-3 col-sm-6 col-xs-12'>
            //                            <div class='action-item-sec text-center'>
            //                                <img src='images/action-item-logo.png' alt='action-item-logo.png'>
            //                                <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
            //                                <a href='#' class='btn btn-danger btn-block'>View Details</a>
            //                                <div class='action-timing-sec'>
            //                                    <p>live</p>
            //                        </div>
            //                    </div>
            //                </div>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               
                //DateTime actionDate = new DateTime(dt.Rows[i]["AuctionDate"].ToString());<img src='./Admin/FileUpload/superbox-full-15.jpg' width='200px'/>
                lit = lit + @"<div class='col-md-3 col-sm-6 col-xs-12'>
                            <div class='action-item-sec text-center'>
                                <img src='./Admin/FileUpload/" + dt.Rows[i]["ImageName"] + "' width='200px' alt='" + dt.Rows[i]["AuctionName"] + " image" + "'/><p>" + dt.Rows[i]["Address"] +
                                        "</p><a href='#' class='btn btn-danger btn-block bidding-sing-btn' data-toggle='modal' data-target='#bidpopup'>View Details</a><div class='action-timing-sec'><p>";
                lit = lit + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d");
                lit = lit + @"</p></div></div></div>";
                //                lit = lit + @"<tr>
                //                                <input type='hidden' class='idField' value='" + dt.Rows[i]["AuctionId"] + "'/>" +
                //                            "<td class=''  >" + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "</td>" +
                //                            "<td class=''>" + dt.Rows[i]["AuctionName"] + "</td>" +
                //                            "<td class=''></td>" +
                //                            "<td class=''>" + dt.Rows[i]["Commission"] + " %" + "</td>" +
                //                            "<td class='last'><i class=\"fa fa-calendar-o\"></i>&nbsp" +
                //                                "<a href='item-auction.aspx?id=" + dt.Rows[i]["AuctionId"] + "" + "'>Requested to schedule</a>" +
                //                            "</td>" +
                //                        "</tr>";

                //                Response.Write(dt.Rows[i]["ImagePath"]);
                //                lit = lit + @"<div class='col-md-3 col-sm-6 col-xs-12'>
                //                            <div class='action-item-sec text-center'>
                //                                <img width='300px'" + dt.Rows[i]["ImagePath"] + "' alt='" + dt.Rows[i]["AuctionName"] + " image" + "'/><p>" + dt.Rows[i]["Address"] +
                //                                        "</p><a href='#' class='btn btn-danger btn-block'>View Details</a><div class='action-timing-sec'><p>";
                //                lit = lit + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d");
                //                lit = lit + @"</p></div></div></div>";
            }
            html.Append(lit);
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}