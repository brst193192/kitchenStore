using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll.interfaces
{
    public interface ICartBll<T> where T : class
    {
        List<T> GetByUserId(int userId);
        T Add(T item);
        List<T> AddMany(List<T> p);
        void UpdateAmount(int prodForCart_id, int amount);
        void UpdateSelecting(int id);
        T Delete(int id);
    }
}
