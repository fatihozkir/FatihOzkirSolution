using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatihOzkirSolutions.Business.Abstract
{
    public interface IManagerService<T> where T : class, new()
    {
        List<T> GetAll();
        T GetById(int? id);
        T Add(T entity);
        T Update(T entity);
        int DeleteById(int? id);

    }
}
