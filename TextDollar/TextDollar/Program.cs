using System;
using System.IO;

namespace TextDollar {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    int n = Convert.ToInt32(line);
                    if (n == 1) {
                        Console.WriteLine("OneKwacha");
                    } else {
                        Console.WriteLine(NumberToText(n) + "Kwacha");
                    }
                }
            }
        }
        static string NumberToText(int n) {
            if (n == 0) {
                return "";
            } else if (n > 0 && n < 20) {
                string[] args = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                return args[n - 1];
            } else if (n > 19 && n < 100) {
                string[] args = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                return args[(n / 10) - 2] + NumberToText(n % 10);
            } else if (n > 99 && n < 200) {
                return "OneHundred" + NumberToText(n % 100);
            } else if (n > 199 && n < 1000) {
                return NumberToText(n / 100) + "Hundred" + NumberToText(n % 100);
            } else if (n > 999 && n < 2000) {
                return "OneThousand" + NumberToText(n % 1000);
            } else if (n > 1999 && n < 1000000) {
                return NumberToText(n / 1000) + "Thousand" + NumberToText(n % 1000);
            } else if (n > 999999 && n < 2000000) {
                return "OneMillion" + NumberToText(n % 1000000);
            } else if (n > 1999999 && n < 1000000000) {
                return NumberToText(n / 1000000) + "Million" + NumberToText(n % 1000000);
            } else if (n > 1000000000 && n < 2000000000) {
                return "OneBillion" + NumberToText(n % 1000000000);
            } else {
                return NumberToText(n / 1000000000) + "Billion" + NumberToText(n % 1000000000);
            }
        }
    }
}
