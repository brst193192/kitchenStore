using DTO_Entity_Common.Classes;
using IBll.interfaces;
using IRepository.interfaces;

namespace BLL_Services.Services
{
    public class ProductService : IProductBll<Product>
    {
        IProductReposotory<Product> _dal;

        public ProductService(IProductReposotory<Product> dal) 
        {
            _dal = dal;
        }


        /* function */
        

        public List<Product> GetAll()
        {
            try
            {
                return _dal.GetAll();
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT SERVICE");
            }
        }
        public Product GetById(int id)
        {
            try
            {
                return _dal.GetById(id);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT SERVICE");
            }
        }
        public List<Product> GetByCategoryId(int id)
        {
            try
            {
                return _dal.GetAll().Where(p => p.CategoryId == id).ToList();
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT SERVICE");
            }
        }
        public void Add(Product entity)
        {
            try
            {
                _dal.Add(entity);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT SERVICE");
            }
        }
        public Product Delete(int id)
        {
            try
            {
                return _dal.DeleteById(id);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT SERVICE");
            }
        }
        public void Update(int id, Product entity)
        {
            try
            {
                _dal.Update(id, entity);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT SERVICE");
            }
        }
    }
}

