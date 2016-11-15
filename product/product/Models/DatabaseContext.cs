using System.Data.Entity;
namespace product.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
           : base("name=DatabaseContext")
        {
        }



        public DbSet<Type> Type { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}