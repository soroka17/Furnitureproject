using Domain.Interfaces;

namespace Data.Interfaces
{
    //Реализация паттерна Репозиторий (CRUD операции)
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default);
        public Task<TEntity> Delete(Guid id, CancellationToken cancellationToken = default);
        public Task<TEntity> GetById(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
