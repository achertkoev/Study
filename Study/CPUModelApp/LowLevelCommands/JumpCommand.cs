using System;

class JumpCommand : ICommand
{
    public void Dump()
    {
        Console.Write("jmp");
    }

    public void Execute(int[] registers, ref int currentCommandIdex)
    {
        currentCommandIdex += registers[0];
    }
}
