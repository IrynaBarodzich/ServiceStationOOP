using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ServiceStation.Models;
using ServiceStation.ViewModels;


namespace ServiceStation.Profiles
{
    public class ClientsMapping : Profile
    {
        //  private readonly IMapperConfiguration MappingConfiguration; 
        protected override void Configure()
        {
            Mapper.CreateMap<Clients, ClientsViewModel>();
            Mapper.CreateMap<ClientsViewModel, Clients>().ForMember(x => x.Cars, y => y.Ignore());
        }
    }
}