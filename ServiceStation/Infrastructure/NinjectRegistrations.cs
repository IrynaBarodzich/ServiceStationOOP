using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using ServiceStation.Data;
using ServiceStation.Repositories;


namespace ServiceStation.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //  Bind<IBestStudent>().To<BestMathStudent>().InSingletonScope();
            ServiceContext db = new ServiceContext();
     //       Bind(typeof(ServiceContext)).ToConstant(db);
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(db);
            Bind(typeof(IRepository<,>)).To(typeof(Repository<,>)).WithConstructorArgument(db);
           


        }
    }
}