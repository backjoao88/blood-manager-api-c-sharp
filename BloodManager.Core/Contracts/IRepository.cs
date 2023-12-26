using System.Linq.Expressions;
using Core.Primitives;

namespace Core.Contracts;

public interface IRepository<TEntity> where TEntity : Entity
{
    public void Save(TEntity value);
    public Task SaveAsync(TEntity data);
    public void Remove(TEntity value);
    public Task RemoveAsync(TEntity data);
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    public TEntity? FindById(TEntity data);
    public Task<TEntity?> FindByIdAsync(TEntity data);
    public Task<List<TEntity>> FindAllAsync();
    public List<TEntity> FindAll();
}