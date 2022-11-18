using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class Provider
    {
        public Provider()
        {
            NewCars = new HashSet<NewCar>();
        }

        public int ProviderId { get; set; }
        public string ProviderName { get; set; } = null!;
        public long ProviderContact { get; set; }
        public string ProviderEmail { get; set; } = null!;
        public string ProviderPassword { get; set; } = null!;
        public string ProviderAddress { get; set; } = null!;
        public string ProviderCity { get; set; } = null!;
        public bool ProviderRegStatus { get; set; }

        public virtual ICollection<NewCar> NewCars { get; set; }
    }
}
