using Data.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    //Контекст базы данных из EntityFramework
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Product> Products { get; set; } // Хранилище продуктов 
        public DbSet<Category> Categories { get; set; } // Хранилище категорий

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
