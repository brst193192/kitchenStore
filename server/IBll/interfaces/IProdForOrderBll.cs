using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll.interfaces
{
    public interface IProdForOrderBll<T> where T : class
    {
        T GetById(int id);
        List<T> GetByOrderId(int orderId);
        void Add(T item);
    }
}
