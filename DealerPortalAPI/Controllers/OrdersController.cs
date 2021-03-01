using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DealerPortalAPI.Models;
using DealerPortal.Models;
using System.Data;

namespace DealerPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AllInNewContext _allin;
        private readonly SysproCompanyAContext _syspro;
        private readonly LabelsContext _piecerate;
        private readonly docimagingContext _docs;

        public OrdersController(AllInNewContext allin, LabelsContext piecerate, SysproCompanyAContext syspro, docimagingContext docs)
        {
            _allin = allin;
            _syspro = syspro;
            _piecerate = piecerate;
            _docs = docs;
        }

        // GET: api/Orders/id
        [HttpGet("{id}/{text}")]
        public async Task<ActionResult<OrderModel>> GetOrders(string id, string text)
        {
            OrderModel orderModel = new OrderModel();
            if (!text.Contains("~"))
            {
                orderModel = await OrderDetails(id, text);
            }
            else
            {
                orderModel.OrderSearch = await OrderList(id, text);
            }
            return orderModel;
        }

        private async Task<OrderModel> OrderDetails(string id, string text)
        {
            OrderModel orderModel = new OrderModel() { OrderStatus = "", Status = "", AllInStatuses = new List<string>() };
            SorMaster sorMaster = await _syspro.SorMaster.Where(x => x.Customer == id && x.CustomerPoNumber == text).Include("SorDetail").FirstOrDefaultAsync();
            OrderMaster orderMaster = await _allin.OrderMaster.Where(x => x.DealerCode == id && x.CustomerPo == text).FirstOrDefaultAsync();

            if (sorMaster == null)
            {
                if (orderMaster == null)
                {
                    orderModel.Message = "Order not found";
                }
                else
                {
                    orderModel.Status = "Received";
                    orderModel.OrderStatus = "In Order Entry";
                    orderModel.ReceiveDate = orderMaster.EntryDate.ToShortDateString();
                    orderModel.SalesOrder = "N/A";
                    orderModel.DeliveryDate = "N/A";
                    if (orderMaster.ShipDate.HasValue)
                    {
                        orderModel.DeliveryDate = orderMaster.ShipDate.Value.ToShortDateString();
                    }
                    List<OrderStatus> orderStatuses = await _allin.OrderStatus.Where(x => x.Ponum == orderMaster.Ponum && x.EndDate == null).ToListAsync();
                    foreach (var item in orderStatuses)
                    {
                        switch (item.Dept)
                        {
                            case "Order Correction":
                                orderModel.AllInStatuses.Add("Waiting for Order Corrections");
                                break;
                            case "Credit":
                                orderModel.AllInStatuses.Add("Waiting for Credit Evaluation");
                                break;
                            case "SQSPR Requests":
                                orderModel.AllInStatuses.Add("Waiting for SQ/SPR");
                                break;
                            case "GPO Requests":
                                orderModel.AllInStatuses.Add("Waiting for GPO");
                                break;
                        }
                    }
                }
            }
            else
            {
                if (orderMaster != null)
                {
                    orderModel.ReceiveDate = orderMaster.EntryDate.ToShortDateString();
                }
                else
                {
                    orderModel.ReceiveDate = sorMaster.EntrySystemDate.Value.ToShortDateString();
                }
                orderModel.ProductionDate = "N/A";
                orderModel.ShipDate = "N/A";
                orderModel.DeliveryDate = "N/A";
                orderModel.InvoiceNumber = "N/A";
                orderModel.TrackingNumber = "N/A";
                orderModel.SalesOrder = Convert.ToInt32(sorMaster.SalesOrder).ToString();
                if (sorMaster.ReqShipDate.Value.DayOfWeek != DayOfWeek.Saturday && sorMaster.ReqShipDate.Value.DayOfWeek != DayOfWeek.Sunday && sorMaster.OrderStatus != "F")
                {
                    orderModel.DeliveryDate = sorMaster.ReqShipDate.Value.ToShortDateString();
                }
                ArCustomer arCustomer = await _syspro.ArCustomer.Where(x => x.Customer == sorMaster.Customer).FirstOrDefaultAsync();
                WipMaster wipMaster = await _syspro.WipMaster.Where(x => x.SalesOrder == sorMaster.SalesOrder).OrderBy(y => y.JobStartDate).FirstOrDefaultAsync();
                if (wipMaster != null)
                {
                    ShipDetails shipDetails = await _piecerate.ShipDetails.Where(x => x.JobNumber == wipMaster.Job).FirstOrDefaultAsync();
                    if (shipDetails != null)
                    {
                        ShipMaster shipMaster = await _piecerate.ShipMaster.Where(x => x.DocumentId == shipDetails.DocumentId && x.Status == 2).FirstOrDefaultAsync();
                        if (shipMaster != null)
                        {
                            orderModel.ShipDate = shipMaster.DateStamp.Value.ToShortDateString();
                        }
                    }
                }
                ArInvoice arInvoice = await _syspro.ArInvoice.Where(x => x.SalesOrder == sorMaster.SalesOrder).FirstOrDefaultAsync();
                if (arInvoice != null)
                {
                    orderModel.InvoiceNumber = Convert.ToInt32(arInvoice.Invoice).ToString();
                    if (orderModel.ShipDate == "N/A")
                    {
                        orderModel.ShipDate = arInvoice.InvoiceDate.Value.ToShortDateString();
                    }
                }
                switch (sorMaster.OrderStatus)
                {
                    case "4":
                        orderModel.OrderStatus = "Ready to Ship";
                        orderModel.Status = "InWarehouse";
                        break;
                    case "8":
                    case "9":
                        orderModel.OrderStatus = "Shipped";
                        orderModel.Status = "Shipped";
                        orderModel.TrackingNumber = string.IsNullOrWhiteSpace(sorMaster.SpecialInstrs) ? "N/A" : sorMaster.SpecialInstrs;
                        if (orderModel.TrackingNumber != "N/A")
                        {
                            if (sorMaster.ShippingInstrs.Contains("UPS"))
                            {
                                orderModel.Carrier = "Ups";
                            }
                            if (sorMaster.ShippingInstrs.Contains("FED EX"))
                            {
                                orderModel.Carrier = "Fdx";
                            }
                        }
                        break;
                    case "S":
                        orderModel.OrderStatus = "In Credit Evaluation";
                        orderModel.Status = "InCredit";
                        break;
                    case "*":
                    case "\\":
                        orderModel.Message = "Order not found";
                        orderModel.Status = "Canceled";
                        break;
                    default:
                        orderModel.OrderStatus = "In Scheduling";
                        orderModel.Status = "InScheduling";
                        orderModel.ShipDate = "N/A";
                        LabPackDetailA labPackDetailA = await _piecerate.LabPackDetailA.Where(x => x.SalesOrder == sorMaster.SalesOrder).FirstOrDefaultAsync();
                        if (labPackDetailA != null)
                        {
                            orderModel.ProductionDate = labPackDetailA.LablPrintDate.HasValue ? labPackDetailA.LablPrintDate.Value.ToShortDateString() : "N/A";
                            orderModel.OrderStatus = "In Production";
                            orderModel.Status = "InProduction";
                        }
                        OperPacking operPacking = await _piecerate.OperPacking.Where(x => x.SalesOrder == sorMaster.SalesOrder).FirstOrDefaultAsync();
                        if (operPacking != null)
                        {
                            orderModel.OrderStatus = "Ready to Ship";
                            orderModel.Status = "InWarehouse";
                        }
                        break;
                }
                if (arCustomer.CustomerOnHold == "Y" && orderModel.Status == "InWarehouse")
                {
                    orderModel.AllInStatuses.Add("Holding Shipment");
                }
            }

            return orderModel;
        }

        private async Task<OrderSearch> OrderList(string id, string text)
        {
            string[] option = text.Split('~');
            OrderSearch orderSearch = new OrderSearch() { SearchDetails = new List<SearchDetail>() };
            OrderMaster orderMaster = null;
            List<OrderMaster> orderMasters = new List<OrderMaster>();
            List<SorMaster> sorMasters = new List<SorMaster>();
            if (!string.IsNullOrWhiteSpace(option[0]))
            {
                option[0] = option[0].PadLeft(15, '0');
                sorMasters = await _syspro.SorMaster.Where(x => x.Customer == id && x.SalesOrder == option[0]).ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(option[1]))
            {
                sorMasters = await _syspro.SorMaster.Where(x => x.Customer == id && x.CustomerPoNumber == option[1]).ToListAsync();
                orderMasters = await _allin.OrderMaster.Where(x => x.DealerCode == id && x.CustomerPo == option[1]).ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(option[2]))
            {
                sorMasters = await _syspro.SorMaster.Where(x => x.Customer == id && x.CustomerName == option[2]).ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(option[3]) && !string.IsNullOrWhiteSpace(option[4]))
            {
                DateTime fromDate = Convert.ToDateTime(option[3].Replace("-", "/"));
                DateTime toDate = Convert.ToDateTime(option[4].Replace("-", "/"));
                sorMasters = await _syspro.SorMaster.Where(x => x.Customer == id && x.OrderDate >= fromDate && x.OrderDate <= toDate).ToListAsync();
                orderMasters = await _allin.OrderMaster.Where(x => x.DealerCode == id && x.ReceiveDate >= fromDate && x.ReceiveDate <= toDate).ToListAsync();
            }
            Nullable<DateTime> shippedDate;
            WipMaster wipMaster;
            string status;
            string salesorder;
            string salesorders;
            string invoices;
            List<string> invoiceList;
            foreach (var item in sorMasters)
            {
                shippedDate = null;
                status = "N/A";
                wipMaster = await _syspro.WipMaster.Where(x => x.SalesOrder == item.SalesOrder).OrderBy(y => y.JobStartDate).FirstOrDefaultAsync();
                if (wipMaster != null)
                {
                    ShipDetails shipDetails = await _piecerate.ShipDetails.Where(x => x.JobNumber == wipMaster.Job).FirstOrDefaultAsync();
                    if (shipDetails != null)
                    {
                        ShipMaster shipMaster = await _piecerate.ShipMaster.Where(x => x.DocumentId == shipDetails.DocumentId && x.Status == 2).FirstOrDefaultAsync();
                        if (shipMaster != null)
                        {
                            shippedDate = shipMaster.DateStamp;
                        }
                    }
                }
                ArInvoice arInvoice = await _syspro.ArInvoice.Where(x => x.SalesOrder == item.SalesOrder).FirstOrDefaultAsync();
                if (arInvoice != null)
                {
                    if (shippedDate == null)
                    {
                        shippedDate = arInvoice.InvoiceDate;
                    }
                }
                switch (item.OrderStatus)
                {
                    case "4":
                        status = "READY TO SHIP";
                        break;
                    case "8":
                    case "9":
                        status = shippedDate == null ? "READY TO SHIP" : "SHIPPED";
                        break;
                    case "*":
                    case "\\":
                        status = "CANCELED";
                        shippedDate = null;
                        break;
                    default:
                        status = "IN SCHEDULING";
                        LabPackDetailA labPackDetailA = await _piecerate.LabPackDetailA.Where(x => x.SalesOrder == item.SalesOrder).FirstOrDefaultAsync();
                        if (labPackDetailA != null)
                        {
                            status = "IN PRODUCTION";
                        }
                        OperPacking operPacking = await _piecerate.OperPacking.Where(x => x.SalesOrder == item.SalesOrder).FirstOrDefaultAsync();
                        if (operPacking != null)
                        {
                            status = "READY TO SHIP";
                        }
                        shippedDate = null;
                        break;
                }
                orderMaster = orderMasters != null ? orderMasters.Where(x => x.CustomerPo == item.CustomerPoNumber).FirstOrDefault() : null;
                salesorder = Convert.ToInt32(item.SalesOrder).ToString();
                salesorders = _docs.PdfInfo.Where(x => x.KeyName == salesorder && x.Type == "SalesOrder").FirstOrDefault() != null ? "yes" : "";
                invoiceList = _syspro.ArInvoice.Where(x => x.SalesOrder == item.SalesOrder).Select(y => Convert.ToInt32(y.Invoice).ToString()).ToList();
                invoices = _docs.PdfInfo.Where(x => invoiceList.Contains(x.KeyName) && x.Type == "Invoice").ToList().Count > 0 ? "yes" : "";
                orderSearch.SearchDetails.Add(new SearchDetail()
                {
                    OrderNumber = salesorder,
                    CustomerPo = item.CustomerPoNumber,
                    ReceivedDate = orderMaster != null ? orderMaster.ReceiveDate : item.EntrySystemDate,
                    ShippedDate = shippedDate,
                    Status = status,
                    SalesOrders = salesorders,
                    Invoices = invoices
                });
            }
            foreach (var item in orderMasters)
            {
                if (orderSearch.SearchDetails.Where(x => x.CustomerPo == item.CustomerPo).FirstOrDefault() == null)
                {
                    orderSearch.SearchDetails.Add(new SearchDetail()
                    {
                        OrderNumber = "N/A",
                        CustomerPo = item.CustomerPo,
                        ReceivedDate = item.ReceiveDate,
                        ShippedDate = null,
                        Status = "IN ORDER ENTRY",
                        SalesOrders = "",
                        Invoices = ""
                    });
                }
            }
            orderSearch.SearchDetails = orderSearch.SearchDetails.OrderByDescending(x => x.ReceivedDate).ToList();
            return orderSearch;
        }
    }
}
