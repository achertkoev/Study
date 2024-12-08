namespace ExploringDesignPatterns.Creational.FactoryMethod;

class MarketingManager : HiringManager
{
    protected override IInterviewer CreateInterviewer()
    {
        return new CommunityExecutive();
    }
}