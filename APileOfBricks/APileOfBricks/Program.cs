using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace APileOfBricks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    int[] holeCoordinates = Array.ConvertAll(line.Split('|')[0].Split(new char[] { '[', ']', ',', ' ' }).Where(x => !string.IsNullOrEmpty(x)).ToArray(), p => int.Parse(p));
                    var hole = new Hole
                    {
                        Breadth = Math.Abs(holeCoordinates[0] - holeCoordinates[2]),
                        Length = Math.Abs(holeCoordinates[1] - holeCoordinates[3])
                    };

                    string[] brickStrings = line.Split('|')[1].Split(';');
                    List<Brick> bricks = new List<Brick>();
                    foreach (var b in brickStrings)
                    {
                        int[] i = Array.ConvertAll(b.Split(new char[] { ' ', '[', ']', ',', '(', ')' }).Where(x => !string.IsNullOrEmpty(x)).ToArray(), p => int.Parse(p));
                        var brick = new Brick
                        {
                            Index = i[0],
                            Breadth = Math.Abs(i[1] - i[4]),
                            Length = Math.Abs(i[2] - i[5]),
                            Depth = Math.Abs(i[3] - i[6])
                        };

                        bricks.Add(brick);
                    }
                    List<Brick> BricksThatFit = new List<Brick>();
                    foreach (var brick in bricks)
                    {
                        //Face A: Depth * Length
                        if (brick.Depth <= hole.Length && brick.Length <= hole.Breadth || brick.Length <= hole.Length && brick.Depth <= hole.Breadth)
                        {
                            BricksThatFit.Add(brick);
                        }
                        //Face B: Depth * Breadth
                        else if (brick.Depth <= hole.Length && brick.Breadth <= hole.Breadth || brick.Breadth <= hole.Length && brick.Depth <= hole.Breadth)
                        {
                            BricksThatFit.Add(brick);
                        }
                        //Face C: Length * Breadth
                        else if (brick.Breadth <= hole.Breadth && brick.Length <= hole.Length || brick.Length <= hole.Breadth && brick.Breadth <= hole.Length)
                        {
                            BricksThatFit.Add(brick);
                        }
                        else
                        {

                        }
                    }
                    List<Brick> ordered = BricksThatFit.OrderBy(x => x.Index).ToList();
                    StringBuilder answer = new StringBuilder();
                    if (ordered.Count != 0)
                    {
                        foreach (var f in ordered)
                        {
                            answer.Append(f.Index.ToString() + ",");
                        }
                        answer.Length--;
                        Console.WriteLine(answer.ToString());
                    }
                    else
                    {
                        Console.WriteLine("-");
                    }
                    Console.ReadLine();
                }            
        }
    }

    public class Brick
    {
        public int Index { get; set; }
        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Depth { get; set; }
    }
    public class Hole
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
    }
}
