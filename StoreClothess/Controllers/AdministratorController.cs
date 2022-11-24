using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StoreClothess.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdministratorController> _logger;
        UserManager<User> _userManager;
        public AdministratorController(ApplicationDbContext context, ILogger<AdministratorController> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

  

        public async Task<IActionResult> Index()
        {

            var stores = _context.AdministratorDB.Include(m => m.Store).Include(n => n.User);
            _logger.LogInformation("Получен список администраторов");

            return View(await stores.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id, string? storename)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.AdministratorDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (administrator == null)
            {
                return NotFound();
            }
            var store = await _context.StoreDB
                .FirstOrDefaultAsync(m => m.Id == administrator.StoreID);
            if (store == null)
            { return NotFound(); }

            return View(administrator);
        }


        [Authorize(Roles = "Директор")]
        public IActionResult Create()
        {
            ViewData["StoreID"] = new SelectList(_context.StoreDB, "Id", "Stores");
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreID,ID,Name,Age,Phone,Employee,UserID")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrator);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Был создан администратор");
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreID"] = new SelectList(_context.StoreDB, "Id", "Id", administrator.StoreID);
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "Id", administrator.UserID);
            return View(administrator);
        }


        [Authorize(Roles = "Директор")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.AdministratorDB.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }
            ViewData["StoreID"] = new SelectList(_context.StoreDB, "Id", "Stores", administrator.StoreID);
            
            return View(administrator);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreID,ID,Name,Age,Phone,Employee,UserID")] Administrator administrator)
        {
            if (id != administrator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministratorExists(administrator.ID))
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
            return View(administrator);
        }


        [Authorize(Roles = "Директор")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.AdministratorDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (administrator == null)
            {
                return NotFound();
            }
            
            return View(administrator);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrator = await _context.AdministratorDB.FindAsync(id);
            _context.AdministratorDB.Remove(administrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministratorExists(int id)
        {
            return _context.AdministratorDB.Any(e => e.ID == id);
        }
    }
}
