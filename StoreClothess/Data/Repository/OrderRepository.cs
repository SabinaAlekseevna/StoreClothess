using StoreClothess.Data.Interfaces;
using System.Data;

namespace StoreClothess.Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly ProductOrd productOrd;

        public OrderRepository(ApplicationDbContext applicationDbContext, ProductOrd productOrd)
        {
            this.applicationDbContext = applicationDbContext;
            this.productOrd = productOrd;
        }

        public void createOrder(Order order)
        {
            order.OrderTame = DateTime.Now;
            applicationDbContext.OrderDB.Add(order);

            var items = productOrd.ProductListOrd;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductID = el.Product.Id,
                    OrderID = order.Id,
                    Prise = el.Product.Prise

                };
                applicationDbContext.OrderDetailsDB.Add(orderDetail);
            }
            applicationDbContext.SaveChanges();


        }
    }
}
