using System;
using System.Linq;
using AutoMapper;
using Ninject;
using Ninject.Modules;
using System.Reflection;

namespace ServiceStation.Infrastructure
{
    public class AutoMapperNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfiguration>().ToMethod(context => Mapper.Configuration);
            Bind<IMappingEngine>().ToMethod(ctx => Mapper.Engine);

            Mapper.Initialize(map =>
            {
                map.ConstructServicesUsing(t => Kernel.Get(t));
                RegisterProfilesAndResolvers();
            });
        }

        private void RegisterProfilesAndResolvers()
        {
            var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            foreach (var profile in profiles)
                Mapper.AddProfile(Activator.CreateInstance(profile) as Profile);
        }
    }
}