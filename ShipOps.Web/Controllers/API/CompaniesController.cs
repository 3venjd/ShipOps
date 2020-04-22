using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipOps.Web.Data;
using ShipOps.Web.Helpers;
using System.Threading.Tasks;

namespace ShipOps.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHerlper _converterHerlper;

        public CompaniesController(DataContext context,
                                   IConverterHerlper converterHerlper
                                  )
        {
            _context = context;
            _converterHerlper = converterHerlper;
        }

        [HttpGet("{name_comany}")]
        public async Task<IActionResult> GetCompanyEntity([FromRoute] string name_comany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyEntity = await _context.Companies
                .Include(v => v.Voys)
                .ThenInclude(o => o.Opinions)
                .Include(v => v.Voys)
                .ThenInclude(vi => vi.Voyimages)
                .Include(v => v.Voys)
                .ThenInclude(td => td.TripDetails)
                .Include(v => v.Voys)
                .ThenInclude(ve => ve.Vessel)
                .ThenInclude(vt => vt.VesselType)
                .Include(v => v.Voys)
                .ThenInclude(s => s.Statuses)
                .ThenInclude(a => a.Alerts)
                .ThenInclude(ai => ai.AlertImages)
                .Include(v => v.Voys)
                .ThenInclude(s => s.Statuses)
                .ThenInclude(h => h.Holds)
                .Include(v => v.Voys)
                .ThenInclude(p => p.Port)
                .ThenInclude(t => t.Terminals)
                .ThenInclude(l => l.LineUps)
                .Include(v => v.Voys)
                .ThenInclude(u => u.Employee)
                .ThenInclude(o => o.Office)
                .Include(u => u.Clients)
                .FirstOrDefaultAsync(c => c.Name == name_comany);

            if (companyEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHerlper.ToCompanyResponse(companyEntity));
        }



    }
}