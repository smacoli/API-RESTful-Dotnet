﻿using AutoMapper;
using Supermarket.Resources;

namespace Supermarket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile() 
        {
            CreateMap<SaveCategoryResource, CategoryResource>();
        }
    }
}
