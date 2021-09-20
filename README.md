# Dependency Injection with Autofac
Dependency injection, or DI, is a design pattern in which a class requests dependencies from external sources rather than creating them.

## Difference between dependency injection and dependency inversion
> Dependency inversion is a principle and dependency injection is how you make it work.

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
