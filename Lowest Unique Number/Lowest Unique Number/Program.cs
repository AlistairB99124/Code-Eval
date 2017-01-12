using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lowest_Unique_Number
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    IEnumerable<int> numbers = Array.ConvertAll(line.Split(' '), s => int.Parse(s));
                    List<Player> players = new List<Player>();
                    int position = 0;
                    foreach (var x in numbers)
                    {
                        int count = (from y in numbers where y == x select y).Count();
                        if (count > 1)
                        {
                            position++;
                            Player player = new Player() { IsDuplicate = true, Value = x, Position = position };
                            players.Add(player);
                        }
                        else
                        {
                            position++;
                            Player player = new Player() { Value = x, IsDuplicate = false, Position = position };
                            players.Add(player);
                        }
                    }
                    if ((from x in players where !x.IsDuplicate select x).Count() != 0)
                    {
                        Console.WriteLine((from z in players where !z.IsDuplicate orderby z.Value select z).First().Position);
                    }
                    else
                    {
                        Console.WriteLine("0");
                    }
                }
            }                
        }
    }
    public class Player
    {
        public int Position { get; set; }
        public int Value { get; set; }
        public bool IsDuplicate { get; set; }
    }
}
