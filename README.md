# Dependency Injection with Autofac
Dependency injection, or DI, is a design pattern in which a class requests dependencies from external sources rather than creating them.

> Dependency inversion is a principle and dependency injection is how you make it work.

## Setup

Setup the configuration in `ContainerConfig` class or whatever you class is.

```c#
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

```

Then in the main file.

```c#
var container = ContainerConfig.Configure();

using (var scope = container.BeginLifetimeScope())
{
    var app = scope.Resolve<IApplication>();
    app.Run();
}
```

## Some benefits of dependency injection

### 1. Test classes easily

Here, we can pass fake logger and dataAccess instead of real logger and database to test the code. But, If we would instantiate inside the class then we could not simulate fake logger and dataAccess.

```c#
public BusinessLogic(ILogger logger, IDataAccess dataAccess)
{
    _logger = logger;
    _dataAccess = dataAccess;
}
```

### 2. Change the actual implementation without changing too much code

Because, it's not tightely coupled together. We can keep the interface same as before and add a new implemented class.

```c#
builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>(); // easy to change the implementation
```

✨✨✨ Autofac does work differently in ASP.NET Core application. Beacause there already some DI implemented there.
