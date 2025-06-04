using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll.interfaces
{
    public interface IProductBll<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> GetByCategoryId(int id);
        void Add(T entity);
        void Update(int id, T entity);
        T Delete(int id);
    }
}
