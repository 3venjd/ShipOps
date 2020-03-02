using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipOps.Web.Data;
using ShipOps.Web.Data.Entities;
using System;
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


                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already exist a company with that name");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,ex.InnerException.Message);
                    }
                    
                }
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
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already exist a company with that name");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
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
