using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreClothess.Data.Migrations;

namespace StoreClothess.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Home()
        {
            return View();
        }

        [Authorize(Roles = "Директор, Администратор, Бухгалтер")]
        public async Task<IActionResult> Index(string searchString)
        {

            var products = from m in _context.ProductDB.Include(m => m.Store)
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Store.Stores.Contains(searchString));
            }


            return View(await products.ToListAsync());
        }

    }
}
