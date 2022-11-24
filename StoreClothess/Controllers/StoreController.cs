using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreClothess.Data;
using StoreClothess.Data.Migrations;
using StoreClothess.Models;
using System.Diagnostics.Metrics;

namespace StoreClothess.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Store> store;
            store = _context.StoreDB.ToList();
            return View(store);
        }

        [HttpGet]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Create()
        {
            Store store = new Store();
            return View(store);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Store store)
        {
            _context.Add(store);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Store store = GetStore(Id);
            return View(store);
        }

        [HttpGet]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Edit(int Id)
        {
            Store store = GetStore(Id);
            return View(store);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Store store)
        {
            _context.Attach(store);
            _context.Entry(store).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private Store GetStore(int id)
        {
            Store store;
            store = _context.StoreDB
             .Where(c => c.Id == id).FirstOrDefault();
            return store;

        }

        [HttpGet]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Delete(int Id)
        {
            Store store = GetStore(Id);
            return View(store);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Store store)
        {
            try
            {
                _context.Attach(store);
                _context.Entry(store).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(store).Reload();
                ModelState.AddModelError("", ex.InnerException.Message);
                return View(store);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
