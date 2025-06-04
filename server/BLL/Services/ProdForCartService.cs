using DTO_Entity_Common.Classes;
using IBll.interfaces;
using IRepository.interfaces;
using REPOSITORY.Entities;
using System.Collections.Generic;

namespace BLL_Services.Services
{
    public class ProdForCartService : ICartBll<ProdForCart>
    {

        IProdForCartReposotory<ProdForCart> _dal;

        public ProdForCartService(IProdForCartReposotory<ProdForCart> dal) 
        {
            _dal=dal;
        }



        /* function */
        public List<ProdForCart> GetByUserId(int userId)
        {
            try
            {
                return _dal.GetByUserId(userId);
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORCART SERVICE");
            }
        }
        
        public ProdForCart Add(ProdForCart p)
        {
            try
            {
                return _dal.Add(p);
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORCART SERVICE");
            }
        }

        public List<ProdForCart> AddMany(List<ProdForCart> p)
        {
            try
            {
                List<ProdForCart> list = new List<ProdForCart>();
                foreach (ProdForCart pc in p)
                {
                    list.Add(_dal.Add(pc));
                }
                return list;
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORCART SERVICE");
            }
        }

        //public void Update(int prodForCart_id, ProdForCart p)
        //{
        //    try
        //    {
        //        _dal.Update(prodForCart_id, p);
        //    }
        //    catch
        //    {
        //        throw new Exception("ERROR IN PRODFORCART SERVICE");
        //    }
        //}

        public void UpdateAmount(int prodForCart_id, int amount)
        {
            try
            {
                if (amount < 0)
                    throw new Exception("Error! can not change amount less than 0!");
                _dal.UpdateAmount(prodForCart_id, amount);
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORCART SERVICE");
            }
        }

        public void UpdateSelecting(int id)
        {
            try
            {
                _dal.UpdateSelecting(id);
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORCART SERVICE");
            }
        }

        public ProdForCart Delete(int id)
        {
            try
            {
                return _dal.DeleteById(id);
            }
            catch
            {
                throw new Exception("ERROR IN PRODFORCART SERVICE");
            }
        }
  
    }
}
