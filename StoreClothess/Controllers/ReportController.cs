using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StoreClothess.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
        // public async Task<IActionResult> Index(int searchString)
        // {

        //    var products = from m in _context.ProductDB
        //                   select m;

        //   if (searchString != null)
        //   {
        //      products = products.Where(s => s.StoreId.Equals(searchString));
        //   }


        // return View(await products.ToListAsync());
        //}

        public IActionResult Home()
        {
            return View();
        }

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
