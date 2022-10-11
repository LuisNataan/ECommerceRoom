using ECommerce.Project.Backend.Domain.Entities;

namespace ECommerce.Project.Backend.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task Create(TEntity entity);
        Task<TEntity> GetById(int id);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task SaveChanges();
    }
}