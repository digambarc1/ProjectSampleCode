using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class WishList
    {
        public int WishlistId { get; set; }
        public int WishListForBuyer { get; set; }
        public int? NewCarId { get; set; }
        public int? UsedCarId { get; set; }
        public int? BuyerId { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual NewCar? NewCar { get; set; }
        public virtual UsedCar? UsedCar { get; set; }
    }
}
