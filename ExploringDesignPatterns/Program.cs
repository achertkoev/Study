using ExploringDesignPatterns.Creational.FactoryMethod;

var devManager = new DevelopmentManager();
Console.WriteLine(devManager.TakeInterview());

var marketingManager = new MarketingManager();
Console.WriteLine(marketingManager.TakeInterview());