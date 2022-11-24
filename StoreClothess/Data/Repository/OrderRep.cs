using Microsoft.AspNetCore.Mvc;

namespace StoreClothess.Data.Repository
{
    public class OrderRep 
    {
        public readonly ApplicationDbContext applicationDbContext;
        public OrderRep(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Product> Products => applicationDbContext.ProductDB;
        public Product GetProduct(int prodId) => applicationDbContext.ProductDB.FirstOrDefault(p => p.Id == prodId);
    }
}
