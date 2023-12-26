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
    public void Remove(TEntity data)
    {
        var entity = FindById(data);
        if (entity is null)
        {
            return;
        }
        entity.Delete();
    }
    public async Task RemoveAsync(TEntity data)
    {
        var entity = await FindByIdAsync(data);
        if (entity is null)
        {
            return;
        }
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
    public async Task<TEntity?> FindByIdAsync(TEntity data)
    {
        return await EfCoreContext.Set<TEntity>().Where(o => !o.IsDeleted).SingleOrDefaultAsync(o => o.Id == data.Id);
    }
    public TEntity? FindById(TEntity data)
    {
        return EfCoreContext.Set<TEntity>().Where(o => !o.IsDeleted).SingleOrDefault(o => o.Id == data.Id);
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