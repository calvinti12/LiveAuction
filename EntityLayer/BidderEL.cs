using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class BidderEL
    {
        public int BidderId { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityQuestionAnswer { get; set; }
        public int IsActive { get; set; }
        public string CustContactNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string TimeZone { get; set; }
        public string OTP { get; set; }
        public string ReturnValue { get; set; }

        public string CardType { get; set; }
        public string CardNo { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
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
        public int UpdatedBy { get; set; }
        public string IpAddress { get; set; }
    }
}
