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
            ProcedureExecute proc = new ProcedureExecute("prcProductLot");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel1");            
            return proc.GetTable();
        }
        public DataTable GetProductCategoryLevel2(int parentCategoryIdLevel1)
        {
            ProcedureExecute proc = new ProcedureExecute("prcProductLot");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel2");
            proc.AddIntegerPara("@ParentCategoryIdLevel1", parentCategoryIdLevel1);
            return proc.GetTable();
        }
        public DataTable GetProductCategoryLevel3(int parentCategoryIdLevel2)
        {
            ProcedureExecute proc = new ProcedureExecute("prcProductLot");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel3");
            proc.AddIntegerPara("@ParentCategoryIdLevel2", parentCategoryIdLevel2);
            return proc.GetTable();
        }
        public DataTable GetAuction(string userType,int userId)
        {
            ProcedureExecute proc = new ProcedureExecute("prcProductLot");
            proc.AddVarcharPara("@Action", 100, "GetAuction");
            proc.AddVarcharPara("@UserType", 10, userType);
            proc.AddIntegerPara("@UserId", userId);
            return proc.GetTable();
        }
        public bool Save(ProductLotEL productLotEL, out string Responcetxt)
        {
            ProcedureExecute proc;
            bool Res = false; string strError = string.Empty;
            try
            {
                using (proc = new ProcedureExecute("prcProductLot"))
                {
                    proc.AddVarcharPara("@Action", 100, "Save");
                    proc.AddVarcharPara("@ProductUsed", 200, productLotEL.ProductUsed);
                    proc.AddIntegerPara("@CategoryId", productLotEL.CategoryId);
                    proc.AddIntegerPara("@AuctionId", productLotEL.AuctionId);
                    proc.AddBooleanPara("@IsBranded", productLotEL.IsBranded);
                    proc.AddVarcharPara("@Title", 200, productLotEL.Title);
                    proc.AddVarcharPara("@SKU", 200, productLotEL.SKU);
                    proc.AddVarcharPara("@Description", 200, productLotEL.Description);
                    proc.AddVarcharPara("@Question", 200, productLotEL.Question);
                    proc.AddIntegerPara("@Quantity", productLotEL.Quantity);
                    proc.AddVarcharPara("@CostBasis", 200, productLotEL.CostBasis);
                    proc.AddVarcharPara("@RetailPrice", 200, productLotEL.RetailPrice);
                    proc.AddVarcharPara("@BuyPrice", 200, productLotEL.BuyPrice);
                    proc.AddVarcharPara("@StartingBid", 200, productLotEL.StartingBid);
                    proc.AddVarcharPara("@ShipWithin", 200, productLotEL.ShipWithin);
                    proc.AddVarcharPara("@DeliveryTime", 200, productLotEL.DeliveryTime);
                    proc.AddVarcharPara("@ShipCountry", 200, productLotEL.ShipCountry);
                    proc.AddVarcharPara("@ShippingPrice", 200, productLotEL.ShippingPrice);
                    proc.AddBooleanPara("@IsFreeShipping", productLotEL.IsFreeShipping);
                    proc.AddBooleanPara("@IsShippedEverywhere", productLotEL.IsShippedEverywhere);
                    proc.AddBooleanPara("@IsScheduled", productLotEL.IsScheduled);
                    proc.AddVarcharPara("@Images", 800, productLotEL.images);
                    proc.AddNVarcharPara("@ReturnValue", 500, productLotEL.ReturnValue, QueryParameterDirection.Output);
                    proc.AddVarcharPara("@LowEstimatePrice", 200, productLotEL.LowEstimatePrice);
                    proc.AddVarcharPara("@HighEstimatePrice", 200, productLotEL.HighEstimatePrice);
                    proc.AddVarcharPara("@LiveAuctionPassed", 200, productLotEL.LiveAuctionPassed);
                    proc.AddBooleanPara("@FairWarning", productLotEL.FairWarning);
                    proc.AddBooleanPara("@IsSold", productLotEL.IsSold);
                    int i = proc.RunActionQuery();
                    if (i > 0)
                    {
                        Res = true;
                        productLotEL.ProductLotId = Convert.ToInt32(proc.GetParaValue("@ReturnValue"));
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
