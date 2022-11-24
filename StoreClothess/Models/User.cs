using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StoreClothess.Models
{
    public class User: IdentityUser
    {
        public virtual Director? Director { get; set; }
        
        public virtual SellerCashier? SellerCashier { get; set; }
        public virtual Administrator? Admivistrator { get; set; }
        public virtual Bookkeeper? Bookkeeper { get; set; }


    }
}
