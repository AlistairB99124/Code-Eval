using System;
using System.IO;
using System.Linq;

namespace Mth_to_last_element {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (line == null)
                        continue;
                    string[] lineResults = line.Split(' ');
                    string result = string.Empty;
                    try {
                        int m = Convert.ToInt32(lineResults[lineResults.Count() - 1]);
                        int index = lineResults.Count() - m - 1;
                        result = lineResults[index];
                        Console.WriteLine(result);
                    } catch {
                        result = "Out of range";
                    }
                }
            }
        }
    }
}
