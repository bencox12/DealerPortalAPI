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
    public class UserEmailController : ControllerBase
    {
        private readonly DealerPortalContext _context;
        private readonly IConfiguration _configuration;

        public UserEmailController(DealerPortalContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/UserEmail/email
        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserEmail(string email)
        {
            DealerUser dealerUser = await _context.DealerUser.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (dealerUser == null)
            {
                return NotFound();
            }
            string subject = "Dealer Portal Registration";
            string url = _configuration.GetValue<string>("AppSettings:RegisterUrl") + dealerUser.DealerUserId;
            string body = "You have been registered to use the Dealer Portal.<br/><br/><a href='" + url + "'>Click here</a> to complete your registration.";

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
                if (!dealerUser.IsActive)
                {
                    dealerUser.IsActive = true;
                    _context.Entry(dealerUser).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch { }
            return NoContent();
        }
    }
}
