using AutoMapper;
using CMS.Application.ApiModels;
using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Application.AutoMapper
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //ReverseMap() for, source(Customer) to destination(CustomerModel)
            //this for HTTPGet  is for HTTPPost,HTTPPut
            CreateMap<CustomerModel, Customer>();
            
        }
    }
}
