using DTO_Entity_Common.Classes;
using IBll.interfaces;
using IRepository.interfaces;
using REPOSITORY.Entities;

namespace BLL_Services.Services
{
    public class OrderService : IOrderBll<Order>
    {
        IOrderReposotory<Order> _order_dal;
        IProductReposotory<Product> _Product_dal;
        public OrderService(IOrderReposotory<Order> _o, IProductReposotory<Product> _p)
        {
            _order_dal = _o;
            _Product_dal = _p;
        }


        /* function */
        public void Add(Order order)
        {
            try
            {
                _order_dal.Add(order);
                foreach (ProdForOrder p in order.Products!)
                {
                    _Product_dal.UpdateAmountInStock(p.ProductId, p.Amount);
                }
            }
            catch
            {
                throw new Exception("ERROR IN ORDER SERVICE");
            }
        }

        public List<Order> GetByUserId(int id)
        {
            try
            {
                return _order_dal.GetByUserId(id);
            }
            catch
            {
                throw new Exception("ERROR IN ORDER SERVICE");
            }
        }

        public Order UpdateAsArrived(int orderId)
        {
            try
            {
                return _order_dal.UpdateAsArrived(orderId);
            }
            catch
            {
                throw new Exception("ERROR IN ORDER SERVICE");
            }
        }
    }
}
