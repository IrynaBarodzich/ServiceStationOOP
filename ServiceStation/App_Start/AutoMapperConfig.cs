using System.Reflection;
using AutoAutoMapper;
using AutoMapper;
using AutoMapper.Configuration;
using ServiceStation.Models;
using ServiceStation.Infrastructure;
using ServiceStation.Profiles;


namespace ServiceStation
{

    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ClientsMapping());
            });
        }

    }

    /*    public static void RegisterProfiles()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ClientsViewModel, Clients>());
            AutoProfiler.RegisterProfiles();
        }
    
    
    public static class MappingConfig
    {

       
        public static void RegisterProfiles()
        {


         //   Mapper.Initialize(cfg => cfg.CreateMap<Clients, ClientsViewModel>());
        //    Mapper.Initialize(cfg => cfg.CreateMap<Clients, ClientsViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<ClientsViewModel, Clients>());
            // To register your AutoMapper profiles, add the following line
            // to the Application_Start method in your Global.asax file:
            // AutoMapperConfig.RegisterProfiles();

            // By default, AutoAutoMapper will only look for Profiles in the assembly
            // that calls it (internally it uses Assembly.GetCallingAssembly()).
            // This means if you call this method via Application_Start in Global.asax,
            // only your web project will be scanned for AutoMapper.Profile implementations.
            // If you define AutoMapper.Profile classes in any other assemblies, see
            // below for instructions on how to tell AutoAutoMapper to scan those assemblies.
            AutoProfiler.RegisterProfiles();

            // If your AutoMapper Profile classes are defined in a different assembly,
            // you can register them by passing an assembly argument:
            //AutoProfiler.RegisterProfiles(Assembly.GetAssembly(typeof(SomeAutoMapperProfileClass)));

            // If you have AutoMapper Profile classes defined in multiple assemblies,
            // you can pass multiple assembly arguments:
            // AutoProfiler.RegisterProfiles(Assembly.GetAssembly(typeof(SomeAutoMapperProfileClass)),
            //    Assembly.GetAssembly(typeof(SomeAutoMapperProfileClassInADifferentAssembly)));

            // Additionally, there is a RegisterProfiles overload that takes an
            // IEnumerable<Assembly> if you wish to pass all assemblies at once:
            // var assemblies = new[]
            //     {
            //         Assembly.GetAssembly(typeof(SomeAutoMapperProfileClass)),
            //         Assembly.GetAssembly(typeof(SomeAutoMapperProfileClassInADifferentAssembly)),
            //     };
            // AutoProfiler.RegisterProfiles(assemblies);
        }
    }

    */
}
