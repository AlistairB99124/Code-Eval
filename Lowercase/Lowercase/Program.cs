using System;
using System.IO;

namespace Lowercase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        continue;
                    Console.WriteLine(line.ToLower());
                }
            }
        }
    }
}
