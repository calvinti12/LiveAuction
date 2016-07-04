using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LiveAuction.Admin
{
    public partial class Auction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                string filePath;
                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentLength < 102400)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            filePath = Server.MapPath(@"~\Admin\FileUpload\") + filename;
                            System.Drawing.Image imgFile = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                            //if (imgFile.PhysicalDimension.Width > 600 || imgFile.PhysicalDimension.Height > 400)
                            //{


                                //filePath = Server.MapPath(@"~/Admin/FileUpload/") + filename;<img src='./Admin/FileUpload/superbox-full-15.jpg' width='200px'/>
                                //filePath = "./Admin/FileUpload/" + filename;
                                //Path.GetFullPath(filePath).Replace(@"/", @"//");
                                FileUpload1.SaveAs(filePath);
                                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                                SqlConnection con = new SqlConnection(connectionString);
                                con.Open();
                                string query = "insert into Auction(AuctionTypeId,AuctionName,AuctionDate,AuctionTime,Address,Commission,IsSchedule,UserType,UserId,ImagePath,SchedulingFee,ImageName)values('3','" + txtAuctionName.Text + "','" + auctiondate.Text + "','" + auctiontime.Text + "','" + address.Text + "','" + number.Text + "',0,'Admin'," + Convert.ToInt32(Session["AdminUserId"]) + "," + "'" + filePath + "'" + "," + "'" + schedulingfee.Text + "'" + "," + "'" + filename + "'" + ")";
                                SqlCommand cmd = new SqlCommand(query, con);
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    txtAuctionName.Text = "";
                                    auctiontime.Text = "";
                                    auctiondate.Text = "";
                                    number.Text = "";
                                    fileUploadLabel.Text = "";
                                    address.Text = "";
                                    schedulingfee.Text = "";
                                    lblMessage.Text = "<span style=\"color: #54a75c\">Auction saved successfully</span>";
                                }
                            //}
                            //else { fileUploadLabel.Text = "Maximum resolution of a image has to be in 600X400 (Width X Height) "; }
                        }
                        catch (Exception ex)
                        {
                            fileUploadLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                        }
                    }
                    else { fileUploadLabel.Text = "File size has to be less than 100kb"; }
                }


            }
        }
    }
}