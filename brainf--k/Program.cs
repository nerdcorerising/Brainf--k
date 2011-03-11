using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace brainf__k
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader inputFile = new System.IO.StreamReader(args[0]);
            Compiler c = new Compiler();
            c.ReadFile(inputFile);
            try
            {
                c.Interpret();
            }
            catch (IndexOutOfRangeException i)
            {
                System.Console.Error.Write("Brainfault.");
            }
        }
    }
}
