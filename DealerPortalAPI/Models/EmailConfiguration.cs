using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class EmailConfiguration
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string KeyType { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string CcEmail { get; set; }
        public string BccEmail { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public bool Active { get; set; }
    }
}
