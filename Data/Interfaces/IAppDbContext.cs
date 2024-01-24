using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    //Абстракиця для контекста бд
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<Category> Categories { get; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class; // Возвращет хранилище заданного типа

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); // Сохранение изменений

    }
}
