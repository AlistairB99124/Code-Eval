using System;
using System.IO;

namespace HappyNumbers
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

                    int result = Convert.ToInt32(line);
                    char[] charArray = result.ToString().ToCharArray();
                    int[] intArray = Array.ConvertAll(charArray, s => int.Parse(s.ToString()));
                    int sum = 0;
                    int attempts = 0;
                    bool isHappy = false;
                    while (sum != 1)
                    {
                        if (attempts == 20)
                        {
                            sum = 1;
                            isHappy = false;
                        }
                        else
                        {
                            foreach (int x in intArray)
                            {
                                sum = sum + Convert.ToInt32(Math.Pow(x, 2));
                            }
                            if (sum == 1)
                            {
                                isHappy = true;
                            }
                            else
                            {
                                charArray = sum.ToString().ToCharArray();
                                intArray = Array.ConvertAll(charArray, s => int.Parse(s.ToString()));
                                sum = 0;
                                ++attempts;
                            }
                        }
                    }
                    if (isHappy)
                    {
                        Console.WriteLine(1);
                    }
                    else
                    {
                        Console.WriteLine(0);
                    }
                }
            }
        }
    }
}
