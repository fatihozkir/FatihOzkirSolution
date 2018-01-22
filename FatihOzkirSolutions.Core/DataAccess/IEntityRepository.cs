using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FatihOzkirSolutions.Core.DataAccess
{
    //I guaranteed with that interface for each object can be class and it has new operator.
    public interface IEntityRepository<T> where T : class, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T GetEntity(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);

    }
}
