using System.IO;

namespace Sudoku.Console {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (null == line) {
                        continue;
                    }
                    Calculations.SudokuCalculations calculations = new Calculations.SudokuCalculations();
                    bool IsValid = calculations.IsValid(line);
                    if (IsValid) {
                        System.Console.WriteLine("True");
                    } else {
                        System.Console.WriteLine("False");
                    }
                }
            }           
        }
    }
}
