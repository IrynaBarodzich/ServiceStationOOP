using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using ServiceStation.Repositories;

namespace ServiceStation.Infrastructure
{
    public class AutofacConfig
    {
        /*     public static void ConfigureContainer()
       {

            var builder = new ContainerBuilder();

           
           builder.RegisterControllers(typeof(MvcApplication).Assembly);

        
           builder.RegisterType<ClientsRepository>().As<IClientsRepository>();
           builder.RegisterType<CarsRepository>().As<ICarsRepository>();
           builder.RegisterType<OrdersRepository>().As<IOrdersRepository>();

      
           var container = builder.Build();

           // установка сопоставителя зависимостей
           DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
       }*/
    
    }
}