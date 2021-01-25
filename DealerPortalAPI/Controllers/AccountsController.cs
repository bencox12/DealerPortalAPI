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
    public class AccountsController : ControllerBase
    {
        private readonly DealerPortalContext _context;
        private readonly IConfiguration _configuration;

        public AccountsController(DealerPortalContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/DealerUsers/id
        [HttpGet("{dealerid}/{id}")]
        public async Task<ActionResult<DealerUser>> GetAccount(string dealerid, string id)
        {
            DealerUser dealerUser = await _context.DealerUser.Where(x => x.SysproDealerId == dealerid && x.Email == id && x.IsActive).FirstOrDefaultAsync();
            if (dealerUser == null)
            {
                dealerUser = await _context.DealerUser.Where(x => x.SysproDealerId == dealerid && x.Name == id && x.IsActive).FirstOrDefaultAsync();
            }

            if (dealerUser == null)
            {
                return NotFound();
            }
            dealerUser.Password = null;

            return dealerUser;
        }

        // GET: api/Accounts
        [HttpPost]
        public async Task<ActionResult<DealerUser>> GetAccount(LoginModel model)
        {
            DealerUser dealerUser;
            if (model.Message != "reset")
            {
                dealerUser = await _context.DealerUser.Where(x => x.Email == model.Email && x.Password == model.Password && x.IsActive).FirstOrDefaultAsync();

                if (dealerUser == null)
                {
                    return NotFound();
                }
            }
            else
            {
                dealerUser = await _context.DealerUser.Where(x => x.Email == model.Email && x.IsActive).FirstOrDefaultAsync();

                if (dealerUser == null)
                {
                    return NotFound();
                }

                string subject;
                string url;
                string body;
                if (string.IsNullOrWhiteSpace(dealerUser.Password))
                {
                    subject = "Dealer Portal Registration";
                    url = _configuration.GetValue<string>("AppSettings:RegisterUrl") + dealerUser.DealerUserId;
                    body = "You have been registered to use the Dealer Portal.<br/><br/><a href='" + url + "'>Click here</a> to complete your registration.";
                }
                else
                {
                    subject = "Dealer Portal Password Reset";
                    url = _configuration.GetValue<string>("AppSettings:ResetUrl") + dealerUser.DealerUserId;
                    body = "A password reset has been requested.<br/><br/><a href = '" + url + "' > Click here </a> to reset your password.";
                }

                var emessage = new MailMessage("postmaster@allseating.com", dealerUser.Email, subject, body)
                {
                    IsBodyHtml = true
                };
                emessage.Bcc.Add("admin@allseating.com");
                using SmtpClient SmtpMail = new SmtpClient("allfs90.allseating.com", 25)
                {
                    UseDefaultCredentials = true
                };
                try
                {
                    SmtpMail.Send(emessage);
                    emessage.Dispose();
                }
                catch { }

            }

            return dealerUser;
        }
    }
}
