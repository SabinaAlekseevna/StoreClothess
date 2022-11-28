using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreClothess.Data.Migrations;
using StoreClothess.Models;

namespace StoreClothess.Controllers
{
    [Authorize]
    public class ReportEmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdministratorController> _logger;
        UserManager<User> _userManager;
        public ReportEmployeeController(ApplicationDbContext context, ILogger<AdministratorController> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }
        [Authorize(Roles = "Директор, Администратор, Бухгалтер")]
        public async Task<IActionResult> Index()
        {

            var stores = _userManager.Users.Include(m => m.Admivistrator).Include(k => k.SellerCashier).Include(d => d.Director).Include(n => n.Bookkeeper);
            _logger.LogInformation("Получен список сотрудников"); 
            return View(await stores.ToListAsync());

        }    

    }
}
