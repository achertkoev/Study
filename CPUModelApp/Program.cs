using System;
using System.Collections.Generic;
using System.Linq;

namespace CPUModelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] registers = new int[2];

            // var commands = GetWhileProgram();

            var commands = GetIfProgram();

            for (int i = 0; i < commands.Length;)
            {
                Console.Write($"[{i.ToString().PadLeft(3,'0')}]");
                var currnetCommand = commands[i];
                currnetCommand.Dump();
                Console.CursorLeft = 60;
                currnetCommand.Execute(registers, ref i);
                Console.CursorLeft = 20;
                registers.Dump();
                Console.CursorLeft = 30;
                Memory.Dump();
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static ICommand[] GetIfProgram()
        {
            /*
            if(10>40)
            {
                
            }
            else
            {
            }
            */

            var condition = new ICommand[]
            {
                new PutConstantToRegisterCommand(0, 10),
                new PutConstantToRegisterCommand(1, 40),
                new GtCommand(0)
            };

            var ifClause = new ICommand[]
            {
                new OutputCommand("if block 1"),
                new OutputCommand("if block 2")
            };

            var elseClause = new ICommand[]
            {
                 new OutputCommand("else block 1"),
                 new OutputCommand("else block 2")
            };

            var commands = new IfCommand(condition, ifClause, elseClause).Compile().ToArray();

            return commands;
        }

        static ICommand[] GetWhileProgram()
        {
            var declarations = new ICommand[]
           {
                  new PutConstantToRegisterCommand(0, 0),
                  new WriteCommand("i", 0),
           };

            var condition = new ICommand[]
            {
                  new PutConstantToRegisterCommand(1, 10),
                  new ReadCommand("i", 0),
                  new LtCommand(0)
            };

            var body = new ICommand[]
            {
                new OutputCommand("while")
            }.Concat(new IncrementCommand("i").Compile()).ToArray();

            var commands = declarations.Concat(new WhileCommand(condition, body).Compile()).ToArray();

            return commands;
        }
    }
}
