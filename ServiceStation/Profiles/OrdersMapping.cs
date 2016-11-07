using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ServiceStation.Models;
using ServiceStation.ViewModels;


namespace ServiceStation.Profiles
{
    public class OrdersMapping : Profile
    {
        //  private readonly IMapperConfiguration MappingConfiguration; 
        protected override void Configure()
        {

            Mapper.CreateMap<Orders, OrdersViewModel>();
            Mapper.CreateMap<OrdersViewModel, Orders>();
        }
    }
}