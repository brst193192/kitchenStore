using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll.interfaces
{
    public interface ICategoryBll<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
    }
}
