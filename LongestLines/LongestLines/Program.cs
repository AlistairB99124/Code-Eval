using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LongestLines
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 1;
            int quantity = 0;
            List<string> sentences = new List<string>();
            List<string> requested = new List<string>();
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        continue;
                    if (lineNumber == 1)
                    {
                        quantity = Convert.ToInt32(line);
                        ++lineNumber;
                    }
                    else
                    {
                        sentences.Add(line);
                    }
                }
            }

            requested = (from x in sentences orderby x.Length descending select x).Take(quantity).ToList();

            foreach (string r in requested)
            {
                Console.WriteLine(r);
            }
        }
    }
}