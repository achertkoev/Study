namespace ExploringDesignPatterns.Creational.FactoryMethod;

abstract class HiringManager
{
    protected abstract IInterviewer CreateInterviewer();

    public string TakeInterview()
    {
        var interviewer = CreateInterviewer();
        return interviewer.AskQuestions();
    }
}