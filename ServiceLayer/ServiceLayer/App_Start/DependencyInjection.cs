using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer;
using BusinessLogicLayer;
using System.Reflection;
using ServiceLayer.Models;

namespace ServiceLayer.App_Start
{
    public class DependencyInjection {

        private static IContainer _container;
        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MenuItemServiceMapper()); });
            var mapper = mapperConfiguration.CreateMapper();

            //EntityFramework Context
            builder.RegisterType<MexicaneseModel>().AsSelf().InstancePerLifetimeScope();

            //Automapper
            builder.RegisterInstance(mapper).As<IMapper>();

            //Repositories
            builder.RegisterType<MenuItemRepository>().As<IMenuItemRepository>();

            //Services
            builder.RegisterType<MenuItemLogic>().As<iMenuItem>();

            _container = builder.Build();

            return _container;
        }
    }
}