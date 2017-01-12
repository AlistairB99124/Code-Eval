using System;
using System.IO;
using System.Linq;

namespace CalculateDistance
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
                    {
                        continue;
                    }                        
                    string[] results = line.Split(new char[] { ')', '(', ' ', ',' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    double x1 = Convert.ToInt32(results[0]);
                    double y1 = Convert.ToDouble(results[1]);
                    double x2 = Convert.ToDouble(results[2]);
                    double y2 = Convert.ToDouble(results[3]);

                    double distance = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
                    Console.WriteLine(distance.ToString());
                    Console.ReadLine();
                }
            }
        }
    }
}
