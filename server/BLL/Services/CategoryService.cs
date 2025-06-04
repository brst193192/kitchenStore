using DTO_Entity_Common.Classes;
using IBll.interfaces;
using IRepository.interfaces;

namespace BLL_Services.Services

{
    public class CategoryService : ICategoryBll<Category>
    {
        ICategoryReposotory<Category> _dal;

        public CategoryService(ICategoryReposotory<Category> dal)
        {
            _dal = dal;
        }


        /* function */
        public List<Category> GetAll()
        {
            try
            {
                return _dal.GetAll();
            }
            catch
            {
                throw new Exception("ERROR IN CATEGORY SERVICE");
            }
        }

        public Category GetById(int id)
        {
            try
            {
                return _dal.GetById(id);
            }
            catch
            {
                throw new Exception("ERROR IN CATEGORY SERVICE");
            }
        }
    }
}
