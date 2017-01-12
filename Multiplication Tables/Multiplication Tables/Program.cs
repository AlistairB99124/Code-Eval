using System;

namespace Multiplication_Tables {
    class Program {
        static void Main(string[] args) {
            int[,] multiArray = new int[12, 12];
            int rowLength = multiArray.GetLength(0);
            int colLength = multiArray.GetLength(1);

            for (int j = 0; j < rowLength; j++) {
                int increment = j + 1;
                int cumulative = 0;
                for (int i = 0; i < colLength; i++) {
                    int value = (j + 1) + cumulative;
                    multiArray[j, i] = value;
                    cumulative = cumulative + increment;
                }
            }
            for (int i = 0; i < rowLength; i++) {
                for (int j = 0; j < colLength; j++) {
                    Console.Write("{0,4}", string.Format("{0} ", multiArray[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}
