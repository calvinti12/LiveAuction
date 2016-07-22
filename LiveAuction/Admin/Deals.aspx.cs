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
    public partial class Deals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id=Request.QueryString["id"];
            var cat = Request.QueryString["cat"];
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            
            if (id != null)
            {
                if (cat.Equals("app"))
                {
                    con.Open();
                    string query = "UPDATE Deals SET IsDealPassed=1 WHERE DealId=" + id;
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    con.Close();
                    Response.Redirect("Deals.aspx");
                }
                if (cat.Equals("del"))
                {
                    con.Open();
                    string query = "DELETE FROM Deals WHERE DealId=" + id;
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    con.Close();
                    Response.Redirect("Deals.aspx");
                }
 
            }
            if (!Page.IsPostBack)
            {
                FillGrid();
            }

        }
        private void FillGrid()
        {
            string modalHtml = "";
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from View_Admin_Approve_Deals where IsDealPassed=0";
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
                                <th>Seller Name</th>
                                <th>Title </th>
                                <th>Date </th>
                                <th>Price</th>                                
                                <th class='no-link last'>
                                    <span class='nobr' colspan=3>Action</span>
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
                                <td class=''>" + dt.Rows[i]["FirstName"] + "&nbsp" + dt.Rows[i]["lastName"] + "</td>" +
                                "<td class=''>" + dt.Rows[i]["Title"] + "</td>" +
                                "<td class=''>" + Convert.ToDateTime(dt.Rows[i]["DealDate"]).Date.ToString("d") + "</td>" +
                                "<td class=''>" + dt.Rows[i]["OriginalPrice"] + "£</td>" +
                                "<td class='last'>" +
                                    "<a data-toggle='modal' data-target='#bidpopup" + dt.Rows[i]["DealId"] + "' href='#'>View</a>&nbsp|&nbsp<a href='Deals.aspx?id=" + dt.Rows[i]["DealId"] + "&cat=app' id='approve" + dt.Rows[i]["DealId"] + "'>Approve</a>&nbsp|&nbsp<a id='reject" + dt.Rows[i]["DealId"] + "'href='Deals.aspx?id=" + dt.Rows[i]["DealId"] + "&cat=del'>Reject</a>&nbsp" +
                                "</td>" +
                            "</tr>";
                }
                else
                {
                    lit = lit + @"<tr class='odd pointer'>
                                <td class='a-center'>
                                    <input type='checkbox' class='tableflat'>
                                </td>
                                <td class=''>" + dt.Rows[i]["FirstName"] + "&nbsp" + dt.Rows[i]["lastName"] + "</td>" +
                                "<td class=''>" + dt.Rows[i]["Title"] + "</td>" +
                                "<td class=''>" + Convert.ToDateTime(dt.Rows[i]["DealDate"]).Date.ToString("d") + "</td>" +
                                "<td class=''>" + dt.Rows[i]["OriginalPrice"] + "£</td>" +
                                "<td class='last'>" +
                                    "<a data-toggle='modal' data-target='#bidpopup" + dt.Rows[i]["DealId"] + "' href='#'>View</a>&nbsp|&nbsp<a href='Deals.aspx?id=" + dt.Rows[i]["DealId"] + "&cat=app' id='approve" + dt.Rows[i]["DealId"] + "'>Approve</a>&nbsp|&nbsp<a id='reject" + dt.Rows[i]["DealId"] + "'href='Deals.aspx?id=" + dt.Rows[i]["DealId"] + "&cat=del'>Reject</a>&nbsp" +
                                "</td>" +
                            "</tr>";
                }

                lit += @"<section class='bid-popup-sector'>
        <div class='modal fade' id='bidpopup" + dt.Rows[i]["DealId"] + "' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'>";
                lit += @"<div class='modal-dialog bid-model-dialog' role='document' style='margin-top:6%'>
            <div class='modal-content bid-model-content'>
              <div class='modal-header bid-model-header spc-bid-model-header'>
                <button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>
                <h4 class='modal-title' id='myModalLabel'>Seller : " + dt.Rows[i]["FirstName"] + "&nbsp" + dt.Rows[i]["lastName"] + "</h4>";
                lit += @"</div>
              <div class='modal-body bid-model-body'>
                  <div class='row'>
                    <div class='col-md-12'>
                      <div class='cr-accnt pop-cr-accnt'>
                        <div class='bid-popup-pic-sec spc-bid-popup-pic-sec text-center'>
                          <div class='bid-popup-title'>
                            <h3>Deal&nbsp" + dt.Rows[i]["DealId"] + "&nbsp,&nbsp" + dt.Rows[i]["Title"] + "";
                lit += @"</div>
                          <div class='bid-popup-pic'>
                            <img style='display: block;width:200px; margin-left: auto;margin-right: auto;' src='../fileupload/upload/" + dt.Rows[i]["Imagename"] + "' alt='this is for bid popup' >";
                lit += @"</div>
                          <div class='bid-p-dis'>
                            <p class='bid-alate'>" + dt.Rows[i]["DealDesc"] + "</p>";
                lit += @"</div>
                          <div class='bid-p-dis text-center'>
                            <h4>Original price :" + dt.Rows[i]["OriginalPrice"] + "£</h4>";
                lit += @"</div>
                          <div class='bid-p-dis text-center'>
                            <h4>Deal price :" + dt.Rows[i]["DealPrice"] + "£ </h4>";
                lit += @"</div>
                          <div class='bid-p-dis'>
                          </div>
                        </div>
                      </div>
                    </div>
                    
                  </div>
                  <div class='row'>
                    
                    
                  </div>
              </div>
            </div>
          </div>
        </div>
      </section>";
               var lita = "<script>$( document ).ready(function() {" +
                    "$('#approve" + dt.Rows[i]["DealId"] + "').click(function(e){" +
                            "e.preventDefault();alert('loaded');" +
                            "$.ajax({"+
                            "type: 'POST',"+
                            "url: 'Deals.aspx/Approve'," +
                            "data: {id:'" + dt.Rows[i]["DealId"] + "'},"+
                            "contentType: 'application/json; charset=utf-8',"+
                            "dataType: 'json',"+
                            "success: function (response) { console.log(response.d); },"+
                            "failure: function (response) { console.log(response.d); }"+
                            "});" +
                        "});" +
                     "});" +
                "</script>";
            }
            lit += "</table>";

            literalText.Text = lit;
        }

        [System.Web.Services.WebMethod]
        public static void Approve(int id)
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "UPDATE Deals SET IsDealPassed=0 WHERE DealId=" + id;
            //SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            con.Close();
        }
        [System.Web.Services.WebMethod]
        public static void Reject(int id)
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "DELETE FROM Deals WHERE DealId=" + id;
            con.Close();
        }

    }
}