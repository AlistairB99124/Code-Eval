using System;
using System.IO;

namespace ArmstrongNumbers
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
                    int lineInt = int.Parse(line);
                    char[] digits = line.ToCharArray();
                    double n = digits.Length;
                    int sum = 0;
                    for (int i = 0; i < n; i++)
                    {
                        sum = Convert.ToInt32(sum + Math.Pow(double.Parse(char.ToString(digits[i])), n));
                    }
                    if (sum == lineInt)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
            }
        }
    }
}
