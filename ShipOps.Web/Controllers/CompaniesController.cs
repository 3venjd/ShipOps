using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipOps.Web.Data;
using ShipOps.Web.Data.Entities;
using ShipOps.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHerlper _converterHerlper;
        private readonly IImageHelper _imageHelper;

        public CompaniesController(DataContext context,
                                   IUserHelper userHelper,
                                   ICombosHelper combosHelper,
                                   IConverterHerlper converterHerlper,
                                   IImageHelper imageHelper
                                  )
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHerlper = converterHerlper;
            _imageHelper = imageHelper;
        }

        // Companies

        public IActionResult Index()
        {
            return View(_context.Companies
                         .Include(c => c.Clients)
                         .Include(v => v.Voys)
                         .ThenInclude(s => s.Statuses)
                         .Include(v => v.Voys)
                         .ThenInclude(ve => ve.Vessel)
                );
        }

        [HttpGet]
        public IActionResult Create_company()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_company(CompanyEntity companyEntity)
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

        public async Task<IActionResult> Edit_Company(int? id)
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
        public async Task<IActionResult> Edit_company(int id, CompanyEntity companyEntity)
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
        public async Task<IActionResult> Delete_company(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEntity = await _context.Companies
                .Include(c => c.Clients)
                .Include(v => v.Voys)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (companyEntity == null)
            {
                return NotFound();
            }

            if (companyEntity.Clients.Count != 0 || companyEntity.Voys.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "You can't delete this company, because it has data asociated");
                return RedirectToAction(nameof(Index));
            }


            _context.Companies.Remove(companyEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //

        
    }
}
