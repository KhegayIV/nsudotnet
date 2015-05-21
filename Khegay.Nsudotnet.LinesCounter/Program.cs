using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Khegay.Nsudotnet.LinesCounter
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Specify file extension");
                return;
            }
            if (args.Length == 1)
            {
                Console.WriteLine("{0} line(s)", Count(new DirectoryInfo(Directory.GetCurrentDirectory()), args[0]));
            }
            else
            {
                Console.WriteLine("{0} line(s)", Count(new DirectoryInfo(args[0]), args[1]));
            }
        }


        private static int Count(DirectoryInfo directoryInfo, string ext)
        {
            var count = 0;
            count += directoryInfo.EnumerateFiles(ext).Sum(file => CountFile(file));        //Iterate files
            count += directoryInfo.EnumerateDirectories().Sum(dir => Count(dir, ext));      //Recursively iterate directories
            return count;
        }

        private static int CountFile(FileInfo fileInfo)
        {
            int count = 0;
            using (var reader = new StreamReader(fileInfo.OpenRead(), Encoding.UTF8))
            {
                bool commentOpen = false;
                Regex commentRegex = new Regex("//.*$|/\\*.*\\*/| +|\\t+");     //Remove commented blocks and spaces
                Regex comEndRegex = new Regex("^.*?\\*/");                      //Close opened multiline comments
                Regex comStartRegex = new Regex("/\\*.*$");                     //Open multiline comments
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line == null) continue;
                    if (commentOpen)
                    {
                        if (comEndRegex.IsMatch(line))
                        {
                            line = comEndRegex.Replace(line, "");
                            commentOpen = false;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    line = commentRegex.Replace(line, "");
                    

                    if (comStartRegex.IsMatch(line)) 
                    {
                        commentOpen = true;
                        line = comStartRegex.Replace(line, "");
                    }

                    if (line.Length != 0) ++count;
                }
            }
            return count;
        }
    }     /* Just a test of a multiline comment
        Theoretically, line count shouldn't 
    change /* /*
/* Yeah /*  It/* Doesn't */}
