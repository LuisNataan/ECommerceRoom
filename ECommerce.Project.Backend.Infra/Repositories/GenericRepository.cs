using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Interfaces;
using ECommerce.Project.Backend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Project.Backend.Infra.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MainContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> Query() => _dbSet.AsNoTracking();
    }
}
