using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using StoreClothess.Data;
using StoreClothess.Models;
using Microsoft.AspNetCore.Authorization;


namespace StoreClothess.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Home()
        {
            return View();
        }


        public async Task<IActionResult> Index(string searchString)
        {

            var products = from m in _context.ProductDB
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }


            return View(await products.ToListAsync());
        }


        [HttpGet]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Create()
        {
            Product Product = new Product();
            ViewBag.Stors = GetStors();
            return View(Product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Create(Product Product)
        {

            _context.Add(Product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]

        public IActionResult Details(int Id)
        {
            Product Product = _context.ProductDB
              .Where(c => c.Id == Id).FirstOrDefault();

            return View(Product);
        }

        [HttpGet]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Edit(int Id)
        {
            Product Product = _context.ProductDB
              .Where(c => c.Id == Id).FirstOrDefault();

            ViewBag.Stors = GetStors();

            return View(Product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            _context.Attach(Product);
            _context.Entry(Product).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Delete(int Id)
        {
            Product Product = _context.ProductDB
              .Where(c => c.Id == Id).FirstOrDefault();

            return View(Product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Product Product)
        {
            _context.Attach(Product);
            _context.Entry(Product).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        private List<SelectListItem> GetStors()
        {
            var lstStors = new List<SelectListItem>();

            List<Store> Stors = _context.StoreDB.ToList();

            lstStors = Stors.Select(ct => new SelectListItem()
            {
                Value = ct.Id.ToString(),
                Text = ct.Stores
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Выберите магазин----"
            };

            lstStors.Insert(0, defItem);

            return lstStors;
        }
    }
}
