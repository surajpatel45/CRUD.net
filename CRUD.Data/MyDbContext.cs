using CRUD.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
