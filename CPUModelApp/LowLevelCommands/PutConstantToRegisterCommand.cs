using System;

class PutConstantToRegisterCommand : ICommand
{
    private readonly int _regNubmberToWrite, _constant;
    public PutConstantToRegisterCommand(int regNubmberToWrite, int constant)
    {
        _regNubmberToWrite = regNubmberToWrite;
        _constant = constant;
    }

    public void Dump()
    {
        Console.Write($"put r{_regNubmberToWrite} {_constant}");
    }

    public void Execute(int[] registers, ref int currentCommandIdex)
    {
        registers[_regNubmberToWrite] = _constant;
        currentCommandIdex++;
    }
}
