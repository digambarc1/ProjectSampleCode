using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class Seller
    {
        public Seller()
        {
            UsedCars = new HashSet<UsedCar>();
        }

        public int SellerId { get; set; }
        public string SellerName { get; set; } = null!;
        public long SellerMobile { get; set; }
        public string SellerEmail { get; set; } = null!;
        public string SellerPassword { get; set; } = null!;
        public string SellerAddress { get; set; } = null!;
        public string SellerCity { get; set; } = null!;

        public virtual ICollection<UsedCar> UsedCars { get; set; }
    }
}
