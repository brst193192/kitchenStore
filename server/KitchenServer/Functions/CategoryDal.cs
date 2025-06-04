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

namespace REPOSITORY.Functions
{
    public class CategoryDal : ICategoryReposotory<Category>
    {
        KitchenStoreContext _db;
        IMapper mapper;
        public CategoryDal(KitchenStoreContext db)
        {
            _db = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<KitchenServerProfile>();
            });
            mapper = config.CreateMapper();
        }



        /* functions */
        public List<Category> GetAll()
        {
            try
            {
                return mapper.Map<List<Category_>, List<Category>>(_db.CategoryTbl.ToList());
            }
            catch
            {
                throw new Exception("CAN NOT GET FROM DB");
            }
        }

        public Category GetById(int id)
        {
            try
            {
                return mapper.Map<Category_, Category>(_db.CategoryTbl.FirstOrDefault(c=>c.Id==id));
            }
            catch
            {
                throw new Exception("CAN NOT GET BY ID FROM DB");
            }
        }
    }
}
