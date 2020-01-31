using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentDictionary
{
    class ConcurrentDictionary
    {
        static void Main(string[] args)
        {
            ConcurrentDictionary<int, int> dictionary = new ConcurrentDictionary<int, int>();


            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; ++i)
                {
                    if (dictionary.TryAdd(i, i))
                    {
                        Console.WriteLine("Added " + i + " from Task1");
                    }
                    Thread.Sleep(100);
                }
            });

            Task t2 = Task.Factory.StartNew(() =>
            {
                //Thread.Sleep(300);
                for (int i = 0; i < 10; ++i)
                {
                    if (dictionary.TryAdd(i, i))
                    {
                        Console.WriteLine("Added " + i + " from Task2");
                    }
                    Thread.Sleep(100);
                }
            });
            
           
                Task.WaitAll(t1, t2);
        
            foreach(var item in dictionary)
            {
                Console.WriteLine("Key:"+item.Key+" Value:"+item.Value);
            }
            Console.ReadLine();
        }
    }
}
