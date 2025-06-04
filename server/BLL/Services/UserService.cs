using DTO_Entity_Common.Classes;
using IBll.interfaces;
using IRepository.interfaces;

namespace BLL_Services.Services
{
    public class UserService : IUserBll<User>
    {
        IUserRepository<User> _dal;

        public UserService(IUserRepository<User> dal)
        {
            _dal = dal;
        }

        /* function */

        public List<User> GetAll()
        {
            try
            {
                return _dal.GetAll();
            }
            catch
            {
                throw new Exception("ERROR IN USER SERVICE");
            }
        }

        public User GetById(int id)
        {
            try
            {
                return _dal.GetById(id);
            }
            catch
            {
                throw new Exception("ERROR IN USER SERVICE");
            }
        }

        public bool IsExist(int userId)
        {
            try
            {
                return _dal.GetAll().FirstOrDefault(u => u.Id == userId) != null; ;
            }
            catch
            {
                throw new Exception("ERROR IN USER SERVICE");
            }
        }

        public User Add(User user)
        {
            try
            {
                return _dal.Add(user);
            }
            catch
            {
                throw new Exception("ERROR IN USER SERVICE");
            }
        }

        public User Login(string email, string pass)
        {
            try
            {
                return _dal.GetByEmailAndPassword(email, pass);
            }
            catch
            {
                throw new Exception("ERROR IN USER SERVICE");
            }
        }

        public void Update(int id, User user)
        {
            try
            {
                _dal.Update(id, user);
            }
            catch
            {
                throw new Exception("ERROR IN USER SERVICE");
            }
        }

    }
}
