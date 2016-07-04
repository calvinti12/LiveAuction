﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web.Services;

namespace LiveAuction.seller_track
{
    public partial class item_auction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                StringBuilder html = new StringBuilder();
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select * from Auction";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                string lit = @"<table class='table table-condensed '>
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

                    if ((int)dt.Rows[i]["IsSchedule"] == 1)
                    {
                        lit = lit + @"<tr>
                                <input type='hidden' class='idField' value='" + dt.Rows[i]["AuctionId"] + "'/>" +
                                    "<td class=''  >" + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "</td>" +
                                    "<td class=''>" + dt.Rows[i]["AuctionName"] + "</td>" +
                                    "<td class=''>" + dt.Rows[i]["SchedulingFee"] + "</td>" +
                                    "<td class=''>" + dt.Rows[i]["Commission"] + " %" + "</td>" +
                                    "<td class='last'><i class=\"fa fa-calendar-o\"></i>&nbsp" +
                                        "<label >Requested to schedule</label>" +
                                    "</td>" +
                                "</tr>";
                    }
                    else
                    {
                        lit = lit + @"<tr>
                                <input type='hidden' class='idField' value='" + dt.Rows[i]["AuctionId"] + "'/>" +
                                    "<td class=''  >" + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "</td>" +
                                    "<td class=''>" + dt.Rows[i]["AuctionName"] + "</td>" +
                                    "<td class=''>" + dt.Rows[i]["SchedulingFee"] + "</td>" +
                                    "<td class=''>" + dt.Rows[i]["Commission"] + " %" + "</td>" +
                                    "<td class='last'><i class=\"fa fa-calendar-o\"></i>&nbsp" +
                                        "<a href='item-auction.aspx?id=" + dt.Rows[i]["AuctionId"] + "" + "'>Request to schedule</a>" +
                                    "</td>" +
                                "</tr>";
                    }
                }
                html.Append(lit);
                html.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }

            string id = Request.QueryString["id"];
            if (id != null)
            {
                UpdateRecord(id);
            }
        }
        public void UpdateRecord(string id)
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "UPDATE Auction SET IsSchedule='1' WHERE AuctionId='" + id+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            Response.Redirect("sell-item.aspx");
        }
    }
}