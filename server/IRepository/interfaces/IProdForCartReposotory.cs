using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.interfaces
{
    public interface IProdForCartReposotory<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> GetByUserId(int userId);
        T Add(T item);
        void UpdateAmount(int id, int amount);
        void UpdateSelecting(int id);
        T DeleteById(int id);
    }
}
