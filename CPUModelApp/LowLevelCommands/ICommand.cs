interface ICommand
{
    void Execute(int[] registers, ref int currentCommandIdex);
    void Dump();
}