namespace DI;

public static class ContainerBuilderExtensions
{
    private static IContainerBuilder RegisterType(this IContainerBuilder builder, Type service, Type implementation, LifeTime lifeTime)
    {
        builder.Register(new TypeBasedServiceDescriptor()
        {
            ImplementationType = implementation,
            ServiceType = service,
            LifeTime = lifeTime
        });
        return builder;
    }

    private static IContainerBuilder RegisterFactory(this IContainerBuilder builder, Type service, Func<IScope, object> factory, LifeTime lifeTime)
    {
        builder.Register(new FactoryBasedServiceDescriptor()
        {
            Factory = factory,
            ServiceType = service,
            LifeTime = lifeTime
        });
        return builder;
    }

    private static IContainerBuilder RegisterInstance(this IContainerBuilder builder, Type service, object instance)
    {
        builder.Register(new InstanceBasedServiceDescriptor(service, instance));
        return builder;
    }

    public static IContainerBuilder RegisterTransient(this IContainerBuilder builder, Type serviceInterface, Type serviceImplementation)
       => builder.RegisterType(serviceInterface, serviceImplementation, LifeTime.Transient);

    public static IContainerBuilder RegisterScoped(this IContainerBuilder builder, Type serviceInterface, Type serviceImplementation)
        => builder.RegisterType(serviceInterface, serviceImplementation, LifeTime.Scoped);

    public static IContainerBuilder RegisterTransient<TService, TImplementation>(this IContainerBuilder builder)
        => builder.RegisterType(typeof(TService), typeof(TImplementation), LifeTime.Transient);

    public static IContainerBuilder RegisterScoped<TService, TImplementation>(this IContainerBuilder builder)
        => builder.RegisterType(typeof(TService), typeof(TImplementation), LifeTime.Scoped);

    public static IContainerBuilder RegisterTransient<TService>(this IContainerBuilder builder, Func<IScope, TService> factory)
        => builder.RegisterFactory(typeof(TService), s => factory(s), LifeTime.Transient);
    public static IContainerBuilder RegisterScoped(this IContainerBuilder builder, Type service, Func<IScope, object> factory)
        => builder.RegisterFactory(service, factory, LifeTime.Scoped);

    public static IContainerBuilder RegisterSingleton(this IContainerBuilder builder, Type serviceInterface, Type serviceImplementation)
        => builder.RegisterType(serviceInterface, serviceImplementation, LifeTime.Singleton);

    public static IContainerBuilder RegisterSingleton<TService, TImplementation>(this IContainerBuilder builder)
        => builder.RegisterType(typeof(TService), typeof(TImplementation), LifeTime.Singleton);

    public static IContainerBuilder RegisterSingleton(this IContainerBuilder builder, Type service, Func<IScope, object> factory)
        => builder.RegisterFactory(service, factory, LifeTime.Singleton);
    public static IContainerBuilder RegisterSingleton<T>(this IContainerBuilder builder, object instance)
        => builder.RegisterInstance(typeof(T), instance);


}