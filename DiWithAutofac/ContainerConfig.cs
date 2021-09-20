using System.Linq;
using System.Reflection;
using Autofac;
using DemoLibrary;

namespace DiWithAutofac
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            //builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>(); // it's now easy to change the implementation

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace != null && t.Namespace.Contains(nameof(DemoLibrary.Utilities)))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name)); // this
                //.AsImplementedInterfaces(); // and this works the same way

            return builder.Build();
        }
    }
}