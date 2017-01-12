using System;
using System.IO;

namespace FileSize
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fileInfo = new FileInfo(args[0]);
            Console.WriteLine(fileInfo.Length.ToString());   
        }
    }
}
