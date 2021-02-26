using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class PdfInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string KeyName { get; set; }
        public byte[] FileData { get; set; }
        public DateTime? DateStamp { get; set; }
        public bool? Emailed { get; set; }
        public DateTime? DateEmailed { get; set; }
    }
}
