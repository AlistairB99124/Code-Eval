using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MorseCode {
    class Program {
        static void Main(string[] args) {
            using (StreamReader reader = File.OpenText(args[0])) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    string[] words = line.Split(new[] { "  " }, StringSplitOptions.None);
                    var alpha = GetAlphabet();
                    StringBuilder answer = new StringBuilder();
                    for (int i = 0; i < words.Length; i++) {
                        StringBuilder word = new StringBuilder();
                        string[] codes = words[i].Split(' ');
                        for (int j = 0; j < codes.Length; j++) {
                            char letter = alpha.Where(x => x.Code == codes[j]).FirstOrDefault().Letter;
                            word.Append(letter.ToString());
                        }
                        answer.Append(word + " ");
                    }
                    Console.WriteLine(answer);
                    Console.ReadLine();
                }
            }            
        }
        static List<MorseAlphabet> GetAlphabet() {
            List<MorseAlphabet> alphabet = new List<MorseAlphabet> {
                new MorseAlphabet { Code = ".-", Letter='A'},
                new MorseAlphabet { Code = "-...", Letter='B'},
                new MorseAlphabet { Code = "-.-.", Letter='C'},
                new MorseAlphabet { Code = "-..", Letter='D'},
                new MorseAlphabet { Code = ".", Letter='E'},
                new MorseAlphabet { Code = "..-.", Letter='F'},
                new MorseAlphabet { Code = "--.", Letter='G'},
                new MorseAlphabet { Code = "....", Letter='H'},
                new MorseAlphabet { Code = "..", Letter='I'},
                new MorseAlphabet { Code = ".---", Letter='J'},
                new MorseAlphabet { Code = "-.-", Letter='K'},
                new MorseAlphabet { Code = ".-..", Letter='L'},
                new MorseAlphabet { Code = "--", Letter='M'},
                new MorseAlphabet { Code = "-.", Letter='N'},
                new MorseAlphabet { Code = "---", Letter='O'},
                new MorseAlphabet { Code = ".--.", Letter='P'},
                new MorseAlphabet { Code = "--.-", Letter='Q'},
                new MorseAlphabet { Code = ".-.", Letter='R'},
                new MorseAlphabet { Code = "...", Letter='S'},
                new MorseAlphabet { Code = "-", Letter='T'},
                new MorseAlphabet { Code = "..-", Letter='U'},
                new MorseAlphabet { Code = "...-", Letter='V'},
                new MorseAlphabet { Code = ".--", Letter='W'},
                new MorseAlphabet { Code = "-..-", Letter='X'},
                new MorseAlphabet { Code = "-.--", Letter='Y'},
                new MorseAlphabet { Code = "--..", Letter='Z'},
                new MorseAlphabet { Code = "-----", Letter='0'},
                new MorseAlphabet { Code = ".----", Letter='1'},
                new MorseAlphabet { Code = "..---", Letter='2'},
                new MorseAlphabet { Code = "...--", Letter='3'},
                new MorseAlphabet { Code = "....-", Letter='4'},
                new MorseAlphabet { Code = ".....", Letter='5'},
                new MorseAlphabet { Code = "-....", Letter='6'},
                new MorseAlphabet { Code = "--...", Letter='7'},
                new MorseAlphabet { Code = "---..", Letter='8'},
                new MorseAlphabet { Code = "----.", Letter='9'},
                new MorseAlphabet { Code = ".-.-", Letter='Ä'},
                new MorseAlphabet { Code = ".--.-", Letter='Á'},
                new MorseAlphabet { Code = ".--.-", Letter='Å'},
                new MorseAlphabet { Code = "----", Letter='C'},
                new MorseAlphabet { Code = "..-..", Letter='É'},
                new MorseAlphabet { Code = "--.--", Letter='Ñ'},
                new MorseAlphabet { Code = "---.", Letter='Ö'},
                new MorseAlphabet { Code = "..--", Letter='Ü'}
            };
            return alphabet;
        }
    }
    public class MorseAlphabet {
        public string Code { get; set; }
        public char Letter { get; set; }
    }
}
