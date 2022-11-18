using System;
using System.Collections.Generic;

namespace CarDekho.Models
{
    public partial class WebsiteHistory
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; } = null!;
        public DateTime? TransactionDateTime { get; set; }
        public string TransactionDesc { get; set; } = null!;
    }
}
