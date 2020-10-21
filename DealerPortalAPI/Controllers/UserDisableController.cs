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
    public class UserDisableController : ControllerBase
    {
        private readonly DealerPortalContext _context;

        public UserDisableController(DealerPortalContext context)
        {
            _context = context;
        }

        // GET: api/UserDisable/ids
        [HttpGet("{ids}")]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserDisable(string ids)
        {
            try
            {
                List<int> userids = ids.Split(',').ToList().Select(int.Parse).ToList();
                List<DealerUser> dealerUsers = await _context.DealerUser.Where(x => userids.Contains(x.DealerUserId)).ToListAsync();
                foreach (var item in dealerUsers)
                {
                    item.IsActive = false;
                }
                _context.DealerUser.UpdateRange(dealerUsers);
                await _context.SaveChangesAsync();
            }
            catch { }
            return NoContent();
        }
    }
}
