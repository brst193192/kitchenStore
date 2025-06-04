        using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Entity_Common.Classes;
using IBll.interfaces;
using IRepository.interfaces;

namespace BLL_Services.Services
{
    public class ProdForOrderService : IProdForOrderBll<ProdForOrder>
    {
        IProdForOrderReposotory<ProdForOrder> _dal;

        public ProdForOrderService(IProdForOrderReposotory<ProdForOrder> dal) 
        {
            _dal = dal;
        }


        /* function */
        public void Add(ProdForOrder item)
        {
            try
            {
                _dal.Add(item);
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORORDERE SERVICE");
            }
        }

        public ProdForOrder GetById(int id)
        {
            try
            {
                return _dal.GetById(id);
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORORDERE SERVICE");
            }
        }

        public List<ProdForOrder> GetByOrderId(int orderId)
        {
            try
            {
                return null;
                //return _dal.GetByOrderId(orderId);
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORORDERE SERVICE");
            }
        }
    }
}
