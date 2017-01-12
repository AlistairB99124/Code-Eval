using System;
using System.IO;

namespace Multiples_of_a_Number {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (line == null)
                        continue;
                    double[] results = Array.ConvertAll(line.Split(','), s => double.Parse(s));
                    double x = results[0];
                    double n = results[1];
                    double y = 1;
                    int counter = 1;
                    while (y < x) {
                        y = (n * counter);
                        ++counter;
                    }
                    Console.WriteLine(y);
                    Console.ReadLine();
                }
            }
        }
    }
}
