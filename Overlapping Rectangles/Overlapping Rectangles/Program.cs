using System;
using System.IO;

namespace Overlapping_Rectangles {
    public class Program {
        public static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (null == line) {
                        continue;
                    }
                    int[] coordinates = Array.ConvertAll(line.Split(','), p => int.Parse(p));
                    Rectangle A = new Rectangle {
                        Width = Math.Abs(coordinates[0] - coordinates[2]),
                        Height = Math.Abs(coordinates[1] - coordinates[3]),
                        x = coordinates[0],
                        y = coordinates[3]
                    };
                    Rectangle B = new Rectangle {
                        Width = Math.Abs(coordinates[4] - coordinates[6]),
                        Height = Math.Abs(coordinates[5] - coordinates[7]),
                        x = coordinates[4],
                        y = coordinates[7]
                    };

                    if (RectanglesOverlap(A, B)) {
                        Console.WriteLine("True");
                    } else {
                        Console.WriteLine("False");
                    }
                }
            }          
        }
        private static bool valueInRange(int value, int min, int max) {
            return (value >= min) && (value <= max);
        }
        private static bool RectanglesOverlap(Rectangle a, Rectangle b) {
            bool xOverlap = valueInRange(a.x, b.x, b.x + b.Width) ||
                            valueInRange(b.x, a.x, a.x + a.Width);
            bool yOverlap = valueInRange(a.y, b.y, b.y + b.Height) ||
                            valueInRange(b.y, a.y, a.y + a.Height);

            return xOverlap && yOverlap;
        }
    }
    public class Rectangle {
        public int x { get; set; }
        public int y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
