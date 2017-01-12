using System;

namespace Odd_Numbers {
    class Program {
        static void Main(string[] args) {
            for (int i = 0; i <= 100; i++) {
                if (!IsNotOdd(i)) {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
        static bool IsNotOdd(int x) {
            if (x == 0) {
                return true;
            } else {
                return x % 2 == 0;
            }
        }
    }
}
