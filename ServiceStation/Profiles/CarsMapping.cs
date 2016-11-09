using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ServiceStation.Models;
using ServiceStation.ViewModels;


namespace ServiceStation.Profiles
{
    public class CarsMapping : Profile
    {
        //  private readonly IMapperConfiguration MappingConfiguration; 
        protected override void Configure()
        {

            Mapper.CreateMap<Cars, CarsViewModel>();
            Mapper.CreateMap<CarsViewModel, Cars>()
                .ForMember(x => x.Clients, y => y.Ignore())
                .ForMember(x => x.Orders, y => y.Ignore());
        }
    }
}