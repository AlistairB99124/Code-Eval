using System;
using System.IO;
using System.Linq;

namespace Number_of_Ones {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (line == null)
                        continue;
                    int x = Convert.ToInt32(line);
                    string binary = Convert.ToString(x, 2);
                    string[] numbers = binary.Select(c => c.ToString()).ToArray();

                    int numberOfOnes = (from z in numbers where z.ToString() == "1" select x).ToList().Count();
                    Console.WriteLine(numberOfOnes);
                }
            }
        }
    }
}
