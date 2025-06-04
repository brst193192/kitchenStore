using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll.interfaces
{
    public interface IOrderBll<T> where T : class
    {

        void Add(T order);
        List<T> GetByUserId(int id);
        T UpdateAsArrived(int orderId);
    }
}