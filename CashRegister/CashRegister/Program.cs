using System;
using System.Text;
using System.Globalization;
using System.IO;

namespace CashRegister
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

                    decimal PurchasePrice = Convert.ToDecimal(line.Split(';')[0], CultureInfo.InvariantCulture);
                    decimal Cash = Convert.ToDecimal(line.Split(';')[1], CultureInfo.InvariantCulture);
                    StringBuilder answer = new StringBuilder();

                    if (Cash < PurchasePrice)
                    {
                        Console.WriteLine("ERROR");
                        Console.ReadKey();
                    }
                    else if (Cash == PurchasePrice)
                    {
                        Console.WriteLine("ZERO");
                        Console.ReadKey();
                    }
                    else
                    {
                        decimal change = Cash - PurchasePrice;
                        while (change >= 100)
                        {
                            answer.Append("ONE HUNDRED,");
                            change = change - 100;
                        }
                        while (change >= 50)
                        {
                            answer.Append("FIFTY,");
                            change = change - 50;
                        }
                        while (change >= 20)
                        {
                            answer.Append("TWENTY,");
                            change = change - 20;
                        }
                        while (change >= 10)
                        {
                            answer.Append("TEN,");
                            change = change - 10;
                        }
                        while (change >= 5)
                        {
                            answer.Append("FIVE,");
                            change = change - 5;
                        }
                        while (change >= 2)
                        {
                            answer.Append("TWO,");
                            change = change - 2;
                        }
                        while (change >= 1)
                        {
                            answer.Append("ONE,");
                            change = change - 1;
                        }
                        while (change >= 0.5M)
                        {
                            answer.Append("HALF DOLLAR,");
                            change = change - 0.5M;
                        }
                        while (change >= 0.25M)
                        {
                            answer.Append("QUARTER,");
                            change = change - 0.25M;
                        }
                        while (change >= 0.1M)
                        {
                            answer.Append("DIME,");
                            change = change - 0.1M;
                        }
                        while (change >= 0.05M)
                        {
                            answer.Append("NICKEL,");
                            change = change - 0.05M;
                        }
                        while (change >= 0.01M)
                        {
                            answer.Append("PENNY,");
                            change = change - 0.01M;
                        }

                        answer.Length--;
                        Console.WriteLine(answer.ToString());
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
