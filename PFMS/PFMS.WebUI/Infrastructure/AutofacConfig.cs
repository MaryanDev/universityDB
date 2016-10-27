using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using PFMS.Entities;
using PFMS.Repositories.Abstract;
using PFMS.Repositories.Concrete.UoW;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Infrastructure
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(HttpApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("context", new PintingFactoryDBEntities());

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}