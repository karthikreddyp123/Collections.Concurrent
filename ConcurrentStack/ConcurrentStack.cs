using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentStack
{
    class ConcurrentStack
    {
        static void Main(string[] args)
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();


            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; ++i)
                {
                    stack.Push(i);
                    Console.WriteLine("Added item:" + i);
                    Thread.Sleep(100);
                }
            });

            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                for (int i = 0; i < 10; ++i)
                {
                    if (stack.TryPop(out int item))
                    {
                        Console.WriteLine("Removed item:" + item + " from Task2");
                    }
                    Thread.Sleep(100);
                }

            });
            Task t3 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(800);
                for (int i = 0; i < 10; ++i)
                {
                    if (stack.TryPop(out int item))
                    {
                        Console.WriteLine("Removed item:" + item + " from Task3");
                    }
                    Thread.Sleep(100);
                }

            });


            Task.WaitAll(t1, t2);
            Console.ReadLine();
        }
    }
}
