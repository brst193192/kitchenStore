using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.interfaces
{
    public interface IProductReposotory<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void UpdateAmountInStock(int id, int amount);
        T DeleteById(int id);
    }
}
