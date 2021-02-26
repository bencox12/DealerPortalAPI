using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class EmailRoutes
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Email { get; set; }
        public bool Acknowledgements { get; set; }
        public bool Invoices { get; set; }
        public bool Notifications { get; set; }
        public bool Statements { get; set; }
    }
}
