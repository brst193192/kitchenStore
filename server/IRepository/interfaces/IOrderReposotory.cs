using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.interfaces
{
    public interface IOrderReposotory<T> where T : class
    {
        T GetById(int id);
        void Add(T item);
        T Delete(int id);
        List<T> GetByUserId(int userId);

        void Update(T item);
        T UpdateAsArrived(int itemId);

    }
}
