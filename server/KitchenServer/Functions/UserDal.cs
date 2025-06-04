using IRepository.interfaces;
using REPOSITORY.Entities;
using DTO_Entity_Common.Classes;
using AutoMapper;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace REPOSITORY.Functions
{
    public class UserDal : IUserRepository<User>
    {
        KitchenStoreContext _db;
        IMapper mapper;
        public UserDal(KitchenStoreContext db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<KitchenServerProfile>();
            });
            mapper = config.CreateMapper();
        }


        /* functions */
        public User Add(User user)
        {
            try
            {
                _db.UserTbl.Add(mapper.Map<User, User_>(user));
                _db.SaveChanges();
                //החזרת המשתמש החדש עם הקוד שקיבל אוטומטית
                User_? newUser = _db.UserTbl.FirstOrDefault(u => u.Email==user.Email && u.Password==user.Password);
                if(newUser != null) 
                    return mapper.Map<User_, User>(newUser);
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e+" CAN NOT ADD USER TO DB");
            }
        }

        public List<User> GetAll()
        {
            try
            {
                List<User_>? users = _db.UserTbl.ToList();
                if (users != null)
                    return mapper.Map<List<User_>, List<User>>(users);
                return null!;
            }
            catch(Exception e)
            {
                throw new Exception(e+" CAN NOT GET ALL USERS FROM DB");
            }
        }

        public User GetById(int id)
        {
            try
            {
                User_? u = _db.UserTbl.FirstOrDefault(u => u.Id == id);
                if(u!=null)
                    return mapper.Map<User_, User>(u);
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e+" CAN NOT GET USER BY ID FROM DB");
            }
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            try
            {
                User_? u = _db.UserTbl
                    .FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
                if (u != null)
                    return mapper.Map<User_, User>(u);
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e+" CAN NOT GET USER BY ID FROM DB");
            }
        }

        public void Update(int id, User user)
        {
            try
            {
                User_ u = mapper.Map<User, User_>(user);
                u.Id = id;
                _db.UserTbl.Update(u);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e+" CAN NOT UPDATE PRODUCT IN DB");
            }
        }
    }
}
