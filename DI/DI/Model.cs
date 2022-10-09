namespace DI;

public enum LifeTime
{
    Transient,
    Scoped,
    Singleton
}

public interface IContainerBuilder
{
    void Register(ServcieDescriptor descriptor);
    IContainer Build();
}

public interface IContainer
{
    IScope CreateScope();
}

public interface IScope
{
    object Resolve(Type service);
}
