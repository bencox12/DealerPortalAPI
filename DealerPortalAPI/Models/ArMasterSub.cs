using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class ArMasterSub
    {
        public string Customer { get; set; }
        public string CustomerSub { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ArCustomer CustomerNavigation { get; set; }
    }
}
