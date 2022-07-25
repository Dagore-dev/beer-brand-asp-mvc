using ASPModelViewController.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPModelViewController.Controllers
{
    public class BrandController : Controller
    {
        private readonly PubContext pubContext;

        public BrandController (PubContext pubContext)
        {
            this.pubContext = pubContext;
        }
        
        public async Task<IActionResult> Index()
        {
            List<Brand> brands = await pubContext.Brands.ToListAsync();
            
            return View(brands);
        }
    }
}
