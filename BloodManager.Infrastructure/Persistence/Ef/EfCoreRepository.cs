using System.Linq.Expressions;
using Core.Contracts;
using Core.Primitives;
using Microsoft.EntityFrameworkCore;

namespace BloodManager.Infrastructure.Persistence.Ef;

/// <summary>
/// Class that represents an EFCore repository with all functionalities.
/// </summary>
public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    public EfCoreRepository(EfCoreContext efCoreContext)
    {
        EfCoreContext = efCoreContext;
    }
    protected readonly EfCoreContext EfCoreContext;
    public void Save(TEntity data)
    {
        EfCoreContext.Set<TEntity>().Add(data);
    }
    public async Task SaveAsync(TEntity data)
    {
        await EfCoreContext.Set<TEntity>().AddAsync(data);
    }
    public void Remove(TEntity entity)
    {
        entity.Delete();
    }
    public async Task<List<TEntity>> FindAllAsync()
    {
        return await EfCoreContext.Set<TEntity>().Where(o => !o.IsDeleted).ToListAsync();
    }
    public List<TEntity> FindAll()
    {
        return EfCoreContext.Set<TEntity>().Where(o => !o.IsDeleted).ToList();
    }
    public async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await EfCoreContext.Set<TEntity>().Where(o => !o.IsDeleted).SingleOrDefaultAsync(o => o.Id == id);
    }
    public TEntity? FindById(Guid id)
    {
        return EfCoreContext.Set<TEntity>().Where(o => !o.IsDeleted).SingleOrDefault(o => o.Id == id);
    }
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return EfCoreContext.Set<TEntity>().Where(o => !o.IsDeleted).Where(predicate).ToList();
    }
    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return EfCoreContext.Set<TEntity>().Where(o => !o.IsDeleted).Where(predicate).ToListAsync();
    }
}