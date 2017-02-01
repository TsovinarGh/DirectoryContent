using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var drives = Directory.GetLogicalDrives();
            
            PrintDirectoryContents(@"D:\C#2016\Starting\");
            Console.ReadKey();
        }

        public static void PrintDirectoryContents(string path, string prefix = "")
        {
            string[] directories = null;

            try
            {
                directories = Directory.GetDirectories(path);
            }
            catch(UnauthorizedAccessException ex)
            {
                return;
            }

            var files = Directory.GetFiles(path);

            foreach(var directory in directories)
            {
                var fileTokens = directory.Split('\\');
                Console.WriteLine(prefix + fileTokens.Last());
                PrintDirectoryContents(directory, prefix + "     ");
            }

            foreach(var file in files)
            {
                var fileTokens = file.Split('\\');
                Console.WriteLine(prefix + fileTokens.Last());
            }
        }
    }
}
