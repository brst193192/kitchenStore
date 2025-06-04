using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll.interfaces
{
    public interface IUserBll<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Update(int id, T user);
        T Add(T user);
        T Login(string email, string pass);
        bool IsExist(int userId);
        
    }
}
