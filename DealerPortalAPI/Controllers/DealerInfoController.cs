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

namespace DealerPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerInfoController : ControllerBase
    {
        private readonly SysproCompanyAContext _syspro;
        private readonly ReportMasterContext _context;

        public DealerInfoController(SysproCompanyAContext syspro, ReportMasterContext context)
        {
            _syspro = syspro;
            _context = context;
        }

        // GET: api/DealerInfo/id
        [HttpGet("{id}")]
        public async Task<ActionResult<DealerInfo>> GetDealerInfo(string id)
        {
            var arCustomer = await _syspro.ArCustomer.Where(x => x.Customer == id).FirstOrDefaultAsync();

            if (arCustomer == null)
            {
                return NotFound();
            }

            var salesRepName = await _syspro.SalSalesperson.Where(x => x.Salesperson == arCustomer.Salesperson).Select(y => y.Name).FirstOrDefaultAsync();
            var addressInfo = await _syspro.ArCustomer1.Where(x => x.Customer == arCustomer.Customer).FirstOrDefaultAsync();
            var shipAddresses = await _syspro.ArMultAddress.Where(x => x.Customer == arCustomer.Customer).ToListAsync();
            var dealerInfo = new DealerInfo();
            dealerInfo.DealerId = arCustomer.Customer.Trim();
            dealerInfo.Name = arCustomer.Name.Trim();
            //dealerInfo.SalesRep = arCustomer.Salesperson.Trim() + " - " + salesRepName.Trim();
            dealerInfo.SalesRep = salesRepName.Trim();
            dealerInfo.PrimaryEmail = arCustomer.Email.Trim();
            dealerInfo.ContactEmail = arCustomer.DocFaxContact.Trim();
            CustomRepMaster rep = await _context.CustomRepMaster.Where(x => x.RepCode == arCustomer.Salesperson).FirstOrDefaultAsync();
            if (rep != null)
            {
                dealerInfo.CSSpecialist = await _context.CustomInsideSalesRep.Where(x => x.InsideSalesRepId == rep.InsideSalesRepId).Select(y => y.InsideSalesRepName.Trim()).FirstOrDefaultAsync();
            }
            dealerInfo.SoldToAddress = new Address()
            {
                Id = 0,
                Name = addressInfo.AttentionTo.Trim(),
                Address1 = arCustomer.SoldToAddr1.Trim(),
                Address2 = arCustomer.SoldToAddr2.Trim(),
                Address3 = arCustomer.SoldToAddr3.Trim(),
                City = arCustomer.SoldToAddr3Loc.Trim(),
                StateProvince = arCustomer.SoldToAddr4.Trim(),
                PostalCode = arCustomer.SoldPostalCode.Trim(),
                Country = arCustomer.SoldToAddr5.Trim(),
                PhoneNumber = arCustomer.Telephone.Trim()
            };
            dealerInfo.ShipToAddresses = new List<Address>();
            int index = 0;
            foreach (var item in shipAddresses)
            {
                dealerInfo.ShipToAddresses.Add(new Address()
                {
                    Id = index++,
                    Name = item.ShipToName.Trim(),
                    Address1 = item.ShipToAddr1.Trim(),
                    Address2 = item.ShipToAddr2.Trim(),
                    Address3 = item.ShipToAddr3.Trim(),
                    City = item.ShipToAddr3Loc.Trim(),
                    StateProvince = item.ShipToAddr4.Trim(),
                    PostalCode = item.ShipPostalCode.Trim(),
                    Country = item.ShipToAddr5.Trim(),
                    PhoneNumber = await _syspro.ArMultAddress1.Where(x => x.Customer == item.Customer && x.AddrCode == item.AddrCode).Select(y => y.MultiPhoneNumber.Trim()).FirstOrDefaultAsync()
                });
            }

            return dealerInfo;
        }
    }
}
