using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipOps.Web.Data;
using ShipOps.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly DataContext _context;

        public CompaniesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEntity = await _context.Companies.FindAsync(id);
            if (companyEntity == null)
            {
                return NotFound();
            }

            return View(companyEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyEntity companyEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyEntity);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEntity = await _context.Companies.FindAsync(id);
            if (companyEntity == null)
            {
                return NotFound();
            }
            return View(companyEntity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyEntity companyEntity)
        {
            if (id != companyEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(companyEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyEntity);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEntity = await _context.Companies.FindAsync(id);
            if (companyEntity == null)
            {
                return NotFound();
            }
            _context.Companies.Remove(companyEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
