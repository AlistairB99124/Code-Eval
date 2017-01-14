using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Calculations {
    public class SudokuCalculations {
        public bool IsValid(string argument) {
            int N = Convert.ToInt32(argument.Split(';')[0]);
            int[] numbers = Array.ConvertAll(argument.Split(';')[1].Split(','), s => int.Parse(s));
            int[,] matrix = new int[N, N];
            int increment = 0;
            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {
                    matrix[i, j] = numbers[increment + j];
                }
                increment += N;
            }
            List<int> requiredNumbers = GetNumbers(N);
            List<bool> results = new List<bool>();
            for(int i = 0; i < N; i++) {
                var row = GetRow(matrix, i).OrderBy(x=>x);
                var column = GetColumn(matrix, i).OrderBy(x => x);
                var square = GetSquare(matrix, i).OrderBy(x => x);
                if (requiredNumbers.SequenceEqual(row)) {
                    results.Add(true);
                } else {
                    results.Add(false);
                }
                if (requiredNumbers.SequenceEqual(column)) {
                    results.Add(true);
                } else {
                    results.Add(false);
                }
                if (requiredNumbers.SequenceEqual(square)) {
                    results.Add(true);
                } else {
                    results.Add(false);
                }
            }
            bool answer = results.Where(x => x == false).Count() < 1;
            return answer;
        }
        private static IEnumerable<int> GetRow(int[,] array, int row) {
            for (int i = 0; i <= array.GetUpperBound(1); i++) {
                yield return array[row, i];
            }
        }
        private static IEnumerable<int> GetColumn(int[,] array, int column) {
            for (int i = 0; i <= array.GetUpperBound(1); i++) {
                yield return array[i, column];
            }
        }
        /// <summary>
        /// Returns IEnumerable of integers from sqrt(N)*sqrt(N)
        /// </summary>
        /// <param name="array">Array to be investigated</param>
        /// <param name="index">Index of square to be counted</param>
        /// <returns>IEnumerable<int></returns>
        private static IEnumerable<int> GetSquare(int[,] array, int index) {
            int N = array.GetLength(0);
            int n = Convert.ToInt32(Math.Sqrt(N));
            List<int> numbers = new List<int>();
            for(int i = 0; i < N; i+=n) {
                for(int j = 0; j < N; j+=n) {
                    for(int k = 0; k < n; k++) {
                        for(int l = 0; l < n; l++) {
                            numbers.Add(array[i + k, j + l]);
                        }
                    }
                }
            }
            int[] list = numbers.GetRange(index * N, N).ToArray();
            return list;
        }
        private static List<int> GetNumbers(int N) {
            List<int> result = new List<int>();
            for (int i = 1; i <= N; i++) {
                result.Add(i);
            }
            return result;
        }
    }
}
