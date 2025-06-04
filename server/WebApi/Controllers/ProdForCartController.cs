using DTO_Entity_Common.Classes;
using IBll.interfaces;
using IRepository.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("prodForCart/")]
    [ApiController]
    public class ProdForCartController : ControllerBase
    {
        ICartBll<ProdForCart> _bll;
        public ProdForCartController(ICartBll<ProdForCart> bll)
        {
            _bll = bll;
        }


        [HttpGet("byUser/{userId}")]
        public List<ProdForCart> GetMyCart(int userId)
        {
            return _bll.GetByUserId(userId);
        }

        [HttpPost("add")]
        public ProdForCart Add(ProdForCart p)
        {
            return _bll.Add(p);
        }

        [HttpPost("addMany")]
        public List<ProdForCart> Add(List<ProdForCart> p)
        {
            return _bll.AddMany(p);
        }

        [HttpPut("UpdateAmount")]
        public bool UpdateAmount(ProdForCart p)
        {
            try
            {
                _bll.UpdateAmount(p.Id, p.Amount);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost("changeSelected")]
        public void UpdateSelecting(ProdForCart pfc)
        {
            _bll.UpdateSelecting(pfc.Id);
        }

        [HttpDelete("delete/{id}")]
        public ProdForCart Delete(int id)
        {
            return _bll.Delete(id);
        }
    }
}
