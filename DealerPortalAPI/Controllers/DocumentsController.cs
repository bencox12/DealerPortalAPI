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
    public class DocumentsController : ControllerBase
    {
        private readonly docimagingContext _context;
        private readonly SysproCompanyAContext _syspro;

        public DocumentsController(docimagingContext context, SysproCompanyAContext syspro)
        {
            _context = context;
            _syspro = syspro;
        }

        // GET: api/Documents/dealer
        [HttpGet("{function}/{type}/{id}")]
        public async Task<ActionResult<IEnumerable<PdfInfo>>> GetPdfInfo(string function, string type, string id)
        {
            List<PdfInfo> pdfInfos = new List<PdfInfo>();
            List<string> invoices = new List<string>();
            switch (function.ToLower())
            {
                case "list":
                    switch (type)
                    {
                        case "All":
                            pdfInfos.AddRange(await _context.PdfInfo.Where(x => x.KeyName == id && x.Type == "SalesOrder").ToListAsync());
                            invoices = _syspro.ArInvoice.Where(x => x.SalesOrder == id.PadLeft(15, '0')).Select(y => Convert.ToInt32(y.Invoice).ToString()).ToList();
                            pdfInfos.AddRange(await _context.PdfInfo.Where(x => invoices.Contains(x.KeyName) && x.Type == "Invoice").ToListAsync());
                            break;
                        case "SalesOrder":
                            pdfInfos = await _context.PdfInfo.Where(x => x.KeyName == id && x.Type == type).ToListAsync();
                            break;
                        case "Invoice":
                            invoices = _syspro.ArInvoice.Where(x => x.SalesOrder == id.PadLeft(15, '0')).Select(y => Convert.ToInt32(y.Invoice).ToString()).ToList();
                            pdfInfos = await _context.PdfInfo.Where(x => invoices.Contains(x.KeyName) && x.Type == type).ToListAsync();
                            break;
                    }
                    break;
                default:
                    pdfInfos = await _context.PdfInfo.Where(x => x.KeyName == id && x.Type == type).ToListAsync();
                    break;
            }
            return pdfInfos;
        }

        // PUT: api/Documents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPdfInfo(int id, PdfInfo pdfInfo)
        {
            if (id != pdfInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(pdfInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdfInfoExists(id))
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

        // POST: api/Documents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PdfInfo>> PostPdfInfo(PdfInfo pdfInfo)
        {
            _context.PdfInfo.Add(pdfInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPdfInfo", new { id = pdfInfo.Id }, pdfInfo);
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PdfInfo>> DeletePdfInfo(int id)
        {
            var pdfInfo = await _context.PdfInfo.FindAsync(id);
            if (pdfInfo == null)
            {
                return NotFound();
            }

            _context.PdfInfo.Remove(pdfInfo);
            await _context.SaveChangesAsync();

            return pdfInfo;
        }

        private bool PdfInfoExists(int id)
        {
            return _context.PdfInfo.Any(e => e.Id == id);
        }
    }
}
