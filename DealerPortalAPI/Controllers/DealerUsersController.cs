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
    public class DealerUsersController : ControllerBase
    {
        private readonly DealerPortalContext _context;
        private readonly IConfiguration _configuration;

        public DealerUsersController(DealerPortalContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/DealerUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealerUser>>> GetDealerUser()
        {
            return await _context.DealerUser.ToListAsync();
        }

        // GET: api/DealerUsers/id
        [HttpGet("{id}")]
        public async Task<ActionResult<DealerUser>> GetDealerUser(int id)
        {
            var dealerUser = await _context.DealerUser.FindAsync(id);

            if (dealerUser == null)
            {
                return NotFound();
            }
            dealerUser.Password = null;

            return dealerUser;
        }

        // PUT: api/DealerUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealerUser(int id, DealerUser dealerUser)
        {
            if (id != dealerUser.DealerUserId)
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(dealerUser.Password))
            {
                dealerUser.Password = await _context.DealerUser.Where(x => x.DealerUserId == id).Select(y => y.Password).FirstOrDefaultAsync();
            }
            _context.Entry(dealerUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealerUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DealerUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DealerUser>> PostDealerUser(DealerUser dealerUser)
        {
            _context.DealerUser.Add(dealerUser);
            await _context.SaveChangesAsync();

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
            }
            catch { }

            return CreatedAtAction("GetDealerUser", new { id = dealerUser.DealerUserId }, dealerUser);
        }

        // DELETE: api/DealerUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DealerUser>> DeleteDealerUser(int id)
        {
            var dealerUser = await _context.DealerUser.FindAsync(id);
            if (dealerUser == null)
            {
                return NotFound();
            }

            _context.DealerUser.Remove(dealerUser);
            await _context.SaveChangesAsync();

            return dealerUser;
        }

        private bool DealerUserExists(int id)
        {
            return _context.DealerUser.Any(e => e.DealerUserId == id);
        }
    }
}
