namespace Threads
{
    internal static class LockKeyword
    {

        public static void DemoTwo()
        {
            Console.WriteLine("------------------ Lock Keyword example ------------------");

            Console.WriteLine("demoing Lock() and it allows only one thread at a time");

            var t1 = new Thread(new ThreadStart(AddToListLock));
            Console.WriteLine("Starting a thread");
            t1.Start();

            var t2 = new Thread(new ThreadStart(AddToListLock));
            Console.WriteLine("Starting a thread");
            t2.Start();

            var t3 = new Thread(new ThreadStart(AddToListLock));
            Console.WriteLine("Starting a thread");
            t3.Start();

            Console.WriteLine("Done...");
        }

        static List<int> numbers = new();
        private static object myLock = new();
        private static Random rnd = new();

        static void AddToListError()
        {
            // Example of an issue where many threads accessing a shared state can cause issues
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }
        }

        static void AddToListLock()
        {
            // lock makes it so only one thread at a time can run this code
            // Flag inside the (), can be any atomic types
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(rnd.Next(1, 100));
                lock (myLock)
                {
                    numbers.Add(i);
                }
            }
            // You can see that at different times we have different results
            numbers.ForEach(i => Console.Write("{0} ", i));
        }
    }
}
