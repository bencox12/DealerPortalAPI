using System;
using System.Collections.Generic;

namespace DealerPortal.Models
{
    public partial class OrderModel
    {
        public int DealerUserId { get; set; }
        public string SysproDealerId { get; set; }
        public string UserName { get; set; }
        public int UserRoleId { get; set; }
        public string OrderFunction { get; set; }
        public string CustomerPo { get; set; }
        public string OrderStatus { get; set; }
        public string SalesOrder { get; set; }
        public string ReceiveDate { get; set; }
        public string ShipDate { get; set; }
        public string ProductionDate { get; set; }
        public string DeliveryDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string TrackingNumber { get; set; }
        public List<string> AllInStatuses { get; set; }
        public string Status { get; set; }
        public OrderSearch OrderSearch { get; set; }
        public string Message { get; set; }
        public string ApiUrl { get; set; }
    }

    public partial class OrderSearch
    {
        public string SalesOrder { get; set; }
        public string CustomerPo { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string ShipToName { get; set; }
        public List<SearchDetail> SearchDetails { get; set; }
    }

    public partial class SearchDetail
    {
        public string OrderNumber { get; set; }
        public string CustomerPo { get; set; }
        public Nullable<DateTime> ReceivedDate { get; set; }
        public Nullable<DateTime> ShippedDate { get; set; }
        public string Status { get; set; }
    }
}