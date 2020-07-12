using AutoMapper;
using ItemAPI.Models;
using ItemAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAPI.ItemMapper
{
    public class ItemMappings : Profile
    {
        public ItemMappings()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
        }
    }
}
