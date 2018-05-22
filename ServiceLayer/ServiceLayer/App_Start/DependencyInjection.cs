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
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<CouponRepository>().As<ICouponRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();

            //Services
            builder.RegisterType<MenuItemLogic>().As<iMenuItem>();
            builder.RegisterType<UserLogic>().As<IUser>();
            builder.RegisterType<OrderLogic>().As<IOrder>();
            builder.RegisterType<CouponLogic>().As<ICoupon>();
            builder.RegisterType<AddressLogic>().As<IAddress>();

            _container = builder.Build();

            return _container;
        }
    }
}