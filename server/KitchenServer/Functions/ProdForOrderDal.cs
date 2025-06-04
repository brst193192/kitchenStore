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
    public class ProdForOrderDal : IProdForOrderReposotory<ProdForOrder>
    {
        KitchenStoreContext _db;
        IMapper mapper;
        public ProdForOrderDal(KitchenStoreContext db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<KitchenServerProfile>();
            });
            mapper = config.CreateMapper();
        }


        /* functions */
        public void Add(ProdForOrder item)
        {
            try
            {
                _db.ProdForOrderTbl.Append(mapper.Map<ProdForOrder, ProdForOrder_>(item));
                _db.SaveChanges();
            }
            catch
            {
                throw new Exception("CAN NOT ADD PROD_FOR_ORDER TO DB");
            }
        }

        public ProdForOrder GetById(int id)
        {
            try
            {
                ProdForOrder_? prod = _db.ProdForOrderTbl
                    .Include(p => p.Product)
                    .ThenInclude(p=>p.Category)
                    .FirstOrDefault(p => p.Id == id);
                if(prod!=null)
                    return mapper.Map<ProdForOrder_, ProdForOrder>(prod);
                return null;
            }
            catch
            {
                throw new Exception("CAN NOT GET BY ID PROD_FOR_ORDER FROM DB");
            }
        }
    }
}
