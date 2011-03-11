using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace brainf__k
{
    class Compiler
    {
        private static int SIZE = 30000;

        private List<char> Symbols = null;
        private Stack<int> Loop = null;
        private byte[] Memory = null;
        private int ExecutionPointer = 0;
        private int Pointer = 0;

        public void ReadFile(System.IO.StreamReader read)
        {
            //The valid characters in the language
            HashSet<char> valid = new HashSet<char>(new List<char> { '<', '>', '+', '-', '.', ',', '[', ']' });

            this.Symbols = new List<char>();

            //Get all the characters from the file
            String line = read.ReadLine();
            while (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (valid.Contains(line[i]))
                    {
                        this.Symbols.Add(line[i]);
                    }
                }
                line = read.ReadLine();
            }
        }

        public void Interpret()
        {
            //Return if no program loaded.
            if (this.Symbols == null) return;

            //Initialize memory.
            this.Memory = new byte[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                this.Memory[i] = 0;
            }

            this.Loop = new Stack<int>();

            //Execute the program.
            for (this.ExecutionPointer = 0; this.ExecutionPointer < this.Symbols.Count; this.ExecutionPointer++)
            {
                switch (this.Symbols[this.ExecutionPointer])
                {
                    case '<':
                        if (this.Pointer > 0)
                        {
                            this.Pointer--;
                        }
                        else
                        {
                            this.Pointer = SIZE - 1;
                        }
                        break;
                    case '>':
                        if (this.Pointer < SIZE)
                        {
                            this.Pointer++;
                        }
                        else
                        {
                            this.Pointer = 0;
                        }
                        break;
                    case '+':
                        this.Memory[this.Pointer]++;
                        break;
                    case '-':
                        this.Memory[this.Pointer]--;
                        break;
                    case '.':
                        System.Console.Write((char)this.Memory[this.Pointer]);
                        break;
                    case ',':
                        this.Memory[this.Pointer] = (byte)System.Console.Read();
                        break;
                    case '[':
                        if (this.Memory[this.Pointer] != 0)
                        {
                            this.Loop.Push(this.ExecutionPointer);
                        }
                        else
                        {
                            int inside = 0;
                            while (this.Symbols[++this.ExecutionPointer] != ']' || inside > 0)
                            {
                                if (this.Symbols[this.ExecutionPointer] == '[')
                                {
                                    inside++;
                                }
                                if (this.Symbols[this.ExecutionPointer] == ']')
                                {
                                    inside--;
                                }
                            }
                        }
                        break;
                    case ']':
                        if (this.Memory[this.Pointer] != 0)
                        {
                            this.ExecutionPointer = this.Loop.Peek();
                        }
                        else
                        {
                            this.Loop.Pop();
                        }
                        break;
                }
            }
        }

        public void CompileToFile(string output)
        {
            //TODO compile the file and stuff.
        }
    }
}
