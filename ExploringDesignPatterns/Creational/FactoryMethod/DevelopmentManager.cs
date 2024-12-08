namespace ExploringDesignPatterns.Creational.FactoryMethod;

class DevelopmentManager : HiringManager
{
    protected override IInterviewer CreateInterviewer()
    {
        return new Developer();
    }
}