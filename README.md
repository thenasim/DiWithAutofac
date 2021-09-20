# Dependency Injection with Autofac

## Some benefits of dependency injection/inversion

Here we can pass fake logger and dataAccess instead of real logger and database to test the code.
But If we would instantiate inside the class then we could not simulate fake logger and dataAccess

```charp
public BusinessLogic(ILogger logger, IDataAccess dataAccess)
{
    _logger = logger;
    _dataAccess = dataAccess;
}
```

---

