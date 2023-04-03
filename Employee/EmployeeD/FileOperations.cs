using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmployeeD
{
    internal class FileOperations
    {
        public void FileExist()
        {
            string path = @"D:\TRAINING\swetha.txt";

            if (File.Exists(path))
            {
                Console.WriteLine("File Exists");
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
            Console.ReadKey();
        }
        public void FileReadAlllines()
        {
            string path = @"D:\TRAINING\swetha.txt";

            if (File.Exists(path))
            {
                string[] lines;
                lines = File.ReadAllLines(path);
                Console.WriteLine(lines[0]);
                Console.WriteLine(lines[1]);
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
            Console.ReadKey();
        }
        public void FileReadAllText()
        {
            string path = @"D:\TRAINING\swetha.txt";
            if (File.Exists(path))
            {
                string lines;
                lines = File.ReadAllText(path);
                Console.WriteLine(lines);
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
            Console.ReadKey();
        }
        public void FileCopy()
        {
            string path = @"D:\TRAINING\swetha.txt";

            string copypath = @"D:\My_Repo\Employee\SampleFileNew.txt";
            if (File.Exists(path))
            {
                File.Copy(path, copypath);
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }

            Console.ReadKey();
        }
        public void FileDelete()
        {
            string path = @"D:\My_Repo\Employee\SampleFileNew.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
            Console.ReadKey();

        }
    }
}
