using System;
using System.IO;

namespace MinimumCoins {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    int total = Convert.ToInt32(line);
                    int coins = 0;
                    while (total >= 5) {
                        total = total - 5;
                        coins++;
                    }
                    while (total >= 3) {
                        total = total - 3;
                        coins++;
                    }
                    while (total >= 1) {
                        total = total - 1;
                        coins++;
                    }

                    Console.WriteLine(coins.ToString());
                }
            }
        }
    }
}
