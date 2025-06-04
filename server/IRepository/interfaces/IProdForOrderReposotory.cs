using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.interfaces
{
    public interface IProdForOrderReposotory<T> where T : class
    {
        T GetById(int id);
        void Add(T item);
    }
}
