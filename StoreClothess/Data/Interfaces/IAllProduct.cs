using System.Collections.Generic;

namespace StoreClothess.Data.Interfaces
{
    public interface IAllProduct
    {
        IEnumerable<Product> products { get; }
        IEnumerable<Product> GetProducts { get;}
        Product GetProduct(int prodId);
        
    }
}
