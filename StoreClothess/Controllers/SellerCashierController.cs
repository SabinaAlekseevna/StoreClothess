using Microsoft.AspNetCore.Authorization;

namespace StoreClothess.Controllers
{
    [Authorize(Roles = "Администратор, Директор")]
    public class SellerCashierController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SellerCashierController> _logger;
        UserManager<User> _userManager;
        public SellerCashierController(ApplicationDbContext context, ILogger<SellerCashierController> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

       
        public async Task<IActionResult> Index()
        {

            var stores = _context.SellerCashierDB.Include(m => m.User).Include(n => n.Store);
            _logger.LogInformation("Получен список продавцов-кассиров");
            return View(await stores.ToListAsync());

        }

        
        public async Task<IActionResult> Details(int? id, string? storename)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerCashier = await _context.SellerCashierDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sellerCashier == null)
            {
                return NotFound();
            }
            var store = await _context.StoreDB
                .FirstOrDefaultAsync(m => m.Id == sellerCashier.StoreID);
            if (store == null)
            { return NotFound(); }

            return View(sellerCashier);
        }


       
        public IActionResult Create()
        {
            ViewData["StoreID"] = new SelectList(_context.StoreDB, "Id", "Stores");
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreID,ID,Name,Age,Phone,Employee,UserID, Times, price")] SellerCashier sellerCashier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellerCashier);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Был создан продавец-кассир");
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreID"] = new SelectList(_context.StoreDB, "Id", "Id", sellerCashier.StoreID);
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "Id", sellerCashier.UserID);
            return View(sellerCashier);
        }


        

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerCashier = await _context.SellerCashierDB.FindAsync(id);
            if (sellerCashier == null)
            {
                return NotFound();
            }
            ViewData["StoreID"] = new SelectList(_context.StoreDB, "Id", "Stores", sellerCashier.StoreID);
            ViewData["UserID"] = new SelectList(_userManager.Users, "Id", "UserName", sellerCashier.UserID);
            return View(sellerCashier);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreID,ID,Name,Age,Phone,Employee,UserID, Times, price")] SellerCashier sellerCashier)
        {
            if (id != sellerCashier.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellerCashier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerCasherExists(sellerCashier.ID))
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
            return View(sellerCashier);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerCashier = await _context.SellerCashierDB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sellerCashier == null)
            {
                return NotFound();
            }

            return View(sellerCashier);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellerCashier = await _context.SellerCashierDB.FindAsync(id);
            _context.SellerCashierDB.Remove(sellerCashier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerCasherExists(int id)
        {
            return _context.SellerCashierDB.Any(e => e.ID == id);
        }
    }
}
