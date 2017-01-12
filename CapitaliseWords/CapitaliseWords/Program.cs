using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CapitaliseWords
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
                    string[] results = line.Split(' ');
                    StringBuilder answer = new StringBuilder();
                    foreach (var i in results)
                    {
                        string x = FirstCharToUpper(i);
                        answer.Append(x + " ");
                    }
                    answer.Length--;
                    Console.WriteLine(answer.ToString());
                }
            }                
        }
        static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("ARGH!");
            }                
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
