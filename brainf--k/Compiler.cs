using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace brainf__k
{
    class Compiler
    {
        List<char> symbols = null;

        void readFile(string input)
        {
            //The valid characters in the language
            HashSet<char> valid = new HashSet<char>(new List<char> { '<', '>', '+', '-', '.', ',', '[', ']' });
            //Open the file
            //TODO add checks and stuff here.
            System.IO.StreamReader read = System.IO.File.OpenText(input);

            //Get all the characters from the file
            String line = read.ReadLine();
            while (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (valid.Contains(line[i]))
                    {
                        this.symbols.Add(line[i]);
                    }
                }
                line = read.ReadLine();
            }
        }

        void compileFile(string output)
        {
            //TODO compile the file and stuff.
        }
    }
}
