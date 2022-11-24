using Microsoft.EntityFrameworkCore;
using StoreClothess.Data.Interfaces;

namespace StoreClothess.Data.Repository
{
    public class ProductRep : IAllProduct
    {
        public readonly ApplicationDbContext applicationDbContext;
        public ProductRep(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Product> products => applicationDbContext.ProductDB;

        public IEnumerable<Product> GetProducts => applicationDbContext.ProductDB;

        public Product GetProduct(int proId) => applicationDbContext.ProductDB.FirstOrDefault(p => p.Id == proId);
    }
}
        

