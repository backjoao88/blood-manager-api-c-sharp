using System.Linq.Expressions;
using Core.Primitives;

namespace Core.Contracts;

public interface IRepository<TEntity> where TEntity : Entity
{
    public void Save(TEntity value);
    public Task SaveAsync(TEntity data);
    public void Remove(TEntity value);
    public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    public TEntity? FindById(Guid data);
    public Task<TEntity?> FindByIdAsync(Guid id);
    public Task<List<TEntity>> FindAllAsync();
    public List<TEntity> FindAll();
}