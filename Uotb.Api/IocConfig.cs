using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Api.CQRS;
using Uotb.Interfaces.CQRS;
using Uotb.Application.People.Commands;
using System.Reflection;

namespace Uotb.Api
{
    public class IocConfig
    {
        public static IContainer RegisterDependencies(IServiceCollection services)
        {
            var assembliesAppDomain = AppDomain.CurrentDomain.GetAssemblies();
            var assembliesApplicationProject = typeof(CreatePerson).GetTypeInfo().Assembly;

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembliesApplicationProject).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembliesApplicationProject).AsClosedTypesOf(typeof(ICommandHandler<,>)).InstancePerLifetimeScope();

            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>().InstancePerRequest().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembliesApplicationProject).AsClosedTypesOf(typeof(IQueryHandler<,>)).InstancePerLifetimeScope();

            //builder.RegisterType<Eshop.Data.DataContext>().As<IEntitiesContext>().InstancePerLifetimeScope();
            //builder.RegisterType<Eshop.Data.DataContext>().As<DbContext>().InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(EntityRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
