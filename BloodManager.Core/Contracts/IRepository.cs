using System.Linq.Expressions;
using Core.Primitives;

namespace Core.Contracts;

public interface IRepository<TValue> where TValue : Entity
{
    public void Save(TValue value);
    public void Remove(TValue value);
    public IEnumerable<TValue> Find(Expression<Func<TValue, bool>> predicate);
}