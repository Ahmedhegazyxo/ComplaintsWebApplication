using Base;
using ComplainsServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseServer;

public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
{
    MigrationsDbContext _context;
    public BaseService(MigrationsDbContext context)
    {
        _context = context;
    }
    public virtual async Task<TEntity> Create(TEntity entity)
    {
        try
        {
            entity.CreationDate = DateTime.Now;
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public async Task<List<TEntity>> CreateBulk(List<TEntity> entities)
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            foreach(TEntity entity in entities) 
            {
                await Create(entity);
            }
            if (transaction is not null)
                await transaction.CommitAsync();
            else
                await transaction.RollbackAsync();
            return entities;
        }
        catch(Exception exception)
        {
            await transaction.RollbackAsync();
            throw exception;
        }
    }

    public async Task<List<TEntity>> CreateBulk(List<TEntity> entities, IDbContextTransaction transaction)
    {
        try
        {
            foreach (TEntity entity in entities)
            {
                await Create(entity);
            }
            return entities;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public virtual async Task Delete(TEntity entity)
    {
        try
        {
            await Task.Run(async () =>
            {
                _context.Set<TEntity>().Remove(entity);
            });
            await _context.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            throw exception;
        }

    }

    public virtual async Task<List<TEntity>> Read()
    {
        try
        {
            return await _context.Set<TEntity>().IgnoreAutoIncludes().ToListAsync();
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    public virtual async Task<List<TEntity>> ReadAllWithCustomIncludes(string customIncludes)
    {
        try
        {
            if (String.IsNullOrWhiteSpace(customIncludes))
                return await _context.Set<TEntity>().ToListAsync();
            else
            {
                IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();
                foreach (string customInclude in customIncludes.Split(","))
                {
                    query = query.Include(customInclude);
                }
                return await query.ToListAsync();
            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public virtual async Task<TEntity> ReadById(int id)
    {
        try
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public async Task<List<TEntity>> ReadByPredicate(Func<TEntity, bool> queryExpression)
    {
        try
        {
            var query = _context.Set<TEntity>().FindAsync(queryExpression);
            return new List<TEntity>();
            
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        try
        {
            entity.CreationDate = DateTime.Now;
            await Task.Run(() =>
            {
                _context.Set<TEntity>().Update(entity);
            });
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}