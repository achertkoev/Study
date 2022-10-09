namespace DI
{
    public class ContainerBuilder : IContainerBuilder
    {
        private readonly List<ServcieDescriptor> _descriptors = new();

        public IContainer Build()
        {
            return new Container(_descriptors);
        }

        public void Register(ServcieDescriptor descriptor)
        {
            _descriptors.Add(descriptor);
        }
    }
}
