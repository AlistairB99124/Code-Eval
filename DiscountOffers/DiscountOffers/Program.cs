using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountOffers {
    class Program {
        static void Main(string[] args) {
            string line = "Jack Abraham,John Evans,Ted Dziuba;iPad 2 - 4-pack,Girl Scouts Thin Mints,Nerf Crossbow";
            string[] customers = line.Split(';')[0].Split(',');
            string[] products = line.Split(';')[1].Split(',');
            decimal totalSS = 0;
            for(int i = 0; i < products.Length; i++) {
                string product = products[i];
                List<char> lettersInProduct = product.ToCharArray().Where(x => !char.IsWhiteSpace(x)).ToList();
                foreach(var c in lettersInProduct.Reverse<char>()) {
                    switch (c) {
                        case '-':
                            lettersInProduct.Remove(c);
                            break;
                        case '1':
                            lettersInProduct.Remove(c);
                            break;
                        case '2':
                            lettersInProduct.Remove(c);
                            break;
                        case '3':
                            lettersInProduct.Remove(c);
                            break;
                        case '4':
                            lettersInProduct.Remove(c);
                            break;
                        case '5':
                            lettersInProduct.Remove(c);
                            break;
                        case '6':
                            lettersInProduct.Remove(c);
                            break;
                        case '7':
                            lettersInProduct.Remove(c);
                            break;
                        case '8':
                            lettersInProduct.Remove(c);
                            break;
                        case '9':
                            lettersInProduct.Remove(c);
                            break;
                        case '0':
                            lettersInProduct.Remove(c);
                            break;
                    }
                }
                int numberOfLettersOfProduct = lettersInProduct.Count;
                int numberOfLettersOfCustomer = 0;
                for (int j = 0; j < customers.Length; j++) {
                    decimal SS = 0;
                    string customer = customers[j];
                    numberOfLettersOfCustomer = customer.ToCharArray().Where(x => !char.IsWhiteSpace(x)).ToArray().Count();
                    if (numberOfLettersOfProduct % 2 == 0) {
                        List<string> vowels = customers[j].ToLower().Split(new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' }).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                        List<char> vow = new List<char>();
                        foreach(var v in vowels) {
                            char[] x = v.Trim().ToCharArray();
                            foreach(var c in x) {
                                if(c!=' ') {
                                    vow.Add(c);
                                }                                
                            }                            
                        }
                        int numberOfVowels = vow.Count();
                        SS = numberOfVowels * 1.5M;
                    }
                    else {
                        List<string> consonants = customers[j].ToLower().Split(new char[] { 'a', 'e', 'i', 'o', 'u','y' }).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                        List<char> con = new List<char>();
                        foreach (var v in consonants) {
                            char[] x = v.Trim().ToCharArray();
                            foreach (var c in x) {
                                if(c!=' ') {
                                    con.Add(c);
                                }                                
                            }
                        }
                        int numberOfConsonants = con.Count();
                        SS = numberOfConsonants;
                    }
                    if (GCD(numberOfLettersOfProduct,numberOfLettersOfCustomer)!=1) {
                        SS = SS * 1.5M;
                    }
                    Console.WriteLine(customer + " " + product + " " + SS.ToString());
                }

            }
            Console.ReadLine();
        }
        static int GCD(int a, int b) {
            int Remainder;

            while (b != 0) {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }
    }
}
