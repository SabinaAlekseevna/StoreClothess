using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreClothess.Models;

namespace StoreClothess.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Administrator> AdministratorDB { get; set; }
        public DbSet<Bookkeeper> BookkeeperDB { get; set; }
        public DbSet<Director> DirectorDB { get; set; }
        public DbSet<Product> ProductDB { get; set; }
        public DbSet<SellerCashier> SellerCashierDB { get; set; }
        public DbSet<Store> StoreDB { get; set; }
        public DbSet<OrderProductId> OrderProductDB { get; set; }
        public DbSet<Order> OrderDB { get; set; }
        public DbSet<OrderDetail> OrderDetailsDB { get; set; }

        public DbSet<ProductOrd> ProductOrdDB { get; set; }

    }
}