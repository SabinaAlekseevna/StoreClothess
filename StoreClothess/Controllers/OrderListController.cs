using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreClothess.Data.Interfaces;
using StoreClothess.Data.Repository;
using StoreClothess.ViewModel;

namespace StoreClothess.Controllers
{
    public class OrderListController : Controller
    {
        private readonly ProductOrd productOrd;
        private readonly IAllProduct orderRep;
    

        public OrderListController(ProductOrd productOrd, IAllProduct orderRep)
        {
            this.productOrd = productOrd;
            this.orderRep = orderRep;   
           
        }

        public IActionResult Index()
        {
            var items = productOrd.GetOrderProductIds();
            productOrd.ProductListOrd = items;

            var obj = new OderProductModelView
            {
                productOrd = productOrd
            };
            return View(obj);
        }

        public RedirectToActionResult addToOrder(int id)
        {
            var item = orderRep.products.FirstOrDefault(i => i.Id == id);
            if(item != null)
            {
                productOrd.AddToOrder(item);
            }
            return RedirectToAction("Index");
        }

    }
}
