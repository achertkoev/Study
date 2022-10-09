namespace DI;

public abstract class ServcieDescriptor
{
    public Type ServiceType { get; init; }
    public LifeTime LifeTime { get; init; }
}

public class TypeBasedServiceDescriptor : ServcieDescriptor
{
    public Type ImplementationType { get; init; }
}

public class FactoryBasedServiceDescriptor : ServcieDescriptor
{
    public Func<IScope, object> Factory { get; init; }
}

public class InstanceBasedServiceDescriptor : ServcieDescriptor
{
    public object Instance { get; init; }
    public InstanceBasedServiceDescriptor(Type serviceType, object instance)
    {
        LifeTime = LifeTime.Singleton;
        ServiceType = serviceType;
        Instance = instance;
    }
}