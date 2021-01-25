using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class OrderStatus
    {
        public int Id { get; set; }
        public int Ponum { get; set; }
        public int Postatus { get; set; }
        public string Dept { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
