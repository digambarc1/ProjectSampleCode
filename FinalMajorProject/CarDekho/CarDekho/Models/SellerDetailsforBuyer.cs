using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class SellerDetailsforBuyer
    {
        public int? UserCarId { get; set; }
        public int? ProviderId { get; set; }
        public int? BuyerId { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual Provider? Provider { get; set; }
        public virtual UsedCar? UserCar { get; set; }
    }
}
