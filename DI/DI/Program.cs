using DI;

IContainerBuilder  builder = new ContainerBuilder();
builder.RegisterTransient<IService, Service>();
builder.RegisterScoped<Controller, Controller>();
builder.RegisterSingleton<IAnotherService>(AnotherServiceInstance.Instance);

var container = builder.Build();

var scope = container.CreateScope();
var scope2 = container.CreateScope();

var controller1 = scope.Resolve(typeof(Controller));
var controller2 = scope.Resolve(typeof(Controller));
var controller3 = scope2.Resolve(typeof(Controller));

if (controller1 != controller2)
    throw new InvalidOperationException();

if (controller2 == controller3)
    throw new InvalidOperationException();

var i1 = scope.Resolve(typeof(IAnotherService));
var i2 = scope2.Resolve(typeof(IAnotherService));


Console.ReadLine();

public interface IHelper
{

}

public class Helper : IHelper
{

}


public interface IAnotherService
{

}

public class AnotherServiceInstance
{
    private AnotherServiceInstance()
    {

    }
    public static AnotherServiceInstance Instance = new();
}

class Registration
{
    public IContainer ConfigureServices()
    {
        var builder = new ContainerBuilder();
        builder.RegisterTransient<IService, Service>();
        builder.RegisterScoped<Controller, Controller>();
        return builder.Build();
    }
}

public interface IService
{
    public void Do();
}

public class Service : IService
{
    public void Do()
    {
        Console.WriteLine("Do");
    }
}

public class Controller
{
    private readonly IService _service;

    public Controller(IService service)
    {
        _service = service;
    }

    public void Action()
    {
        _service.Do();
    }
}