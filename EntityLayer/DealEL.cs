using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DealEL
    {
        public int DealId { get; set; }
        public string ProductUsed { get; set; }
        public int CategoryId { get; set; }
        public bool IsBranded { get; set; }
        public string Title { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Question { get; set; }
        public string OriginalPrice { get; set; }
        public string DealPrice { get; set; }
        public DateTime DealDate { get; set; }
        public string DealTime { get; set; }    
        public string StartingBid { get; set; }
        public string ShipWithin { get; set; }
        public string DeliveryTime { get; set; }
        public string ShipCountry { get; set; }
        public bool IsFreeShipping { get; set; }
        public string ShippingPrice { get; set; }
        public bool IsShippedEverywhere { get; set; }
        public string images { get; set; }
        public string ReturnValue { get; set; }
    }
}
