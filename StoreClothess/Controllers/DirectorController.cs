using Microsoft.AspNetCore.Authorization;
using StoreClothess.Models;

namespace StoreClothess.Controllers
{
    [Authorize(Roles = "Директор")]
    public class DirectorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DirectorController> _logger;
        UserManager<User> _userManager;
        public DirectorController(ApplicationDbContext context, ILogger<DirectorController> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {

            var directors = _context.DirectorDB.Include(n => n.User);
            _logger.LogInformation("Получен список директоров");
            return View(await directors.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.DirectorDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }


       
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create([Bind("ID,Name,Age,Phone,Employee,UserID, Times, price")] Director director)
        {
            if (ModelState.IsValid)
            {
                _context.Add(director);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Был создан директор");
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "Id", director.UserID);
            return View(director);
        }


       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.DirectorDB.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "UserName", director.UserID);
            return View(director);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age,Phone,Employee,UserID, Times, price")] Director director)
        {
            if (id != director.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(director);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.ID))
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
            return View(director);
        }


       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.DirectorDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _context.DirectorDB.FindAsync(id);
            _context.DirectorDB.Remove(director);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
            return _context.DirectorDB.Any(e => e.ID == id);
        }
    }
}