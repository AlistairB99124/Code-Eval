using System;
using System.IO;
using System.Text;

namespace FindAWriter
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
                    if (null == line)
                        continue;
                    string chars = line.Split('|')[0];
                    string charsTwo = line.Split('|')[1].TrimStart();
                    string[] codes = charsTwo.Split(' ');
                    int[] code = Array.ConvertAll(codes, s => int.Parse(s));

                    StringBuilder name = new StringBuilder();
                    foreach (var x in code)
                    {
                        char y = chars[x - 1];
                        name.Append(y.ToString());
                    }
                    Console.WriteLine(name.ToString());
                }
            }                
        }
    }
}
