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

        private static readonly Regex CommentRegex = new Regex("//.*$|/\\*.*\\*/| +|\\t+", RegexOptions.Compiled);     
        //Remove commented blocks and spaces
        private static readonly Regex ComEndRegex = new Regex("^.*?\\*/", RegexOptions.Compiled);                      
        //Close opened multiline comments
        private static readonly Regex ComStartRegex = new Regex("/\\*.*$", RegexOptions.Compiled);                     
        //Open multiline comments

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
                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line == null) continue;
                    if (commentOpen)
                    {
                        if (ComEndRegex.IsMatch(line))
                        {
                            line = ComEndRegex.Replace(line, "");
                            
                            commentOpen = false;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    line = CommentRegex.Replace(line, "");
                    

                    if (ComStartRegex.IsMatch(line)) 
                    {
                        commentOpen = true;
                        line = ComStartRegex.Replace(line, "");
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
