using System;
using System.IO;
using System.Linq;

namespace ArrayAbsurdity
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
                    string arrayString = line.Substring(line.LastIndexOf(";") + 1);
                    int[] array = Array.ConvertAll(arrayString.Split(','), s => int.Parse(s));
                    var groups = array.GroupBy(v => v);
                    foreach (var group in groups)
                    {
                        if (group.Count() == 2)
                        {
                            Console.WriteLine(group.Key);
                        }
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
