using IRepository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Entity_Common.Classes;
using REPOSITORY.Entities;
using AutoMapper;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace REPOSITORY.Functions
{
    public class ProductDal : IProductReposotory<Product>
    {
        KitchenStoreContext _db;
        IMapper mapper;
        public ProductDal(KitchenStoreContext db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<KitchenServerProfile>();
            });
            mapper = config.CreateMapper();
        }


        /* functions */
        public void Add(Product entity)
        {
            try
            {
                Product_ p = mapper.Map<Product, Product_>(entity);
                Category_? c=_db.CategoryTbl.FirstOrDefault(c=>c.Id==entity.CategoryId);
                if (c!=null)
                    p.Category = c;
                _db.ProductTbl.Add(p);
                _db.SaveChanges();
            }
            catch
            {
                throw new Exception("CAN NOT ADD PRODUCT TO DB");
            }
        }

        public Product DeleteById(int id)
        {
            try
            {
                Product_? p = _db.ProductTbl.FirstOrDefault(p => p.Id == id);
                if (p != null)
                {
                    _db.ProductTbl.Remove(p);
                    _db.SaveChanges();
                    return mapper.Map<Product_, Product>(p);
                }
                return null;
            }
            catch
            {
                throw new Exception("CAN NOT REMOVE PRODUCT BY ID FROM DB");
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                return mapper.Map<List<Product_>, List<Product>>(_db.ProductTbl.Include(p => p.Category).ToList());
            }
            catch
            {
                throw new Exception("CAN NOT GET ALL PRODUCTS FROM DB");
            }
        }

        public Product GetById(int id)
        {
            try
            {
                Product_? p = _db.ProductTbl
                    .Include(p => p.Category)
                    .FirstOrDefault(p => p.Id == id);
                if(p!=null)
                    return mapper.Map<Product_, Product>(p);
                return null;
            }
            catch
            {
                throw new Exception("CAN NOT GET PRODUCT BY ID FROM DB");
            }
        }

        public void Update(int id, Product entity)
        {
            try
            {
                Product_ p = mapper.Map<Product, Product_>(entity);
                Category_? c = _db.CategoryTbl.FirstOrDefault(c => c.Id == entity.CategoryId);
                if (c != null)
                {
                    p.Id = id;
                    p.Category = c;
                    _db.ProductTbl.Update(p);
                    _db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("CAN NOT UPDATE PRODUCT IN DB");
            }
        }

        public void UpdateAmountInStock(int id, int amount)
        {
            try
            {
                Product_? p = _db.ProductTbl.FirstOrDefault(p=>p.Id == id);
                if (p != null)
                {
                    p.AmountInStock -= amount;
                    _db.ProductTbl.Update(p);
                    _db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("CAN NOT UPDATE PRODUCT IN DB");
            }
        }
    }
}
