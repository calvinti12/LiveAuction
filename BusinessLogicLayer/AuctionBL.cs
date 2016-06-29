using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AuctionBL
    {
        public DataTable GetAuctionWithType(int AuctionTypeId)
        {
            ProcedureExecute proc = new ProcedureExecute("prcAuction");
            proc.AddVarcharPara("@Action", 100, "GetAuctionWithType");
            proc.AddIntegerPara("@AuctionTypeId", AuctionTypeId);            
            return proc.GetTable();
        }
        public DataSet GetLotListByAuctionID(int AuctionId)
        {
            ProcedureExecute proc = new ProcedureExecute("prcAuction");
            proc.AddVarcharPara("@Action", 100, "GetLotListByAuctionID");
            proc.AddIntegerPara("@AuctionId", AuctionId);
            return proc.GetDataSet();
        }
    }
}
