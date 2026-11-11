using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BACKEND_PROJEKT.DATA;
using BACKEND_PROJEKT.Models;
using BACKEND_PROJEKT.ViewModels;

namespace BACKEND_PROJEKT.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var homeVM = new HomeVM
            {
                Sliders = await _context.Sliders.ToListAsync(),
                ServiceFeatures = await _context.ServiceFeatures.ToListAsync(),
                Products = await _context.Products.ToListAsync()
            };

            return View(homeVM);
        }

        public async Task<IActionResult> Search(string? query)
        {
            var productsQuery = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(query) || (p.Category != null && p.Category.Contains(query)));
            }

            ViewBag.SearchQuery = query;
            var results = await productsQuery.ToListAsync();
            return View(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

