using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class NewCar
    {
        public NewCar()
        {
            WishLists = new HashSet<WishList>();
        }

        public int NewCarId { get; set; }
        public string NcarName { get; set; } = null!;
        public decimal NcarCost { get; set; }
        public DateTime CarManufacturedate { get; set; }
        public string? NcarTransmission { get; set; }
        public string? NcarInsuranceType { get; set; }
        public double NcarMileage { get; set; }
        public bool NcarStatus { get; set; }
        public string CarType { get; set; } = null!;
        public string? BookingStatus { get; set; }
        public int? ProviderId { get; set; }

        public virtual Provider? Provider { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
