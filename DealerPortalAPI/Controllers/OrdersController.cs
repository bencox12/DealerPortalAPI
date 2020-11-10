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
            OrderModel orderModel = new OrderModel();
            SorMaster sorMaster = await _syspro.SorMaster.Where(x => x.Customer == id && x.CustomerPoNumber == text).Include("SorDetail").FirstOrDefaultAsync();

            if (sorMaster == null)
            {
                OrderMaster orderMaster = await _allin.OrderMaster.Where(x => x.DealerCode == id && x.CustomerPo == text).FirstOrDefaultAsync();
                if (orderMaster == null)
                {
                    orderModel.Message = "Order not found";
                }
                else
                {
                    orderModel.Status = "Received";
                    orderModel.ReceiveDate = orderMaster.EntryDate.ToShortDateString();
                    orderModel.SalesOrder = "N/A";
                    orderModel.DeliveryDate = "N/A";
                    if (orderMaster.ShipDate.HasValue)
                    {
                        orderModel.DeliveryDate = orderMaster.ShipDate.Value.ToShortDateString();
                    }
                    switch (orderMaster.Status)
                    {
                        case 5:
                            orderModel.OrderStatus = "Waiting for Order Corrections";
                            break;
                        case 11:
                        case 13:
                            orderModel.OrderStatus = "In Credit Review";
                            break;
                        case 18:
                            orderModel.OrderStatus = "Waiting for SQ/SPR";
                            break;
                        case 22:
                            orderModel.OrderStatus = "Waiting for GPO";
                            break;
                        case 28:
                            orderModel.OrderStatus = "Waiting for Sales Support";
                            break;
                        default:
                            orderModel.OrderStatus = "In Order Entry";
                            break;
                    }
                }
            }
            else
            {
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
                switch (sorMaster.OrderStatus)
                {
                    case "4":
                        orderModel.OrderStatus = "Waiting to be Shipped";
                        orderModel.Status = "InProduction";
                        break;
                    case "9":
                        orderModel.OrderStatus = "Shipped";
                        orderModel.Status = "Shipped";
                        break;
                    case "*":
                    case "\\":
                        break;
                    default:
                        if (orderModel.ShipDate == "N/A")
                        {
                            orderModel.OrderStatus = "In Production";
                            orderModel.Status = "InProduction";
                        }
                        else
                        {
                            orderModel.OrderStatus = "Shipped";
                            orderModel.Status = "Shipped";
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
            List<SorMaster> sorMaster = new List<SorMaster>();
            if (!string.IsNullOrWhiteSpace(option[0]))
            {
                option[0] = option[0].PadLeft(15, '0');
                sorMaster = await _syspro.SorMaster.Where(x => x.Customer == id && x.SalesOrder == option[0]).ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(option[1]))
            {
                sorMaster = await _syspro.SorMaster.Where(x => x.Customer == id && x.CustomerPoNumber == option[1]).ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(option[2]))
            {
                sorMaster = await _syspro.SorMaster.Where(x => x.Customer == id && x.CustomerName == option[2]).ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(option[3]) && !string.IsNullOrWhiteSpace(option[4]))
            {
                DateTime fromDate = Convert.ToDateTime(option[3].Replace("-", "/"));
                DateTime toDate = Convert.ToDateTime(option[4].Replace("-", "/"));
                sorMaster = await _syspro.SorMaster.Where(x => x.Customer == id && x.OrderDate >= fromDate && x.OrderDate <= toDate).ToListAsync();
            }
            string shippedDate;
            string jobNumber;
            string status;
            foreach (var item in sorMaster)
            {
                shippedDate = "N/A";
                status = "N/A";
                switch (item.OrderStatus)
                {
                    case "9":
                        status = "SHIPPED";
                        break;
                    case "*":
                    case "\\":
                        status = "CANCELED";
                        break;
                    default:
                        status = "IN PRODUCTION";
                        break;
                }
                jobNumber = await _syspro.WipMaster.Where(x => x.SalesOrder == item.SalesOrder).Select(y => y.Job).FirstOrDefaultAsync();
                if (!string.IsNullOrWhiteSpace(jobNumber))
                {
                    ShipDetails shipDetails = await _piecerate.ShipDetails.Where(x => x.JobNumber == jobNumber).FirstOrDefaultAsync();
                    if (shipDetails != null)
                    {
                        ShipMaster shipMaster = await _piecerate.ShipMaster.Where(x => x.DocumentId == shipDetails.DocumentId && x.Status == 2).FirstOrDefaultAsync();
                        if (shipMaster != null)
                        {
                            shippedDate = shipMaster.DateStamp.Value.ToShortDateString();
                        }
                    }
                }
                orderSearch.SearchDetails.Add(new SearchDetail()
                {
                    OrderNumber = Convert.ToInt32(item.SalesOrder).ToString(),
                    CustomerPo = item.CustomerPoNumber,
                    ReceivedDate = item.OrderDate.HasValue ? item.OrderDate.Value.ToShortDateString() : "",
                    ShippedDate = shippedDate,
                    Status = shippedDate == "N/A" ? status : "SHIPPED"
                });
            }
            return orderSearch;
        }
    }
}
