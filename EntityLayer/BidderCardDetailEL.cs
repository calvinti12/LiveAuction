using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class BidderCardDetailEL
    {
        public int BidderId { get; set; }
        public string CardType { get; set; }
        public string CardNo { get; set; }
        public DateTime CardExpiry { get; set; }
        public string SecurityCode { get; set; }
        public string CardNickName { get; set; }
        public string CardHolderName { get; set; }
        public string CardBillingAddress1 { get; set; }
        public string CardBillingAddress2 { get; set; }
        public string CardBillingCity { get; set; }
        public string CardBillingCountry { get; set; }
        public string CardBillingState { get; set; }
        public string CardBillingZipCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string IpAddress { get; set; }
    }
}
