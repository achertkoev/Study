using System;

class OutputCommand : ICommand
{
    private readonly string _text;

    public OutputCommand(string text)
    {
        _text = text;
    }

    public void Dump()
    {
        Console.Write("out");
    }

    public void Execute(int[] registers, ref int currentCommandIdex)
    {
        Console.Write(_text);
        currentCommandIdex++;
    }
}