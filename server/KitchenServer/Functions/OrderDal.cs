using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository.interfaces;
using DTO_Entity_Common.Classes;
using REPOSITORY.Entities;
using AutoMapper;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace REPOSITORY.Functions
{
    public class OrderDal : IOrderReposotory<Order>
    {
        KitchenStoreContext _db;
        IMapper mapper;
        public OrderDal(KitchenStoreContext db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<KitchenServerProfile>();
            });
            mapper = config.CreateMapper();
        }


        /* functions */
        public void Add(Order item)
        {
            try
            {
                if (item.Products!.Count() < 1)
                {
                    throw new Exception("Error! can not add empty order!");
                }
                Order_ o = mapper.Map<Order, Order_>(item);
                List<ProdForOrder_> list = o.Products;
                o.Products = null!;
                o.OrderDate = DateTime.Now;
                o.ReceiveDate = null;
                _db.OrderTbl.Add(o);
                _db.SaveChanges();
                foreach (ProdForOrder_ p in list)
                {
                    p.OrderId = o.Id;
                    p.Order = null!;
                    p.Product = null!;
                    _db.ProdForOrderTbl.Add(p);
                }
                try
                {
                    _db.SaveChanges();
                }
                catch(Exception e)
                {
                    _db.OrderTbl.Remove(o);
                    throw new Exception(e.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "CAN NOT ADD ORDER TO DB");
            }
        }

        public List<Order> GetByUserId(int userId)
        {
            try
            {
                List<Order_> orders = _db.OrderTbl
                    .Include(o => o.Products)
                    .ThenInclude(o => o.Product)
                    .ThenInclude(o => o.Category)
                    .Where(o => o.UserId == userId)
                    .ToList();
                return mapper.Map<List<Order_>, List<Order>>(orders);
            }
            catch
            {
                throw new Exception("CAN NOT GET BY USER ID FROM DB");
            }
        }

        public Order GetById(int id)
        {
            try
            {
                Order_? o = _db.OrderTbl
                    //.Include(o => o.Products)
                    //.ThenInclude(p => p.Product)
                    .FirstOrDefault(o => o.Id == id);
                if (o != null)
                    return mapper.Map<Order_, Order>(o);
                return null;
            }
            catch
            {
                throw new Exception("CAN NOT GET BY ID FROM DB");
            }
        }

        public Order Delete(int id)
        {
            try
            {
                Order_? o = _db.OrderTbl.FirstOrDefault(o => o.Id == id);
                if (o != null)
                {
                    _db.OrderTbl.Remove(o);
                    return mapper.Map<Order_, Order>(o);
                }
                return null;
            }
            catch
            {
                throw new Exception("CAN NOT DELETE BY ID FROM DB");
            }
        }

        public void Update(Order o)
        {
            try
            {
                _db.OrderTbl.Update(mapper.Map<Order, Order_>(o));
                _db.SaveChanges();
            }
            catch
            {
                throw new Exception("CAN NOT UPDATE AS ARRIVED IN DB");
            }
        }

        public Order UpdateAsArrived(int orderId)
        {
            try
            {
                Order_? o = _db.OrderTbl
                    .Include(o=>o.Products)
                    .ThenInclude(p=>p.Product)
                    .ThenInclude(p=>p.Category)
                    .FirstOrDefault(o => o.Id == orderId);
                if (o != null) 
                {
                    o.ReceiveDate = DateTime.Now;
                    _db.OrderTbl.Update(o);
                    _db.SaveChanges();
                    return mapper.Map<Order_, Order>(o!);
                }
                return null!;
            }
            catch
            {
                throw new Exception("CAN NOT UPDATE AS ARRIVED IN DB");
            }
        }
    }
}
