using DTO_Entity_Common.Classes;
using IBll.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("category/")]
    public class CategoryController : ControllerBase
    {
        ICategoryBll<Category> _bll;
        public CategoryController(ICategoryBll<Category> bll)
        {
            _bll = bll;
        }



        [HttpGet("all")]
        public List<Category> GetAllCategories()
        {
            try
            {
                return _bll.GetAll();
            }
            catch
            {
                throw new Exception("ERROR IN CATEGORY CONTROLLER");
            }
        }

        [HttpGet("byId/{id}")]
        public Category GetCategoryById(int id)
        {
            try
            {
                return _bll.GetById(id);
            }
            catch
            {
                throw new Exception("ERROR IN CATEGORY CONTROLLER");
            }
        }
    }
}
