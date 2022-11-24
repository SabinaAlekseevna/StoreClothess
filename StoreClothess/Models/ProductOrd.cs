namespace StoreClothess.Models
{
    public class ProductOrd
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProductOrd(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public string ProductOrdId { get; set; }
        public List<OrderProductId> ProductListOrd;

        public static ProductOrd GetProduct(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string productOrdId = session.GetString("ProductId") ?? Guid.NewGuid().ToString();

            session.SetString("ProductId", productOrdId);

            return new ProductOrd(context) { ProductOrdId = productOrdId};
        }

        public void AddToOrder(Product product)
        {
            this.applicationDbContext.OrderProductDB.Add(new OrderProductId
            {
                ProductStoreOrderId = ProductOrdId,
                Product = product,
                Price = product.Prise
            });
            applicationDbContext.SaveChanges();
        }

        public List<OrderProductId> GetOrderProductIds()
        {
            return applicationDbContext.OrderProductDB.Where(c => c.ProductStoreOrderId == ProductOrdId).Include(s => s.Product).ToList();
        } 


    }
}
