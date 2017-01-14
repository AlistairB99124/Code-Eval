using System;
using System.IO;
using System.Text;

namespace MineSweeper {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    int M = Convert.ToInt32(line.Split(';')[0].Split(',')[0]);// No. of Rows
                    int N = Convert.ToInt32(line.Split(';')[0].Split(',')[1]);//No. of Columns
                    char[] sequence = line.Split(';')[1].ToCharArray();// Row major sequence
                    char[,] field = new char[M, N];// Two dimensional array to store matrix or minefield
                    int increment = 0;// Variable to make loop skip to the next 'row' in the row major sequence
                    for (int i = 0; i < M; i++) {
                        for (int j = 0; j < N; j++) {
                            field[i, j] = sequence[increment + j];// Populate field from sequence
                        }
                        increment = increment + N;// Increment by size of Columns
                    }
                    for (int i = 0; i < M; i++) {
                        for (int j = 0; j < N; j++) {
                            int tally = 0;// Variable to count mines found
                            char x = field[i, j];// Check if current position contains a mine
                            if (x != '*') {
                                for (int a = i - 1; a <= i + 1; a++) {
                                    //Ensure position fits in the matrics
                                    if (a >= 0 && a <= M - 1) {
                                        for (int z = j - 1; z <= j + 1; z++) {
                                            if (z >= 0 && z <= N - 1) {
                                                if (field[a, z] == '*') {
                                                    ++tally;//Mine found so tally
                                                }
                                            }
                                        }
                                    }
                                }
                                // Append tally to the field
                                field[i, j] = char.Parse(tally.ToString());
                            }
                        }
                    }
                    StringBuilder answer = new StringBuilder();
                    foreach (var q in field) {
                        answer.Append(q);
                    }
                    Console.WriteLine(answer);
                }
            }  
        }
    }
}
