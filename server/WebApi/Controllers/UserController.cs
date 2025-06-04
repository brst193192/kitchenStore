using DTO_Entity_Common.Classes;
using IBll.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REPOSITORY.Entities;

namespace WebApi.Controllers
{
    [Route("user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBll<User> _bll;
        public UserController(IUserBll<User> bll)
        {
            _bll = bll;
        }




        [HttpGet("getAll")]
        public List<User> GetAllUsers()
        {
            try
            {
                return _bll.GetAll();
            }
            catch
            {
                throw new Exception("ERROR IN USER CONTROLLER");
            }
        }

        [HttpGet("checkExisting")]
        public bool IsExistUser(int userid)
        {
            try
            {
                return _bll.IsExist(userid);
            }
            catch
            {
                throw new Exception("ERROR IN USER CONTROLLER");
            }
        }

        [HttpPost("login")]
        public User Login(User u)
        {
            try
            {
                return _bll.Login(u.Email, u.Password);
            }
            catch
            {
                throw new Exception("ERROR IN USER CONTROLLER");
            }
        }

        [HttpPost("register")]
        public User Register(User u)
        {
            try
            {
                return _bll.Add(u);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT CONTROLLER");
            }
        }

        [HttpPut("update/{id}")]
        public void UpdateUser(int id, User user)
        {
            try
            {
                _bll.Update(id, user);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT CONTROLLER");
            }
        }

    }
}
