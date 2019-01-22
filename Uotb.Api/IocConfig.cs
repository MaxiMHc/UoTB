using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Api.CQRS;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api
{
    public class IocConfig
    {
        public static IContainer RegisterDependencies(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(ICommandHandler<,>)).InstancePerLifetimeScope();

            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>().InstancePerRequest().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(IQueryHandler<,>)).InstancePerLifetimeScope();

            //builder.RegisterType<Eshop.Data.DataContext>().As<IEntitiesContext>().InstancePerLifetimeScope();
            //builder.RegisterType<Eshop.Data.DataContext>().As<DbContext>().InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(EntityRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
