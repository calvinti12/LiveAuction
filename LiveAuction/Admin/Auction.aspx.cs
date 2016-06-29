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
                    try
                    {
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        filePath = Server.MapPath(@"~\Admin\FileUpload\") + filename;
                        Path.GetFullPath(filePath).Replace(@"\", @"\\");
                        FileUpload1.SaveAs(filePath);
                        string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                        SqlConnection con = new SqlConnection(connectionString);
                        con.Open();
                        string query = "insert into Auction(AuctionTypeId,AuctionName,AuctionDate,AuctionTime,Commission,IsSchedule,UserType,UserId,ImagePath)values('3','" + txtAuctionName.Text + "','" + auctiondate.Text + "','" + auctiontime.Text + "','" + number.Text + "',0,'Admin'," + Convert.ToInt32(Session["AdminUserId"]) +","+"'"+ filePath+"'"+")";
                        SqlCommand cmd = new SqlCommand(query, con);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            txtAuctionName.Text = "";
                            auctiontime.Text = "";
                            auctiondate.Text = "";
                            number.Text = "";
                            lblMessage.Text = "Auction saved successfully";
                        }
                    }
                    catch (Exception ex)
                    {
                        // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }


            }
        }
    }
}