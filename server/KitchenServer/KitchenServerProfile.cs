using AutoMapper;
using DTO_Entity_Common.Classes;
using REPOSITORY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public class KitchenServerProfile : Profile
    {
        public KitchenServerProfile()
        {
            CreateMap<Address_, Address>().ReverseMap();
            CreateMap<Category_, Category>().ReverseMap();
            CreateMap<Product_, Product>()
                .ReverseMap();
            CreateMap<Order_, Order>()
                .ReverseMap();
            CreateMap<ProdForCart_, ProdForCart>()
                .ReverseMap();
            CreateMap<ProdForOrder_, ProdForOrder>()
                .ReverseMap();
            CreateMap<User_, User>()
                .ReverseMap();
        }
    }
}
