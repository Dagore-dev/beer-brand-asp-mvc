using ASPModelViewController.Models;
using ASPModelViewController.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPModelViewController.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext pubContext;
        
        public BeerController (PubContext pubContext)
        {
            this.pubContext = pubContext;
        }
        
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Beer, Brand> joinWithBrand = pubContext.Beers.Include(tables => tables.Brand);
            List<Beer> beers = await joinWithBrand.ToListAsync();
            
            return View(beers);
        }

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(pubContext.Brands, "BrandId", "Name");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Beer beer = new Beer()
                {
                    Name = viewModel.Name,
                    BrandId = viewModel.BrandId,
                };

                pubContext.Add(beer);
                await pubContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            ViewData["Brands"] = new SelectList(pubContext.Brands, "BrandId", "Name", viewModel.BrandId);

            return View(viewModel);
        }
    }
}
