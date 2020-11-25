using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class Resource
    {
        public int ResourceId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }
        public byte[] Image { get; set; }
    }
}
