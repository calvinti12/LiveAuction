using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data.SqlClient;
using System.Data;
using System.Text;
namespace LiveAuction
{
    public partial class CatDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Category = Request.QueryString["cat"];
            string dealCategory = Request.QueryString["dcat"];
            if (Category != null && !Category.Equals(""))
            {
                if (Category.Equals("AllAuctions"))
                {
                    var id = Request.QueryString["id"];
                    if (id != null && !id.Equals(""))
                    {
                        PopulateAuctions(id);
                    }
                    else
                    {
                        PopulateAuctions();
                    }
                }
                else
                {
                    PopulateItems(Category);
                }
            }
            else if (dealCategory != null && !dealCategory.Equals(""))
            {
                if (dealCategory.Equals("AllDeals"))
                {
                    var id = Request.QueryString["id"];
                    if (id != null && !id.Equals(""))
                    {
                        PopulateDeals(id);
                    }
                    else
                    {
                        PopulateDeals();
                    }
                }
                else
                {
                    PopulateDefaulDeals(dealCategory);
                }
            }
            else { Response.Redirect("Index.aspx"); }

        }
        #region Populate Items
        public void PopulateItems(string id)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder mainContainerHtml = new StringBuilder();
            string template = "";
            string mainContainerStringLit = "";
            //string subCategoryHeading = "<strong><h4>Jewelry</h4></strong>";
            //string categoryHeading = "<h2>Fine Jewelry</h2>";

            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select CategoryId,CategoryName,CategoryDesc,ParentId from dbo.ProductCategory where ParentId=" + id + "";
            //string mainContainerQuery = "select * from dbo.View_ProductAuction_Category where ParentId=" + id + " AND IsScheduled=1";
            string mainContainerQuery = "select AuctionId,LotId,LotDesc,CategoryId,Title,StartingBid,AuctionName,AuctionDate,AuctionTime,[Address],LotImageName,ImageName from View_ProductAuction_Category where IsSchedule=1 and ParentId=" + id;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                template += @"<li><a href='CatDisplay.aspx?cat=AllAuctions&id=" + dt.Rows[i]["CategoryId"] + "&pid=" + id + "'>" + dt.Rows[i]["CategoryName"] + "</a></li>";
            }
            con.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(mainContainerQuery, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            con.Close();
            if (dt1.Rows.Count != 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    mainContainerStringLit += @"<a href='bid-detail.aspx?id=" + dt1.Rows[i]["LotId"] + "&cat=auction'><div class='col-md-4'>";
                    mainContainerStringLit += @"<div class='action-item-del-sec cat-item-sec'>
                        <div class='deal-pict'>
                            <img src='../fileupload/upload/" + dt1.Rows[i]["LotImageName"] + "' alt='deal-bag.png' class='img-responsive'>";
                    mainContainerStringLit += @"</div>
                        <div class='deal-pic-caption'>
                            <div class='deal-pic-caption-title'>
                                <p>" + dt1.Rows[i]["AuctionName"] + "</p>";
                    mainContainerStringLit += @"</div>
                            <div class='time-butt clearfix'>
                                <div class='pull-left'>
                                  <span><i class='fa fa-heart-o' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class='pull-right'>
                                  <span><i class='fa fa-shopping-cart' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>£" + dt1.Rows[i]["StartingBid"] + "</span>";
                    mainContainerStringLit += @"</div>
                            </div>
                        </div>
                    </div>
                  </div></a>";
                }
            }
            else
            {
                mainContainerStringLit += @"<h1>No items found</h1>";
            }
            html.Append(template);
            mainContainerHtml.Append(mainContainerStringLit);
            PlaceHolderSubCategory.Controls.Add(new Literal { Text = html.ToString() });
            PlaceHolderCatagoriesMainContainer.Controls.Add(new Literal { Text = mainContainerHtml.ToString() });
            //CategoryHeading.Controls.Add(new Literal { Text = categoryHeading.ToString() });
            //SubCategoryHeading.Controls.Add(new Literal { Text = subCategoryHeading.ToString() });
        }
        #endregion
        #region All Auctions
        public void PopulateAuctions()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder mainContainerHtml = new StringBuilder();
            string template = "";
            //string subCategoryHeading = "<strong><h4>Categoris</h4></strong>";
            //string categoryHeading = "<h2>All Auctions</h2>";
            string mainContainerStringLit = "";
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select distinct a.ParentId, b.CategoryName,b.CategoryDesc,b.CategoryId from dbo.ProductCategory a ,dbo.ProductCategory b where a.ParentId = b.CategoryId";
            string allAuctionsQuery = "  select AuctionId,LotId,LotDesc,CategoryId,Title,StartingBid,AuctionName,AuctionDate,AuctionTime,[Address],LotImageName,ImageName from dbo.View_list_item where IsScheduled=1";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            SqlDataAdapter adapter1 = new SqlDataAdapter(allAuctionsQuery, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                template += @"<li><a href='CatDisplay.aspx?cat=" + dt.Rows[i]["CategoryId"] + "'>" + dt.Rows[i]["CategoryName"] + "</a></li>";
            }
            if (dt1.Rows.Count != 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    mainContainerStringLit += @"<a href='bid-detail.aspx?id=" + dt1.Rows[i]["LotId"] + "&cat=auction'><div class='col-md-4'>";
                    mainContainerStringLit += @"<div class='action-item-del-sec cat-item-sec'>
                        <div class='deal-pict'>
                            <img src='../fileupload/upload/" + dt1.Rows[i]["LotImageName"] + "' alt='deal-bag.png' class='img-responsive'>";
                    mainContainerStringLit += @"</div>
                        <div class='deal-pic-caption'>
                            <div class='deal-pic-caption-title'>
                                <p>" + dt1.Rows[i]["AuctionName"] + "</p>";
                    mainContainerStringLit += @"</div>
                            <div class='time-butt clearfix'>
                                <div class='pull-left'>
                                  <span><i class='fa fa-heart-o' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class='pull-right'>
                                  <span><i class='fa fa-shopping-cart' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>£" + dt1.Rows[i]["StartingBid"] + "</span>";
                    mainContainerStringLit += @"</div>
                            </div>
                        </div>
                    </div>
                  </div></a>";
                }
            }
            else
            {
                mainContainerStringLit += @"<h1>No items found</h1>";
            }
            html.Append(template);
            mainContainerHtml.Append(mainContainerStringLit);
            PlaceHolderSubCategory.Controls.Add(new Literal { Text = html.ToString() });
            PlaceHolderCatagoriesMainContainer.Controls.Add(new Literal { Text = mainContainerHtml.ToString() });
            //CategoryHeading.Controls.Add(new Literal { Text = categoryHeading.ToString() });
            //SubCategoryHeading.Controls.Add(new Literal { Text = subCategoryHeading.ToString() });

        }
        public void PopulateAuctions(string id)
        {
            var pid = Request.QueryString["pid"];
            StringBuilder html = new StringBuilder();
            StringBuilder mainContainerHtml = new StringBuilder();
            string template = "";
            //string subCategoryHeading = "<strong><h4>Categoris</h4></strong>";
            //string categoryHeading = "<h2>All Auctions</h2>";
            string mainContainerStringLit = "";
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select CategoryId,CategoryName,CategoryDesc,ParentId from dbo.ProductCategory where ParentId=" + pid + "";
            string allAuctionsQuery = "  select AuctionId,LotId,LotDesc,CategoryId,Title,StartingBid,AuctionName,AuctionDate,AuctionTime,[Address],LotImageName,ImageName from dbo.View_list_item where IsSchedule=1 and CategoryId=" + id + "";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            SqlDataAdapter adapter1 = new SqlDataAdapter(allAuctionsQuery, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                template += @"<li><a href='CatDisplay.aspx?cat=AllAuctions&id=" + dt.Rows[i]["CategoryId"] + "&pid=" + pid + "'>" + dt.Rows[i]["CategoryName"] + "</a></li>";
            }
            if (dt1.Rows.Count != 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    mainContainerStringLit += @"<a href='bid-detail.aspx?id=" + dt1.Rows[i]["LotId"] + "&cat=auction'><div class='col-md-4'>";
                    mainContainerStringLit += @"<div class='action-item-del-sec cat-item-sec'>
                        <div class='deal-pict'>
                            <img src='../fileupload/upload/" + dt1.Rows[i]["LotImageName"] + "' alt='deal-bag.png' class='img-responsive'>";
                    mainContainerStringLit += @"</div>
                        <div class='deal-pic-caption'>
                            <div class='deal-pic-caption-title'>
                                <p>" + dt1.Rows[i]["AuctionName"] + "</p>";
                    mainContainerStringLit += @"</div>
                            <div class='time-butt clearfix'>
                                <div class='pull-left'>
                                  <span><i class='fa fa-heart-o' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class='pull-right'>
                                  <span><i class='fa fa-shopping-cart' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>£" + dt1.Rows[i]["StartingBid"] + "</span>";
                    mainContainerStringLit += @"</div>
                            </div>
                        </div>
                    </div>
                  </div></a>";

                }
            }
            else
            {
                mainContainerStringLit += @"<h1>No items found</h1>";
            }
            html.Append(template);
            mainContainerHtml.Append(mainContainerStringLit);
            PlaceHolderSubCategory.Controls.Add(new Literal { Text = html.ToString() });
            PlaceHolderCatagoriesMainContainer.Controls.Add(new Literal { Text = mainContainerHtml.ToString() });
            //CategoryHeading.Controls.Add(new Literal { Text = categoryHeading.ToString() });
            //SubCategoryHeading.Controls.Add(new Literal { Text = subCategoryHeading.ToString() });

        }
        #endregion
        #region Populate Deals
        public void PopulateDefaulDeals(string id)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder mainContainerHtml = new StringBuilder();
            string template = "";
            string mainContainerStringLit = "";
            //string subCategoryHeading = "<strong><h4>Jewelry</h4></strong>";
            //string categoryHeading = "<h2>Fine Jewelry</h2>";

            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select CategoryId,CategoryName,CategoryDesc,ParentId from dbo.ProductCategory where ParentId=" + id + "";
            //string mainContainerQuery = "select * from dbo.View_ProductAuction_Category where ParentId=" + id + " AND IsScheduled=1";
            string mainContainerQuery = "select * from View_ProductDeals_Category where IsDealPassed=1 and ParentId=" + id;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                template += @"<li><a href='CatDisplay.aspx?dcat=AllDeals&id=" + dt.Rows[i]["CategoryId"] + "&pid=" + id + "'>" + dt.Rows[i]["CategoryName"] + "</a></li>";
            }
            con.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(mainContainerQuery, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            con.Close();
            if (dt1.Rows.Count != 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    mainContainerStringLit += @"<a href='bid-detail.aspx?id=" + dt1.Rows[i]["DealId"] + "&cat=auction'><div class='col-md-4'>";
                    mainContainerStringLit += @"<div class='action-item-del-sec cat-item-sec'>
                        <div class='deal-pict'>
                            <img src='../fileupload/upload/" + dt1.Rows[i]["ImageName"] + "' alt='deal-bag.png' class='img-responsive'>";
                    mainContainerStringLit += @"</div>
                        <div class='deal-pic-caption'>
                            <div class='deal-pic-caption-title'>
                                <p>" + dt1.Rows[i]["Title"] + "</p>";
                    mainContainerStringLit += @"</div>
                            <div class='time-butt clearfix'>
                                <div class='pull-left'>
                                  <span><i class='fa fa-heart-o' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class='pull-right'>
                                  <span><i class='fa fa-shopping-cart' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>£" + dt1.Rows[i]["DealPrice"] + "</span>";
                    mainContainerStringLit += @"</div>
                            </div>
                        </div>
                    </div>
                  </div></a>";
                }
            }
            else
            {
                mainContainerStringLit += @"<h1>No items found</h1>";
            }
            html.Append(template);
            mainContainerHtml.Append(mainContainerStringLit);
            PlaceHolderSubCategory.Controls.Add(new Literal { Text = html.ToString() });
            PlaceHolderCatagoriesMainContainer.Controls.Add(new Literal { Text = mainContainerHtml.ToString() });
            //CategoryHeading.Controls.Add(new Literal { Text = categoryHeading.ToString() });
            //SubCategoryHeading.Controls.Add(new Literal { Text = subCategoryHeading.ToString() });
        }
        #endregion
        #region All Deals
        public void PopulateDeals()
        {
            var pid = Request.QueryString["pid"];
            StringBuilder html = new StringBuilder();
            StringBuilder mainContainerHtml = new StringBuilder();
            string template = "";
            //string subCategoryHeading = "<strong><h4>Categoris</h4></strong>";
            //string categoryHeading = "<h2>All Deals</h2>";
            string mainContainerStringLit = "";
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select distinct a.ParentId, b.CategoryName,b.CategoryDesc,b.CategoryId from dbo.ProductCategory a ,dbo.ProductCategory b where a.ParentId = b.CategoryId";
            string allAuctionsQuery = "  select DealId,CategoryId,Title,DealPrice,DealDate,DealTime,ImageName from dbo.View_list_deals where IsDealPassed=1";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            SqlDataAdapter adapter1 = new SqlDataAdapter(allAuctionsQuery, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                template += @"<li><a href='CatDisplay.aspx?dcat=" + dt.Rows[i]["CategoryId"] + "'>" + dt.Rows[i]["CategoryName"] + "</a></li>";
            }

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                mainContainerStringLit += @"<a href='bid-detail.aspx?id=" + dt1.Rows[i]["DealId"] + "&cat=deal'><div class='col-md-4'>";
                mainContainerStringLit += @"<div class='action-item-del-sec cat-item-sec'>
                        <div class='deal-pict'>
                            <img src='../fileupload/upload/" + dt1.Rows[i]["ImageName"] + "' alt='deal-bag.png' class='img-responsive'>";
                mainContainerStringLit += @"</div>
                        <div class='deal-pic-caption'>
                            <div class='deal-pic-caption-title'>
                                <p>" + dt1.Rows[i]["Title"] + "</p>";
                mainContainerStringLit += @"</div>
                            <div class='time-butt clearfix'>
                                <div class='pull-left'>
                                  <span><i class='fa fa-heart-o' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class='pull-right'>
                                  <span><i class='fa fa-shopping-cart' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>£" + dt1.Rows[i]["DealPrice"] + "</span>";
                mainContainerStringLit += @"</div>
                            </div>
                        </div>
                    </div>
                  </div></a>";
            }
            html.Append(template);
            mainContainerHtml.Append(mainContainerStringLit);
            PlaceHolderSubCategory.Controls.Add(new Literal { Text = html.ToString() });
            PlaceHolderCatagoriesMainContainer.Controls.Add(new Literal { Text = mainContainerHtml.ToString() });
            //CategoryHeading.Controls.Add(new Literal { Text = categoryHeading.ToString() });
            //SubCategoryHeading.Controls.Add(new Literal { Text = subCategoryHeading.ToString() });

        }
        public void PopulateDeals(string id)
        {
            var pid = Request.QueryString["pid"];
            StringBuilder html = new StringBuilder();
            StringBuilder mainContainerHtml = new StringBuilder();
            string template = "";
            //string subCategoryHeading = "<strong><h4>Categoris</h4></strong>";
            //string categoryHeading = "<h2>All Auctions</h2>";
            string mainContainerStringLit = "";
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select CategoryId,CategoryName,CategoryDesc,ParentId from dbo.ProductCategory where ParentId=" + pid + "";
            string allAuctionsQuery = "  select * from dbo.View_list_deals where IsDealPassed=1 and CategoryId=" + id + "";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            SqlDataAdapter adapter1 = new SqlDataAdapter(allAuctionsQuery, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                template += @"<li><a href='CatDisplay.aspx?dcat=AllDeals&id=" + dt.Rows[i]["CategoryId"] + "&pid=" + pid + "'>" + dt.Rows[i]["CategoryName"] + "</a></li>";
            }
            if (dt1.Rows.Count != 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    mainContainerStringLit += @"<a href='bid-detail.aspx?id=" + dt1.Rows[i]["DealId"] + "&cat=deals'><div class='col-md-4'>";
                    mainContainerStringLit += @"<div class='action-item-del-sec cat-item-sec'>
                        <div class='deal-pict'>
                            <img src='../fileupload/upload/" + dt1.Rows[i]["ImageName"] + "' alt='deal-bag.png' class='img-responsive'>";
                    mainContainerStringLit += @"</div>
                        <div class='deal-pic-caption'>
                            <div class='deal-pic-caption-title'>
                                <p>" + dt1.Rows[i]["Title"] + "</p>";
                    mainContainerStringLit += @"</div>
                            <div class='time-butt clearfix'>
                                <div class='pull-left'>
                                  <span><i class='fa fa-heart-o' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class='pull-right'>
                                  <span><i class='fa fa-shopping-cart' aria-hidden='true'></i></span>&nbsp;&nbsp;<span>£" + dt1.Rows[i]["DealPrice"] + "</span>";
                    mainContainerStringLit += @"</div>
                            </div>
                        </div>
                    </div>
                  </div></a>";

                }
            }
            else
            {
                mainContainerStringLit += @"<h1>No items found</h1>";
            }
            html.Append(template);
            mainContainerHtml.Append(mainContainerStringLit);
            PlaceHolderSubCategory.Controls.Add(new Literal { Text = html.ToString() });
            PlaceHolderCatagoriesMainContainer.Controls.Add(new Literal { Text = mainContainerHtml.ToString() });
            //CategoryHeading.Controls.Add(new Literal { Text = categoryHeading.ToString() });
            //SubCategoryHeading.Controls.Add(new Literal { Text = subCategoryHeading.ToString() });

        }
        #endregion
    }
}