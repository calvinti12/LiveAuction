using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class TimedProductLotBL
    {
        public DataTable GetProductCategoryLevel1()
        {
            ProcedureExecute proc = new ProcedureExecute("prcTimedProductLot");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel1");            
            return proc.GetTable();
        }
        public DataTable GetProductCategoryLevel2(int parentCategoryIdLevel1)
        {
            ProcedureExecute proc = new ProcedureExecute("prcTimedProductLot");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel2");
            proc.AddIntegerPara("@ParentCategoryIdLevel1", parentCategoryIdLevel1);
            return proc.GetTable();
        }
        public DataTable GetProductCategoryLevel3(int parentCategoryIdLevel2)
        {
            ProcedureExecute proc = new ProcedureExecute("prcTimedProductLot");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel3");
            proc.AddIntegerPara("@ParentCategoryIdLevel2", parentCategoryIdLevel2);
            return proc.GetTable();
        }
        public DataTable GetAuction(string userType,int userId)
        {
            ProcedureExecute proc = new ProcedureExecute("prcTimedProductLot");
            proc.AddVarcharPara("@Action", 100, "GetAuction");
            proc.AddVarcharPara("@UserType", 10, userType);
            proc.AddIntegerPara("@UserId", userId);
            return proc.GetTable();
        }
        public bool Save(TimedProductLotEL TimedProductLotEL, out string Responcetxt)
        {
            ProcedureExecute proc;
            bool Res = false; string strError = string.Empty;
            try
            {
                using (proc = new ProcedureExecute("prcTimedProductLot"))
                {
                    proc.AddVarcharPara("@Action", 100, "Save");
                    proc.AddVarcharPara("@ProductUsed", 200, TimedProductLotEL.ProductUsed);
                    proc.AddIntegerPara("@CategoryId", TimedProductLotEL.CategoryId);
                    proc.AddIntegerPara("@AuctionId", TimedProductLotEL.AuctionId);
                    proc.AddBooleanPara("@IsBranded", TimedProductLotEL.IsBranded);
                    proc.AddVarcharPara("@Title", 200, TimedProductLotEL.Title);
                    proc.AddVarcharPara("@SKU", 200, TimedProductLotEL.SKU);
                    proc.AddVarcharPara("@Description", 200, TimedProductLotEL.Description);
                    proc.AddVarcharPara("@Question", 200, TimedProductLotEL.Question);
                    proc.AddIntegerPara("@Quantity", TimedProductLotEL.Quantity);
                    proc.AddVarcharPara("@CostBasis", 200, TimedProductLotEL.CostBasis);
                    proc.AddVarcharPara("@RetailPrice", 200, TimedProductLotEL.RetailPrice);
                    proc.AddVarcharPara("@BuyPrice", 200, TimedProductLotEL.BuyPrice);
                    proc.AddVarcharPara("@StartingBid", 200, TimedProductLotEL.StartingBid);
                    proc.AddVarcharPara("@ShipWithin", 200, TimedProductLotEL.ShipWithin);
                    proc.AddVarcharPara("@DeliveryTime", 200, TimedProductLotEL.DeliveryTime);
                    proc.AddVarcharPara("@ShipCountry", 200, TimedProductLotEL.ShipCountry);
                    proc.AddVarcharPara("@ShippingPrice", 200, TimedProductLotEL.ShippingPrice);
                    proc.AddBooleanPara("@IsFreeShipping", TimedProductLotEL.IsFreeShipping);
                    proc.AddBooleanPara("@IsShippedEverywhere", TimedProductLotEL.IsShippedEverywhere);
                    proc.AddVarcharPara("@Images", 800, TimedProductLotEL.images);
                    proc.AddNVarcharPara("@ReturnValue", 500, TimedProductLotEL.ReturnValue, QueryParameterDirection.Output);
                    proc.AddVarcharPara("@LowEstimatePrice", 200, TimedProductLotEL.LowEstimatePrice);
                    proc.AddVarcharPara("@HighEstimatePrice", 200, TimedProductLotEL.HighEstimatePrice);
                    proc.AddVarcharPara("@MaximumReserveValue", 200, TimedProductLotEL.MaximumReserveValue);
                    proc.AddBooleanPara("@IsSold", TimedProductLotEL.IsSold);
                    proc.AddIntegerPara("@BidderId", TimedProductLotEL.BidderId);
                    int i = proc.RunActionQuery();
                    if (i > 0)
                    {
                        Res = true;
                        TimedProductLotEL.ProductLotId = Convert.ToInt32(proc.GetParaValue("@ReturnValue"));
                        strError = "Item added successfully.";
                    }
                    else
                        strError = Convert.ToString(proc.GetParaValue("@ReturnValue"));

                    Responcetxt = strError;
                    return Res;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                proc = null;
            }
        }
    }
}
