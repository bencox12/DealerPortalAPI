using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class EmailLog
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Filename { get; set; }
        public int RouteId { get; set; }
        public string Email { get; set; }
        public string SentBy { get; set; }
        public DateTime DateSent { get; set; }
    }
}
