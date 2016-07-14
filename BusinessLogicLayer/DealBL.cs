using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class DealBL
    {
        public DataTable GetProductCategoryLevel1()
        {
            ProcedureExecute proc = new ProcedureExecute("prcDeal");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel1");            
            return proc.GetTable();
        }
        public DataTable GetProductCategoryLevel2(int parentCategoryIdLevel1)
        {
            ProcedureExecute proc = new ProcedureExecute("prcDeal");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel2");
            proc.AddIntegerPara("@ParentCategoryIdLevel1", parentCategoryIdLevel1);
            return proc.GetTable();
        }
        public DataTable GetProductCategoryLevel3(int parentCategoryIdLevel2)
        {
            ProcedureExecute proc = new ProcedureExecute("prcDeal");
            proc.AddVarcharPara("@Action", 100, "GetCategoryLevel3");
            proc.AddIntegerPara("@ParentCategoryIdLevel2", parentCategoryIdLevel2);
            return proc.GetTable();
        }
        public DataTable GetAuction(string userType,int userId)
        {
            ProcedureExecute proc = new ProcedureExecute("prcDeal");
            proc.AddVarcharPara("@Action", 100, "GetAuction");
            proc.AddVarcharPara("@UserType", 10, userType);
            proc.AddIntegerPara("@UserId", userId);
            return proc.GetTable();
        }
        public bool Save(DealEL DealEL, out string Responcetxt)
        {
            ProcedureExecute proc;
            bool Res = false; string strError = string.Empty;
            try
            {
                using (proc = new ProcedureExecute("prcDeal"))
                {
                    proc.AddVarcharPara("@Action", 100, "Save");
                    proc.AddVarcharPara("@ProductUsed", 200, DealEL.ProductUsed);
                    proc.AddIntegerPara("@CategoryId", DealEL.CategoryId);
                    proc.AddBooleanPara("@IsBranded", DealEL.IsBranded);
                    proc.AddVarcharPara("@Title", 200, DealEL.Title);
                    proc.AddVarcharPara("@SKU", 200, DealEL.SKU);
                    proc.AddVarcharPara("@Description", 200, DealEL.Description);
                    proc.AddVarcharPara("@Question", 200, DealEL.Question);
                    proc.AddVarcharPara("@OriginalPrice", 200, DealEL.OriginalPrice);
                    proc.AddVarcharPara("@DealPrice", 200, DealEL.DealPrice);
                    proc.AddDateTimePara("@DealDate", DealEL.DealDate);
                    proc.AddVarcharPara("@DealTime", 200, DealEL.DealTime);
                    proc.AddVarcharPara("@StartingBid", 200, DealEL.StartingBid);
                    proc.AddVarcharPara("@ShipWithin", 200, DealEL.ShipWithin);
                    proc.AddVarcharPara("@DeliveryTime", 200, DealEL.DeliveryTime);
                    proc.AddVarcharPara("@ShipCountry", 200, DealEL.ShipCountry);
                    proc.AddVarcharPara("@ShippingPrice", 200, DealEL.ShippingPrice);
                    proc.AddBooleanPara("@IsFreeShipping", DealEL.IsFreeShipping);
                    proc.AddBooleanPara("@IsShippedEverywhere", DealEL.IsShippedEverywhere);
                    proc.AddVarcharPara("@Images", 800, DealEL.images);
                    proc.AddNVarcharPara("@ReturnValue", 500, DealEL.ReturnValue, QueryParameterDirection.Output);

                    int i = proc.RunActionQuery();
                    if (i > 0)
                    {
                        Res = true;
                        DealEL.DealId = Convert.ToInt32(proc.GetParaValue("@ReturnValue"));
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
