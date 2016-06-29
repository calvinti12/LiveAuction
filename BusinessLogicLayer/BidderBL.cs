using System.Data;
using DataAccessLayer;
using EntityLayer;
using System;

namespace BusinessLogicLayer
{
    public class BidderBL
    {

        public bool BidderSignUp(BidderEL objBidderEL, out string Responcetxt)
        {
            ProcedureExecute proc;
            bool Res = false; string strError = string.Empty;
            try
            {
                using (proc = new ProcedureExecute("prcBidder"))
                {
                    proc.AddVarcharPara("@Action", 100, "BidderSellerSignUp");
                    proc.AddVarcharPara("@Email", 200, objBidderEL.Email);
                    proc.AddVarcharPara("@Password", 200, objBidderEL.Password);
                    proc.AddVarcharPara("@UserType", 200, objBidderEL.UserType);
                    proc.AddNVarcharPara("@ReturnValue", 500, objBidderEL.ReturnValue, QueryParameterDirection.Output);

                    int i = proc.RunActionQuery();
                    if (i > 0)
                    {
                        Res = true;
                        objBidderEL.BidderId = Convert.ToInt32(proc.GetParaValue("@ReturnValue"));
                        strError = "Successfully Registered.";
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


        public DataTable GetLoginUser(string Email, string Password, string UserType)
        {
            ProcedureExecute proc = new ProcedureExecute("prcBidder");
            proc.AddVarcharPara("@Action", 100, "BidderSellerLogin");
            proc.AddVarcharPara("@Email", 200, Email);
            proc.AddVarcharPara("@Password", 200, Password);
            proc.AddVarcharPara("@UserType", 200, UserType);
            return proc.GetTable();
        }

        public DataTable EmailCheck(string Email, string UserType)
        {
            ProcedureExecute proc = new ProcedureExecute("prcBidder");
            proc.AddVarcharPara("@Action", 100, "EmailCheck");
            proc.AddVarcharPara("@Email", 200, Email);            
            proc.AddVarcharPara("@UserType", 200, UserType);
            return proc.GetTable();
        }

        public DataTable SellerAccountDetails(int SellerId)
        {
            ProcedureExecute proc = new ProcedureExecute("prcBidder");
            proc.AddVarcharPara("@Action", 100, "SellerAccountDetails");
            proc.AddIntegerPara("@SellerId", SellerId);            
            return proc.GetTable();
        }
        public DataTable GetCountries()
        {
            ProcedureExecute proc = new ProcedureExecute("prcBidder");
            proc.AddVarcharPara("@Action", 100, "GetCountries");            
            return proc.GetTable();
        }
        public DataTable GetTimeZonesFromCountry(int CountryId)
        {
            ProcedureExecute proc = new ProcedureExecute("prcBidder");
            proc.AddVarcharPara("@Action", 100, "GetTimeZonesFromCountry");
            proc.AddIntegerPara("@CountryId", CountryId); 
            return proc.GetTable();
        }

        public bool UpdateSellerAccount(BidderEL objBidderEL, out string Responcetxt)
        {
            ProcedureExecute proc;
            bool Res = false; string strError = string.Empty;
            try
            {
                using (proc = new ProcedureExecute("prcBidder"))
                {
                    proc.AddVarcharPara("@Action", 100, "UpdateSellerAccount");
                    proc.AddVarcharPara("@PreferredName", 200, objBidderEL.PreferredName);
                    proc.AddVarcharPara("@Telephone", 50, objBidderEL.Telephone);
                    proc.AddVarcharPara("@Country", 50, objBidderEL.Country);
                    proc.AddVarcharPara("@TimeZone", 50, objBidderEL.TimeZone);
                    proc.AddIntegerPara("@SellerId", objBidderEL.BidderId); 

                    proc.AddNVarcharPara("@ReturnValue", 500, objBidderEL.ReturnValue, QueryParameterDirection.Output);

                    int i = proc.RunActionQuery();
                    if (i > 0)
                    {
                        Res = true;
                        //objBidderEL.BidderId = Convert.ToInt32(proc.GetParaValue("@ReturnValue"));
                        strError = "Successfully Updated.";
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
