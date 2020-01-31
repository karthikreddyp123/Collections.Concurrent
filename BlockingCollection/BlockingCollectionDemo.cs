using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockingCollection
{
    class BlockingCollectionDemo
    {
        static void Main(string[] args)
        {
            BlockingCollection<int> bCollection = new BlockingCollection<int>(boundedCapacity: 5);

            Task producerThread = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; ++i)
                {
                    bCollection.TryAdd(i);
                    Console.WriteLine("Producer added element:"+i);
                }

                bCollection.CompleteAdding();
            });

            Task consumerThread = Task.Factory.StartNew(() =>
            {
                while (!bCollection.IsCompleted)
                {
                    if (bCollection.TryTake(out int item,TimeSpan.FromSeconds(0.1)))
                    {
                        Console.WriteLine("Consumer comsumed element:" + item);
                    }
                    else
                    {
                        Console.WriteLine("Cannot consume");
                    }
                }
            });

            Task.WaitAll(producerThread, consumerThread);
            Console.ReadLine();
        }
    }
}
