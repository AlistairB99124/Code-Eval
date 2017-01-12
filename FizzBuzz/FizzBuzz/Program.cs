using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FizzBuzz
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
                    string[] lineResult = line.Split(' ');
                    double x = Convert.ToDouble(lineResult[0]);
                    double y = Convert.ToDouble(lineResult[1]);
                    double n = Convert.ToDouble(lineResult[2]);
                    List<string> results = new List<string>();
                    for (int i = 1; i <= n; i++)
                    {
                        double iD = (double)i;
                        double resultX = (double)(iD / x);
                        double resultY = (double)(iD / y);
                        bool isIntX = IsInteger(resultX);
                        bool isIntY = IsInteger(resultY);
                        if (isIntX)
                        {
                            if (isIntX && isIntY)
                            {
                                results.Add("FB");
                            }
                            else
                            {
                                results.Add("F");
                            }
                        }
                        else if (isIntY)
                        {
                            if (isIntX && isIntY)
                            {
                                results.Add("FB");
                            }
                            else
                            {
                                results.Add("B");
                            }
                        }
                        else
                        {
                            results.Add(iD.ToString());
                        }
                    }
                    StringBuilder result = new StringBuilder();
                    foreach (string s in results)
                    {
                        result.Append(s + " ");
                    }
                    Console.WriteLine(result.ToString().TrimEnd());
                    Console.ReadLine();
                }
            }
        }
        public static bool IsInteger(double number)
        {
            return number == Math.Truncate(number);
        }
    }
}
