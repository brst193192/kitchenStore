using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.interfaces
{
    public interface IUserRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T user);
        void Update(int id, T user);
        T GetByEmailAndPassword(string email, string pass);
    }
}
