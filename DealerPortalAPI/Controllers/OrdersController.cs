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
        private readonly IConfiguration _configuration;

        public OrdersController(AllInNewContext allin, LabelsContext piecerate, SysproCompanyAContext syspro, IConfiguration configuration)
        {
            _allin = allin;
            _syspro = syspro;
            _piecerate = piecerate;
            _configuration = configuration;
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
                                orderModel.AllInStatuses.Add("Waiting for Order Corrections - " + item.StartDate.Value.ToShortDateString());
                                break;
                            case "Credit":
                                orderModel.AllInStatuses.Add("In Credit Review - " + item.StartDate.Value.ToShortDateString());
                                break;
                            case "SQSPR Requests":
                                orderModel.AllInStatuses.Add("Waiting for SQ/SPR - " + item.StartDate.Value.ToShortDateString());
                                break;
                            case "GPO Requests":
                                orderModel.AllInStatuses.Add("Waiting for GPO - " + item.StartDate.Value.ToShortDateString());
                                break;
                            case "Sales Support":
                                orderModel.AllInStatuses.Add("Waiting for Sales Support - " + item.StartDate.Value.ToShortDateString());
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
                WipMaster wipMaster = await _syspro.WipMaster.Where(x => x.SalesOrder == sorMaster.SalesOrder).OrderBy(y => y.JobStartDate).FirstOrDefaultAsync();
                if (wipMaster != null)
                {
                    orderModel.ProductionDate = wipMaster.JobStartDate.Value.ToShortDateString();
                    ShipDetails shipDetails = await _piecerate.ShipDetails.Where(x => x.JobNumber == wipMaster.Job).FirstOrDefaultAsync();
                    if (shipDetails != null)
                    {
                        ShipMaster shipMaster = await _piecerate.ShipMaster.Where(x => x.DocumentId == shipDetails.DocumentId && x.Status == 2).FirstOrDefaultAsync();
                        if (shipMaster != null)
                        {
                            orderModel.ShipDate = shipMaster.DateStamp.Value.ToShortDateString();
                        }
                    }
                    else
                    {
                        if (DateTime.Now > wipMaster.JobDeliveryDate.Value)
                            orderModel.ShipDate = wipMaster.JobDeliveryDate.Value.ToShortDateString();
                    }
                    ArInvoice arInvoice = await _syspro.ArInvoice.Where(x => x.SalesOrder == sorMaster.SalesOrder).FirstOrDefaultAsync();
                    if (arInvoice != null)
                    {
                        orderModel.InvoiceNumber = Convert.ToInt32(arInvoice.Invoice).ToString();
                    }
                }
                orderModel.ReceiveDate = sorMaster.OrderDate.Value.ToShortDateString();
                orderModel.SalesOrder = Convert.ToInt32(sorMaster.SalesOrder).ToString();
                if (sorMaster.ReqShipDate.Value.DayOfWeek != DayOfWeek.Saturday && sorMaster.ReqShipDate.Value.DayOfWeek != DayOfWeek.Sunday)
                {
                    orderModel.DeliveryDate = sorMaster.ReqShipDate.Value.ToShortDateString();
                }
                else
                {
                    orderModel.OrderStatus = "Being Scheduled";
                    orderModel.Status = "InScheduling";
                }
                switch (sorMaster.OrderStatus)
                {
                    case "4":
                        orderModel.OrderStatus = "Waiting to be Shipped";
                        orderModel.Status = "InProduction";
                        break;
                    case "9":
                        orderModel.OrderStatus = "Shipped";
                        orderModel.Status = "Shipped";
                        orderModel.TrackingNumber = sorMaster.SpecialInstrs;
                        break;
                    case "*":
                    case "\\":
                        orderModel.ShipDate = "N/A";
                        break;
                    default:
                        orderModel.ShipDate = "N/A";
                        if (orderModel.OrderStatus == "")
                        {
                            orderModel.OrderStatus = "In Production";
                            orderModel.Status = "InProduction";
                        }
                        break;
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
                orderMasters = await _allin.OrderMaster.Where(x => x.DealerCode == id && x.EntryDate >= fromDate && x.EntryDate <= toDate).ToListAsync();
            }
            Nullable<DateTime> shippedDate;
            WipMaster wipMaster;
            string status;
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
                    else
                    {
                        if (DateTime.Now > wipMaster.JobDeliveryDate.Value)
                            shippedDate = wipMaster.JobDeliveryDate.Value;
                    }
                }
                switch (item.OrderStatus)
                {
                    case "9":
                        status = shippedDate == null ? "READY TO SHIP" : "SHIPPED";
                        break;
                    case "*":
                    case "\\":
                        status = "CANCELED";
                        shippedDate = null;
                        break;
                    default:
                        status = "IN PRODUCTION";
                        shippedDate = null;
                        break;
                }
                orderMaster = orderMasters != null ? orderMasters.Where(x => x.CustomerPo == item.CustomerPoNumber).FirstOrDefault() : null;
                orderSearch.SearchDetails.Add(new SearchDetail()
                {
                    OrderNumber = Convert.ToInt32(item.SalesOrder).ToString(),
                    CustomerPo = item.CustomerPoNumber,
                    ReceivedDate = orderMaster != null ? orderMaster.EntryDate : item.EntrySystemDate,
                    ShippedDate = shippedDate,
                    Status = status
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
                        ReceivedDate = orderMaster.EntryDate,
                        ShippedDate = null,
                        Status = "IN ORDER ENTRY"
                    });
                }
            }
            orderSearch.SearchDetails = orderSearch.SearchDetails.OrderByDescending(x => x.ReceivedDate).ToList();
            return orderSearch;
        }
    }
}
