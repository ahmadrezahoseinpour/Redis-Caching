using AutoMapper;
using ShoppingCart.API.Dtos;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CartItemDTO, CartItem>();
            CreateMap<CartItem, CartItemDTO>();
        }
    }
}

