using IRepository.interfaces;
using DTO_Entity_Common.Classes;
using REPOSITORY.Entities;
using AutoMapper;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace REPOSITORY.Functions
{
    public class ProdForCartDal : IProdForCartReposotory<ProdForCart>
    {
        KitchenStoreContext _db;
        IMapper mapper;
        public ProdForCartDal(KitchenStoreContext db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<KitchenServerProfile>();
            });
            mapper = config.CreateMapper();
        }


        /* functions */
        public ProdForCart Add(ProdForCart prod_for_cart)
        {
            try
            {
                ProdForCart_? pfc = _db.ProdForCartTbl.FirstOrDefault(p => p.ProductId == prod_for_cart.ProductId && p.UserId == prod_for_cart.UserId);
                if (pfc != null)
                {
                    UpdateAmount(pfc.Id, pfc.Amount + 1);
                }
                else
                {
                    pfc = mapper.Map<ProdForCart, ProdForCart_>(prod_for_cart);
                    Product_? prod = _db.ProductTbl.FirstOrDefault(prod => prod.Id == prod_for_cart.ProductId);
                    if (prod != null)
                    {
                        pfc.Product = prod;
                        _db.Add(pfc);
                        _db.SaveChanges();
                    }
                }
                return prod_for_cart;
            }
            catch
            {
                throw new Exception("CAN NOT ADD PROD_FOR_CART TO DB");
            }
        }

        public ProdForCart DeleteById(int id)
        {
            try
            {
                ProdForCart_? del = _db.ProdForCartTbl.FirstOrDefault(x=>x.Id==id);
                if (del != null)
                {
                    _db.ProdForCartTbl.Remove(del);
                    _db.SaveChanges();
                    return mapper.Map<ProdForCart_, ProdForCart>(del);
                }
                return null!;
            }
            catch
            {
                throw new Exception("CAN NOT REMOVE PROD_FOR_CART FROM DB");
            }
        }

        public List<ProdForCart> GetByUserId(int userId)
        {
            try
            {
                List<ProdForCart_> list = _db.ProdForCartTbl
                    .Include(p => p.Product)
                    .ThenInclude(p => p.Category)
                    .Where(p => p.UserId == userId)
                    .ToList();
                if (list != null)
                {
                    return mapper.Map < List<ProdForCart_>,  List<ProdForCart>>(list);
                }
                return null!;
            }
            catch
            {
                throw new Exception("CAN NOT REMOVE PROD_FOR_CART FROM DB");
            }
        }

        public ProdForCart GetById(int id)
        {
            try
            {
                ProdForCart_? p = _db.ProdForCartTbl
                    .Include(p => p.Product)
                    .ThenInclude(p => p.Category)
                    .FirstOrDefault(x => x.Id == id);
                if(p!=null)
                    return mapper.Map<ProdForCart_, ProdForCart>(p);
                return null;
            }
            catch
            {
                throw new Exception("CAN NOT GET PROD_FOR_CART BY ID FROM DB");
            }
        }

        public List<ProdForCart> GetAll()
        {
            try
            {
                List<ProdForCart_>? list = _db.ProdForCartTbl
                    .Include(p => p.Product)
                    .Include(p => p.Product.Category)
                    .ToList();
                return mapper.Map<List<ProdForCart_>, List<ProdForCart>>(list);
            }
            catch
            {
                throw new Exception("CAN NOT GET ALL PROD_FOR_CART BY ID FROM DB");
            }
        }

        //public void Update(int id, ProdForCart item)
        //{
        //    try
        //    {
        //        ProdForCart_? p = _db.ProdForCartTbl.FirstOrDefault(p => p.Id == id);
        //        if (p != null)
        //        {
        //            p.Amount = item.Amount;
        //            p.UserId = item.UserId;
        //            _db.ProdForCartTbl.Update(p);
        //            _db.SaveChanges();
        //        }
        //    }
        //    catch
        //    {
        //        throw new Exception("CAN NOT UPDATE PROD_FOR_CART IN DB");
        //    }
        //}

        public void UpdateSelecting(int id)
        {
            try
            {
                ProdForCart_? pfc = _db.ProdForCartTbl.FirstOrDefault(p => p.Id == id);
                if (pfc != null)
                {
                    pfc.IsSelect = !pfc.IsSelect;
                    _db.ProdForCartTbl.Update(pfc);
                    _db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("CAN NOT UPDATE PROD_FOR_CART IN DB");
            }
        }

        public void UpdateAmount(int id, int amount)
        {
            try
            {
                if (amount == 0)
                {
                    DeleteById(id);
                    return;
                }
                ProdForCart_? p = _db.ProdForCartTbl.Include(p=>p.Product).FirstOrDefault(p => p.Id == id);
                if (p != null)
                {
                    if (p.Product.AmountInStock < amount)
                        p.Amount = p.Product.AmountInStock;
                    else 
                        p.Amount = amount;
                    _db.ProdForCartTbl.Update(p);
                    _db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("CAN NOT UPDATE PROD_FOR_CART IN DB");
            }
        }
    }
}
