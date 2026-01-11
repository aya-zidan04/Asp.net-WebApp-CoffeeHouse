using Microsoft.EntityFrameworkCore;

namespace Coffee_House_Aya.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Sweet> Sweets { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }


    }
}
