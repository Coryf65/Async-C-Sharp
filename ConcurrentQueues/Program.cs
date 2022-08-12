using System.Collections.Concurrent;

Console.WriteLine("------------------  Concurrent Queue examples ------------------");

Console.WriteLine("Fib: {0}", Fib(5));

// usually used as globals to be available to all threads
// FIFO
var conQueue = new ConcurrentQueue<ulong>();

// add to the queue
//conQueue.Enqueue(1);
Random rnd = new Random();
Thread threadFb = new(new ThreadStart(GenerateFib))
{
    IsBackground = false
};
threadFb.Start();

Thread threadRead = new(new ThreadStart(ReadFib))
{
    IsBackground = false
};
threadRead.Start();

void ReadFib()
{
    Console.WriteLine("Starting to read from the queue ...");

    do
    {
        if (conQueue.TryDequeue(out ulong n))
        {
            Console.Write("Fib: {0}", n);
        }
        else
        {
            Console.Write(".");
        }
    } while (true);
}

void GenerateFib()
{
    // slowing it down
    for (ushort i = 0; i < 50; i++)
    {
        Thread.Sleep(rnd.Next(1, 500));
        conQueue.Enqueue(Fibonacci(i));
    }
}

ulong Fibonacci(ushort n)
{
    return (n == 0) ? 0 : Fib(n);
}

ulong Fib(ushort n)
{
    ulong a = 0;
    ulong b = 1;

    for (uint i = 0; i < n - 1; i++)
    {
        ulong next = checked(a + b);
        a = b;
        b = next;
    }
    return b;
}