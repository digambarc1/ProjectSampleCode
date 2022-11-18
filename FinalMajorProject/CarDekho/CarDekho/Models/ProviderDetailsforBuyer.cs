using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class ProviderDetailsforBuyer
    {
        public int? NewCarId { get; set; }
        public int? ProviderId { get; set; }
        public int? BuyerId { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual NewCar? NewCar { get; set; }
        public virtual Provider? Provider { get; set; }
    }
}
