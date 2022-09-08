using System;

class ReadCommand : ICommand
{
    private readonly string _address;
    private readonly int _regNumberToSaveReadValue;

    public ReadCommand(string address, int regNumberToSaveReadValue)
    {
        _address = address;
        _regNumberToSaveReadValue = regNumberToSaveReadValue;
    }

    public void Dump()
    {
        Console.Write($"r{_regNumberToSaveReadValue}={Memory.Read(_address)} {_address}");
    }


    public void Execute(int[] registers, ref int currentCommandIdex)
    {
        registers[_regNumberToSaveReadValue] = Memory.Read(_address);
        currentCommandIdex++;
    }
}
