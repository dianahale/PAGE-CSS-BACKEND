﻿namespace PageCss.DataAccess.Repositories
{
    public interface IRepository<TId, TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetAsync(TId id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TId id);
    }
}
