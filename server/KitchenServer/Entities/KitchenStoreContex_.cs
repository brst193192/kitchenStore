using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Entities
{
    public class KitchenStoreContext : DbContext
    {
        public KitchenStoreContext() { }
        public KitchenStoreContext(DbContextOptions<KitchenStoreContext> options)
        : base(options){}


        public DbSet<Category_> CategoryTbl { get; set; }
        public DbSet<Product_> ProductTbl { get; set; }
        public DbSet<ProdForOrder_> ProdForOrderTbl { get; set; }
        public DbSet<ProdForCart_> ProdForCartTbl { get; set; }
        public DbSet<Order_> OrderTbl { get; set; }
        public DbSet<User_> UserTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-783IDMP\\SQLEXPRESS; Database=KitchenStoreDB; Trusted_Connection=True; MultipleActiveResultSets=True; Encrypt=False");

    }
}
