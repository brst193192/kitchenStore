using DTO_Entity_Common.Classes;
using IBll.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Product/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBll<Product> _bll;
        public ProductController(IProductBll<Product> bll)
        {
            _bll = bll;
        }


        [HttpGet("all")]
        public List<Product> GetAllProducts()
        {
            try
            {
                return _bll.GetAll();
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT CONTROLLER");
            }
        }

        [HttpGet("byCategory{ctgryId}")]
        public List<Product> GetProductsByCategory(int ctgryId)
        {
            try
            {
                return _bll.GetByCategoryId(ctgryId);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT CONTROLLER");
            }
        }

        [HttpGet("byId/{id}")]
        public Product GetProductsById(int id)
        {
            try
            {
                return _bll.GetById(id);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT CONTROLLER");
            }
        }

        [HttpPost("add")]
        public void AddProduct(Product product)
        {
            try
            {
                _bll.Add(product);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT CONTROLLER");
            }
        }

        [HttpPut("update")]
        public void UpdateProduct(int id, Product product)
        {
            try
            {
                _bll.Update(id, product);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT CONTROLLER");
            }
        }

        [HttpDelete("delete/{prodId}")]
        public Product DeleteProduct(int prodId)
        {
            try
            {
                return _bll.Delete(prodId);
            }
            catch
            {
                throw new Exception("ERROR IN PRODUCT CONTROLLER");
            }
        }
    }
}
