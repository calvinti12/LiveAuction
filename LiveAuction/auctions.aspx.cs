using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;
using System.Data;

namespace LiveAuction
{
    public partial class auctions : System.Web.UI.Page
    {
        public string AuctionId = string.Empty;
        public string AuctionType = string.Empty;
        public string AuctionName = string.Empty;
        public string AuctionDate = string.Empty;
        public string AuctionTime = string.Empty;
        public string AuctionAddress = string.Empty;
        AuctionBL objAuctionBL = new AuctionBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = objAuctionBL.GetAuctionWithType(3);
            if (dt != null && dt.Rows.Count > 0)
            {
                AuctionId = Convert.ToString(dt.Rows[0]["AuctionId"]);
                AuctionType = Convert.ToString(dt.Rows[0]["AuctionType"]);
                AuctionName = Convert.ToString(dt.Rows[0]["AuctionName"]);
                AuctionDate = Convert.ToString(dt.Rows[0]["AuctionDate"]);
                AuctionTime = Convert.ToString(dt.Rows[0]["AuctionTime"]);
                AuctionAddress = Convert.ToString(dt.Rows[0]["Address"]);
            }

        }
    }
}