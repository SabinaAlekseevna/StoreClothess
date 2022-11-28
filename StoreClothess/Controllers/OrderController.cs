using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreClothess.Data.Interfaces;
using StoreClothess.Data.Migrations;

namespace StoreClothess.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrder allOrder;
        private readonly ProductOrd productOrder;
        private readonly ApplicationDbContext _context;


        public OrderController (IOrder allOrder, ProductOrd productOrder, ApplicationDbContext context)
        {
            this.allOrder = allOrder;
            this.productOrder = productOrder;
            _context = context;

        }
        [HttpGet]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Create()
        {
            Order order = new Order();
            return View(order);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // public IActionResult Checkout()
        //  {
        //     return View();
        //  }
        // [HttpPost]
        //  public IActionResult Checkout(Order order)
        //  {
        //      productOrder.ProductListOrd = productOrder.GetOrderProductIds();
        //     if(productOrder.ProductListOrd.Count == 0)
        //      {
        //         ModelState.AddModelError("", "У вас должны быть товары!");
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         allOrder.createOrder(order);
        //        return RedirectToAction("Complete");
        //    }
        //     return View(order);
        // }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

        public IActionResult Index()
        {
            List<Order> order;
            order = _context.OrderDB.ToList();
            return View(order);
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
            Order order = GetOrder(Id);
            return View(order);
        }

        [HttpGet]
        [Authorize(Roles = "Администратор, Директор")]
        public IActionResult Delete(int Id)
        {
            Order order = _context.OrderDB
              .Where(c => c.Id == Id).FirstOrDefault();

            return View(order);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Order order)
        {
            _context.Attach(order);
            _context.Entry(order).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private Order GetOrder(int id)
        {
           Order order;
            order = _context.OrderDB
             .Where(c => c.Id == id).FirstOrDefault();
            return order;

        }
    }
}
