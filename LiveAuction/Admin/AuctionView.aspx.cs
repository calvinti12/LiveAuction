using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace LiveAuction.Admin
{
    public partial class AuctionView : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            //Response.Write(id);
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from Auction where AuctionId="+id;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            //Response.Write("Id selected "+dt.Rows[0]["AuctionName"]);
            txtAuctionName.Text = dt.Rows[0]["AuctionName"].ToString();
            auctiontime.Text = dt.Rows[0]["AuctionTime"].ToString();
            auctiondate.Text = Convert.ToDateTime(dt.Rows[0]["AuctionDate"]).Date.ToString("dd-MM-yyyy");
            number.Text = dt.Rows[0]["Commission"].ToString();
            //fileUploadLabel.Text = "";
            address.Text = dt.Rows[0]["Address"].ToString();
            schedulingfee.Text = dt.Rows[0]["SchedulingFee"].ToString();
        }
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtAuctionName.Text = "";
            auctiontime.Text = "";
            auctiondate.Text = "";
            number.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                //string filePath;
                //if (FileUpload1.HasFile)
                //{
                    //if (FileUpload1.PostedFile.ContentLength < 102400)
                    //{
                    try
                    {
                        //string filename = Path.GetFileName(FileUpload1.FileName);
                        //filePath = Server.MapPath(@"~\Admin\FileUpload\") + filename;
                        //System.Drawing.Image imgFile = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                        //if (imgFile.PhysicalDimension.Width > 600 || imgFile.PhysicalDimension.Height > 400)
                        //{


                        //filePath = Server.MapPath(@"~/Admin/FileUpload/") + filename;<img src='./Admin/FileUpload/superbox-full-15.jpg' width='200px'/>
                        //filePath = "./Admin/FileUpload/" + filename;
                        //Path.GetFullPath(filePath).Replace(@"/", @"//");
                        //FileUpload1.SaveAs(filePath);
                        string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                        SqlConnection con = new SqlConnection(connectionString);
                        con.Open();
                        //string query = "insert into Auction(AuctionTypeId,AuctionName,AuctionDate,AuctionTime,Address,Commission,IsSchedule,UserType,UserId,ImagePath,SchedulingFee,ImageName)values('3','" + txtAuctionName.Text + "','" + auctiondate.Text + "','" + auctiontime.Text + "','" + address.Text + "','" + number.Text + "',0,'Admin'," + Convert.ToInt32(Session["AdminUserId"]) + "," + "'" + filePath + "'" + "," + "'" + schedulingfee.Text + "'" + "," + "'" + filename + "'" + ")";
                        string query = "update Auction set AuctionName='" + txtAuctionName.Text + "',AuctionDate=" + auctiondate.Text + ",AuctionTime='" + auctiontime.Text + "',Address='" + address.Text + "',Commission=" + number.Text + ",SchedulingFee=" + schedulingfee.Text + " where AuctionId="+id;
                        SqlCommand cmd = new SqlCommand(query, con);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            txtAuctionName.Text = "";
                            auctiontime.Text = "";
                            auctiondate.Text = "";
                            number.Text = "";
                            //fileUploadLabel.Text = "";
                            address.Text = "";
                            schedulingfee.Text = "";
                            lblMessage.Text = "<span style=\"color: #54a75c\">Auction saved successfully</span>";
                        }
                        //}
                        //else { fileUploadLabel.Text = "Maximum resolution of a image has to be in 600X400 (Width X Height) "; }
                    }
                    catch (Exception ex)
                    {
                        //fileUploadLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                    //}
                    //else { fileUploadLabel.Text = "File size has to be less than 100kb"; }
                    //}
                //}

            }
        }

        [System.Web.Services.WebMethod]
        public static string SaveAuctionEdit(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();

            //string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //SqlConnection con = new SqlConnection(connectionString);
            //con.Open();
            ////string query = "insert into Auction(AuctionTypeId,AuctionName,AuctionDate,AuctionTime,Address,Commission,IsSchedule,UserType,UserId,ImagePath,SchedulingFee,ImageName)values('3','" + txtAuctionName.Text + "','" + auctiondate.Text + "','" + auctiontime.Text + "','" + address.Text + "','" + number.Text + "',0,'Admin'," + Convert.ToInt32(Session["AdminUserId"]) + "," + "'" + filePath + "'" + "," + "'" + schedulingfee.Text + "'" + "," + "'" + filename + "'" + ")";
            //string query = "update Auction set AuctionName='" + txtAuctionName.Text + "',AuctionDate=" + auctiondate.Text + ",AuctionTime='" + auctiontime.Text + "',Address='" + address.Text + "',Commission=" + number.Text + ",SchedulingFee=" + schedulingfee.Text + " where AuctionId=" + id;
            //SqlCommand cmd = new SqlCommand(query, con);
            //int i = cmd.ExecuteNonQuery();
            //if (i > 0)
            //{
            //    txtAuctionName.Text = "";
            //    auctiontime.Text = "";
            //    auctiondate.Text = "";
            //    number.Text = "";
            //    //fileUploadLabel.Text = "";
            //    address.Text = "";
            //    schedulingfee.Text = "";
            //    lblMessage.Text = "<span style=\"color: #54a75c\">Auction saved successfully</span>";
            //}
        }

    }
}