using System;

static class RegistersExtensions
{
    public  static void Dump(this int[] registers)
    {
        foreach(int item in registers)
        {
            Console.Write($"{item,3}");
        }
    }
}
