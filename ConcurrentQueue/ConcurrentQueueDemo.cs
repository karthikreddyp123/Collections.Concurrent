using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentQueue
{
    class ConcurrentQueueDemo
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();


            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; ++i)
                {
                    queue.Enqueue(i);
                    Console.WriteLine("Added item:" + i);
                    Thread.Sleep(100);
                }
            });

            Task t2 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; ++i)
                {
                    if(queue.TryDequeue(out int item))
                    {
                        Console.WriteLine("Removed item:"+item+" from Task2");
                    }
                    Thread.Sleep(100);
                }

            });
            Task t3 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; ++i)
                {
                    if (queue.TryDequeue(out int item))
                    {
                        Console.WriteLine("Removed item:" + item+" from Task3");
                    }
                    Thread.Sleep(100);
                }

            });

            
            Task.WaitAll(t1, t2);
            Console.ReadLine();
           
        }
    }
}
