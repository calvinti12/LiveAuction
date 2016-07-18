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
    public partial class ListAuction : System.Web.UI.Page
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
            string query = "select * from Auction";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            string lit = @"<table id='example' class='table table-striped responsive-utilities jambo_table'>
                        <thead>
                            <tr class='headings'>
                                <th>
                                    <input type='checkbox' class='tableflat'>
                                </th>
                                <th>Auction Id </th>
                                <th>Auction Name </th>
                                <th>Auction Date </th>
                                <th>Commission(%) </th>                                
                                <th class='no-link last'>
                                    <span class='nobr'>Action</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody>";
            for (int i=0;i<dt.Rows.Count;i++)
            {
                if (i % 2 == 0)
                {
                    lit = lit + @"<tr class='even pointer'>
                                <td class='a-center'>
                                    <input type='checkbox' class='tableflat'>
                                </td>
                                <td class=''>" + dt.Rows[i]["AuctionId"] + "</td>" +
                                "<td class=''>" + dt.Rows[i]["AuctionName"] + "</td>" +
                                "<td class=''>" + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "</td>" +
                                "<td class=''>" + dt.Rows[i]["Commission"] + "</td>" +
                                "<td class='last'>" +
                                    "<a href='#'>View</a>" +
                                "</td>" +
                            "</tr>";
                }
                else {
                    lit = lit + @"<tr class='odd pointer'>
                                <td class='a-center'>
                                    <input type='checkbox' class='tableflat'>
                                </td>
                                <td class=''>" + dt.Rows[i]["AuctionId"] + "</td>" +
                                "<td class=''>" + dt.Rows[i]["AuctionName"] + "</td>" +
                                "<td class=''>" + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "</td>" +
                                "<td class=''>" + dt.Rows[i]["Commission"] + "</td>" +
                                "<td class='last'>" +
                                    "<a href='#')>View</a>" +
                                "</td>" +
                            "</tr>";
                }

            }
            literalText.Text = lit;
        }
    }
}