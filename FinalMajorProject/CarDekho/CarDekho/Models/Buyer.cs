using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            WishLists = new HashSet<WishList>();
        }

        public int BuyerId { get; set; }
        public string BuyerName { get; set; } = null!;
        public long BuyerMobile { get; set; }
        public string BuyerEmail { get; set; } = null!;
        public string BuyerPassword { get; set; } = null!;
        public string BuyerAddress { get; set; } = null!;
        public string BuyerCity { get; set; } = null!;

        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
