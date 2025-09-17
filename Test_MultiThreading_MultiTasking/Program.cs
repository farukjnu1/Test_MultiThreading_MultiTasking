using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_MultiThreading_MultiTasking
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Main thread start");

            //example of Multi thread
            //MyWork w = new MyWork();
            //ThreadStart s1 = w.Count;
            //ThreadStart s2 = w.Alphabets;
            //Thread thread1 = new Thread(s1);
            //Thread thread2 = new Thread(s2);
            //thread1.Start();
            //thread2.Start();

            MyFile f = new MyFile();
            Task t = new Task(f.Copy);
            t.Start();

            Console.WriteLine("Main Thread end");

            Console.ReadKey();
        }
    }

    class MyWork
    {
        public void Count()
        {
            Console.WriteLine("Thread 1 start");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Thread 1 end");
        }

        public void Alphabets()
        {
            Console.WriteLine("Thread 2 start");
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("Thread 2 end");
        }

    }

    class MyFile
    {
        public void Copy()
        {
            Console.WriteLine("File copying...");

            FileStream inStream = new FileStream(@"DummyFile.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            FileStream outStream = new FileStream(@"DummyFileCopy.txt", FileMode.Create, FileAccess.Write, FileShare.Read);

            using (inStream)
            {
                while (true)
                {
                    int b = inStream.ReadByte();
                    if (b == -1)
                    {
                        break;
                    }
                    outStream.WriteByte((byte)b);
                }
            }

            Console.WriteLine("File Copied..!");
        }
    }

}
