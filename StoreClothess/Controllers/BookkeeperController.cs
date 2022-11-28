using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StoreClothess.Models;

namespace StoreClothess.Controllers
{
    [Authorize(Roles = "Директор")]
    public class BookkeeperController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookkeeperController> _logger;
        UserManager<User> _userManager;
        public BookkeeperController(ApplicationDbContext context, ILogger<BookkeeperController> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {

            var bookkeepers = _context.BookkeeperDB.Include(n => n.User);
            _logger.LogInformation("Получен список директоров");
            return View(await bookkeepers.ToListAsync());

        }

 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookkeeper = await _context.BookkeeperDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bookkeeper == null)
            {
                return NotFound();
            }

            return View(bookkeeper);
        }


        
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Name,Age,Phone,Employee,UserID, Times, price")] Bookkeeper bookkeeper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookkeeper);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Был создан бухгалтер");
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "Id", bookkeeper.UserID);
            return View(bookkeeper);
        }

       
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookkeeper = await _context.BookkeeperDB.FindAsync(id);
            if (bookkeeper == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "UserName", bookkeeper.UserID);
            return View(bookkeeper);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age,Phone,Employee,UserID, Times, price")] Bookkeeper bookkeeper)
        {
            if (id != bookkeeper.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookkeeper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(bookkeeper.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookkeeper);
        }

 
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookkeeper = await _context.BookkeeperDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bookkeeper == null)
            {
                return NotFound();
            }

            return View(bookkeeper);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookkeeper = await _context.BookkeeperDB.FindAsync(id);
            _context.BookkeeperDB.Remove(bookkeeper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
            return _context.BookkeeperDB.Any(e => e.ID == id);
        }
    }
}
