using DTO_Entity_Common.Classes;
using IBll.interfaces;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("order/")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBll<Order> _bll;
        public OrderController(IOrderBll<Order> bll)
        {
            _bll = bll;
        }


        [HttpGet("byUser/{userId}")]
        public List<Order> GetOrdersByUserId(int userId)
        {
            try
            {
                return _bll.GetByUserId(userId);
            }
            catch
            {
                throw new Exception("ERROR IN ORDER CONTROLLER");
            }
        }

        [HttpPut("apdateArrived/")]
        public Order UpdateOrderAsArrived(Order order)
        {
            try
            {
                return _bll.UpdateAsArrived(order.Id);
            }
            catch
            {
                throw new Exception("ERROR IN ORDER CONTROLLER");
            }
        }

        [HttpPost("add")]
        public void Add(Order order)
        {
            try
            {
                _bll.Add(order);
            }
            catch
            {
                throw new Exception("ERROR IN ORDER CONTROLLER");
            }
        }
    }
}
