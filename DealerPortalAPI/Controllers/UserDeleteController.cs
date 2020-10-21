using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealerPortalAPI.Models;

namespace DealerPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDeleteController : ControllerBase
    {
        private readonly DealerPortalContext _context;

        public UserDeleteController(DealerPortalContext context)
        {
            _context = context;
        }

        // GET: api/UserDelete/ids
        [HttpGet("{ids}")]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserDelete(string ids)
        {
            try
            {
                List<int> userids = ids.Split(',').ToList().Select(int.Parse).ToList();
                List<DealerUser> dealerUsers = await _context.DealerUser.Where(x => userids.Contains(x.DealerUserId)).ToListAsync();
                _context.DealerUser.RemoveRange(dealerUsers);
                await _context.SaveChangesAsync();
            }
            catch { }
            return NoContent();
        }
    }
}
