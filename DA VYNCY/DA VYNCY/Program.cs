using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_VYNCY {
    class Program {
        static void Main(string[] args) {
            string line = "O draconia;conian devil! Oh la;h lame sa;saint!";
            string[] fragments = line.Split(';');
            List<string> longestWords = new List<string>();
            for (int i = 0;i<fragments.Length;i++) {
                char[] chars = fragments[i].ToCharArray();
                for(int j = 0; j < fragments.Length; j++) {
                    List<string> justWords = new List<string>();                    
                    if (i != j) {
                        char[] charsNext = fragments[j].ToCharArray();
                        for(int q =0;q<chars.Length;q++) {
                            for(int z = 0;z<charsNext.Length;z++) {
                                int counter = 0;
                                bool found = true;
                                StringBuilder part = new StringBuilder();
                                while (found) {
                                    try {
                                        if (chars[q + counter] == charsNext[z + counter]) {
                                            part.Append(chars[q + counter]);
                                            ++counter;
                                            found = true;
                                        } else {
                                            found = false;
                                        }
                                    } catch {
                                        found = false;
                                    }                                  
                                }
                                if (part.Length != 0) {
                                    justWords.Add(part.ToString());
                                }                                
                            }
                        }
                    }
                    if (justWords.Count() != 0) {
                        string longestWord = (from x in justWords orderby x.Length descending select x).First();
                        longestWords.Add(longestWord);
                    }                                     
                }
            }
            foreach(var t in longestWords) {
                Console.WriteLine(t);
            }
            Console.ReadLine();
        }
    }
}
