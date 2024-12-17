using Base;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseServer;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> ReadById(int id);
    Task<List<TEntity>> Read();
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<List<TEntity>> ReadAllWithCustomIncludes(string customIncludes);
    Task<List<TEntity>> ReadByPredicate(Func<TEntity , bool> queryExpression);
    Task<List<TEntity>> CreateBulk(List<TEntity> entities);
    Task<List<TEntity>> CreateBulk(List<TEntity> entities , IDbContextTransaction transaction);

}
