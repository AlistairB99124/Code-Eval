using System;
using System.IO;
using System.Text;

namespace LongestCommonSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "XMJYAUZ;MZJAWXU";
            if (line != string.Empty)
            {
                char[] first = line.Split(';')[0].ToCharArray();
                char[] second = line.Split(';')[1].ToCharArray();

                StringBuilder answer = new StringBuilder();
                int lastIndex = 0;
                int counter = 0;
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < second.Length; j++)
                    {
                        if (first[i] == second[j])
                        {
                            if (i == 0)
                            {
                                lastIndex = j;
                            }
                            else
                            {
                                if (lastIndex < j)
                                {
                                    ++counter;
                                    if (counter == 1)
                                    {
                                        answer.Append(second[lastIndex].ToString() + second[j].ToString());
                                    }
                                    else
                                    {
                                        answer.Append(second[j].ToString());
                                    }
                                }
                                lastIndex = j;
                            }
                        }
                    }
                }

                Console.WriteLine(answer.ToString());
                Console.ReadKey();
            }
        }
    }
}
