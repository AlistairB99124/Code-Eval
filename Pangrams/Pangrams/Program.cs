using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pangrams {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (null == line) {
                        continue;
                    }
                    char[] letters = line.ToLower().ToCharArray().Where(x => !char.IsWhiteSpace(x)).ToArray();
                    letters = Array.FindAll<char>(letters, (c => (char.IsLetter(c) || c == '-')));
                    char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                    List<string> missing = new List<string>();
                    foreach (var l in alphabet) {
                        bool match = false;
                        foreach (var a in letters) {
                            if (l == a) {
                                match = true;
                            }
                        }
                        if (!match) {
                            missing.Add(l.ToString());
                        }
                    }
                    List<string> sorted = missing.Distinct().OrderBy(x => x).ToList();
                    StringBuilder answer = new StringBuilder();
                    if (sorted.Count == 0) {
                        Console.WriteLine("NULL");
                    } else {
                        foreach (var a in sorted) {
                            answer.Append(a);
                        }
                        Console.WriteLine(answer);
                    }
                }
            }
        }
    }
}
