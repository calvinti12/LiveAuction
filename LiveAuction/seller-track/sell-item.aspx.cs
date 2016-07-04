using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LiveAuction.seller_track
{
    public partial class sell_item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                StringBuilder html = new StringBuilder();
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select * from [AuctionBidPlatform].[dbo].[View_list_item]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                string lit = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lit = lit + @"<div class='sell-item-con'>
                          <div class='sell-item-prt'>
                            <div class='sell-left-pic'>
                              <img src='images/sell-item.png' alt='ttt' class='img-responsive'>
                            </div>
                            <div class='sell-pic-des'>
                              <ul class='list-unstyled'>
                                <li>Item: <span>#13484292</span></li>
                                <li>SKU: <span>" + dt.Rows[i]["SKU"] + "";
                    lit = lit + @"<li>Views: <span>0</span></li>
                              </ul>
                            </div>
                          </div>
                          <div class='sell-item-prt sell-item-prt-2'>
                            <div class='sell-item-pt-part clearfix'>
                              <div class='pull-left'>
                                <div class='pull-left-st'>
                                  <div class='checkbox'>
                                    <label>
                                      <input type='checkbox' value=''>
                                      <span>SCHEDULED</span>"+ dt.Rows[i]["Title"] + "";
                    lit = lit + @"</label>
                                  </div>
                                </div>
                              </div>
                              <div class='pull-right'>
                                <ul class='list-inline'>
                                  <li>selling: <span>" + dt.Rows[i]["AuctionTime"] + "";
                    lit = lit + @"&nbsp; " + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "";
                    lit = lit + @"</span></li>
                                  <li>
                                    <div class='dropdown'>
                                      <button class='btn btn-default dropdown-toggle' type='button' id='selldrop' data-toggle='dropdown' aria-haspopup='true' aria-expanded='true'>
                                        <i class='fa fa-bars' aria-hidden='true'></i>
                                        <span class='caret'></span>
                                      </button>
                                      <ul class='dropdown-menu sellDrop' aria-labelledby='selldrop'>
                                        <li><a href='#'>1</a></li>
                                        <li><a href='#'>2</a></li>
                                      </ul>
                                    </div>
                                  </li>
                                </ul>
                              </div>
                            </div>
                            <div class='sell-item-pt-part'>
                              <div class='sell-pic-prt-dv'>
                                <p>schudule in the <strong>" + dt.Rows[i]["AuctionName"] + "</strong> Auction.</p>";
                    lit = lit + @"
                              </div>
                            </div>
                          </div>
                      </div>";
                }
                html.Append(lit);
                html.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }
    }
}