using Data.Interfaces;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    //Реализация интерфейса репозитория
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity // можем работать только с типами, которые помечены как сущности
    {
        private readonly IAppDbContext _context;
        private readonly DbSet<TEntity> _set;

        //Внедрение зависимостей
        public BaseRepository(IAppDbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>(); // получаем хранилище сущностей взависимости от типа
        }

        //Метод создания сущности в бд
        public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = await _set.AddAsync(entity, cancellationToken)
                ?? throw new InvalidOperationException("Cannot add entity to database");

            return entry.Entity;
        }

        //Метод удаление сущности из бд
        public async Task<TEntity> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _set.FindAsync(id, cancellationToken)
                ?? throw new InvalidOperationException("Cannot find entity");

            var entry = _set.Remove(entity);

            return entry.Entity;
        }

        //Метод получение всех сущностей из бд
        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default)
        {
            var entry = await _set
                .OfType<Product>()
                .Include(x => x.Maker) // ТАк же получаем все сущности, которые внутри Product
                .Include(x => x.Categories)
                .Include(x => x.Features)
                .ToListAsync(cancellationToken)
                ?? throw new InvalidOperationException("Cannot get list of entities");

            return (IEnumerable<TEntity>)entry;
        }

        //Получаем одну сущности из бд по айди
        public async Task<TEntity> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var entry = await _set
                .OfType<Product>()
                .Include(x => x.Maker) // И так же ввсе подсущности
                .Include(x => x.Categories)
                .Include(x => x.Features)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new InvalidOperationException("Cannot find entity");

            return entry as TEntity;
        }

        //Сохранание изменений
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
