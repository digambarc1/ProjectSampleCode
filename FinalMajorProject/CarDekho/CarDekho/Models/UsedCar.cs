using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class UsedCar
    {
        public UsedCar()
        {
            WishLists = new HashSet<WishList>();
        }

        public int UsedCarId { get; set; }
        public string UcarName { get; set; } = null!;
        public DateTime CarPurchaseDate { get; set; }
        public decimal UcarCost { get; set; }
        public string? UcarTransmission { get; set; }
        public string UcarInsuranceType { get; set; } = null!;
        public double UcarMileage { get; set; }
        public int UcarNoOfPrevOwner { get; set; }
        public string UcarRto { get; set; } = null!;
        public int UcarDriven { get; set; }
        public bool UcarStatus { get; set; }
        public string CarType { get; set; } = null!;
        public string? BookingStatus { get; set; }
        public int? SellerId { get; set; }

        public virtual Seller? Seller { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
